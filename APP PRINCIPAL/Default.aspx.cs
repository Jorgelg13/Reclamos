using System;
using System.Linq;
using System.Web;
using System.Data;

public partial class seleccionar : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils comprobar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerID();
    }

    public void obtenerID()
    {
        try
        {
            var usuario = DBReclamos.usuario.Select(U => new { U.id, U.id_cabina, U.codigo, U.nombre }).Where(us => us.nombre == userlogin).First();
            Session.Add("id_usuario", usuario.id.ToString());
            Session.Add("id_cabina", usuario.id_cabina.ToString());
            Session.Add("codigo", usuario.codigo.ToString());
        }

        catch (Exception)
        {
           // Utils.ShowMessage(this.Page, "A ocurrido un error al traer las variables de session", "Nota..!", "warning");
        }
    }
}


