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
        if (userlogin == "cmejia" || userlogin == "jlaj" || userlogin == "jsagastume" || userlogin == "mbarrios")
        {
            PnAlarmas.Visible = true;
        }

        EstadosAgrupados = "select count(*) as Total, estado_reclamo_unity as Estado from reclamos_varios where usuario_unity = '"+userlogin+"' and estado_unity = 'Seguimiento' group by estado_reclamo_unity ";

        selectGeneral = "SELECT " +
                "dbo.reclamos_varios.id as ID," +
                "gestores.nombre as Gestor," +
                "dbo.reclamos_varios.estado_reclamo_unity as Estado," +
                "dbo.reg_reclamo_varios.poliza as Poliza," +
                "dbo.reg_reclamo_varios.asegurado as Asegurado," +
                "dbo.reg_reclamo_varios.cliente as Cliente," +
                "dbo.reg_reclamo_varios.aseguradora as Aseguradora," + //4
                "dbo.reg_reclamo_varios.contratante as Contratante," +
                "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +//6
                "dbo.reg_reclamo_varios.ramo as Ramo," +
                "dbo.reg_reclamo_varios.status as Estatus," +
                "dbo.reg_reclamo_varios.tipo as Tipo," +//10
                "dbo.reclamos_varios.reportante as Reportante," +
                "Convert(varchar(20),dbo.reclamos_varios.fecha_commit, 103) as [Fecha Creacion]," +
                //"gestores.telefono, " +//38
                //"gestores.correo, " +//39
                //"dbo.cabina.nombre as cabina," +
                //"dbo.sucursal.nombre as sucursal," +
                //"dbo.empresa.nombre as empresa," +
                //"dbo.pais.nombre as pais," +
                //"dbo.usuario.nombre as usuario, " +
                "Convert(varchar(20),dbo.reclamos_varios.fecha_visualizar, 103) as [Fecha Visualizar] " +
                "FROM " +
                "dbo.reg_reclamo_varios " +
                "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id "+
                "INNER JOIN gestores on reclamos_varios.id_gestor = gestores.id ";
                //"INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
                //"INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
                //"INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
                //"INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
                //"INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id ";

        string reclamosPrioritarios = selectGeneral +
               " where ((reclamos_varios.prioritario = 'true') and (reclamos_varios.usuario_unity = '" + userlogin + "' and reclamos_varios.estado_unity = 'Seguimiento' ))";

        string reclamosComplicados = selectGeneral +
               " where ((reclamos_varios.complicado = 'true') and (reclamos_varios.usuario_unity = '" + userlogin + "' and reclamos_varios.estado_unity = 'Seguimiento' ))";

        string inactivos = selectGeneral +
              " where usuario_unity = '" + userlogin + "' and estado_unity = 'Seguimiento' and DATEDIFF(DAY, fecha_visualizar, convert(date,getdate(),103) ) >= 50  and estado_reclamo_unity = 'Pendiente Asegurado' ";

        alarmas = selectGeneral + " where reclamos_varios.estado_unity = 'Seguimiento' and convert(date, reclamos_varios.fecha_visualizar,112) < getdate() order by gestores.nombre, reclamos_varios.fecha_visualizar";

        if (!IsPostBack)
        {
            llenado.llenarGrid(EstadosAgrupados, GridReclamosSeguimiento);
            llenado.llenarGrid(reclamosPrioritarios, GridPrioritarios);
            llenado.llenarGrid(reclamosComplicados, GridComplicados);
            llenado.llenarGrid(inactivos, GridInactivos);
            llenado.llenarGrid(alarmas, GridAlarmas);
            lblTotalAlarmas.Text = "Total de reclamos: " + GridAlarmas.Rows.Count.ToString();
        }
    }

    //metodo para actualizar la fecha a la actual
    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        estado = GridReclamosSeguimiento.SelectedRow.Cells[2].Text;
        reclamosSeguimiento = selectGeneral +
               " where (reclamos_varios.usuario_unity = '" + userlogin + "' and reclamos_varios.estado_unity = 'Seguimiento' and reclamos_varios.estado_reclamo_unity like '"+estado+"') ";
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
            if (Convert.ToDateTime(e.Row.Cells[15].Text) >= DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #8ace8e "); //verdes
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[15].Text) < DateTime.Today)
            {
               e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[15].Text) == DateTime.Today.AddDays(2) || Convert.ToDateTime(e.Row.Cells[14].Text) == DateTime.Today.AddDays(1))
            {
               e.Row.Attributes.Add("style", "background-color: #f9f595"); //amarillos
            }

        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[15].Text) == DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #afcaf7"); //azules
            }
    }

    protected void ddlgestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        String reclamosGestor = selectGeneral +
              "where ( reclamos_varios.id_gestor = " + ddlgestor.SelectedValue + " and reclamos_varios.estado_unity = 'Seguimiento') order by reclamos_varios.fecha_visualizar";

        String Prioritarios = selectGeneral +
             " where ((reclamos_varios.prioritario = 'true') and (reclamos_varios.id_gestor = " + ddlgestor.SelectedValue + " and reclamos_varios.estado_unity = 'Seguimiento')) order by reclamos_varios.fecha_visualizar";

        String Complicados = selectGeneral +
             " where ((reclamos_varios.complicado = 'true') and (reclamos_varios.id_gestor = " + ddlgestor.SelectedValue + " and reclamos_varios.estado_unity = 'Seguimiento' )) order by reclamos_varios.fecha_visualizar";

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
        alarmas = selectGeneral + " where reclamos_varios.estado_unity = 'Seguimiento' and id_gestor = " + ddlAlarmaGestor.SelectedValue + " and " +
            " convert(date, reclamos_varios.fecha_visualizar, 112) < getdate() order by reclamos_varios.fecha_visualizar ";
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
}



