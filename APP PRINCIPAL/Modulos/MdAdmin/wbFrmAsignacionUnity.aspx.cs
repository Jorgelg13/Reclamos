using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdAdmin_wbFrmAsignacionUnity : System.Web.UI.Page
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
            Response.Redirect("/portada.aspx");
        }
    }

    private void asignar_reclamos()
    {
        foreach (GridViewRow row in GridAsignacionAutos.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAsig.Checked)
            {
                try
                {
                    var asignar = DBReclamos.reclamo_auto.Find(id);
                    asignar.usuario_unity = DDLusuario.SelectedValue;
                    DBReclamos.SaveChanges();
                    GridAsignacionAutos.DataBind();
                    Utils.ShowMessage(this.Page, "Reclamos asignados exitosamente", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido asigar el reclamo" + ex.Message, "Excelente", "success");
                }
            }
        }
    }

    protected void bntAsignar_Click(object sender, EventArgs e)
    {
        asignar_reclamos();
    }
}