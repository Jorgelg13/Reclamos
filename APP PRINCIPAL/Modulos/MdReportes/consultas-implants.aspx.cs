using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReportes_consultas_implants : System.Web.UI.Page
{
    string consulta;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        consulta= "select " +
            "id, " +
            "asegurado as Asegurado, " +
            "telefono as Telefono," +
            "correo as Correo," +
            "empresa as Empresa," +
            "motivo as Motivo," +
            "comentario as Comentario," +
            "usuario as Usuario," +
            "fechareg as Fecha," +
            "fechafin as [Fecha Resolucion]," +
            "estado as Estado " +
            "from asegurados_implants where convert(date,fechareg,103) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"'";

        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenar.llenarGrid(consulta,GridReporte);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridReporte, Response, "Reporte de atencion implants");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}