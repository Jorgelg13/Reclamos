using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Modulos_MdReclamos_wbFrmReclamosAutosGeneral : System.Web.UI.Page
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

    //protected void GridAutosGeneral_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string idReclamo = GridAutosGeneral.SelectedRow.Cells[3].Text;
    //    string auto = GridAutosGeneral.SelectedRow.Cells[13].Text;
    //    string placa = GridAutosGeneral.SelectedRow.Cells[4].Text;
    //    Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo="+idReclamo+"&ultimoAuto="+auto+"&placa="+placa+"");
    //}
}