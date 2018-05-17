using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils comprobar = new Utils();
    Email util = new Email();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/portada.aspx");
        }

        obtenerID();
        Conteo();
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
            Utils.ShowMessage(this.Page, "A ocurrido un error al traer las variables de session", "Nota..!", "warning");
        }
    }

    public void Conteo()
    {
        try
        {
            var autos = DBReclamos.reclamo_auto.ToList().Where(a => a.id_estado == 1).Count();
            totalReclamosAutos.Text = autos.ToString();

            var danios = DBReclamos.reclamos_varios.ToList().Where(d => d.id_estado == 1).Count();
            totalReclamosDaños.Text = danios.ToString();

            var medicos = DBReclamos.reclamos_medicos.ToList().Where(m => m.estado_unity == "Sin Asignar" && m.id_estado != 3).Count();
            totalReclamosMedicos.Text = medicos.ToString();

            var autorizaciones = DBReclamos.autorizaciones.ToList().Where(a => a.tipo_estado != "Cerrado").Count();
            totalReclamosAutorizaciones.Text = autorizaciones.ToString();
        }

        catch(Exception ex)
        {
            Email.EnviarERROR("Descripcion del error: " + ex, "Error en conteo de reclamos en cabina");
        }
    }
}