using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Modulos_MdReclamosUnity_wbFrmReportesAutorizaciones : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenado = new Utils();
    String Join;
    conexionBD obj = new conexionBD();
    DataTable dt = new DataTable();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int TotalReclamos;
    Double TotalPromedioHoras, TotalGrid;
    String buscar, eficienciaGestores;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkSinFiltro.Checked = true;
            checkSinFiltro_CheckedChanged(sender, e);
            aseguradoras();
        }

        Join = " FROM " +
          " dbo.reg_reclamos_medicos as reg " +
          " INNER JOIN autorizaciones as aut ON aut.id_reg_reclamos_medicos = reg.id ";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        PanelEficiencia.Visible = false;
        PanelTitulo.Visible = true;
        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccion

        if (checkSinFiltro.Checked)
        {
            string listado;
            listado = "Select aut.id, ";
            //recorre la lista de checks que seleccionaron para generar el reporte
            for (int i = 0; i < checkCampos.Items.Count; i++)
            {
                if (checkCampos.Items[i].Selected)
                {
                    listado += checkCampos.Items[i].Value + ", ";
                }
            }
            //si seleccionarion cerrado ejecuta este query 
            if (ddlEstado.SelectedValue == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where (Convert(date,aut.fecha_completa_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "')  and aut.tipo_estado = 'Cerrado'", GridCamposSeleccion);
                Conteo();
                //eficiencia();
            }
            //si seleccionaron cualquier otra opcion de tipo de estado
            else if (ddlEstado.SelectedValue != "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,aut.fecha_completa_commit,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and tipo_estado "+ddlEstado.SelectedValue+" ", GridCamposSeleccion);
                Conteo();
                eficiencia();
            }
            TituloReporte("Reporte de autorizaciones");
        }

        else
        {
            if (ddlElegir.SelectedItem.Text == "Aseguradora")
            {
                buscar = ddlBuscar.SelectedItem.Text;
                eficiencia();
                //eficienciaPorAseguradora();
            }
            else
            {
                buscar = txtBuscar.Text;
            }

            string listado;
            listado = "Select aut.id, ";
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
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert( date,aut.fecha_completa_cierre, 112) " +
                  "between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and aut.tipo_estado = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text != "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (Convert(date,aut.fecha_completa_commit,112) " +
                  "between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and aut.tipo_estado "+ddlEstado.SelectedValue+" ", GridCamposSeleccion);
                Conteo();
            }

            TituloReporte("Reporte Autorizaciones");
        }
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if(PanelPrincipal.Visible == true)
        {
            Utils.ExportarExcel(PanelPrincipal, Response, "Reporte Autorizaciones");
        }

        else
        {
            Utils.ExportarExcel(PanelEficiencia, Response, "Reporte Eficiencia");
        }
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

        if(ddlElegir.SelectedItem.Text == "Aseguradora")
        {
            ddlBuscar.Visible = true;
        }
    }

    protected void CheckTodos_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckTodos.Checked)
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

    protected void ddlElegir_SelectedIndexChanged(object sender, EventArgs e)
    {
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
       // Utils.ExportarExcel(PnEficiencia, Response, "Eficiencia Autorizaciones del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    public void aseguradoras()
    {
        ddlBuscar.DataSource = DBReclamos.aseguradoras.ToList();
        ddlBuscar.DataTextField = "aseguradora";
        ddlBuscar.DataValueField = "codigo";
        ddlBuscar.DataBind();
    }

    public void eficiencia()
    {
        try
        {
            SqlCommand comando = new SqlCommand("pa_kpi_autirizaciones", obj.ObtenerConexionReclamos());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicio", txtFechaInicio.Text);
            comando.Parameters.AddWithValue("@fechaFin", txtFechaFin.Text);
            comando.Parameters.AddWithValue("@idAseguradora", (ddlBuscar.Visible == false) ? 0 : Convert.ToInt32(ddlBuscar.SelectedValue));
            comando.Parameters.AddWithValue("@aseguradora", (ddlBuscar.Visible == false) ?  "" : ddlBuscar.SelectedItem.Text );
            comando.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            GridEficiencia.DataSource = dt;
            GridEficiencia.DataBind();
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al generar la eficiencia de autorizaciones" + ex.Message, "Error..", "error");
        }
    }

    public void eficienciaPorAseguradora()
    {
        try
        {
            SqlCommand comando = new SqlCommand("pa_kpi_autorizaciones_aseguradora", obj.ObtenerConexionReclamos());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicio", txtFechaInicio.Text);
            comando.Parameters.AddWithValue("@fechaFin", txtFechaFin.Text);
            comando.Parameters.AddWithValue("@aseguradora", ddlBuscar.SelectedItem.Text);
            comando.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            GridEficiencia.DataSource = dt;
            GridEficiencia.DataBind();
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al generar la eficiencia de autorizaciones" + ex.Message, "Error..", "error");
        }
    }

    //funcion para realizar una sumatoria y colocar el total en la parte de abajo del Grid
    protected void GridEficiencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            TotalGrid = Convert.ToDouble(GridEficiencia.Rows.Count);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalReclamos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[total]"));
                TotalPromedioHoras += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Promedio Horas]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                e.Row.Cells[2].Text = (TotalPromedioHoras / TotalGrid).ToString("N2");
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    public void TituloReporte(String Titulo)
    {
        try
        {
            PanelPrincipal.Visible = true;
            lblPeriodo.Text = "Periodo del " + Convert.ToDateTime(txtFechaInicio.Text).ToString("dd/MM/yyyy") + " al " + Convert.ToDateTime(txtFechaFin.Text).ToString("dd/MM/yyyy");
            lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString();
            lblUsuario.Text = "Usuario: " + userlogin;
            lblTitulo.Text = Titulo;
        }
        catch (Exception)
        {

        }
    }

    protected void btnMostrarEficiencia_Click(object sender, EventArgs e)
    {
        eficiencia();

        if (checkSinFiltro.Checked)
        {
            ddlBuscar.Visible = false;
        }
        else
        {
            ddlBuscar.Visible = true;
        }
        lblTitulo.Text = "Reporte de Eficiencia de autorizaciones " + ((ddlBuscar.Visible == false) ? "" : ddlBuscar.SelectedItem.Text).ToString();
        PanelTitulo.Visible = true;
        PanelPrincipal.Visible = false;
        PanelEficiencia.Visible = true;
    }
}