using System;
using System.Web.UI;

public partial class ReportesMedicos : System.Web.UI.Page
{
    Utils llenado = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string consulta = "SELECT " +
            "r.id as ID," +
            "reg.ejecutivo as Ejecutivo," +
            "reg.asegurado as Asegurado," +
            "reg.contratante as Contratante," +
            "reg.poliza as Poliza," +
            "reg.aseguradora as Aseguradora," +
            "reg.tipo as Tipo," +
            "reg.clase as Clase," +
            "reg.estado_poliza as Estado," +
            "r.fecha_commit as Fecha_registro," +
            "r.fecha_cierre as Fecha_cierre " +
            "FROM reg_reclamos_medicos reg " +
            "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id ";

        if (ddlTipoFecha.SelectedValue == "1")
        {
            consulta += "where(convert(date,r.fecha_commit,103) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (r.id_estado = 1)";
        }

        else
        {
            consulta += "where(convert(date,r.fecha_cierre,103) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (r.id_estado = 2)";
        }
           

        llenado.llenarGrid(consulta, GridMedicos);
        //Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_ReportesMedicos", GridMedicos);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx",false);
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridMedicos, Response, "Reporte Gastos Medicos");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}