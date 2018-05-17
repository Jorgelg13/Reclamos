using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int TotalReclamos;
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
                eficiencia();
            }
            //si seleccionaron cualquier otra opcion de tipo de estado
            else if (ddlEstado.SelectedValue != "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,aut.fecha_completa_commit,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and tipo_estado "+ddlEstado.SelectedValue+" ", GridCamposSeleccion);
                Conteo();
                eficiencia();
            }
        }

        else
        {
            if (ddlElegir.SelectedItem.Text == "Aseguradora")
            {
                buscar = ddlBuscar.SelectedValue;
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
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (convert( date,aut.fecha_completa_cierre, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and aut.tipo_estado = 'Cerrado'", GridCamposSeleccion);
                Conteo();
            }

            else if (ddlEstado.SelectedItem.Text != "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (" + ddlElegir.SelectedValue + " like '%" + buscar + "%') and (Convert(date,aut.fecha_completa_commit,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and aut.tipo_estado "+ddlEstado.SelectedValue+" ", GridCamposSeleccion);
                Conteo();
            }
        }
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        ExportarExcel(GridCamposSeleccion, "Reporte Autorizaciones");
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    private void ExportarExcel(GridView gridExportar, string reporte)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + reporte + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridExportar.AllowPaging = false;
            gridExportar.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
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

    //funcion para realizar una sumatoria y colocar el total en la parte de abajo del grid

    protected void GridPromedioAseguradora_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalReclamos += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "[total]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[1].Text = TotalReclamos.ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;

                //e.Row.Cells[2].Text = (totalPromedioPonderado / TotalReclamos).ToString("N2");
                //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[3].Text = totalPromedioPonderado.ToString();
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Font.Bold = true;

                //e.Row.Cells[4].Text = (kpiAseguradora / (totalPromedioPonderado / TotalReclamos) * 100).ToString("N2") + "%";
                //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Font.Bold = true;
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
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
        Utils.ExportarExcel(GridEficiencia, Response, "Eficiencia Autorizaciones");
    }

    public void aseguradoras()
    {
        ddlBuscar.DataSource = DBReclamos.aseguradoras.ToList();
        ddlBuscar.DataTextField = "aseguradora";
        ddlBuscar.DataValueField = "aseguradora";
        ddlBuscar.DataBind();
    }

    public void eficiencia()
    {
        try
        {
            conexionBD obj = new conexionBD();
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("pa_kpi_autirizaciones", obj.ObtenerConexionReclamos());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicio", txtFechaInicio.Text);
            comando.Parameters.AddWithValue("@fechaFin", txtFechaFin.Text);
            comando.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            GridEficiencia.DataSource = dt;
            GridEficiencia.DataBind();
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al generar la eficiencia de autoriazaciones" + ex.Message, "Error..", "error");
        }
    }
}