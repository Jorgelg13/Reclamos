﻿using System;
using System.Web.UI;
using System.IO;
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
    int kpiCliente = 17;
    int kpiAseguradora = 15;
    int kpiUnity = 48;
    int TotalReclamos;
    double totalPromedio, totalPromedioPonderado, totalPromedioEjecucion;
    String buscar, eficienciaGestores;
    String tipo_reclamo = "I";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            listas();
            checkSinFiltro.Checked = true;
            checkSinFiltro_CheckedChanged(sender, e);
        }

        //if (userlogin == "jlaj" || userlogin == "jwiesner" || userlogin == "jflores" || userlogin == "lteo" || userlogin == "kmejia")
        //{
        //    btnMostrarEficiencia.Visible = true;
        //}

        eficienciaGestores = "select rs.nombre,rs.Pendientes,rs.Nuevos,rs.Cerrados, " +
            "CAST(cast((rs.Cerrados * 100) / ((rs.Pendientes * 1.0) + nuevos) as float) as varchar) + '%' as Ejecucion from " +
            "(select r.nombre, Pendientes = (select COUNT(*) from reclamos_medicos where estado_unity = 'Seguimiento' and usuario_unity = r.usuario) ," +
            "Nuevos = (select COUNT(*) from reclamos_medicos where Convert(date, fecha_apertura, 112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and usuario_unity = r.usuario), " +
            "Cerrados = (select COUNT(*) from reclamos_medicos where Convert(date, fecha_cierre, 112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and estado_unity = 'Cerrado' and usuario_unity = r.usuario) " +
            "from (select id, usuario, nombre from gestores where tipo = 'medicos') as r) rs where rs.Pendientes != 0 order by Ejecucion desc";

        //variable que contiene todos los joins que se hacen en el query del reporte
        lblKpiAseguradora.Text = "KPI Aseguradora " + kpiAseguradora.ToString() + " Dias";
        lblKpiCliente.Text = "KPI Cliente " + kpiCliente.ToString() + " Dias";
        lblEjecutivoKpi.Text = "KPI Ejecutivo " + kpiUnity.ToString() + " Horas";
        Join = " FROM " +
          " dbo.reg_reclamos_medicos " +
          "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
          "INNER JOIN dbo.estado on dbo.reclamos_medicos.id_estado = dbo.estado.id ";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccion
        
        if (checkSinFiltro.Checked)
        {
            string listado;
            listado = "Select reclamos_medicos.id, ";
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
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue+ ") and reclamos_medicos.estado_unity = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,reclamos_medicos.fecha_commit,112) between '" + txtFechaInicio.Text + "' and  '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and reclamos_medicos.estado_unity = 'Seguimiento' " +
                "", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,reclamos_medicos.fecha_commit,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and (" +ddlEstado.SelectedValue+ ") ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Aperturados")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (Convert(date,reclamos_medicos.fecha_apertura, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and (reclamos_medicos.estado_unity = 'Seguimiento') ", GridCamposSeleccion);
                Conteo();
            }
        }

        else
        {

            if (ddlElegir.SelectedItem.Text == "Usuario")
            {
                buscar = ddlBuscar.SelectedValue;
            }
            else
            {
                buscar = txtBuscar.Text;
            }

            string listado;
            listado = "Select reclamos_medicos.id, ";
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
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert( date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and reclamos_medicos.estado_unity = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (Convert(date,reclamos_medicos.fecha_commit,112) between '" + txtFechaInicio.Text + "' and '"+txtFechaFin.Text+"') and (" + ddlTipoReclamo.SelectedValue + ") and reclamos_medicos.estado_unity = 'Seguimiento' ", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and ( Convert(date,reclamos_medicos.fecha_commit, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and (" + ddlEstado.SelectedValue + ") ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Aperturados")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and ( Convert(date,reclamos_medicos.fecha_apertura, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") and (reclamos_medicos.estado_unity = 'Seguimiento') ", GridCamposSeleccion);
                Conteo();
            }
        }
    }

    public void Eficiencia()
    {
        llenado.llenarGrid(eficienciaGestores, GridEficiencia);
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridCamposSeleccion, Response, "Reporte_gastos_medicos");
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx");
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

    //ciclos para medir tiempos
    public void CicloAseguradora()
    {
        string promedio_aseguradora = "select " +
            "count(*) total_reclamos," +
            "reg_reclamos_medicos.aseguradora, " +
            "promedio_dias = cast(AVG(DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg, reclamos_medicos.fecha_recepcion_cheque)* (1.0) / 60 / 24) as decimal(5,2))" +
            "into #cicloAseguradora " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where(reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + " ) group by reg_reclamos_medicos.aseguradora " +
            "select " +
            "aseguradora as Aseguradora, " +
            "total_reclamos as [Total_Reclamos], " +
            "ISNULL(promedio_dias, 0) as [Promedio_Dias], " +
            "ISNULL(total_reclamos * promedio_dias, 0) as [Promedio_Ponderado], " +
            "case when(ISNULL(promedio_dias, 0)) = 0 then 0 else cast((" + kpiAseguradora + " / (promedio_dias * 1.0)) * 100 as decimal(5, 2)) end as Ejecucion " +
            "from #cicloAseguradora ORDER BY [Promedio_Dias]";

        llenado.llenarGrid(promedio_aseguradora, GridPromedioAseguradora);
    }

    public void CicloCliente()
    {
        string ciclo_cliente = "select " +
            "count(*) as total_reclamos, " +
            "promedio = cast(AVG(DATEDIFF(minute, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre) *(1.0) / 60 / 24) as decimal(5,2)), " +
            "reg_reclamos_medicos.aseguradora as Aseguradora " +
            "into #cicloCliente " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where (reclamos_medicos.estado_unity = 'Cerrado') and ( Convert(date,reclamos_medicos.fecha_cierre,112) between '" +txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"') and (" + ddlTipoReclamo.SelectedValue + ") group by reg_reclamos_medicos.aseguradora " +
            "select " +
            "Aseguradora, " +
            "total_reclamos as Total_Reclamos," +
            "promedio as Promedio_Dias, " +
            "isnull(total_reclamos * promedio, 0) as Promedio_Ponderado," +
            "case when(isnull(total_reclamos, 0)) = 0 then 0 else cast(("+kpiCliente+" / (promedio * 1.0)) * 100 as decimal) end as Ejecucion " +
            "from #cicloCliente order by Promedio_Dias";

        llenado.llenarGrid(ciclo_cliente, GridCicloCliente);
    }

    public void cicloEjecutivoKPI()
    {
        if(ddlTipoReclamo.SelectedItem.Text == "Colectivos")
        {
            kpiUnity = 72;
        }

        string ejecutivoKPI = "select " +
            "count(*) total_reclamos," +
            "sum(DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre) - DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg, reclamos_medicos.fecha_recepcion_cheque)) as total_resta," +
            "AVG(DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre) - DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg, reclamos_medicos.fecha_recepcion_cheque)) as promedio, " +
            "promedio_segundos = AVG(DATEDIFF(SECOND, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre) - DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg, reclamos_medicos.fecha_recepcion_cheque)), " +
            "reclamos_medicos.usuario_unity " +
            "into #ciclo_ejecutivoKPI " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where(reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ")  group by reclamos_medicos.usuario_unity " +
            "select " +
            "usuario_unity as Usuario, " +
            "total_reclamos as Total_Reclamos," +
            "CONCAT( " +
            "promedio / 60, ':', " +
            "promedio % 60, ':', " +
            "promedio_segundos % 60) as [Promedio por usuario], " +
            "case when(isnull(total_reclamos, 0)) = 0 then 0 else ROUND( cast( ("+kpiUnity+" / ( (promedio / 60.0) * 1.0)) * 100 as float ),2,0) end as Ejecucion " +
            "from #ciclo_ejecutivoKPI";

        llenado.llenarGrid(ejecutivoKPI, GridEjecutivosKPI);
        lblEjecutivoKpi.Text = "KPI Ejecutivo " + kpiUnity.ToString() + " Horas";
    }

    public void CicloEjecutivo()
    {
        string cicloEjecutivo = "select count(*) total_reclamos," +
            "sum(DATEDIFF(minute, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_asignacion)) as minutos," +
            "promedio = AVG(DATEDIFF(minute,reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_asignacion)), " +
            "promedio_segundos = AVG(DATEDIFF(second, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_asignacion))," +
            "reclamos_medicos.usuario_unity " +
            "into #ciclo_ejecutivo " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where (reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"') and (" +ddlTipoReclamo.SelectedValue+ ") group by reclamos_medicos.usuario_unity " +
            "select CONCAT('0' + ':', promedio % 60, ':', promedio_segundos % 60) as [Promedio por usuario] ,total_reclamos as [Total R.], usuario_unity AS Usuario from #ciclo_ejecutivo";

        string AsignacionApertura = "select count(*) total_reclamos," +
            "sum(DATEDIFF(MINUTE, reclamos_medicos.fecha_asignacion, reclamos_medicos.fecha_apertura)) as minutos," +
            "promedio_minutos = AVG(DATEDIFF(minute, reclamos_medicos.fecha_asignacion, reclamos_medicos.fecha_apertura))," +
            "promedio_segundos = AVG(DATEDIFF(SECOND, reclamos_medicos.fecha_asignacion, reclamos_medicos.fecha_apertura))," +
            "reclamos_medicos.usuario_unity " +
            "into #ciclo_ejecutivo2 " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where(reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre,112) between '" + txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"') and (" +ddlTipoReclamo.SelectedValue+ ") group by reclamos_medicos.usuario_unity " +
            "select CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as [Promedio por usuario] ,total_reclamos as [Total R.], usuario_unity as Usuario from #ciclo_ejecutivo2";

        string AperturaAseguradora = "select " +
            "count(*) total_reclamos," +
            "sum(DATEDIFF(MINUTE, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg)) as minutos," +
            "AVG(isnull(DATEDIFF(minute, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg), 0)) as promedio_minutos," +
            "promedio_segundos = AVG(DATEDIFF(SECOND, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg))," +
            "reclamos_medicos.usuario_unity " +
            "into #ciclo_ejecutivo3 " +
            "from reclamos_medicos " +
            "inner join reg_reclamos_medicos  on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
            "where(reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text+"' and '"+txtFechaFin.Text+ "') and (" +ddlTipoReclamo.SelectedValue+ ") group by reclamos_medicos.usuario_unity " +
            "select " +
            "CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as [Promedio por usuario]," +
            "total_reclamos as [Total R.], usuario_unity as Usuario from #ciclo_ejecutivo3";

        string recepcionChequeCierre = "select " +
           "count(*) total_reclamos," +
           "sum(DATEDIFF(MINUTE, reclamos_medicos.fecha_recepcion_cheque, reclamos_medicos.fecha_cierre)) as minutos," +
           "AVG(isnull(DATEDIFF(MINUTE, reclamos_medicos.fecha_recepcion_cheque, reclamos_medicos.fecha_cierre), 0)) as promedio_minutos," +
           "promedio_segundos = AVG(DATEDIFF(SECOND, reclamos_medicos.fecha_recepcion_cheque, reclamos_medicos.fecha_cierre))," +
           "reclamos_medicos.usuario_unity " +
           "into #ciclo_ejecutivo3 " +
           "from reclamos_medicos " +
           "inner join reg_reclamos_medicos  on reg_reclamos_medicos.id = reclamos_medicos.id_reg_reclamos_medicos " +
           "where(reclamos_medicos.estado_unity = 'Cerrado') and (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (" + ddlTipoReclamo.SelectedValue + ") group by reclamos_medicos.usuario_unity " +
           "select " +
           "CONCAT(promedio_minutos / 60, ':', promedio_minutos % 60, ':', promedio_segundos % 60) as [Promedio por usuario]," +
           "total_reclamos as [Total R.], usuario_unity as Usuario from #ciclo_ejecutivo3";

        llenado.llenarGrid(cicloEjecutivo, GridCicloEjecutivo);
        llenado.llenarGrid(AsignacionApertura, GridCicloAsignacionApertura);
        llenado.llenarGrid(AperturaAseguradora, GridAperturaAseguradora);
        llenado.llenarGrid(recepcionChequeCierre, GridRecepcionChequeCierre);
    }

    //ciclos para mostrar o no los reportes
    protected void linKRegresar_Click(object sender, EventArgs e)
    {
        PnReporte.Visible = true;
        PnCicloAseguradora.Visible = false;
        PnCicloCliente.Visible = false;
        PnCicloEjecutivo.Visible = false;
        PnCicloEjecutivoKPI.Visible = false;
    }

    //exportar reportes a excel
    protected void LinkCicloCliente_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridCicloCliente,Response, "Reporte Ciclo Cliente");
    }

    protected void linkDescarPromedio_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridPromedioAseguradora,Response, "Reporte Ciclo Aseguradora");
    }

    protected void linkCicloEjecutivo_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnCicloEjecutivo, Response, "Ciclos Ejecutivos");
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

                e.Row.Cells[2].Text =  (totalPromedioPonderado / TotalReclamos).ToString("N2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = totalPromedioPonderado.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = (kpiAseguradora / (totalPromedioPonderado / TotalReclamos) *100).ToString("N2") + "%";
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

                e.Row.Cells[4].Text = (kpiAseguradora / (totalPromedioPonderado / TotalReclamos) * 100).ToString("N2") + "%";
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
                TotalReclamos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                totalPromedioEjecucion += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Ejecucion]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = (kpiUnity / (totalPromedioEjecucion / TotalReclamos) * 100).ToString("N2") + "%";
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
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
            ddlBuscar.DataValueField = "codigo";
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

    protected void btnExportarEficiencia_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridEficiencia, Response,"Eficiencia Reclamos Medicos"); 
    }

    protected void Mostrar_Click(object sender, EventArgs e)
    {
        if (ddlCiclos.SelectedValue == "Ciclo Aseguradora")
        {
            CicloAseguradora();
            PnReporte.Visible = false;
            PnCicloAseguradora.Visible = true;
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Cliente")
        {
            CicloCliente();
            PnReporte.Visible = false;
            PnCicloCliente.Visible = true;
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Ejecutivo")
        {
            cicloEjecutivoKPI();
            PnReporte.Visible = false;
            PnCicloEjecutivoKPI.Visible = true;
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Ejecutivo por etapa")
        {
            CicloEjecutivo();
            PnReporte.Visible = false;
            PnCicloEjecutivo.Visible = true;
        }

        else if (ddlCiclos.SelectedValue == "Eficiencia")
        {
            Eficiencia();
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalDetalle').modal('show');", addScriptTags: true);
        }
    }
}