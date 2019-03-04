using System;

public partial class DashboardUnity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    protected void ConsultarReclamos_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelReportes.Visible = false;
        PanelConsultas.Visible = true;

    }

    protected void ConsultarReportes_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelConsultas.Visible = false;
        PanelReportes.Visible = true;
    }

    protected void ConsultarMaternidad_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/ControlMaternidad.aspx");
    }
}