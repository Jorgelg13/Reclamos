using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReportes_wbActividades : System.Web.UI.Page
{
    Utils llenado = new Utils();
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBreclamos = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ddlusuarios.DataSource = DBreclamos.usuario.Where(us => us.estado == true && us.id_cabina == 5).ToList();
            ddlusuarios.DataTextField = "nombre_completo";
            ddlusuarios.DataValueField = "nombre";
            ddlusuarios.DataBind();
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        string actividades = "";
        PanelPrincipal.Visible = true;

        if(chFiltro.Checked)
        {
            actividades = "select m.nombre as Actividad, g.nombre_completo as Usuario, a.fecha as Fecha, t.nombre as Tipo,a.id_reclamo as [ID Reclamo] " +
                "from actividades as a " +
                "inner join movimientos as m on a.id_movimiento = m.id " +
                "inner join tipo_reclamos as t on t.id = a.id_tipo " +
                "inner join(select distinct nombre, nombre_completo from usuario) as g on g.nombre = a.usuario " +
                "where CONVERT(date, a.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' and a.usuario = '"+ddlusuarios.SelectedValue+"' order by g.nombre";
        }

        else
        {
            actividades = "select m.nombre as Actividad, g.nombre_completo as Usuario, a.fecha as Fecha, t.nombre as Tipo,a.id_reclamo as [ID Reclamo] " +
                "from actividades as a " +
                "inner join movimientos as m on a.id_movimiento = m.id " +
                "inner join tipo_reclamos as t on t.id = a.id_tipo " +
                "inner join(select distinct nombre, nombre_completo from usuario) as g on g.nombre = a.usuario " +
                "where CONVERT(date, a.fecha,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' order by g.nombre";
        }


        llenado.llenarGrid(actividades, GridActividades);

        lblConteo.Text = "Total de Registros:  " + GridActividades.Rows.Count.ToString();
       // TituloReporte("Reporte de actividades Departamento de Reclamos","");
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PanelPrincipal, Response, "Reporte de actividades");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/Dashboard/DashboardUnity.aspx", false);
    }

    //public void TituloReporte(String Titulo, String KPI)
    //{
    //    try
    //    {
    //        //PanelPrincipal.Visible = true;
    //        lblPeriodo.Text = "Periodo del " + Convert.ToDateTime(txtFechaInicio.Text).ToString("dd/MM/yyyy") + " al " + Convert.ToDateTime(txtFechaFin.Text).ToString("dd/MM/yyyy");
    //        lblFechaGeneracion.Text = "Generado: " + DateTime.Now.ToString();
    //        lblUsuario.Text = "Usuario: " + userlogin;
    //        lblTitulo.Text = Titulo;
    //    }
    //    catch (Exception)
    //    {

    //    }
    //}

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTipo.SelectedValue == "1")
        {
            ddlusuarios.DataSource = DBreclamos.gestores.Where(us => us.tipo == "autos").ToList();
            ddlusuarios.DataTextField = "nombre";
            ddlusuarios.DataValueField = "usuario";
            ddlusuarios.DataBind();
        }

        if (ddlTipo.SelectedValue == "2")
        {
            ddlusuarios.DataSource = DBreclamos.gestores.Where(us => us.tipo == "Daños varios").ToList();
            ddlusuarios.DataTextField = "nombre";
            ddlusuarios.DataValueField = "usuario";
            ddlusuarios.DataBind();
        }

        if (ddlTipo.SelectedValue == "3")
        {
            ddlusuarios.DataSource = DBreclamos.gestores.Where(us => us.tipo == "Medicos").ToList();
            ddlusuarios.DataTextField = "nombre";
            ddlusuarios.DataValueField = "usuario";
            ddlusuarios.DataBind();
        }

        if(ddlTipo.SelectedValue == "0")
        {
            ddlusuarios.DataSource = DBreclamos.usuario.Where(us => us.estado == true && us.id_cabina == 5).ToList();
            ddlusuarios.DataTextField = "nombre_completo";
            ddlusuarios.DataValueField = "nombre";
            ddlusuarios.DataBind();
        }
    }

    protected void chFiltro_CheckedChanged(object sender, EventArgs e)
    {
        if(chFiltro.Checked)
        {
            ddlTipo.Enabled = true;
            ddlusuarios.Enabled = true;
        }

        else
        {
            ddlTipo.Enabled = false;
            ddlusuarios.Enabled = false;
        }

    }
}