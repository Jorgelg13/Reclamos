using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.Data;

public partial class Modulos_MdReclamosUnity_wbFrmReportesMedicos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenado = new Utils();
    String Join;
    conexionBD obj = new conexionBD();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int kpiCliente = 18; //dias
    int kpiAseguradora = 15; //dias
    int kpiUnity = 72; //horas
    Double TotalReclamos, totalPromedioUsuario, totalPendientes;
    int totalNuevos, totalCerrados,pendientesFueratiempo, totalFueraTiempo;
    Double totalPromedio, totalPromedioPonderado, totalPromedioEjecucion;
    String buscar;
    //variable que contiene todos los joins que se hacen en el query del reporte
    String KPI_ASEGURADORA, KPI_CLIENTE, KPI_EJECUTIVO, KPI_EFICIENCIA;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            listas();
            checkSinFiltro.Checked = true;
            checkSinFiltro_CheckedChanged(sender, e);
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }

        //if (userlogin == "jlaj" || userlogin == "jwiesner" || userlogin == "jflores" || userlogin == "lteo" || userlogin == "kmejia")
        //{
        //    btnMostrarEficiencia.Visible = true;
        //}

        //variable que contiene todos los joins que se hacen en el query del reporte
        Join = " FROM " +
          " dbo.reg_reclamos_medicos as reg " +
          "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id " +
          "INNER JOIN estado on r.id_estado = estado.id ";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccio

        if (checkSinFiltro.Checked)
        {
            string listado;
            listado = "Select r.id, ";
            //recorre la lista de checks que seleccionaron para generar el reporte
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }
            //si seleccionarion cerrado ejecuta este query 
            if (ddlEstado.SelectedItem.Text == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where (Convert(date,r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' " +
                    "and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue+ ") and ("+ddlMoneda.SelectedValue+") and r.estado_unity = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,r.fecha_commit,112) between '" + txtFechaInicio.Text + "' and  '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") " +
                " and (" + ddlMoneda.SelectedValue + ") and r.estado_unity = 'Seguimiento' " +
                "", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,r.fecha_commit,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") " +
                " and (" + ddlMoneda.SelectedValue + ") and r.estado_unity in ('Seguimiento', 'Cerrado') ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Aperturados")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (Convert(date,r.fecha_apertura, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") " +
                  " and (" + ddlMoneda.SelectedValue + ") and (r.estado_unity = 'Seguimiento') ", GridCamposSeleccion);
                Conteo();
            }
        }

        else
        {
            if (ddlElegir.SelectedItem.Text == "Usuario" || ddlElegir.SelectedItem.Text == "Aseguradora")
            {
                buscar = ddlBuscar.SelectedValue;
            }
            else
            {
                buscar = txtBuscar.Text;
            }

            string listado;
            listado = "Select r.id, ";
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }

            if (ddlEstado.SelectedItem.Text == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert( date,r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' " +
                  "and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlMoneda.SelectedValue + ") and r.estado_unity = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (Convert(date,r.fecha_commit,112) between '" + txtFechaInicio.Text + "' and '"+txtFechaFin.Text+"') " +
                  "and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlMoneda.SelectedValue + ") and r.estado_unity = 'Seguimiento' ", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and ( Convert(date,r.fecha_commit, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')" +
                  " and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlMoneda.SelectedValue + ") and (r.estado_unity in ('Cerrado','Seguimiento')) ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Aperturados")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and ( Convert(date,r.fecha_apertura, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                  "and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlMoneda.SelectedValue + ") and (r.estado_unity = 'Seguimiento') ", GridCamposSeleccion);
                Conteo();
            }
        }

        Utils.actividades(0, Constantes.DANIOS(), 29, Constantes.USER());
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.actividades(0, Constantes.DANIOS(), 35, Constantes.USER());
        Utils.ExportarExcel(GridCamposSeleccion, Response, "Reporte Gastos Medicos");
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void checkSinFiltro_CheckedChanged(object sender, EventArgs e)
    {
        if (checkSinFiltro.Checked)
        {
            txtBuscar.Enabled = false;
            ddlElegir.Enabled = false;
            ddlBuscar.Enabled = false;
        }
        else
        {
            txtBuscar.Enabled = true;
            ddlElegir.Enabled = true;
            ddlBuscar.Enabled = true;
        }
    }

    protected void CheckTodos_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckTodos.Checked)
        {
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (!checkCampos.Items[i].Selected)
                {
                    checkCampos.Items[i].Selected = true;
                }
            }
        }

        else
        {
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    checkCampos.Items[i].Selected = false;
                }
            }
        }
    }

    //ciclos para medir tiempos de la aseguradora
    public void CicloAseguradora()
    {
        if (ddlTipoReclamo.SelectedItem.Text == "Colectivos")
        {
            kpiAseguradora = ddlMoneda.SelectedItem.Text == "Dolares" ? 35 : 11;
        }

        else if (ddlTipoReclamo.SelectedItem.Text == "Individual")
        {
            kpiAseguradora = ddlMoneda.SelectedItem.Text == "Dolares" ? 35 : 15;
        }

        string promedio_aseguradora = "select " +
             "count(*) total_reclamos," +
             "reg.aseguradora, " +
             "promedio_dias = cast(AVG(dbo.FN_DIAS_HABILES(r.fecha_envio_aseg, r.fecha_recepcion_cheque)* (1.0)) as decimal(5,2))" +
             "into #cicloAseguradora " +
             "from reclamos_medicos as r " +
             "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
             "where r.estado_unity = 'Cerrado' and (Convert(date,r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
             "and (" + ddlTipoReclamo.SelectedValue + " ) and (" + ddlMoneda.SelectedValue + ") group by reg.aseguradora " +
             "select " +
             "aseguradora as Aseguradora, " +
             "total_reclamos as [Total_Reclamos], " +
             "ISNULL(promedio_dias, 0) as [Promedio_Dias], " +
             "ISNULL(total_reclamos * promedio_dias, 0) as [Promedio_Ponderado], " +
             "case when(ISNULL(promedio_dias, 0)) = 0 then 0 else cast((" + kpiAseguradora + " / (promedio_dias * 1.0)) * 100 as decimal) end as Ejecucion " +
             "from #cicloAseguradora ORDER BY [Promedio_Dias]";


        llenado.llenarGrid(promedio_aseguradora, GridPromedioAseguradora);
    }

    //ciclo de cliente o ciclo total
    public void CicloCliente()
    {

        if (ddlTipoReclamo.SelectedItem.Text == "Colectivos")
        {
            kpiCliente = ddlMoneda.SelectedItem.Text == "Dolares" ? 38 : 15;
        }

        if (ddlTipoReclamo.SelectedItem.Text == "Individual")
        {
            kpiCliente = ddlMoneda.SelectedItem.Text == "Dolares" ? 38 : 18;
        }

        string ciclo_cliente = "select " +
             "count(*) as total_reclamos, " +
             "promedio = cast(AVG(dbo.FN_DIAS_HABILES(r.fecha_completa_commit, r.fecha_cierre) *(1.0)) as decimal(5,2)), " +
             "reg.aseguradora as Aseguradora " +
             "into #cicloCliente " +
             "from reclamos_medicos as r " +
             "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
             "where (r.estado_unity = 'Cerrado') and ( Convert(date,r.fecha_cierre,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
             "and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlMoneda.SelectedValue + ") group by reg.aseguradora " +
             "update #cicloCliente set promedio = 1 where promedio = 0.00"+
             "select " +
             "Aseguradora, " +
             "total_reclamos as Total_Reclamos," +
             "promedio as Promedio_Dias, " +
             "isnull(total_reclamos * promedio, 0) as Promedio_Ponderado," +
             "case when(isnull(total_reclamos, 0)) = 0 then 0 else cast((" + kpiCliente + " / (promedio * 1.0)) * 100 as decimal) end as Ejecucion " +
             "from #cicloCliente order by Promedio_Dias";

        llenado.llenarGrid(ciclo_cliente, GridCicloCliente);
    }
    //ciclo del ejecutivo o ciclo UNITY....
    public void cicloEjecutivoKPI()
    {
        if(ddlTipoReclamo.SelectedItem.Text == "Colectivos")
        {
            kpiUnity = 35;
        }

        string ejecutivoKPI = "select count(*) total_reclamos, " +
            "AVG(((dbo.FN_DIAS_HABILES(r.fecha_completa_commit, r.fecha_cierre) - dbo.FN_DIAS_HABILES(r.fecha_envio_aseg, isnull(r.fecha_recepcion_cheque, r.fecha_cierre ))) * 24) - DATEDIFF(HOUR, r.fecha_completa_commit, r.fecha_asignacion) ) as promedio, " +
            "r.usuario_unity " +
            "into #ciclo_ejecutivoKPI " +
            "from reclamos_medicos as r " +
            "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
            "where(r.estado_unity = 'Cerrado') and (" + ddlMoneda.SelectedValue + ") and (Convert(date, r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
            "and(" + ddlTipoReclamo.SelectedValue + ") group by r.usuario_unity " +
            " select usuario_unity as Usuario, total_reclamos as Total_Reclamos , " +
            " abs(isnull(promedio, 1)) as Promedio_usuario, " +
            " abs(cast(("+kpiUnity+" / ((case when promedio = 0 then 1 " +
            " when promedio is NULL then 1 else promedio end) * 1.0) ) *100 as decimal)) as Ejecucion " +
            " from #ciclo_ejecutivoKPI";

        llenado.llenarGrid(ejecutivoKPI, GridEjecutivosKPI);
    }

    //ciclos del ejecutivo desde la apertura al cierre
    public void CicloEjecutivo()
    {
        string cicloEjecutivo = "select count(*) total_reclamos, promedio = AVG(DATEDIFF(minute, r.fecha_completa_commit, r.fecha_asignacion)), " +
            "promedio_segundos = AVG(DATEDIFF(second, r.fecha_completa_commit, r.fecha_asignacion)), " +
            "r.usuario_unity " +
            "into #ciclo_ejecutivo " +
            "from reclamos_medicos as r " +
            "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
            "where(r.estado_unity = 'Cerrado') and (Convert(date, r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
            "and(" +ddlTipoReclamo.SelectedValue+ ") and (" + ddlMoneda.SelectedValue + ") group by r.usuario_unity " +
            "select " +
            "CONCAT(promedio / 60, ':', promedio % 60, ':', promedio_segundos % 60) as [Promedio usuario], " +
            "total_reclamos as Total_Reclamos,"+
            "usuario_unity AS Usuario from #ciclo_ejecutivo";

        string AsignacionApertura = "select count(*) total_reclamos," +
            "promedio_minutos = AVG(DATEDIFF(minute, r.fecha_asignacion, r.fecha_apertura))," +
            "promedio_segundos = AVG(DATEDIFF(SECOND, r.fecha_asignacion, r.fecha_apertura))," +
            "r.usuario_unity " +
            "into #ciclo_ejecutivo2 " +
            "from reclamos_medicos as r " +
            "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
            "where(r.estado_unity = 'Cerrado') and (Convert(date,r.fecha_cierre,112) between '" + txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"') " +
            " and (" + ddlMoneda.SelectedValue + ") and (" + ddlTipoReclamo.SelectedValue+ ") group by r.usuario_unity " +
            "select CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as Promedio_usuario,total_reclamos as Total_Reclamos, usuario_unity as Usuario from #ciclo_ejecutivo2";

        string AperturaAseguradora = "select " +
            "count(*) total_reclamos," +
            "promedio_minutos  = AVG(DATEDIFF(minute, r.fecha_apertura, r.fecha_envio_aseg))," +
            "promedio_segundos = AVG(DATEDIFF(SECOND, r.fecha_apertura, r.fecha_envio_aseg))," +
            "r.usuario_unity " +
            "into #ciclo_ejecutivo3 " +
            "from reclamos_medicos as r " +
            "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
            "where(r.estado_unity = 'Cerrado') and (Convert(date,r.fecha_cierre, 112) between '" + txtFechaInicio.Text+"' and '"+txtFechaFin.Text+ "') " +
            " and (" + ddlMoneda.SelectedValue + ") and (" + ddlTipoReclamo.SelectedValue+ ") group by r.usuario_unity " +
            "select " +
            "CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as Promedio_usuario," +
            "total_reclamos as Total_Reclamos, usuario_unity as Usuario from #ciclo_ejecutivo3";

        string recepcionChequeCierre = "select " +
           "count(*) total_reclamos," +
           "promedio_minutos  = AVG(DATEDIFF(MINUTE, r.fecha_recepcion_cheque, r.fecha_cierre))," +
           "promedio_segundos = AVG(DATEDIFF(SECOND, r.fecha_recepcion_cheque, r.fecha_cierre))," +
           "r.usuario_unity " +
           "into #ciclo_ejecutivo3 " +
           "from reclamos_medicos as r " +
           "inner join reg_reclamos_medicos as reg on reg.id = r.id_reg_reclamos_medicos " +
           "where(r.estado_unity = 'Cerrado') and (Convert(date,r.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
           " and (" + ddlMoneda.SelectedValue + ") and (" + ddlTipoReclamo.SelectedValue + ") group by r.usuario_unity " +
           "select " +
           "CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as [Promedio_usuario]," +
           "total_reclamos as Total_Reclamos, usuario_unity as Usuario from #ciclo_ejecutivo3";

        llenado.llenarGrid(cicloEjecutivo, GridCicloEjecutivo);
        llenado.llenarGrid(AsignacionApertura, GridCicloAsignacionApertura);
        llenado.llenarGrid(AperturaAseguradora, GridAperturaAseguradora);
        llenado.llenarGrid(recepcionChequeCierre, GridRecepcionChequeCierre);
    }

    //ciclos para mostrar o no los reportes
    protected void linKRegresar_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PnReporte.Visible = true;
        PnCicloAseguradora.Visible = false;
        PnCicloCliente.Visible = false;
        PnCicloEjecutivo.Visible = false;
        PnCicloEjecutivoKPI.Visible = false;
        PnEficiencia.Visible = false;
    }

    protected void linkDescarExcel_Click(object sender, EventArgs e)
    {
        if(PnCicloAseguradora.Visible == true)
        {
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 37, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Ciclo Aseguradora");
        }

        else if (PnCicloCliente.Visible == true)
        {
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 38, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Ciclo Cliente");
        }

        else if (PnCicloEjecutivoKPI.Visible == true)
        {
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 39, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Ciclo Ejecutivo");
        }

        else if (PnEficiencia.Visible == true)
        {
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 36, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Eficiencia");
        }

        else if (PnCicloEjecutivo.Visible == true)
        {
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Ciclo Ejecutivo por etapas");
        }
    }

    //funcion para realizar una sumatoria y colocar el total en la parte de abajo del grid

    protected void GridPromedioAseguradora_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalReclamos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                totalPromedio += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
                totalPromedioPonderado += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio_ponderado]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (totalPromedioPonderado / TotalReclamos).ToString("N2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = totalPromedioPonderado.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = (kpiAseguradora / (totalPromedioPonderado / TotalReclamos) * 100).ToString("N2");
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridCicloCliente_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalReclamos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                totalPromedio += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
                totalPromedioPonderado += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio_ponderado]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (totalPromedioPonderado / TotalReclamos).ToString("N2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = totalPromedioPonderado.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = (kpiCliente / (totalPromedioPonderado / TotalReclamos) * 100).ToString("N2");
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }

    }

    protected void GridEjecutivosKPI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalReclamos          += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                totalPromedioUsuario   += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio_usuario]"));
                totalPromedioEjecucion += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Ejecucion]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (totalPromedioUsuario / GridEjecutivosKPI.Rows.Count).ToString("N");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = ((kpiUnity / (totalPromedioUsuario / GridEjecutivosKPI.Rows.Count)) * 100).ToString("N");
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;

                e.Row.Font.Bold = true;
            }
        }
        catch (Exception)
        {
           // Response.Write(err);
        }
    }

    protected void GridEficiencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalPendientes += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Pendientes]"));
                totalNuevos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Nuevos]"));
                totalCerrados += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Cerrados]"));
                pendientesFueratiempo += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Pendientes_fuera_tiempo]"));
                totalFueraTiempo += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Cerrados_fuera_tiempo]"));
                totalPromedioEjecucion += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Ejecucion]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = totalPendientes.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = totalNuevos.ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = totalCerrados.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = pendientesFueratiempo.ToString();
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[5].Text = totalFueraTiempo.ToString();
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[6].Text = ((1 - (Convert.ToDouble(totalFueraTiempo) / Convert.ToDouble(totalCerrados) )) * 100).ToString("N2");
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[7].Text = ((1 - (Convert.ToDouble(pendientesFueratiempo) / Convert.ToDouble(totalPendientes))) * 100).ToString("N2");
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception)
        {
            // Response.Write(err);
        }
    }

    public void listas()
    {
        if(ddlElegir.SelectedItem.Text == "Usuario")
        {
            ddlBuscar.DataSource = DBReclamos.gestores.ToList().Where(ge => ge.tipo == "Medicos").OrderBy(ges => ges.nombre);
            ddlBuscar.DataValueField = "usuario";
            ddlBuscar.DataTextField = "nombre";
            ddlBuscar.DataBind();
        }

        if (ddlElegir.SelectedItem.Text == "Aseguradora")
        {
            ddlBuscar.DataSource = DBReclamos.aseguradoras.ToList();
            ddlBuscar.DataTextField = "aseguradora";
            ddlBuscar.DataValueField = "aseguradora";
            ddlBuscar.DataBind();
        }
    }

    protected void ddlElegir_SelectedIndexChanged(object sender, EventArgs e)
    {
        listas();
        if (ddlElegir.SelectedItem.Text == "Usuario" || ddlElegir.SelectedItem.Text == "Aseguradora")
        {
            txtBuscar.Visible = false;
            ddlBuscar.Visible = true;
        }
        else
        {
            ddlBuscar.Visible = false;
            txtBuscar.Visible = true;
        }
    }

    protected void Mostrar_Click(object sender, EventArgs e)
    {
        if (ddlCiclos.SelectedValue == "Ciclo Aseguradora")
        {
            CicloAseguradora();
            KPI_ASEGURADORA = "KPI Aseguradora " + kpiAseguradora.ToString() + " Dias";
            TituloReporte("Promedio Ciclo Aseguradora", KPI_ASEGURADORA, ddlMoneda.SelectedItem.Text);
            PnReporte.Visible = false;
            PnCicloAseguradora.Visible = true;
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 32, Constantes.USER());
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Cliente")
        {
            CicloCliente();
            KPI_CLIENTE = "KPI Cliente " + kpiCliente.ToString() + " Dias";
            TituloReporte("Promedio Ciclo Total", KPI_CLIENTE, ddlMoneda.SelectedItem.Text);
            PnReporte.Visible = false;
            PnCicloCliente.Visible = true;
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 33, Constantes.USER());
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Ejecutivo")
        {
            cicloEjecutivoKPI();
            KPI_EJECUTIVO = "KPI Ejecutivo " + kpiUnity.ToString() + " Horas";
            TituloReporte("Promedio Ciclo Ejecutivo", KPI_EJECUTIVO, ddlMoneda.SelectedItem.Text);
            PnReporte.Visible = false;
            PnCicloEjecutivoKPI.Visible = true;
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 31, Constantes.USER());
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Ejecutivo por etapa")
        {
            CicloEjecutivo();
            TituloReporte("Promedio Ciclo Ejecutivo por etapas", "", ddlMoneda.SelectedItem.Text);
            PnReporte.Visible = false;
            PnCicloEjecutivo.Visible = true;
            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 32, Constantes.USER());
        }
    }

    public void TituloReporte(String Titulo, String KPI, String Moneda)
    {   
        try
        {
            PanelPrincipal.Visible = true;
            lblPeriodo.Text = "Periodo del " + Convert.ToDateTime(txtFechaInicio.Text).ToString("dd/MM/yyyy") + " al " + Convert.ToDateTime(txtFechaFin.Text).ToString("dd/MM/yyyy");
            lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString();
            lblUsuario.Text = "Usuario: " + userlogin;
            lblTitulo.Text = Titulo;
            lblKpi.Text = KPI;
            lblMoneda.Text = "Moneda: " + Moneda;
        }
        catch(Exception)
        {
            
        }
    }

    protected void btnEficiencia_Click(object sender, EventArgs e)
    {
        if (ddlTipoReclamo.SelectedItem.Text == "Individual")
        {
            KPI_EFICIENCIA = "Eficiencia evaluada sobre el 80%";
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_eficiencia_individuales", GridEficiencia);
        }

        else
        {
            KPI_EFICIENCIA = "Eficiencia evaluada sobre el 85%";
            Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_eficiencia_colectivos", GridEficiencia);
        }

        TituloReporte("Eficiencia Usuarios", KPI_EFICIENCIA, ddlMoneda.SelectedItem.Text);
        PnReporte.Visible = false;
        PnEficiencia.Visible = true;
        Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 30, Constantes.USER());
    }
}