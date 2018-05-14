using System;
using System.Web.UI;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Text;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmReportesAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String Join;
    conexionBD obj = new conexionBD();
    String buscar;
    String eficienciaGestores;
    int Pendientes ;
    int Nuevos ;
    int Cerrados ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gestores();
        }

        if (userlogin == "jsagastume" || userlogin == "jlaj" || userlogin == "jwiesner" || userlogin == "nsierra" || userlogin == "jpazos")
        {
            btnMostrarEficiencia.Visible = true;
        }

        else
        {
            btnMostrarEficiencia.Visible = false;
        }

        eficienciaGestores = "select rs.nombre as Usuario, rs.Pendientes, rs.Nuevos, rs.Cerrados , " +
            "CAST(cast((rs.Cerrados * 100) / ((rs.Pendientes * 1.0) + nuevos) as decimal(4,2)) as varchar) + '%' as Ejecucion " +
            "from(select r.nombre, " +
            "Pendientes = (select COUNT(*) from reclamo_auto where estado_unity = 'Seguimiento' and id_gestor = r.id)," +
            "Nuevos = (select COUNT(*) from reclamo_auto where fecha_apertura_reclamo between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and id_gestor = r.id), " +
            "Cerrados = (select COUNT(*) from reclamo_auto where fecha_cierre_reclamo between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' and estado_unity = 'Cerrado' and id_gestor = r.id) " +
            "from(select id, usuario, nombre from gestores where tipo = 'autos') as r)  rs where Pendientes !=0";

        //variable que contiene todos los joins que se hacen en el query del reporte
        Join = " from auto_reclamo" +
                  " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
                  " INNER JOIN gestores on reclamo_auto.id_gestor = gestores.id" +
                  " INNER JOIN talleres on reclamo_auto.id_taller = talleres.id" +
                  " INNER JOIN analistas on reclamo_auto.id_analista = analistas.id " +
                  " LEFT JOIN contacto_auto on reclamo_auto.id = contacto_auto.id_reclamo_auto " +
                  " INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
                  " INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
                  " INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
                  " INNER JOIN pais ON empresa.id_pais = pais.id " +
                  " INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccion
        if(checkSinFiltro.Checked)
        {
            string listado;
            listado = "Select distinct reclamo_auto.id, ";
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
                  " where (reclamo_auto.fecha_cierre_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedItem + "') " +
                  "", GridCamposSeleccion);
                Conteo();
            }
            else if(ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedItem + "') " +
                 "", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')" +
                 "", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Nuevos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')" +
                 "", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where reclamo_auto.estado_unity = 'Seguimiento'  ", GridCamposSeleccion);
                Conteo();
            }
        }

        else
        {
            if (ddlElegir.SelectedItem.Text == "Gestor")
            {
                buscar = ddlBuscar.SelectedItem.Text;
            }
            else
            {
                buscar = txtBuscar.Text;
            }
            string listado;
            
            listado = "Select distinct reclamo_auto.id, ";
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }

            if(ddlEstado.SelectedItem.Text == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (reclamo_auto.fecha_cierre_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedItem + "')  ", GridCamposSeleccion);
                Conteo();
                Eficiencia();
            }

            else if(ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedItem + "')  ", GridCamposSeleccion);
                Conteo();
                Eficiencia();
            }

            else if (ddlEstado.SelectedItem.Text == "Todos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')", GridCamposSeleccion);
                Conteo();
                Eficiencia();
            }

            else if (ddlEstado.SelectedItem.Text == "Nuevos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (reclamo_auto.fecha_apertura_reclamo between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')", GridCamposSeleccion);
                Conteo();
                Eficiencia();
            }

            else if (ddlEstado.SelectedItem.Text == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (estado_unity = 'Seguimiento' ) and (reclamo_auto.fecha_apertura_reclamo <= '"+txtFechaInicio.Text+"') ", GridCamposSeleccion);
                Conteo();
                Eficiencia();
            }
        }
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Reporte_autos.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridCamposSeleccion.AllowPaging = false;
            GridCamposSeleccion.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    //link para salir y ponerse en los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx");
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
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Eficiencia Reclamos Autos.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridEficiencia.AllowPaging = false;
            GridEficiencia.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void Eficiencia()
    {
        try
        {
            llenado.llenarGrid(eficienciaGestores, GridEficiencia);
        }

        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido generar la eficiencia", "Nota..!", "warning");
        }
    }

    protected void ddlElegir_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlElegir.SelectedItem.Text == "Gestor")
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

    public void Gestores()
    {
        ddlBuscar.DataSource = DBReclamos.gestores.ToList().Where(ge => ge.tipo == "autos");
        ddlBuscar.DataValueField = "id";
        ddlBuscar.DataTextField = "nombre";
        ddlBuscar.DataBind();
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

    protected void GridEficiencia_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Pendientes += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Pendientes]"));
                Nuevos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Nuevos]"));
                Cerrados += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[Cerrados]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = Pendientes.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = Nuevos.ToString();
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[3].Text = Cerrados.ToString();
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }
}