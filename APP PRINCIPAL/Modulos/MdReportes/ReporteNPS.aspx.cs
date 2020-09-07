using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReportes_ReporteNPS : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    conexionBD obj = new conexionBD();
    String autos;
    String titulo,id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToString(Request.QueryString[0]).ToString();

        if(id == "2")
        {
            PnClientes.Visible = true;
            PnNPS.Visible = false;
        }
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

        else if (ddlElegir.SelectedValue == "4")
        {
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_nps_general", GridNPS);
        }

        lbltotal.Text = " " + GridNPS.Rows.Count.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        if (ddlElegir.SelectedValue == "1" && PnNPS.Visible == true)
        { 
            titulo = "Reporte NPS Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
            Utils.ExportarExcel(GridNPS, Response, titulo);
        }

        else if (ddlElegir.SelectedValue == "2" && PnNPS.Visible == true)
        {
            titulo = "Reporte NPS Daños varios del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
            Utils.ExportarExcel(GridNPS, Response, titulo);
        }

        else if (ddlElegir.SelectedValue == "3" && PnNPS.Visible == true)
        {
            titulo = "Reporte NPS Gastos medicos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
            Utils.ExportarExcel(GridNPS, Response, titulo);
        }

        else if(PnClientes.Visible == true)
        {
            titulo = "Reporte Renovaciones y Cancelaciones " + txtFechaInicio.Text + " al " + txtFechaFin.Text + " ";
            Utils.ExportarExcel(GridClientsCrm, Response, titulo);
        }

    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        Utils.ReportesSeguro(Convert.ToDateTime(fechaInicio.Text).ToString("dd/MM/yyyy"),Convert.ToDateTime(fechaFin.Text).ToString("dd/MM/yyyy"), "pa_cierre_depto_Ind_lst_nuevo_2", GridClientsCrm,ddlGrupoEconomico);
        lblTotalCRM.Text = "El total de registros es: " + GridClientsCrm.Rows.Count.ToString();
    }

    protected void GridClientsCrm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int pocision = 8;

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.Cells[pocision].Text == "Nueva          ")
            {
                e.Row.Attributes.Add("style", "background-color: #8ace8e "); //verdes
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.Cells[pocision].Text == "Cancelada      ")
            {
                e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            }
    }
}