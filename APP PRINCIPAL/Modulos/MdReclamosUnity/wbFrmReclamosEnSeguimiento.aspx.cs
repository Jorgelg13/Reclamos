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
    string reclamosGeneral, estadosAgrupados, estado, reclamosSeguimiento, alarmas;
    int id, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(userlogin == "nsierra" || userlogin == "jlaj" || userlogin == "jsagastume" || userlogin =="mbarrios")
        {
            PnAlarmas.Visible = true;
        }
        estadosAgrupados = "select count(*) as Total, estado_auto_unity as Estado from reclamo_auto where usuario_unity = '"+userlogin+"' and estado_unity = 'Seguimiento' " +
            "group by estado_auto_unity ";

        reclamosGeneral = "SELECT " +
          " r.id AS ID," +
          " r.estado_unity as [Estado Unity],"+
          " r.estado_auto_unity as [Estado Auto]," +
          " r.usuario_unity as [Usuario Unity]," +
          " a.poliza as Poliza," +
          " a.asegurado as Asegurado, " +
          " a.placa as Placa," +
          " a.marca as Marca," +
          " a.color as Color, " +
          " a.modelo as Modelo," +
          " a.ejecutivo as Ejecutivo," +
          " a.aseguradora as Aseguradora," +
          " CONVERT(varchar(12), r.fecha_visualizar,103) as [Fecha Visualizar] " +
          " FROM auto_reclamo a " +
          " INNER JOIN reclamo_auto as r ON r.id_auto_reclamo = a.id ";

        //query con el que se muestran los reclamos complicados por usuario.
        string reclamosComplicados = reclamosGeneral +
                    " where ((r.complicado = 'true') and (r.usuario_unity = '" + userlogin + "' and r.estado_unity != 'Cerrado' ))";

        //query con el que se muestran los reclamos prioritarios.
        string reclamosPrioritarios = reclamosGeneral +
                    " where ((r.prioritario = 'true') and (r.usuario_unity = '" + userlogin + "' and r.estado_unity != 'Cerrado' ))";

        //query con el que se muestran los reclamos proximos a ser inactivados.
        string inactivos = reclamosGeneral +
              " where r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and DATEDIFF(DAY, r.fecha_visualizar, GETDATE()) >= 43  " +
              "and r.estado_auto_unity = 'Pendiente Asegurado' ";

        alarmas = reclamosGeneral + " where r.estado_unity = 'Seguimiento' and  convert(date, r.fecha_visualizar,112) < getdate() order by r.usuario_unity, r.fecha_visualizar";

        if(!IsPostBack)
        {
            //funciones que llenan los grid con los registros
            llenado.llenarGrid(estadosAgrupados, GridReclamosSeguimiento);
            llenado.llenarGrid(reclamosComplicados, GridComplicados);
            llenado.llenarGrid(reclamosPrioritarios, GridPrioritarios);
            llenado.llenarGrid(inactivos, GridInactivos);
            llenado.llenarGrid(alarmas, GridAlarmas);
            lblTotalAlarmas.Text = "   Total de reclamos: " + GridAlarmas.Rows.Count.ToString();
        }
    }

    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        estado = GridReclamosSeguimiento.SelectedRow.Cells[2].Text;
        reclamosSeguimiento = reclamosGeneral +
        " where (r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and r.estado_auto_unity = '" + estado + "') ";
        llenado.llenarGrid(reclamosSeguimiento, GridReclamosEstado);
    }

    protected void GridComplicados_SelectedIndexChanged(object sender, EventArgs e)
    {

        id = Convert.ToInt32(GridComplicados.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    protected void GridPrioritarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridPrioritarios.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    protected void GridReclamosGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    protected void GridReclamosEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosEstado.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    protected void GridInactivos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridInactivos.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    protected void GridAlarmas_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAlarmas.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.AUTOS(), 27, Constantes.USER());
    }

    //funcion que coloca en rojo los registros que no se an abierto en el dia
    protected void GridReclamosSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int pocision = 13;
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[pocision].Text) >= DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #8ace8e "); //verdes
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[pocision].Text) < DateTime.Today && e.Row.Cells[pocision].Text =="")
            {
                 e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[pocision].Text) == DateTime.Today.AddDays(2) || Convert.ToDateTime(e.Row.Cells[pocision].Text) == DateTime.Today.AddDays(1))
            {
               e.Row.Attributes.Add("style", "background-color: #f9f595"); //amarillos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[pocision].Text) == DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #afcaf7"); //azules
            }
    }

    protected void ddlGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        String reclamosGestor = reclamosGeneral +
              "where ( r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento') order by r.fecha_visualizar";

        String Prioritarios = reclamosGeneral +
             " where ((r.prioritario = 'true') and (r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento' ))";

        String Complicados = reclamosGeneral +
             " where ((r.complicado = 'true') and (r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento' ))";

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

    protected void ddlAlarmaGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        alarmas = reclamosGeneral + " where r.estado_unity = 'Seguimiento' and r.id_gestor = "+ddlAlarmaGestor.SelectedValue+" and " +
            " convert(date, r.fecha_visualizar,112) < getdate() order by r.fecha_visualizar ";
        llenado.llenarGrid(alarmas, GridAlarmas);
        GridAlarmas.DataBind();
        lblTotalAlarmas.Text = "   Total de reclamos: " + GridAlarmas.Rows.Count.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnAlarmas,Response, "Alarmas de reclamos autos");
    }

    protected void lnDescargarTotalGestor_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridReclamosGeneral, Response, "Reclamos En seguimiento de " + ddlgestor.SelectedItem.Text);
        Utils.actividades(id, Constantes.AUTOS(), 28, Constantes.USER());
    }
}