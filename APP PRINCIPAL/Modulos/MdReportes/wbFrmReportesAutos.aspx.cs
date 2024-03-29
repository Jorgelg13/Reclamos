﻿using System;
using System.Web.UI;
using System.Data;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmReportesAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    conexionBD obj = new conexionBD();
    String buscar, Join, eficienciaGestores;
    int Total, Promedio, EjecucionCiclos, kpi, kpiImportacion;
    int Total2, Promedio2, EjecucionCiclos2;
    Double Pendientes, Nuevos, Cerrados, Congelados, Ejecucion, CCIFT, CSIFT,PCIFT,PSIFT,EficienciaCierre,Anejamiento;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkSinFiltro_CheckedChanged(sender, e);
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }

        if (userlogin == "jmorales" || userlogin == "hosoy" || userlogin == "nmelgar" || userlogin == "jlaj" || userlogin == "jwiesner" || userlogin == "sgordillo " ||
            userlogin == "nsierra" || userlogin =="cmejia" || userlogin == "hvillacinda" || userlogin == "lgarcia" || userlogin == "mguillen")
        {
            btnMostrarEficiencia.Visible = true;
        }

        else
        {
            btnMostrarEficiencia.Visible = false;
        }

        eficienciaGestores = "select " +
            "rs.nombre as Usuario, " +
            "rs.Pendientes, " +
            "rs.Nuevos, " +
            "rs.Cerrados , " +
            "CAST(cast((rs.Cerrados * 100) / (rs.Pendientes + nuevos) as decimal) as varchar)  as Ejecucion " +
            "from(select r.nombre, " +
            "Pendientes = (select COUNT(*) from reclamo_auto where estado_unity = 'Seguimiento' and id_gestor = r.id)," +
            "Nuevos = (select COUNT(*) from reclamo_auto where convert(date, fecha_apertura_reclamo,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and id_gestor = r.id), " +
            "Cerrados = (select COUNT(*) from reclamo_auto where convert(date, fecha_cierre_reclamo,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and estado_unity = 'Cerrado' and id_gestor = r.id) " +
            "from(select id, usuario, nombre from gestores where tipo = 'autos') as r)  rs where Pendientes !=0";

        //variable que contiene todos los joins que se hacen en el query del reporte
        Join = " from auto_reclamo" +
                  " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
                  " INNER JOIN gestores on reclamo_auto.id_gestor = gestores.id" +
                  " INNER JOIN talleres on reclamo_auto.id_taller = talleres.id" +
                  " INNER JOIN analistas on reclamo_auto.id_analista = analistas.id " +
                  " LEFT JOIN contacto_auto on reclamo_auto.id = contacto_auto.id_reclamo_auto " +
                  " lEFT JOIN motivos_cierre as m on m.id = reclamo_auto.id_motivo_cierre " +
                  " INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
                  " INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
                  " INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
                  " INNER JOIN pais ON empresa.id_pais = pais.id " +
                  " INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        PanelCamposSeleccion.Visible = true;
        PanelEficiencia.Visible = false;
        PnCiclos.Visible = false;

        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccion
        if(checkSinFiltro.Checked)
        {
            string listado;
            listado = "Select reclamo_auto.id, ";
            //recorre la lista de checks que seleccionaron para generar el reporte
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }
            //si seleccionarion cerrado ejecuta este query 
            if(ddlEstado.SelectedItem.Text == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (convert(date, reclamo_auto.fecha_cierre_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                  "and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "') " +
                  "", GridCamposSeleccion);

                //Response.Write(listado.Substring(0, (listado.Length - 2)) + Join +
                //  " where (convert(date, reclamo_auto.fecha_cierre_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                //  "and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "') ");
            }
            else if(ddlEstado.SelectedValue == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (convert(date, reclamo_auto.fecha_apertura_reclamo, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                 "and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "') " +
                 "", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (convert(date, reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')" +
                 "", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Nuevos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (convert(date, reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')" +
                 "", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where reclamo_auto.estado_unity = 'Seguimiento'  ", GridCamposSeleccion);
            }
            Conteo();
           
        }

        else
        {
            if (ddlElegir.SelectedItem.Text == "Gestor" || ddlElegir.SelectedItem.Text == "Ejecutivo" || ddlElegir.SelectedItem.Text == "Taller" || ddlElegir.SelectedItem.Text == "Aseguradora" || ddlElegir.SelectedItem.Text =="Motivo Cierre")
            {
                if(ddlElegir.SelectedItem.Text =="Motivo Cierre")
                {
                    buscar = ddlBuscar.SelectedValue;
                }
                else
                {
                    buscar = ddlBuscar.SelectedItem.Text;
                }
            }
            else
            {
                buscar = txtBuscar.Text;
            }

            string listado;
            
            listado = "Select reclamo_auto.id, ";

            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }

            if(ddlEstado.SelectedValue == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert(date, reclamo_auto.fecha_cierre_reclamo,112) between '" + txtFechaInicio.Text + "' " +
                  "and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "')  ", GridCamposSeleccion);
            }

            else if(ddlEstado.SelectedValue == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert(date,reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' " +
                  "and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "')  ", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert(date, reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' " +
                  "and '" + txtFechaFin.Text + "')", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Nuevos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert(date,reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' " +
                  "and '" + txtFechaFin.Text + "')", GridCamposSeleccion);
            }   

            else if (ddlEstado.SelectedValue == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (estado_unity = 'Seguimiento' ) and " +
                  "(convert(date, reclamo_auto.fecha_apertura_reclamo,112) <= '"+txtFechaInicio.Text+"') ", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedValue == "Estado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + ddlBuscar.SelectedItem.Text + "%') and (estado_unity = 'Seguimiento') ", GridCamposSeleccion);

                Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos / Depto. Reclamos Autos / "+ ddlBuscar.SelectedItem.Text +" ", userlogin, txtFechaInicio, txtFechaFin, "");
            }
            Conteo();
        }

        if (ddlEstado.SelectedValue != "Estado")
        {
            Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Reclamos de Autos", userlogin, txtFechaInicio, txtFechaFin, "");
        }

        Utils.actividades(0, Constantes.AUTOS(), 29, Constantes.USER());
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if(PanelCamposSeleccion.Visible == true)
        {
            Utils.actividades(0, Constantes.AUTOS(), 35, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Reclamos Autos");
        }
        
        else if (PanelEficiencia.Visible == true)
        {
            Utils.actividades(0, Constantes.AUTOS(), 36, Constantes.USER());
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte de Eficiencia");
        }

        else if (PnCiclos.Visible == true)
        {
            if(ddlCiclos.SelectedValue == "Ciclo Total")
            {
               Utils.actividades(0, Constantes.AUTOS(), 40, Constantes.USER());
            }

            else if (ddlCiclos.SelectedValue == "Ciclo Unity")
            {
                Utils.actividades(0, Constantes.AUTOS(), 39, Constantes.USER());
            }

            else if (ddlCiclos.SelectedValue == "Ciclo Cliente")
            {
                Utils.actividades(0, Constantes.AUTOS(), 38, Constantes.USER());
            }

            else if (ddlCiclos.SelectedValue == "Ciclo Aseguradora")
            {
                Utils.actividades(0, Constantes.AUTOS(), 37, Constantes.USER());
            }

            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte de "+ddlCiclos.SelectedValue+" ");
        }
    }

    //link para salir y ponerse en los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx", false);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    //metodo para inabilitar las cajas de texto y seleccion
    protected void checkSinFiltro_CheckedChanged(object sender, EventArgs e)
    {
        if(checkSinFiltro.Checked)
        {
            txtBuscar.Enabled = false;
            ddlElegir.Enabled = false;
        }
        else
        {
            txtBuscar.Enabled = true;
            ddlElegir.Enabled = true;
        }
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    protected void btnExportarEficiencia_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridEficiencia,Response, "Eficiencia Reclamos Autos");
    }

    public void Eficiencia()
    {
        try
        {
            PanelCamposSeleccion.Visible = false;
            PnCiclos.Visible = false;
            llenado.llenarGrid(eficienciaGestores, GridEficiencia);
            Utils.actividades(0, Constantes.AUTOS(), 30, Constantes.USER());
        }

        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido generar la eficiencia", "Nota..!", "warning");
        }
    }

    protected void ddlElegir_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBuscar.Visible = false;
        ddlBuscar.Visible = true;

        if (ddlElegir.SelectedItem.Text == "Estado Auto")
        {
            ddlBuscar.DataSource = DBReclamos.estados_reclamos_unity.ToList().Where(es => es.tipo == "auto");
            ddlBuscar.DataValueField = "id";
            ddlBuscar.DataTextField = "descripcion";
            ddlBuscar.DataBind();
        }

        else if(ddlElegir.SelectedItem.Text == "Ejecutivo")
        {
            ddlBuscar.DataSource = DBReclamos.ejecutivos.ToList();
            ddlBuscar.DataValueField = "codigo";
            ddlBuscar.DataTextField = "gestor";
            ddlBuscar.DataBind();
        }

        else if (ddlElegir.SelectedItem.Text == "Gestor")
        {
            ddlBuscar.DataSource = DBReclamos.gestores.ToList().Where(ge => ge.tipo == "autos" && ge.estado == true);
            ddlBuscar.DataValueField = "id";
            ddlBuscar.DataTextField = "nombre";
            ddlBuscar.DataBind();
        }

        else if (ddlElegir.SelectedItem.Text == "Taller")
        {
            ddlBuscar.DataSource = DBReclamos.talleres.ToList();
            ddlBuscar.DataValueField = "id";
            ddlBuscar.DataTextField = "nombre";
            ddlBuscar.DataBind();
        }

        else if (ddlElegir.SelectedItem.Text == "Aseguradora")
        {
            ddlBuscar.DataSource = DBReclamos.aseguradoras.ToList();
            ddlBuscar.DataValueField = "id";
            ddlBuscar.DataTextField = "aseguradora";
            ddlBuscar.DataBind();
        }

        else if(ddlElegir.SelectedItem.Text == "Motivo Cierre")
        {
            ddlBuscar.DataSource = DBReclamos.motivos_cierre.ToList();
            ddlBuscar.DataValueField = "id";
            ddlBuscar.DataTextField = "nombre";
            ddlBuscar.DataBind();
        }

        else
        {
            txtBuscar.Visible = true;
            ddlBuscar.Visible = false;
        }
    }

    protected void checkTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (checkTodos.Checked)
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
    //detalle para detalle de eficiencia
    protected void GridEficiencia_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Pendientes       += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Pendientes]"));
                Nuevos           += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Nuevos]"));
                Cerrados         += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Cerrados]"));
                Congelados       += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Congelados]"));
                CCIFT            += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Cerrados Con Importacion_Fuera_Tiempo]"));
                CSIFT            += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Cerrados Sin Importacion_Fuera_Tiempo]"));
                PCIFT            += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Pendientes Con Importacion_Fuera_Tiempo]"));
                PSIFT            += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Pendientes Sin Importacion_Fuera_Tiempo]"));
                EficienciaCierre += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Eficiencia Cierre]"));
                Anejamiento      += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Añejamiento]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = Pendientes.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = Nuevos.ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = Cerrados.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[4].Text = Congelados.ToString();
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[5].Text = CCIFT.ToString();
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[6].Text = CSIFT.ToString();
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[7].Text = PCIFT.ToString();
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[8].Text = PSIFT.ToString();
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[9].Text =((1- ((CCIFT + CSIFT) /Cerrados)) *100 ).ToString("N2");
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;

                e.Row.Cells[10].Text = ((1 -((PCIFT + PSIFT) / Pendientes)) * 100).ToString("N2");
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridCiclos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                Promedio += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
                EjecucionCiclos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Ejecucion"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";

                e.Row.Cells[1].Text = Total.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (Promedio / GridCiclos.Rows.Count).ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = (Convert.ToDouble(kpi) / (Promedio /GridCiclos.Rows.Count) * 100).ToString("N2");
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void GridCiclos2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Total2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Total_Reclamos]"));
                Promedio2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Promedio_dias]"));
                EjecucionCiclos2 += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Ejecucion"));

                if (Convert.ToInt32(e.Row.Cells[3].Text) >= 100)
                {
                    e.Row.Attributes.Add("style", "background-color: #8ace8e"); //verdes
                }

                if (Convert.ToInt32(e.Row.Cells[3].Text) < 90)
                {
                    e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";

                e.Row.Cells[1].Text = Total2.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (Promedio2 / GridCiclos2.Rows.Count).ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = ((Convert.ToDouble(kpi)/ (Promedio2 / GridCiclos2.Rows.Count)) *100 ).ToString("N2");
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    protected void Mostrar_Click(object sender, EventArgs e)
    {
        PanelCamposSeleccion.Visible = false;
        PanelEficiencia.Visible = false;
        PnCiclos.Visible = true;

        if (ddlCiclos.SelectedValue == "Ciclo Total")
        {
            kpi = 73;
            kpiImportacion = 73;
            Utils.Ciclos_Reclamos_tipo(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos_con_importacion", GridCiclos, 4, kpi, 1);
            kpi = 43;
            Utils.Ciclos_Reclamos_tipo(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos_con_importacion", GridCiclos2, 4, kpi, 0);
            Titulo("Total",kpi,kpiImportacion);
            KPI(true);
            Utils.actividades(0, Constantes.AUTOS(), 34, Constantes.USER());
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Unity")
        {
            kpi = 6;
            Utils.Ciclos_Reclamos(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos", GridCiclos, 1, kpi);
            Utils.Ciclos_Reclamos(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos", GridCiclos2, 5, kpi);
            lblTitulo.Text = "Ciclo Unity, KPI sobre " + kpi.ToString() + " dias";
            Utils.actividades(0, Constantes.AUTOS(), 31, Constantes.USER());
            KPI(false);
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Aseguradora")
        {
            kpi = 54;
            kpiImportacion = 54;
            Utils.Ciclos_Reclamos_tipo(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos_con_importacion", GridCiclos, 2, kpi,1);
            kpi = 24;
            Utils.Ciclos_Reclamos_tipo(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos_con_importacion", GridCiclos2, 2, kpi,0);
            Titulo("Aseguradora", kpi, kpiImportacion);
            KPI(true);
            Utils.actividades(0, Constantes.AUTOS(), 32, Constantes.USER());
        }

        else if (ddlCiclos.SelectedValue == "Ciclo Cliente")
        {
            kpi = 13;
            Utils.Ciclos_Reclamos(txtFechaInicio, txtFechaFin, "pa_ciclos_reclamos_autos", GridCiclos, 3, kpi);
            lblTitulo.Text = "Ciclo Cliente, KPI sobre " + kpi.ToString() + " dias";
            Utils.actividades(0, Constantes.AUTOS(), 33, Constantes.USER());
            KPI(false);
        }
    }

    public void Titulo(string titulo, int kpi, int kpiImportacion)
    {
        lblTitulo.Text = "Ciclo "+titulo+", KPI sobre " + kpi.ToString() + " dias sin importacion y " + kpiImportacion + " con importacion";
        KpiConImportacion.Text = "Con importación Evaluado sobre " + kpiImportacion + " Dias";
        KpiSinImportacion.Text = "Sin importación Evaluado sobre " + kpi + " Dias";
    }

    private void KPI(bool valor)
    {
        KpiSinImportacion.Visible = valor;
        KpiConImportacion.Visible = valor;
    }

    protected void linKRegresar_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = true;
        PnCiclos.Visible = false;
    }

    protected void linkDescarPromedio_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridCiclos, Response, lblTitulo.Text + " Reclamos Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    protected void btnMostrarEficiencia_Click(object sender, EventArgs e)
    {
        PanelCamposSeleccion.Visible = false;
        PnCiclos.Visible = false;
        PanelEficiencia.Visible = true;
        //Eficiencia();
        Utils.Reportes(txtFechaInicio, txtFechaFin, "pa_eficiencia_autos", GridEficiencia);
        Utils.TituloReporte(PanelPrincipal, lblPeriodo, lblFechaGeneracion, lblUsuario, lblTitulo, "Reporte de Efectividad / Depto. Reclamos Autos", userlogin, txtFechaInicio, txtFechaFin, "");
    }
}