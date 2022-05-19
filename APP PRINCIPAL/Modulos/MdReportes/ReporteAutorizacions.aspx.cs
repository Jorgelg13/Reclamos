using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReportes_ReporteAutorizacions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_reportesAutorizaciones", GridAutorizaciones);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx", false);
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridAutorizaciones, Response, "Reporte de autorizaciones");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}