using System;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReporteNoConforme : System.Web.UI.Page
{
    Utils llenado = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        string no_conforme;
        no_conforme = "Select *from v_producto_no_conforme where tipo "+ddlTipo.SelectedValue+" and estado " + ddlEstado.SelectedValue + " and " +
            "convert (date,[Fecha Creacion],112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";
        llenado.llenarGrid(no_conforme, GridNoConforme);
        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_eficiencia_pnc", GridEficiencia);
        lblConteo.Text = GridNoConforme.Rows.Count.ToString();
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridNoConforme, Response, "Reporte producto no conforme");
    }

    protected void btnExportarEficiencia_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridEficiencia, Response, "Eficiencia No conforme del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + "");
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