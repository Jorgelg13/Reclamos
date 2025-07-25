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
    string reclamosSinAperturar = "select \r\nr.id, \t\r\ng.nombre as Ejecutivo,\r\na.poliza as Poliza,\r\na.placa as Placa,\r\nr.fecha_asignacion as [Fecha asignacion]\r\nfrom reclamo_auto as r\r\ninner join auto_reclamo as a on r.id_auto_reclamo = a.id\r\ninner join gestores as g on r.usuario_unity = g.usuario\r\nwhere r.fecha_apertura_reclamo is null\r\nand g.estado = 1\r\nand g.tipo = 'autos'\r\nand r.estado_unity = 'Sin Cerrar'";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");

            ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(ges => ges.tipo == "autos" && ges.estado == true);
            ddlGestor.DataTextField = "nombre";
            ddlGestor.DataValueField = "id";
            ddlGestor.DataBind();
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos de Autos", userlogin, txtFechaInicio, txtFechaFin, "");
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (PnCiclos.Visible == true)
        {
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte de "+ddlGestor.SelectedValue+" ");
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

   

    protected void GridCiclos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
            //    Promedio += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
            //    EjecucionCiclos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Ejecucion"));
            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[0].Text = "TOTALES:";

            //    e.Row.Cells[1].Text = Total.ToString();
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;

            //    e.Row.Cells[2].Text = (Promedio / GridAsignaciones.Rows.Count).ToString();
            //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;

            //    e.Row.Cells[3].Text = (Convert.ToDouble(kpi) / (Promedio / GridAsignaciones.Rows.Count) * 100).ToString("N2");
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;
            //}
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridCiclos2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Total2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
            //    Promedio2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
            //    EjecucionCiclos2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Ejecucion"));

            //    if (Convert.ToInt32(e.Row.Cells[3].Text) >= 100)
            //    {
            //        e.Row.Attributes.Add("style", "background-color: #8ace8e"); //verdes
            //    }

            //    if (Convert.ToInt32(e.Row.Cells[3].Text) < 90)
            //    {
            //        e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            //    }
            //}
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[0].Text = "TOTALES:";

            //    e.Row.Cells[1].Text = Total2.ToString();
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;

            //    e.Row.Cells[2].Text = (Promedio2 / GridPendientes.Rows.Count).ToString();
            //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;

            //    e.Row.Cells[3].Text = ((Convert.ToDouble(kpi)/ (Promedio2 / GridPendientes.Rows.Count)) *100 ).ToString("N2");
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Font.Bold = true;
            //}
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void Mostrar_Click(object sender, EventArgs e)
    {
        PnCiclos.Visible = true;
        lblGestor.Text = ddlGestor.SelectedItem.ToString();
        Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos de Autos", userlogin, txtFechaInicio, txtFechaFin, "");
        Utils.resumen_reclamos(txtFechaInicio, txtFechaFin, "pa_resumen_asignacion_reclamos_autos", GridAsignaciones);
        Utils.resumen_reclamos(txtFechaInicio, txtFechaFin, "pa_resumen_reclamos_autos_pendientes", GridPendientes);
        Utils.resumen_reclamos_por_estado(Convert.ToInt32(ddlGestor.SelectedValue), "pa_resumen_reclamos_por_estado", GridReclamosPorEstado);
        llenar.llenarGrid(reclamosSinAperturar, GridReclamosSinAperturar);
    }

    protected void linkDescarPromedio_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridAsignaciones, Response, lblTitulo.Text + " Reclamos Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }
}