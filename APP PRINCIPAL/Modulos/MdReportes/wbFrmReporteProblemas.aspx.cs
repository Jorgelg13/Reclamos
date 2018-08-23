using System;
using System.Web;
using System.Web.UI;

public partial class Modulos_MdReportes_wbFrmReporteProblemas : System.Web.UI.Page
{
    Utils llenado = new Utils();
    String idRecibido;
    String userlogin = HttpContext.Current.User.Identity.Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        if(idRecibido == "1")
        {
            Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Problemas / Depto. Reclamos Autos", userlogin, txtFechaInicio, txtFechaFin, "");
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reporte_problemas_autos", GvProblemas);
            lblConteo.Text = GvProblemas.Rows.Count.ToString();
        }

        else
        {
            Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Problemas / Depto. Reclamos Daños", userlogin, txtFechaInicio, txtFechaFin, "");
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reporte_problemas_danios", GvProblemas);
            lblConteo.Text = GvProblemas.Rows.Count.ToString();
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PanelPrincipal, Response, "Reporte de problemas " + txtFechaInicio.Text + " al " + txtFechaFin.Text + "");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/Dashboard/DashboardUnity.aspx", false);
    }
}