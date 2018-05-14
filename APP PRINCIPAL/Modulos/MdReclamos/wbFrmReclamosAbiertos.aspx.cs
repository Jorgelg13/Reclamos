using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_wbFrmReclamosAbiertos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();

    private void Page_Error(object sender, EventArgs e)
    {
        Response.Write("A ocurrido un error intentelo de nuevo.");
        Server.ClearError();
        //Response.Redirect("/Defualt.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        lblusuario.Text = (string)(Session["id_usuario"]);
        SqlDataSourceReclamosAbiertos.SelectParameters.Add("idUsuario", lblusuario.Text);

    }
}