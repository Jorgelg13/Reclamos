using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosEnSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    ReclamosEntities DBReclamos = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    string reclamosGeneral, estadosAgrupados, estado, reclamosSeguimiento;
    int total;

    protected void Page_Load(object sender, EventArgs e)
    {
        estadosAgrupados = "select count(*) as Total, estado_auto_unity as Estado from reclamo_auto where usuario_unity = '"+userlogin+"' and estado_unity = 'Seguimiento' " +
            "group by estado_auto_unity ";

        reclamosGeneral = "SELECT reclamo_auto.id AS ID," +
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
          " CONVERT(varchar(12), reclamo_auto.fecha_visualizar,103) as [Fecha Visualizar] " +
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

        //query con el que se muestran los reclamos complicados por usuario.
        string reclamosComplicados = reclamosGeneral +
                    " where ((reclamo_auto.complicado = 'true') and (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.estado_unity != 'Cerrado' ))";

        //query con el que se muestran los reclamos prioritarios.
        string reclamosPrioritarios = reclamosGeneral +
                    " where ((reclamo_auto.prioritario = 'true') and (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.estado_unity != 'Cerrado' ))";
        if(!IsPostBack)
        {
            //funciones que llenan los grid con los registros
            llenado.llenarGrid(estadosAgrupados, GridReclamosSeguimiento);
            llenado.llenarGrid(reclamosComplicados, GridComplicados);
            llenado.llenarGrid(reclamosPrioritarios, GridPrioritarios);
        }
    }

    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        estado = GridReclamosSeguimiento.SelectedRow.Cells[2].Text;
        reclamosSeguimiento = reclamosGeneral +
        " where (reclamo_auto.usuario_unity = '" + userlogin + "' and reclamo_auto.estado_unity = 'Seguimiento' and reclamo_auto.estado_auto_unity = '" + estado + "') ";

        llenado.llenarGrid(reclamosSeguimiento, GridReclamosEstado);
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
            if (Convert.ToDateTime(e.Row.Cells[18].Text) >= DateTime.Today)
            {
                for (int cell = 0; cell <= e.Row.Cells.Count - 1; cell++)
                {
                    e.Row.CssClass = "pendientes"; //verdes
                }
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[18].Text) < DateTime.Today)
            {
                for (int cell = 0; cell <= e.Row.Cells.Count - 1; cell++)
                {
                    e.Row.CssClass = "atrasados";//rojos
                }
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[18].Text) == DateTime.Today.AddDays(2) || Convert.ToDateTime(e.Row.Cells[18].Text) == DateTime.Today.AddDays(1))
            {
                for (int cell = 0; cell <= e.Row.Cells.Count - 1; cell++)
                {
                    e.Row.CssClass = "precaucion"; //amarillos
                }
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[18].Text) == DateTime.Today)
            {
                for (int cell = 0; cell <= e.Row.Cells.Count - 1; cell++)
                {
                    e.Row.CssClass = "ver-hoy"; //azules
                }
            }
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

    protected void GridReclamosSeguimiento_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTAL:";
                e.Row.Cells[1].Text = total.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al realizar el conteo de reclamos" + ex.Message, "Error..","error");
        }
    }
}