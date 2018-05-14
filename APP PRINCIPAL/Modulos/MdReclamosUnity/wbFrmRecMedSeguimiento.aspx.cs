using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmRecMedSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    String ReclamoSeguimiento, ReclamosPendientes, ReclamosGestor;
    Utils llenado = new Utils();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        String seleccionarRegistros = "SELECT " +
           "dbo.reclamos_medicos.id as ID," + //1
           "dbo.reg_reclamos_medicos.asegurado as Asegurado," +
           "dbo.reg_reclamos_medicos.poliza as Poliza," +
           "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +
           "dbo.reclamos_medicos.telefono as Telefono," +
           "dbo.reclamos_medicos.correo as Correo," +
           "dbo.reclamos_medicos.empresa as Empresa," +
           "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
           "dbo.reg_reclamos_medicos.ramo as Ramo," +
           "dbo.reg_reclamos_medicos.tipo as Tipo," +
           "dbo.reg_reclamos_medicos.clase as Clase," +
           "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
           "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
           "dbo.reg_reclamos_medicos.vip as VIP," +
           "dbo.reg_reclamos_medicos.moneda as Moneda," +
           "dbo.cabina.nombre as Cabina," +
           "dbo.sucursal.nombre as Sucursal," +
           "dbo.empresa.nombre as Empresa," +
           "dbo.pais.nombre as Pais, " +
           "CASE WHEN CONVERT(date, reclamos_medicos.fecha_visualizar, 110) < CONVERT(date, GETDATE(), 110)  THEN 0 ELSE 1 END AS mostrar, " +
           "Convert(varchar(10),dbo.reclamos_medicos.fecha_visualizar, 103) As [Fecha Visualizar] " +
           "FROM " +
           " dbo.reg_reclamos_medicos " +
           "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
           "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id " +
           "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
           "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
           "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id ";

        ReclamoSeguimiento = seleccionarRegistros +
          "where usuario_unity = '" + userlogin + "' and estado_unity = 'Seguimiento' and reclamos_medicos.fecha_visualizar <= GETDATE() and id_estado != " + 2 + "";

        ReclamosPendientes = seleccionarRegistros +
          " where usuario_unity = '" + userlogin + "' and estado_unity = 'Seguimiento' and id_estado != " + 2 + "";

        ReclamosGestor = seleccionarRegistros +
          " where usuario_unity = '" + ddlGestor.SelectedItem + "' and estado_unity = 'Seguimiento'";

        llenado.llenarGrid(ReclamoSeguimiento, GridReclamosSeguimiento);
        llenado.llenarGrid(ReclamosPendientes, GridPendientes);
    }

    //funcion que coloca en rojo los registros que no se an abierto en el dia
    protected void GridReclamosSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.Cells[20].Text == "0")
            {
                for (int _xCell = 0; _xCell <= e.Row.Cells.Count - 1; _xCell++)
                {
                    e.Row.Cells[_xCell].ForeColor = System.Drawing.Color.Red;
                }
            }
    }

    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosSeguimiento.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo="+ id, false);
    }

    protected void GridPendientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridPendientes.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void GridReclamosPorGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosPorGestor.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(ReclamosGestor, GridReclamosPorGestor);
    }
}