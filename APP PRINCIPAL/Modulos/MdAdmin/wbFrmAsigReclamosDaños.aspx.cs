using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public partial class Modulos_MdAdmin_wbFrmAsigReclamosDaños : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils comprobar = new Utils();
    int id;

    private void Page_Error(object sender, EventArgs e)
    {
        Response.Write("<Script>alert('A ocurrido algo inesperado intentelo de nuevo')</script>");
        Server.ClearError();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
    }

    protected void GridAsigDaños_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAsigDaños.SelectedRow.Cells[29].Text);

        try
        {
            var reclamo = DBReclamos.reclamos_varios.Find(id);
            reclamo.usuario_unity = DDLusuario.SelectedItem.Text;
            DBReclamos.SaveChanges();
            GridAsigDaños.DataBind();
            Utils.ShowMessage(this.Page, "Reclamos asignados con exito", "Excelente..!", "success");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudo asignar este reclamo", "Error..!", "error");
        }
    }
}
