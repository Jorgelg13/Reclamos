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
               "r.vigf as [Vigencia Final]," +
               "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
               "r.placa as Placa," +
               "r.codigo_gestor as [Codigo Gestor]," +
               "r.asegurado as Asegurado " +
               "from renovaciones_polizas as r " +
               "where r.estado = " + ddlEstado.SelectedValue + " " +
               " and convert(date,fecha_registro,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";

        if (ddlEstado.SelectedValue == "2")
        {
            consulta = "select r.id as ID," +
                "r.poliza_unity as [Poliza Unity]," +
                "r.vigf as [Vigencia Final]," +
                "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
                "convert(varchar, p.fecha, 103) as [Fecha Asignada]," +
                "r.placa as Placa," +
                "r.codigo_gestor as [Codigo Gestor]," +
                "r.asegurado as Asegurado " +
                "from renovaciones_polizas as r " +
                "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 2 " +
                "where r.estado = " + ddlEstado.SelectedValue + " " +
                " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }

        else if (ddlEstado.SelectedValue == "3")
        {
            consulta = "select r.id as ID," +
                 "r.poliza_unity as [Poliza Unity]," +
                 "r.vigf as [Vigencia Final]," +
                 "convert(varchar, r.fecha_registro, 103) as [Fecha Registro],"+
                 "convert(varchar, p.fecha, 103) as [Fecha Enviada],"+
                 "r.placa as Placa," +
                 "r.codigo_gestor as [Codigo Gestor]," +
                 "r.asegurado as Asegurado " +
                 "from renovaciones_polizas as r " +
                 "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 3 " +
                 "where r.estado = " + ddlEstado.SelectedValue + " " +
                 " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }

        else if (ddlEstado.SelectedValue == "4")
        {
            consulta = "select r.id as ID," +
                "r.poliza_unity as [Poliza Unity]," +
                "r.vigf as [Vigencia Final],"+
                "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
                "convert(varchar, p.fecha, 103) as [Fecha Renovacion]," +
                "r.placa as Placa," +
                "r.codigo_gestor as [Codigo Gestor]," +
                "r.asegurado as Asegurado, " +
                "r.comentario_renovacion as [Comentario Renovacion] " +
                "from renovaciones_polizas as r " +
                "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 4 " +
                "where r.estado = " + ddlEstado.SelectedValue + " " +
                " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }

        else if (ddlEstado.SelectedValue == "5")
        {
            consulta = "select r.id as ID," +
                "r.poliza_unity as [Poliza Unity]," +
                "r.vigf as [Vigencia Final]," +
                "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
                "convert(varchar, p.fecha, 103) as [Fecha Cancelacion]," +
                "r.placa as Placa," +
                "r.codigo_gestor as [Codigo Gestor]," +
                "r.asegurado as Asegurado " +
                "from renovaciones_polizas as r " +
                "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 5 " +
                "where r.estado = " + ddlEstado.SelectedValue + " " +
                " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }

        else if (ddlEstado.SelectedValue == "6")
        {
            consulta = "select r.id as ID," +
                "r.poliza_unity as [Poliza Unity]," +
                "r.vigf as [Vigencia Final]," +
                "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
                "convert(varchar, p.fecha, 103) as [Fecha No Enviada]," +
                "r.placa as Placa," +
                "r.codigo_gestor as [Codigo Gestor]," +
                "r.asegurado as Asegurado " +
                "from renovaciones_polizas as r " +
                "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 6 " +
                "where r.estado = " + ddlEstado.SelectedValue + " " +
                " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
        }

        else if(ddlEstado.SelectedValue == "7")
        {
            consulta = "select r.id as ID," +
                 "r.poliza_unity as [Poliza Unity]," +
                 "r.vigf as [Vigencia Final]," +
                 "convert(varchar, r.fecha_registro, 103) as [Fecha Registro]," +
                 "convert(varchar, p.fecha, 103) as [Fecha Facturada]," +
                 "r.placa as Placa," +
                 "r.codigo_gestor as [Codigo Gestor]," +
                 "r.asegurado as Asegurado " +
                 "from renovaciones_polizas as r " +
                 "inner join renovaciones_log as p on r.id = p.poliza and p.estado = 7 " +
                 "where r.estado = " + ddlEstado.SelectedValue + " " +
                 " and convert(date,p.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";
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