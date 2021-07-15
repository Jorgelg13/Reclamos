using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_Caja_de_ahorro_ReportesMedicos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenado = new Utils();
    String Join;
    conexionBD obj = new conexionBD();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Double TotalReclamos, totalPromedioUsuario, totalPendientes;
    int totalNuevos, totalCerrados, totalFueraTiempo;
    Double totalPromedio, totalPromedioPonderado, totalPromedioEjecucion;
    String buscar;
    String tipo_reclamo = "I";
    //variable que contiene todos los joins que se hacen en el query del reporte
    String KPI_ASEGURADORA, KPI_CLIENTE, KPI_EJECUTIVO, KPI_EFICIENCIA;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkSinFiltro.Checked = true;
        }

        //variable que contiene todos los joins que se hacen en el query del reporte
        Join = " FROM " +
          " dbo.reg_reclamos_medicos " +
          "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
          "INNER JOIN dbo.estado on dbo.reclamos_medicos.id_estado = dbo.estado.id ";
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccio

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
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where (Convert(date,reclamos_medicos.fecha_cierre, 112) between '" + txtFechaInicio.Text + "' " +
                    "and '" + txtFechaFin.Text + "') and reclamos_medicos.estado_unity = 'Cerrado' and (reg_reclamos_medicos.poliza in('SC-1291','SC-1288','SC-1289','SC-1290')) ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where (Convert(date,reclamos_medicos.fecha_commit,112) between '" + txtFechaInicio.Text + "' and  '" + txtFechaFin.Text + "') " +
                " and reclamos_medicos.estado_unity = 'Seguimiento'  and ( reg_reclamos_medicos.poliza in('SC-1291','SC-1288','SC-1289','SC-1290')) " +
                "", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                " where reclamos_medicos.estado_unity = 'Seguimiento' and ( reg_reclamos_medicos.poliza in('SC-1291','SC-1288','SC-1289','SC-1290')) ", GridCamposSeleccion);
                Conteo();
            }
            else if (ddlEstado.SelectedItem.Text == "Aperturados")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (Convert(date,reclamos_medicos.fecha_apertura, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                  " and (reclamos_medicos.estado_unity = 'Seguimiento')  and (reg_reclamos_medicos.poliza in('SC-1291','SC-1288','SC-1289','SC-1290')) ", GridCamposSeleccion);
                Conteo();
            }

            Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 53, "caja");
        }

        else
        {
           
        }
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 54, "caja");
        Utils.ExportarExcel(GridCamposSeleccion, Response, "Reporte Gastos Medicos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/Dashboard.aspx", false);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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


    protected void Mostrar_Click(object sender, EventArgs e)
    {
        
    }

    public void TituloReporte(String Titulo, String KPI)
    {

    }
}