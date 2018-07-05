using System;
using System.Web.UI;

public partial class ReportesAutorizacionesAbiertas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reportesAutorizacionesAbiertas", GridReporteAutorizaciones);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridReporteAutorizaciones,Response,"Autorizaciones Abiertas");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}