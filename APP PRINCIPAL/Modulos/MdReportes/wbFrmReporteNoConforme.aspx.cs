using System;
using System.Web;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReporteNoConforme : System.Web.UI.Page
{
    Utils llenado = new Utils();
    String userlogin = HttpContext.Current.User.Identity.Name;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        string no_conforme;
        PanelPrincipal.Visible = true;
        GridNoConforme.Visible = true;
        GridEficiencia.Visible = false;

        no_conforme = "Select *from v_producto_no_conforme where tipo "+ddlTipo.SelectedValue+" and estado " + ddlEstado.SelectedValue + " and " +
            "convert (date,[Fecha Creacion],112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";
        llenado.llenarGrid(no_conforme, GridNoConforme);

        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_eficiencia_pnc", GridEficiencia);
        lblConteo.Text = "Total de Registros:  " + GridNoConforme.Rows.Count.ToString();
        TituloReporte("Reporte Producto No Conforme / Depto de Reclamos "+ ddlTipo.SelectedItem.Text +" ","");
    }

    public void ocultar()
    {
        if(ddlTipo.SelectedItem.Text == "General")
        {

        }

        else if(ddlTipo.SelectedItem.Text == "Autos")
        {
            GridEficiencia.Rows[1].Visible = false;
            GridEficiencia.Rows[2].Visible = false;
            GridEficiencia.Rows[3].Visible = false;
        }

        else if (ddlTipo.SelectedItem.Text == "Daños varios")
        {
            GridEficiencia.Rows[0].Visible = false;
            GridEficiencia.Rows[2].Visible = false;
            GridEficiencia.Rows[3].Visible = false;
        }

        else if (ddlTipo.SelectedItem.Text == "Individuales")
        {
            GridEficiencia.Rows[0].Visible = false;
            GridEficiencia.Rows[1].Visible = false;
            GridEficiencia.Rows[3].Visible = false;
        }

        else if (ddlTipo.SelectedItem.Text == "Colectivos")
        {
            GridEficiencia.Rows[0].Visible = false;
            GridEficiencia.Rows[1].Visible = false;
            GridEficiencia.Rows[2].Visible = false;
        }
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
            //PanelPrincipal.Visible = true;
            lblPeriodo.Text = "Periodo del " + Convert.ToDateTime(txtFechaInicio.Text).ToString("dd/MM/yyyy") + " al " + Convert.ToDateTime(txtFechaFin.Text).ToString("dd/MM/yyyy");
            lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString();
            lblUsuario.Text = "Usuario: " + userlogin;
            lblTitulo.Text = Titulo;
        }
        catch (Exception)
        {

        }
    }

    protected void btnMostrarEficiencia_Click(object sender, EventArgs e)
    {
        TituloReporte("Eficiencia Producto No Conforme / Depto de Reclamos " + ddlTipo.SelectedItem.Text + " ", "");

        GridEficiencia.Rows[0].Visible = true;
        GridEficiencia.Rows[1].Visible = true;
        GridEficiencia.Rows[2].Visible = true;
        GridEficiencia.Rows[3].Visible = true;

        GridEficiencia.Visible = true;
        GridNoConforme.Visible = false;
        ocultar();
    }
}