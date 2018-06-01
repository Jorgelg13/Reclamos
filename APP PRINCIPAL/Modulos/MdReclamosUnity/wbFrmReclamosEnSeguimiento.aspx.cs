using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosEnSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    ReclamosEntities DBReclamos = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    string reclamosGeneral, estadosR;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        estadosR = "select count(*) as total, estado_auto_unity from reclamo_auto where usuario_unity = 'nsierra' and fecha_visualizar >= GETDATE() and estado_unity != 'Cerrado' " +
            "group by estado_auto_unity ";

        reclamosGeneral = "SELECT reclamo_auto.id, " +
          " reclamo_auto.estado_unity as [Estado Unity]," +
          " reclamo_auto.usuario_unity as [Usuario Unity]," +
          " auto_reclamo.poliza as Poliza," +
          " auto_reclamo.asegurado as Asegurado, " +
          " auto_reclamo.placa as Placa," +
          " auto_reclamo.marca as Marca," +
          " auto_reclamo.color as Color, " +
          " auto_reclamo.modelo as Modelo," +
          " auto_reclamo.chasis as Chasis," +
          " auto_reclamo.motor as Motor, " +
          " auto_reclamo.propietario as Propietario, " +
          " auto_reclamo.ejecutivo as Ejecutivo," +
          " auto_reclamo.aseguradora as Aseguradora," +
          //" auto_reclamo.contratante as Contratante, " +
          //" auto_reclamo.estado_poliza as [Estado Poliza]," +
          //" reclamo_auto.boleta as Boleta," +
          //" reclamo_auto.titular  as Titular," +
          //" reclamo_auto.hora as Hora," +
          " Convert(varchar(10),reclamo_auto.fecha, 103) As [Fecha Siniestro]," +
          //" reclamo_auto.fecha_commit as [Fecha Commit]," 21 +
          //" reclamo_auto.ubicacion as Ubicacion," +
          " reclamo_auto.reportante as Reportante," +
          //" reclamo_auto.version as Version," +
          //" reclamo_auto.piloto as Piloto," +
          //" reclamo_auto.edad as Edad, " +
          //" reclamo_auto.telefono as Telefono," +
          //" reclamo_auto.ajustador as Ajustador," +
          //" reclamo_auto.observaciones," +
          //" reclamo_auto.prioritario, " +
          //" reclamo_auto.complicado as Complicado, " +
          //" reclamo_auto.compromiso_pago as [Compromiso Pago], " +
          //" reclamo_auto.alquiler_auto as [Alquiler Auto], " +
          //" reclamo_auto.perdida_total as [Perdida Total], " +
          " reclamo_auto.estado_auto_unity as [Estado Auto]," +
          //" gestores.nombre as [Gestor Reclamo], " +
          //" talleres.nombre as Taller, " +
          //" analistas.nombre as Analista, " +
          //" cabina.nombre as Cabina," +
          //" sucursal.nombre as Sucursal," +
          //" empresa.nombre as Empresa," +
          //" pais.nombre as Pais," +
          //" usuario.nombre as [Usuario Cabina]," +
          " CONVERT(varchar(12), reclamo_auto.fecha_visualizar,103) as [Fecha Visualizar]," +
          " CASE WHEN CONVERT(date, reclamo_auto.fecha_visualizar, 110) < CONVERT(date, GETDATE(), 110)  THEN 0 ELSE 1 END AS mostrar " +
          " FROM auto_reclamo " +
          " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id ";
          //" INNER JOIN gestores on reclamo_auto.id_gestor = gestores.id" +
          //" INNER JOIN talleres on reclamo_auto.id_taller = talleres.id" +
          //" INNER JOIN analistas on reclamo_auto.id_analista = analistas.id";
           //" INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
           //" INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
           //" INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
           //" INNER JOIN pais ON empresa.id_pais = pais.id " +
           //" INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id ";

        string reclamosSeguimiento = reclamosGeneral + 
            " where (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.fecha_visualizar <= getdate() and estado_unity != 'Cerrado' and estado_unity != 'Sin Cerrar' ) ";

        //query con el que se muestran los reclamos complicados por usuario.
        string reclamosComplicados = reclamosGeneral +
                    " where ((reclamo_auto.complicado = 'true') and (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.estado_unity != 'Cerrado' ))";

        //query con el que se muestran los reclamos prioritarios.
        string reclamosPrioritarios = reclamosGeneral +
                    " where ((reclamo_auto.prioritario = 'true') and (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.estado_unity != 'Cerrado' ))";
        if(!IsPostBack)
        {
            //funciones que llenan los grid con los registros
            llenado.llenarGrid(reclamosSeguimiento, GridReclamosSeguimiento);
            llenado.llenarGrid(reclamosComplicados, GridComplicados);
            llenado.llenarGrid(reclamosPrioritarios, GridPrioritarios);
        }
    }

    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id1;
        id1 = Convert.ToInt32(GridReclamosSeguimiento.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id1,false);
    }

    protected void GridComplicados_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id2;
        id2 = Convert.ToInt32(GridComplicados.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id2, false);
    }

    protected void GridPrioritarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id3;
        id3 = Convert.ToInt32(GridPrioritarios.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id3, false);
    }

    protected void GridReclamosGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id4;
        id4 = Convert.ToInt32(GridReclamosGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id4, false);
    }

    protected void GridReclamosEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id5;
        id5 = Convert.ToInt32(GridReclamosEstado.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id5, false);
    }

    //funcion que coloca en rojo los registros que no se an abierto en el dia
    protected void GridReclamosSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.Cells[19].Text == "0")
            {
                for (int _xCell = 0; _xCell <= e.Row.Cells.Count - 1; _xCell++)
                {
                    e.Row.Cells[_xCell].ForeColor = System.Drawing.Color.Red;
                }
            }
    }

    protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string reclamosSeguimiento2 = reclamosGeneral +
               " where (reclamo_auto.estado_auto_unity = '" + DDLTipo.SelectedItem + "' and reclamo_auto.usuario_unity = '" + userlogin + "' and estado_unity != 'Cerrado' ) ";

        llenado.llenarGrid(reclamosSeguimiento2, GridReclamosEstado);
        GridReclamosSeguimiento.Visible = false;
    }

    protected void ddlGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        String reclamosGestor = reclamosGeneral +
              "where ( reclamo_auto.id_gestor = " + ddlgestor.SelectedValue + " and reclamo_auto.estado_unity = 'Seguimiento')";

        String Prioritarios = reclamosGeneral +
             " where ((reclamo_auto.prioritario = 'true') and (reclamo_auto.id_gestor = " + ddlgestor.SelectedValue + " and reclamo_auto.estado_unity = 'Seguimiento' ))";

        String Complicados = reclamosGeneral +
             " where ((reclamo_auto.complicado = 'true') and (reclamo_auto.id_gestor = " + ddlgestor.SelectedValue + " and reclamo_auto.estado_unity = 'Seguimiento' ))";

        llenado.llenarGrid(reclamosGestor, GridReclamosGeneral);
        llenado.llenarGrid(Prioritarios, GridPrioritarios);
        llenado.llenarGrid(Complicados, GridComplicados);   
    }
}