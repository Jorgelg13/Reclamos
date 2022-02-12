using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmRecDañosSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    Utils llenado = new Utils();
    String selectGeneral, EstadosAgrupados,estado,reclamosSeguimiento, alarmas;
    int id, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (userlogin == "cmejia" || userlogin == "jlaj" || userlogin == "mbarrios")
        {
            PnAlarmas.Visible = true;
        }

        EstadosAgrupados = "select count(*) as Total, estado_reclamo_unity as Estado from reclamos_varios where usuario_unity = '"+userlogin+"' and estado_unity = 'Seguimiento' group by estado_reclamo_unity ";

        selectGeneral = "SELECT " +
                "r.id as ID," +
                "gestores.nombre as Gestor," +
                "r.estado_reclamo_unity as Estado," +
                "DATEDIFF(DAY, r.fecha_commit, GETDATE()) as  [Total Dias]," +
                "case when reaseguro=1 then 'Si' else 'No' end as Reaseguro,"+
                "reg.poliza as Poliza," +
                "reg.asegurado as Asegurado," +
                "reg.aseguradora as Aseguradora," + //4
                "reg.contratante as Contratante," +
                "reg.ejecutivo as Ejecutivo," +//6
                "reg.ramo as Ramo," +
                "reg.status as Estatus," +
                "reg.tipo as Tipo," +//10
                "r.reportante as Reportante," +
                "Convert(varchar(20),r.fecha_commit, 103) as [Fecha Creacion]," +
                "Convert(varchar(20),r.fecha_visualizar, 103) as [Fecha Visualizar] " +
                "FROM reg_reclamo_varios as reg " +
                "INNER JOIN reclamos_varios as r on r.id_reg_reclamos_varios = reg.id "+
                "INNER JOIN gestores on r.id_gestor = gestores.id ";

        string reclamosPrioritarios = selectGeneral +
               " where ((r.prioritario = 'true') and (r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' ))";

        string reclamosComplicados = selectGeneral +
               " where ((r.complicado = 'true') and (r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' ))";

        string inactivos = selectGeneral +
              " where r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and DATEDIFF(DAY, r.fecha_visualizar, convert(date,getdate(),103) ) >= 30  and r.estado_reclamo_unity = 'Pendiente Asegurado' ";

        alarmas = selectGeneral + " where r.estado_unity = 'Seguimiento' and convert(date, r.fecha_visualizar,112) < getdate() order by gestores.nombre, r.fecha_visualizar";

        if (!IsPostBack)
        {
            llenado.llenarGrid(EstadosAgrupados, GridReclamosSeguimiento);
            llenado.llenarGrid(reclamosPrioritarios, GridPrioritarios);
            llenado.llenarGrid(reclamosComplicados, GridComplicados);
            llenado.llenarGrid(inactivos, GridInactivos);
            llenado.llenarGrid(alarmas, GridAlarmas);
            lblTotalAlarmas.Text = "Total de reclamos: " + GridAlarmas.Rows.Count.ToString();

            lblProximosInactivos.Text = GridInactivos.Rows.Count.ToString();
            lblProximosInactivos.Visible = (lblProximosInactivos.Text == "0") ? false : true;
        }
    }

    //metodo para actualizar la fecha a la actual
    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        estado = GridReclamosSeguimiento.SelectedRow.Cells[2].Text;
        reclamosSeguimiento = selectGeneral +
               " where (r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and r.estado_reclamo_unity = '"+HttpUtility.HtmlDecode(estado)+"') ";
        llenado.llenarGrid(reclamosSeguimiento, GridReclamosEstado);
    }

    protected void GridPrioritarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridPrioritarios.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    protected void GridComplicados_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridComplicados.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    protected void GridReclamosEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosEstado.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    protected void GridReclamosGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    protected void GridInactivos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridInactivos.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    protected void GridAlarmas_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAlarmas.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        Utils.actividades(id, Constantes.DANIOS(), 27, Constantes.USER());
    }

    //funcion que coloca en rojo los registros que no se an abierto en el dia
    protected void GridReclamosSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[16].Text) >= DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #8ace8e "); //verdes
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[16].Text) < DateTime.Today)
            {
               e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[16].Text) == DateTime.Today.AddDays(2) || Convert.ToDateTime(e.Row.Cells[15].Text) == DateTime.Today.AddDays(1))
            {
               e.Row.Attributes.Add("style", "background-color: #f9f595"); //amarillos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[16].Text) == DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #afcaf7"); //azules
            }
    }

    protected void ddlgestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        String reclamosGestor = selectGeneral +
              "where ( r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento') order by r.fecha_visualizar";

        String Prioritarios = selectGeneral +
             " where ((r.prioritario = 'true') and (r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento')) order by r.fecha_visualizar";

        String Complicados = selectGeneral +
             " where ((r.complicado = 'true') and (r.id_gestor = " + ddlgestor.SelectedValue + " and r.estado_unity = 'Seguimiento' )) order by r.fecha_visualizar";

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
            Utils.ShowMessage(this.Page, "Error al realizar el conteo de reclamos" + ex.Message, "Error..", "error");
        }
    }

    protected void ddlAlarmaGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        alarmas = selectGeneral + " where r.estado_unity = 'Seguimiento' and r.id_gestor = " + ddlAlarmaGestor.SelectedValue + " and " +
            " convert(date, r.fecha_visualizar, 112) < getdate() order by r.fecha_visualizar ";
        llenado.llenarGrid(alarmas, GridAlarmas);
        GridAlarmas.DataBind();
        lblTotalAlarmas.Text = "Total de reclamos: " + GridAlarmas.Rows.Count.ToString();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.actividades(0, Constantes.DANIOS(), 28, Constantes.USER());
        Utils.ExportarExcel(PnAlarmas, Response, "Alarmas de reclamos daños");
    }

    protected void LinKReclamosPorGestor_Click(object sender, EventArgs e)
    {
        Utils.actividades(0, Constantes.DANIOS(), 28, Constantes.USER());
        Utils.ExportarExcel(GridReclamosGeneral, Response, "reclamos por gestor");
    }

}



