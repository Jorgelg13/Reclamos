using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosAsignados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    Utils llenado = new Utils();
    Utils update = new Utils();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    String ReclamosAsignados, sql;
    int totalDias = 10;


    protected void Page_Load(object sender, EventArgs e)
    {
        ReclamosAsignados = "SELECT "+
           "dbo.reclamos_medicos.id as ID,"+ //1
           "dbo.reg_reclamos_medicos.asegurado as Asegurado,"+
           "dbo.reg_reclamos_medicos.poliza as Poliza,"+
           "dbo.reg_reclamos_medicos.aseguradora as Aseguradora,"+
           "dbo.reclamos_medicos.telefono as Telefono,"+
           "dbo.reclamos_medicos.correo as Correo,"+
           "dbo.reclamos_medicos.empresa as Empresa,"+
           "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo],"+
           "dbo.reg_reclamos_medicos.ramo as Ramo,"+
           "dbo.reg_reclamos_medicos.tipo as Tipo,"+
           "dbo.reg_reclamos_medicos.clase as Clase,"+
           "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo,"+
           "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza],"+
           "dbo.reg_reclamos_medicos.vip as VIP,"+
           "dbo.reg_reclamos_medicos.moneda as Moneda," +
           "dbo.cabina.nombre as Cabina,"+
           "dbo.sucursal.nombre as Sucursal,"+
           "dbo.empresa.nombre as Empresa,"+
           "dbo.pais.nombre as Pais "+
           "FROM "+
           " dbo.reg_reclamos_medicos "+
           "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id "+
           "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id "+
           "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
           "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id "+
           "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
           "where usuario_unity = '" + userlogin + "' and estado_unity = 'Asignado' ";


        llenado.llenarGrid(ReclamosAsignados, GridMedicosAsignados);
    }

    protected void GridMedicosAsignados_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id_reclamo_medico;
        string actualizarFecha = "update reclamos_medicos set fecha_revision = getdate() , fecha_apertura = getdate(), estado_unity = 'Seguimiento', id_estado= "+ 8 + ", fecha_visualizar = getdate() +3  ";
        id_reclamo_medico = Convert.ToInt32(GridMedicosAsignados.SelectedRow.Cells[1].Text);
        update.actualizarDatos(actualizarFecha, id_reclamo_medico);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id_reclamo_medico);
    }
}