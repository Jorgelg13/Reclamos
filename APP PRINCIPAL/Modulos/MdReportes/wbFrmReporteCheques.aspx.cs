using System;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Modulos_MdReportes_wbFrmReporteCheques : System.Web.UI.Page
{
    Utils llenado = new Utils();
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DB = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuarios();
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        string ingreso;
        PanelPrincipal.Visible = true;


        ingreso = "select " +
            "c.id_reclamo as ID, " +
            "u.nombre_completo AS Nombre, " +
            "reg.poliza as Poliza, " +
            "reg.ejecutivo as Ejecutivo," +
            "p.no_cheque as [No. Cheque], " +
            "reg.aseguradora as Aseguradora, " +
            "c.fecha as Fecha " +
            "from ingreso_cheques as c " +
            "inner join reclamos_medicos as r on r.id = c.id_reclamo " +
            "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
            "inner join detalle_pagos_reclamos_medicos as p on p.id_reclamo_medico = c.id_reclamo " +
            "inner join usuario as u on u.id = c.usuario where CONVERT(date, c.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "'";

        if (chFiltro.Checked)
        {
            ingreso += " and u.id = '" + ddlUsuario.SelectedValue + "'";
        }

        llenado.llenarGrid(ingreso, GridCheques);
        lblConteo.Text = GridCheques.Rows.Count.ToString();
        TituloReporte("Reporte de cheques ingresados", "");
    }

    private void usuarios()
    {
        ddlUsuario.DataSource = DB.usuario.ToList().Where(u => u.estado == true && !String.IsNullOrEmpty(u.nombre_completo));
        ddlUsuario.DataTextField = "nombre_completo";
        ddlUsuario.DataValueField = "id";
        ddlUsuario.DataBind();
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PanelPrincipal, Response, "Reporte producto no conforme");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/Dashboard/DashboardUnity.aspx", false);
    }

    public void TituloReporte(String Titulo, String KPI)
    {
        try
        {
            lblPeriodo.Text = "Periodo del " + Convert.ToDateTime(txtFechaInicio.Text).ToString("dd/MM/yyyy") + " al " + Convert.ToDateTime(txtFechaFin.Text).ToString("dd/MM/yyyy");
            lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString();
            lblUsuario.Text = "Usuario: " + userlogin;
            lblTitulo.Text = Titulo;
        }
        catch (Exception)
        {

        }
    }

    protected void chFiltro_CheckedChanged(object sender, EventArgs e)
    {
        if (chFiltro.Checked)
        {
            ddlUsuario.Enabled = true;
        }
        else
        {
            ddlUsuario.Enabled = false;
        }
    }
}