using System;
using System.Web.UI;

public partial class Modulos_MdReportes_wbFrmReporteProblemas : System.Web.UI.Page
{
    Utils llenado = new Utils();
    String idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        if(idRecibido == "1")
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reporte_problemas_autos", GvProblemas);
            lblConteo.Text = GvProblemas.Rows.Count.ToString();
        }

        else
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reporte_problemas_danios", GvProblemas);
            lblConteo.Text = GvProblemas.Rows.Count.ToString();
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GvProblemas, Response, "Reporte de problemas " + txtFechaInicio.Text + " al " + txtFechaFin.Text + "");
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