using System;
using System.Linq;

public partial class DashboardUnity : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Conteo();
        }
    }

    protected void ConsultarReclamos_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelReportes.Visible = false;
        PanelCabina.Visible = false;
        PanelConsultas.Visible = true;

    }

    protected void ConsultarReportes_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelConsultas.Visible = false;
        PanelCabina.Visible = false;
        PanelReportes.Visible = true;
    }

    protected void ConsultarCabina_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelConsultas.Visible = false;
        PanelReportes.Visible = false;
        PanelCabina.Visible = true;
    }

    protected void ConsultarMaternidad_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/ControlMaternidad.aspx");
    }

    public void Conteo()
    {
        try
        {
            var autos = DBReclamos.reclamo_auto.ToList().Where(a => a.id_estado == 1).Count();
            totalReclamosAutos.Text = autos.ToString();

            var danios = DBReclamos.reclamos_varios.ToList().Where(d => d.id_estado == 1).Count();
            totalReclamosDaños.Text = danios.ToString();
        }

        catch (Exception ex)
        {
            Email.ENVIAR_ERROR("Error en conteo de reclamos en cabina", "Descripcion del error: " + ex);
        }
    }
}