using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmAsignarChequeGM : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    Utils llenado = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String seleccionarRegistros;
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        seleccionarRegistros = "SELECT " +
          "r.id as ID," + //1
          "reg.asegurado as Asegurado," +
          "reg.poliza as Poliza," +
          "reg.aseguradora as Aseguradora," +
          //"r.telefono as Telefono," +
          //"r.correo as Correo," +
          //"r.empresa as Empresa," +
          "r.tipo_reclamo as [Tipo Reclamo]," +
          //"reg.ramo as Ramo," +
          //"reg.tipo as Tipo," +
          //"reg.clase as Clase," +
          "reg.ejecutivo as Ejecutivo," +
          //"reg.estado_poliza as [Estado Poliza]," +
          "reg.vip as VIP," +
          "reg.moneda as Moneda " +
          "FROM reg_reclamos_medicos as reg " +
          "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id " +
          " where r.estado_unity = 'Seguimiento' and r.bandera_cheque = 0";

        if (!IsPostBack)
        {
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ingresar-cheque').modal('show');", addScriptTags: true);
        lblId.Text = GridGeneral.SelectedRow.Cells[1].Text;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            id = Convert.ToInt32(GridGeneral.SelectedRow.Cells[1].Text);

            var usuario = DBReclamos.usuario.Where(us => us.nombre == userlogin).First();
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

            ingreso_cheques cheque = new ingreso_cheques();
            var sec_registro = DBReclamos.pa_sec_ingreso_cheque();
            long? id_registro = sec_registro.Single();
            cheque.id = Convert.ToInt32(id_registro);
            cheque.tipo = "GM";
            cheque.id_reclamo = id;
            cheque.fecha = DateTime.Now;
            cheque.usuario = usuario.id;
            DBReclamos.ingreso_cheques.Add(cheque);
            DBReclamos.SaveChanges();

            Utils.ShowMessage(this.Page, "Cheque agregado con exito", "Excelente..!", "info");
            GridGeneral.DataBind();
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
            txtMontoCheque.Text = "";
            txtNumeroCheque.Text = "";
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido efectuar el ingreso del cheque" + ex.Message, "Error..!", "error");
        }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
       /* id = Convert.ToInt32(txtbuscar.Text);
        string consulta = "SELECT " +
          "r.id as ID," +
          "reg.asegurado as Asegurado," +
          "reg.poliza as Poliza," +
          "reg.aseguradora as Aseguradora," +
          "r.tipo_reclamo as [Tipo Reclamo]," +
          "reg.ejecutivo as Ejecutivo," +
          "reg.vip as VIP," +
          "reg.moneda as Moneda " +
          "FROM reg_reclamos_medicos as reg " +
          "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id " +
          " where r.estado_unity = 'Seguimiento' and r.id = "+id+" ";

        llenado.llenarGrid(consulta, GridGeneral);*/
    }
}