using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Catalogo_correo : System.Web.UI.Page
{
    string usuarioLogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

        if (user.rol == "E" || user.rol == "S" || user.rol == "F")
        {
            Response.Redirect("/Modulos/MdRenovaciones/Dashboard.aspx", false);
        }

        llenar.llenarGridRenovaciones("select * from contenido_correo", GridContenido);
    }

    protected void GridContenido_SelectedIndexChanged(object sender, EventArgs e)
    {
        var correo = DBRenovaciones.contenido_correo.Find(1);
        string contenido;

        txtCuerpo.Text = correo.contenido;
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        var correo = DBRenovaciones.contenido_correo.Find(1);
        correo.contenido = txtCuerpo.Text;
        DBRenovaciones.SaveChanges();
        Utils.ShowMessage(this.Page, "Contenido actualizado con exito ", "Excelente..", "success");
    }
}