using System;
using System.Web.UI;

public partial class Modulos_MdRenovaciones_Reportes_Estados : System.Web.UI.Page
{
    string consulta;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        consulta = "select r.poliza as Poliza," +
            "r.poliza_unity as Poliza_Unity," +
            "r.fecha_registro as [Fecha Registro]," +
            "r.ramo as Ramo," +
            "r.placa, " +
            "r.nombre_gestor as Gestor," +
            "r.asegurado as Asegurado," +
            "r.comentario_renovacion as [Comentario Renovacion]," +
            "r.comentario_invalida as [Comentario Invalida],"+
            "r.telefono_cliente," +
            "r.correo_cliente as [Correo Cliente] " +
            "from renovaciones_polizas as r " +
            "inner join(select distinct poliza from renovaciones_log where estado = "+ddlEstado.SelectedValue+") as l on l.poliza = r.id " +
            "and convert(date,fecha_registro,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";

        llenar.llenarGridRenovaciones(consulta,GridReporte);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridReporte,Response,"Reporte de polizas " + ddlEstado.SelectedItem.Text);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}