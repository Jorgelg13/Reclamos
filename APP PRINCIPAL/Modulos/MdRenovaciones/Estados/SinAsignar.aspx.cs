using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_SinAsignar : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String Cargadas;

    protected void Page_Load(object sender, EventArgs e)
    {

        Cargadas = "Select " +
           "r.id as ID, " +
           "r.poliza as Poliza," +
           "r.asegurado as Asegurado," +
           "r.marca as Marca," +
           "r.modelo as Modelo," +
           "r.placa as Placa," +
           "r.vigf as [Vigencia Final]," +
           "r.correo_cliente as [Correo Cliente]," +
           "  (select top 1 fecha from renovaciones_log where poliza = r.id) as [Fecha Registro]" +
           "from renovaciones_polizas r " +
           "where  r.estado = 1 ";

        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Cargadas, GridSinAsignar);
            DropEjecutivos();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    public void DropEjecutivos()
    {
        ddlEjecutivo.DataSource = DBReclamos.ejecutivos.ToList();
        ddlEjecutivo.DataTextField = "gestor";
        ddlEjecutivo.DataValueField = "codigo";
        ddlEjecutivo.DataBind();
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridSinAsignar, Response, "NoEnviadas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Cargadas, GridSinAsignar);
    }

    protected void btnGenerarTabla_Click1(object sender, EventArgs e)
    {

    }

    protected void GridNoEnviadas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridSinAsignar.SelectedRow.Cells[1].Text);
        var registro = DB.renovaciones_polizas.Find(id);
        txtCorreo.Text = registro.correo_cliente;
        Guardar.Enabled = true;
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            string correo_gestor;
            var gestor = DBReclamos.ejecutivos.Find(Convert.ToInt32(ddlEjecutivo.SelectedValue));
            correo_gestor = gestor.correo;
            int id = Convert.ToInt32(GridSinAsignar.SelectedRow.Cells[1].Text);
            var registro = DB.renovaciones_polizas.Find(id);
            registro.codigo_gestor = Convert.ToInt32(ddlEjecutivo.SelectedValue);
            registro.nombre_pagador = ddlEjecutivo.SelectedItem.Text;
            registro.correo_cliente = txtCorreo.Text;
            registro.poliza_unity = txtPolizaUnity.Text;
            registro.vigf_acs = txtVigfacs.Text;
            registro.correo_gestor = correo_gestor;
            registro.estado = 2;
            DB.SaveChanges();
            llenarGrid();
            Utils.ShowMessage(this.Page, "Registro actualizado y asignado con exito","Excelente..","success");
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el registro " + ex.Message, "Error..", "error");
        }
    }

    protected void GridSinAsignar_SelectedIndexChanged(object sender, EventArgs e)
    {
        Guardar.Enabled = true;
    }
}