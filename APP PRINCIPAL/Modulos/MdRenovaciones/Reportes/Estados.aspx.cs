using System;
using System.Web.UI;

public partial class Modulos_MdRenovaciones_Reportes_Estados : System.Web.UI.Page
{
    string consulta, consulta2;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
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
        //consulta = "select r.poliza as Poliza," +
        //    "r.poliza_unity as Poliza_Unity," +
        //    "r.fecha_registro as [Fecha Registro]," +
        //    "r.ramo as Ramo," +
        //    "r.placa as Placa, " +
        //    "r.codigo_gestor as [Codigo Gestor],"+
        //    "r.nombre_gestor as Gestor," +
        //    "r.asegurado as Asegurado," +
        //    "r.comentario_renovacion as [Comentario Renovacion]," +
        //    "r.telefono_cliente as [Telefono Cliente]," +
        //    "r.correo_cliente as [Correo Cliente], " +
        //    "r.comentario_invalida as [Comentario Invalida]," +
        //    "r.aclaracion as Aclaracion," +
        //    "r.facturador as Facturador, " +
        //    "r.fecha_facturacion as [Fecha Facturacion] " +
        //    "from renovaciones_polizas as r " +
        //    "where r.estado = "+ddlEstado.SelectedValue+" "+
        //    "and convert(date,fecha_registro,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";

        consulta = "select r.id as ID," +
               "r.poliza_unity as [Poliza Unity]," +
               "r.fecha_registro as [Fecha Registro]," +
               "r.placa as Placa," +
               "r.codigo_gestor as [Codigo Gestor]," +
               "r.asegurado as Asegurado " +
               "from renovaciones_polizas as r " +
               "where r.estado = " + ddlEstado.SelectedValue + " " +
               " and convert(date,fecha_registro,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";

        if (ddlEstado.SelectedValue == "4")
        {
            consulta = "select r.id as ID," +
                "r.poliza_unity as [Poliza Unity]," +
                "r.fecha_registro as [Fecha Registro]," +
                "r.placa as Placa," +
                "r.codigo_gestor as [Codigo Gestor]," +
                "r.asegurado as Asegurado, " +
                "r.comentario_renovacion as [Comentario Renovacion] " +
                "from renovaciones_polizas as r " +
                "where r.estado = " + ddlEstado.SelectedValue + " " +
                " and convert(date,fecha_registro,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }


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