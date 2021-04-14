using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_Colectivos_reclamos_pendientes : System.Web.UI.Page
{
    ReclamosEntities DB = new ReclamosEntities();
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Convert.ToString(Request.QueryString[0]).ToString();

        String Consulta = "select " +
            "r.empresa as Empresa, " +
            "reg.poliza as Poliza," +
            "reg.aseguradora as Aseguradora," +
            "reg.tipo_registro as [Tipo Reclamo]," +
            "r.id as ID," +
            "r.asegurado as Asegurado," +
            "reg.clase as Clase," +
            "reg.moneda as Moneda," +
            "r.fecha_completa_commit as [Fecha Registro]" +
            "from reclamos_medicos as r " +
            "inner join reg_reclamos_medicos as reg on r.id_reg_reclamos_medicos = reg.id " +
            "where r.estado_unity = 'Seguimiento' and reg.tipo ='C' and r.correo= '"+email+"' ";

        llenado.llenarGrid(Consulta, GridPendientes);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void lnExcel_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridPendientes, Response, "Reclamos Pendientes Cierre");
    }
}