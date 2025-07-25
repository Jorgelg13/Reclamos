using System;
using System.Web.UI;
using System.Data;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmReportesAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenar = new Utils();
    string reclamosSinAperturar = "select \r\nr.id as ID, \t\r\ng.nombre as Ejecutivo,\r\nreg.poliza as Poliza,\r\nr.fecha_asignacion as [Fecha Asignacion]\r\nfrom reclamos_varios as r\r\ninner join reg_reclamo_varios as reg on r.id_reg_reclamos_varios = reg.id\r\ninner join gestores as g on r.usuario_unity = g.usuario\r\nwhere r.fecha_apertura_reclamo is null\r\nand g.estado = 1\r\nand g.tipo = 'Daños varios'\r\nand r.estado_unity = 'Sin Cerrar'";
    int totalAsignaciones = 0;
    int totalPorcentajeParticipacion = 0;
    int totalPendientes = 0;
    int totalMenores30 = 0;
    int totalMayores30 = 0;
    int totalMayores180 = 0;
    int totalNoAperturados = 0;
    int totalReclamosPorEstado = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");

            ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(ges => ges.tipo == "Daños varios" && ges.estado == true);
            ddlGestor.DataTextField = "nombre";
            ddlGestor.DataValueField = "id";
            ddlGestor.DataBind();
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos de Daños varios", userlogin, txtFechaInicio, txtFechaFin, "");
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (PnCiclos.Visible == true)
        {
            Utils.ExportarExcel(PanelPrincipal, Response, "Resumen-reclamos-varios-del-"+ Convert.ToDateTime(txtFechaInicio.Text).ToString("dd-MM-yyyy") + "-al-" + Convert.ToDateTime(txtFechaFin.Text).ToString("dd-MM-yyyy"));
        }
    }

    //link para salir y ponerse en los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx", false);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void Mostrar_Click(object sender, EventArgs e)
    {
        PnCiclos.Visible = true;
        lblGestor.Text = ddlGestor.SelectedItem.ToString();
        Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos de Daños", userlogin, txtFechaInicio, txtFechaFin, "");
        Utils.resumen_reclamos(txtFechaInicio, txtFechaFin, "pa_resumen_asignacion_reclamos_varios", GridAsignaciones);
        Utils.resumen_reclamos(txtFechaInicio, txtFechaFin, "pa_resumen_reclamos_varios_pendientes", GridPendientes);
        Utils.resumen_reclamos_por_estado(Convert.ToInt32(ddlGestor.SelectedValue), "pa_resumen_reclamos_varios_por_estado", GridReclamosPorEstado);
        llenar.llenarGrid(reclamosSinAperturar, GridReclamosSinAperturar);
    }

    protected void linkDescarPromedio_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridAsignaciones, Response, lblTitulo.Text + " Reclamos Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    protected void GridAsignaciones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalAsignaciones += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Reclamos Asignados]"));
                totalPorcentajeParticipacion += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Porcentaje participacion]"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";

                e.Row.Cells[1].Text = totalAsignaciones.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = totalPorcentajeParticipacion.ToString() + "%";
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalPendientes += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Pendientes]"));
                totalMenores30 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Reclamos_menores_30]"));
                totalMayores30 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Reclamos_mayores_30]"));
                totalMayores180 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Reclamos_mayores_180]"));
                totalNoAperturados += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Reclamos_asignados_sin_aperturar]"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";

                e.Row.Cells[1].Text = totalPendientes.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = totalMenores30.ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = totalMayores30.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = totalMayores180.ToString();
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[5].Text = totalNoAperturados.ToString();
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridReclamosPorEstado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalReclamosPorEstado += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTAL:";

                e.Row.Cells[1].Text = totalReclamosPorEstado.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }
}