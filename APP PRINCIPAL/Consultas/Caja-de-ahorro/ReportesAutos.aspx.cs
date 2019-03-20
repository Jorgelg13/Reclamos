using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_Caja_de_ahorro_ReportesAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    conexionBD obj = new conexionBD();
    String buscar, Join, eficienciaGestores;
    int Total, Promedio, EjecucionCiclos, kpi;
    Double Pendientes, Nuevos, Cerrados, Ejecucion;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkSinFiltro_CheckedChanged(sender, e);
        }

        eficienciaGestores = "select rs.nombre as Usuario, rs.Pendientes, rs.Nuevos, rs.Cerrados , " +
            "CAST(cast((rs.Cerrados * 100) / (rs.Pendientes + nuevos) as decimal) as varchar)  as Ejecucion " +
            "from(select r.nombre, " +
            "Pendientes = (select COUNT(*) from reclamo_auto where estado_unity = 'Seguimiento' and id_gestor = r.id)," +
            "Nuevos = (select COUNT(*) from reclamo_auto where convert(date, fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' and id_gestor = r.id), " +
            "Cerrados = (select COUNT(*) from reclamo_auto where convert(date, fecha_cierre_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' and estado_unity = 'Cerrado' and id_gestor = r.id) " +
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
        PanelCamposSeleccion.Visible = true;

        //si el check esta chequeado entra aqui 
        //este check sirve para no filtrar el reporte por alguna seleccion
        if (checkSinFiltro.Checked)
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
            if (ddlEstado.SelectedItem.Text == "Cerrado")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                  " where (convert(date, reclamo_auto.fecha_cierre_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                  "and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "' and poliza in ('AUTO-366487','AUTO-366488')) " +
                  "", GridCamposSeleccion);
            }
            else if (ddlEstado.SelectedItem.Text == "Seguimiento")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (convert(date, reclamo_auto.fecha_apertura_reclamo, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') " +
                 "and (reclamo_auto.estado_unity = '" + ddlEstado.SelectedValue + "' and poliza in ('AUTO-366487','AUTO-366488')) " +
                 "", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedItem.Text == "Nuevos")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join +
                 " where (convert(date, reclamo_auto.fecha_apertura_reclamo,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "') and poliza in ('AUTO-366487','AUTO-366488') " +
                 "", GridCamposSeleccion);
            }

            else if (ddlEstado.SelectedItem.Text == "Pendientes")
            {
                llenado.llenarGrid(listado.Substring(0, (listado.Length - 2)) + Join + " where reclamo_auto.estado_unity = 'Seguimiento' and poliza in ('AUTO-366487','AUTO-366488') ", GridCamposSeleccion);
            }
            Conteo();
            Utils.actividades(0, Constantes.AUTOS(), 53, "caja");
        }

        else
        {

        }
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (PanelCamposSeleccion.Visible == true)
        {
            Utils.actividades(0, Constantes.AUTOS(), 54, "caja");
            Utils.ExportarExcel(PanelPrincipal, Response, "Reclamos autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
        }
    }

    //link para salir y ponerse en los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/Dashboard.aspx", false);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    //metodo para inabilitar las cajas de texto y seleccion
    protected void checkSinFiltro_CheckedChanged(object sender, EventArgs e)
    {
       
    }

    public void Conteo()
    {
        lblConteo.Text = this.GridCamposSeleccion.Rows.Count.ToString();
    }

    protected void btnExportarEficiencia_Click(object sender, EventArgs e)
    {
       // Utils.ExportarExcel(GridEficiencia, Response, "Eficiencia Reclamos Autos");
    }

    public void Eficiencia()
    {
       
    }

    protected void ddlElegir_SelectedIndexChanged(object sender, EventArgs e)
    {
       
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

    protected void Mostrar_Click(object sender, EventArgs e)
    {

    }

    protected void linKRegresar_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = true;
    }

    protected void linkDescarPromedio_Click(object sender, EventArgs e)
    {
       //s Utils.ExportarExcel(GridCiclos, Response, lblTitulo.Text + " Reclamos Autos del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    protected void btnMostrarEficiencia_Click(object sender, EventArgs e)
    {
       
    }
}