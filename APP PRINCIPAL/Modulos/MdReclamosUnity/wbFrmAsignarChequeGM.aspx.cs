using System;

public partial class Modulos_MdReclamosUnity_wbFrmAsignarChequeGM : System.Web.UI.Page
{
    Utils llenado = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String seleccionarRegistros;
    protected void Page_Load(object sender, EventArgs e)
    {
        seleccionarRegistros = "SELECT " +
          "dbo.reclamos_medicos.id as ID," + //1
          "dbo.reg_reclamos_medicos.asegurado as Asegurado," +
          "dbo.reg_reclamos_medicos.poliza as Poliza," +
          "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +
          "dbo.reclamos_medicos.telefono as Telefono," +
          "dbo.reclamos_medicos.correo as Correo," +
          "dbo.reclamos_medicos.empresa as Empresa," +
          "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
          "dbo.reg_reclamos_medicos.ramo as Ramo," +
          "dbo.reg_reclamos_medicos.tipo as Tipo," +
          "dbo.reg_reclamos_medicos.clase as Clase," +
          "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
          "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
          "dbo.reg_reclamos_medicos.vip as VIP," +
          "dbo.reg_reclamos_medicos.moneda as Moneda " +
          "FROM  dbo.reg_reclamos_medicos " +
          "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
          " where reclamos_medicos.estado_unity = 'Seguimiento' and reclamos_medicos.bandera_cheque = 0";

        llenado.llenarGrid(seleccionarRegistros, GridGeneral);
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ingresar-cheque').modal('show');", addScriptTags: true); 
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            int id;
            id = Convert.ToInt32(GridGeneral.SelectedRow.Cells[1].Text);
            var reclamo = DBReclamos.reclamos_medicos.Find(id);
            detalle_pagos_reclamos_medicos pago = new detalle_pagos_reclamos_medicos();
            pago.banco = ddlBanco.SelectedItem.Text;
            pago.monto = Convert.ToDecimal(txtMontoCheque.Text);
            pago.no_cheque = txtNumeroCheque.Text;
            pago.total_reclamado = 0;
            pago.total_aprobado = 0;
            pago.total_no_cubierto = 0;
            pago.total_iva = 0;
            pago.deducible = 0;
            pago.coaseguro = 0;
            pago.timbres = 0;
            pago.total = 0;
            pago.porcen_coaseguro = Convert.ToDecimal(0.15);
            pago.porcen_timbres = Convert.ToDecimal(0.03);
            pago.moneda = "Quetzales";
            pago.fecha_creacion = DateTime.Now;
            pago.id_reclamo_medico = id;
            DBReclamos.detalle_pagos_reclamos_medicos.Add(pago);

            reclamo.bandera_cheque = true;
            reclamo.fecha_recepcion_cheque = DateTime.Now;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Cheque agregado con exito", "Excelente..!", "info");
            GridGeneral.DataBind();
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
            txtMontoCheque.Text = "";
            txtNumeroCheque.Text = "";
        }

        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido efectuar el ingreso del cheque", "Error..!", "error");
        }
    }
}