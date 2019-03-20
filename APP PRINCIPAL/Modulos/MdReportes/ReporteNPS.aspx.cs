using System;
using System.Web;
using System.Web.UI;

public partial class Modulos_MdReportes_ReporteNPS : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    conexionBD obj = new conexionBD();
    String autos;
    String titulo;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if(ddlElegir.SelectedValue == "1")
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_nps_autos", GridNPS);
        }

        else if (ddlElegir.SelectedValue == "2")
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_nps_danios_varios", GridNPS);
        }

        else if (ddlElegir.SelectedValue == "3")
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_nps_gastos_medicos", GridNPS);
        }

        lbltotal.Text = " " + GridNPS.Rows.Count.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        if (ddlElegir.SelectedValue == "1")
        {
            titulo = "Reporte NPS Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
        }

        else if (ddlElegir.SelectedValue == "2")
        {
            titulo = "Reporte NPS Daños varios del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
        }

        else if (ddlElegir.SelectedValue == "3")
        {
            titulo = "Reporte NPS Gastos medicos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
        }

        Utils.ExportarExcel(GridNPS, Response, titulo);
    }
}