using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_wbFrmReclamosMedicosGeneral : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
    }
}