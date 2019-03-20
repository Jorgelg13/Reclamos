using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Globalization;
using System.IO;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosSeguimientos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    ReclamosEntities DBReclamos = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    Utils actualizar = new Utils();
    DateTime thisDay = DateTime.Today;
    String metodo = "sistema";
    String idRecibido,comentarios, Documentos, pagos, datosReclamos, detalle_gastos, detalle_gastos2, updateFecha, correo, simbolo, MinimaFechaGastoMedico;
    String mensaje;
    Double total;
    Decimal sumaTotal;
    Double montoReclamado, montoAprobado, montoNoCubierto, montoConIva, montoConDeducible, deducible, iva, timbres, coaseguro, montoTotal, totalIva, totalCoaseguro,totalTimbres;
    bool bandera_asegurado;
    int id, totalDias, identificadorPago;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        id = Int32.Parse(idRecibido);
        Session.Add("id_RM", id.ToString());
        lblId.Text   = "<b>No.</b>" + id.ToString();
        labelID.Text = "<b>ID:</b>" + id.ToString();
        lblIdOculto.Text = idRecibido;
        lblFechaEnvioCliente.Text = thisDay.ToString("D");
        mensaje = "UNITY: Estimado cliente hemos revisado su reclamo ID "+id+" y se estará enviando a la Aseguradora el siguiente día hábil, para los trámites correspondientes.";

        Documentos  = Consultas.DOCUMENTOS_GM(id);
        comentarios = Consultas.COMENTARIOS_GM(id);
        pagos       = Consultas.PAGOS_GM(id);

        if(Verificar())
        {
            if (!IsPostBack)
            {
                DevolverDatos(id);
                llenado.llenarGrid(Documentos, GridRecibo);
                llenado.llenarGrid(comentarios, GridComentarios);
                llenado.llenarGrid(pagos, GridPagos);
                totalDetalleGasto(id);
                cargarDirecciones();
                ddlMonedaPoliza.DataBind();
                tiempos();
            }
        }

        else
        {
            panelInformacion.Visible = true;
            panelPrincipal.Visible = false;
            Utils.ShowMessage(this.Page, "Este reclamo no esta aperturado", "Nota..!", "error");
        }
    }

    public bool Verificar()
    {
        bool aperturado = true;
        try
        {
            var revisar = DBReclamos.reclamos_medicos.Select(f => new { f.fecha_apertura, f.fecha_asignacion, f.id }).Where(fe => fe.id == id).First();
            if (revisar.fecha_asignacion == null || revisar.fecha_apertura == null )
            {
                aperturado = false;
                panelPrincipal.Visible = false;
            }
        }

        catch(Exception)
        {
            aperturado = false;
        }

        return aperturado;
    }

    public void DevolverDatos(int identificador)
    {
        try
        {
            var reclamo = DBReclamos.reclamos_medicos.Find(id);
            //datos imprimir formulario para aseguarado
            lblAsegurado.Text     = "<ins>" + reclamo.reg_reclamos_medicos.asegurado + "</ins>";
            lblAseguradora.Text   = "<ins>" + reclamo.reg_reclamos_medicos.aseguradora + "</ins>";
            lblpoliza.Text        = "<ins>" + reclamo.reg_reclamos_medicos.poliza + "</ins>";
            lblEmpresa.Text       = "<ins>" + reclamo.empresa + "</ins>";
            lblfechaCreacion.Text = "<ins>" + reclamo.fecha_commit + "</ins>";

            if (reclamo.fecha_modificacion.ToString() != "") txtFechaModificado.Text = "Ultima Modificacion: " + reclamo.fecha_modificacion;
            if (reclamo.fecha_envio_cheque.ToString() != "") txtFechaEnvioCheque.Text = Convert.ToDateTime(reclamo.fecha_envio_cheque).ToString("yyyy/MM/dd").Replace("/", "-");

            //mostrar campo de copago cuando es de seguros g&t
            if(reclamo.reg_reclamos_medicos.aseguradora == "SEGUROS G y T, S.A."  && reclamo.reg_reclamos_medicos.tipo =="I")
            {
                PanelCopago.Visible = true;
                PanelDetalleCopago.Visible = true;
            }

            //datos de informacion lateral que se puede modificar
            txtAsegurado.Text       = reclamo.reg_reclamos_medicos.asegurado;
            txtAseguradora.Text     = reclamo.reg_reclamos_medicos.aseguradora;
            txtPoliza.Text          = reclamo.reg_reclamos_medicos.poliza;
            txtCorreo.Text          = reclamo.correo;
            txtTelefono.Text        = reclamo.telefono;
            txtDestinatario.Text    = reclamo.correo;
            DDLTipo.Text            = reclamo.tipo_reclamo;
            ddlEstado.SelectedValue = reclamo.estado.id.ToString();
            txtValorEstado.Text     = reclamo.estado.id.ToString();
            txtdetalle.Text         = reclamo.detalle_cliente;
            txtObservaciones.Text   = reclamo.observacion;
            txtNumReclamo.Text      = reclamo.num_reclamo;
            txtObservaciones.Text.Replace("<br/>", "\n");
            ddlMonedaPoliza.SelectedValue = String.IsNullOrEmpty(reclamo.reg_reclamos_medicos.moneda) ? "Quetzales" : reclamo.reg_reclamos_medicos.moneda;
            ddlNoConforme.SelectedValue   = String.IsNullOrEmpty(reclamo.detalle_no_conforme) ? "" : reclamo.detalle_no_conforme;
            txtObservacionesNoConf.Text   = reclamo.observacion_no_conforme;

            //Informacion lateral derecha
            lblEstadoReclamo.Text = ddlEstado.SelectedItem.Text;
            lblAsegurado2.Text = "<b>Asegurado:</b>        " + reclamo.reg_reclamos_medicos.asegurado;
            lblPoliza2.Text = "<b>Poliza:</b>              " + reclamo.reg_reclamos_medicos.poliza;
            lblRamo.Text = "<b>Ramo:</b>                   " + reclamo.reg_reclamos_medicos.ramo; 
            lblRamoMemo.Text =                                 reclamo.reg_reclamos_medicos.ramo;
            lblTipo.Text =                                     reclamo.reg_reclamos_medicos.tipo;
            lblClase.Text = "<b>Clase:</b>                 " + reclamo.reg_reclamos_medicos.clase;
            lblClaseOculto.Text =                              reclamo.reg_reclamos_medicos.clase;
            lblEjecutivo.Text = "<b>Ejecutivo:</b>         " + reclamo.reg_reclamos_medicos.ejecutivo;
            lblAseguradora2.Text = "<b>Aseguradora:</b>    " + reclamo.reg_reclamos_medicos.aseguradora;
            lblContratante.Text = "<b>Contratante:</b>     " + reclamo.empresa;
            lblEstado.Text = "<b>Estado:</b>               " + reclamo.reg_reclamos_medicos.estado_poliza;
            lblVip.Text = "<b>VIP:</b>                     " + reclamo.reg_reclamos_medicos.vip;
            lblMoneda.Text = "<b>Moneda:</b>               " + reclamo.reg_reclamos_medicos.moneda;
            lblDocumento.Text = String.IsNullOrEmpty(reclamo.documento) ? "" : reclamo.documento.Replace("\\", "/");

            //si el reclamo esta cerrado colocar el estado en rojo
            if (ddlEstado.SelectedItem.Text == "Cerrado") lblEstadoReclamo.ForeColor = System.Drawing.Color.Red;
            if (reclamo.bandera_cheque == true) inabilitarTextPago();
            if (reclamo.bandera_cierre == true) ddlEstado.Enabled = false;
            if (reclamo.reg_reclamos_medicos.tipo == "C") txtContacto.Visible = true;
            checkAgregar.Enabled = (reclamo.bandera_cheque == false)  ? false: true;

            //memo envio aseguradora
            lblCartaDestinatario.Text = "Depto de reclamos de " + reclamo.reg_reclamos_medicos.aseguradora;
            lblCartaEjecutivo.Text = reclamo.reg_reclamos_medicos.ejecutivo;

            lblCartaId.Text = reclamo.id.ToString();
            lblCartaPoliza.Text        = reclamo.reg_reclamos_medicos.poliza;
            lblCartaContratante.Text   = reclamo.empresa;
            lblCartaFechaCreacion.Text = reclamo.fecha_commit.ToString();
            lblCartaEjecutivo2.Text    = reclamo.reg_reclamos_medicos.ejecutivo;
            lblCartaAseguradoPrincipal.Text = reclamo.titular;
            lblCartaCertificado.Text = reclamo.reg_reclamos_medicos.certificado;
            lblCartaDependiente.Text = reclamo.reg_reclamos_medicos.asegurado;
            lblCartaObservacion.Text = reclamo.observacion.Replace("\n", "<br/>");
            lblNumeroClienteInterno.Text = reclamo.reg_reclamos_medicos.cliente.ToString();

            //producto no conforme
            if (reclamo.no_conforme == false)
            {
                ddlEstadoNoConforme.SelectedItem.Text = "Cerrado";
                ddlEstadoNoConforme.Enabled = false;
                btnProductoNoConforme.Enabled = false;
            }

            //memo al cliente
            if (reclamo.reg_reclamos_medicos.clase == "Principal")
            {
                lblCartaDependiente.Text = "";
                LblMemoDependiente.Visible = false;
            }

            if (reclamo.reg_reclamos_medicos.clase == "Dependiente") lblMemoAsegurado.Text = reclamo.reg_reclamos_medicos.contratante;

            else
            {
                lblMemoAsegurado.Text = lblCartaAseguradoPrincipal.Text;
            }

            if (lblRamoMemo.Text != "12")
            {
                lblMemoPara.Visible = false;
                lblMemoAsegurado.Visible = false;
            }

            lblMemoContratante.Text = reclamo.empresa;
            lblMemoDe.Text = reclamo.reg_reclamos_medicos.ejecutivo;
            lblMemoAsunto.Text = "Reclamo No. " + reclamo.num_reclamo;
            lblMemoDetalleCliente.Text = reclamo.detalle_cliente.Replace("\n", "<br/>"); ;
            lblMemoPoliza.Text = reclamo.reg_reclamos_medicos.poliza;
            lblMemoCertificado.Text = reclamo.reg_reclamos_medicos.certificado;
            lblMemoTitular.Text = reclamo.titular;
            LblMemoDependiente.Text = reclamo.asegurado;
            lblNumeroCliente.Text = reclamo.reg_reclamos_medicos.cliente.ToString();
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos del asegurado " + ex.Message, "Nota..!", "warning");
        }
    }

    //seleccionar el correo electronico del ejecutivo que tiene asignado el reclamo
    private void seleccionarCorreo()
    {
        try
        {
            var correoGestor = DBReclamos.gestores.Select(g => new { g.correo, g.usuario }).Where(c => c.usuario == userlogin).First();
            correo = correoGestor.correo;
        }
      
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    //enviar un correo electronico e insertarlo en los comentarios del reclamo
    public void enviarcorreo()
    {
        try
        {
            string from = correo;
            string password = txtPassword.Text;
            string to = txtDestinatario.Text;
            string mensaje = txtMensaje.Text;
            string asunto = txtAsunto.Text;
            new Email().NOTIFICACION(to, mensaje, asunto);
            Utils.ShowMessage(this.Page, "Correo Enviado con exito", "Excelente..!", "success");
            agregarComentario("Envio de correo: \n" + txtMensaje.Text);
            GridComentarios.DataBind();
        }

        catch (SmtpException ex)
        {
            Utils.ShowMessage(this.Page, "Erorr de autenticacion digite bien su contraseña." + ex.Message, "Nota..!", "warning");
            agregarComentario("Destinatario: " + txtDestinatario.Text + " Asunto: " + txtAsunto.Text + " Cuerpo del mensaje: " + txtMensaje.Text);
            varciarCorreo();
        }
    }
    //vaciar el correo electronico
    public void varciarCorreo()
    {
        txtMensaje.Text  = "";
        txtPassword.Text = "";
        txtAsunto.Text   = "";
        txtDestinatario.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx",false);
    }
    //agregar un comentario nuevo
    private void agregarComentario(String descripcion)
    {
        try
        {
            comentarios_reclamos_medicos comentario = new comentarios_reclamos_medicos();
            comentario.descripcion = descripcion;
            comentario.estado = ddlEstado.SelectedItem.Text;
            comentario.usuario = Constantes.USER();
            comentario.fecha = DateTime.Now;
            comentario.id_reclamo_medico = id;
            DBReclamos.comentarios_reclamos_medicos.Add(comentario);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(comentarios, GridComentarios);
            Utils.ShowMessage(this.Page, "Comentario ingresado con exito", "Excelente..!", "success");
            txtComentarios.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al ingresar el comentario", "Nota..!", "error");
        }
    }
    //evento para guardar un nuevo comentario
    protected void btnGuardarComentario_Click(object sender, EventArgs e)
    {
        agregarComentario(txtComentarios.Text);
        Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 3, Constantes.USER());
    }

    //evento para guardar un correo a los comentarios
    protected void btnEnviarCorreo_Click(object sender, EventArgs e)
    {
        agregarComentario("Para: " + txtDestinatario.Text + "  ,Asunto: " + txtAsunto.Text + "  ,Mensaje: " + txtMensaje.Text);
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        actualizarReclamo();
    }

    //actualiza el reclamo en general
    private void actualizarReclamo()
    {
        var reclamo = DBReclamos.reclamos_medicos.Find(id);
        reclamo.reg_reclamos_medicos.moneda = ddlMonedaPoliza.SelectedValue;
        DBReclamos.SaveChanges();

        String query = "Update reclamos_medicos set asegurado = '" + txtAsegurado.Text + "', telefono = '" + txtTelefono.Text + "', correo = '" + txtCorreo.Text + "', " +
            "tipo_reclamo = '" + DDLTipo.SelectedItem + "', id_estado = " + ddlEstado.SelectedValue + ", fecha_modificacion = getdate(), detalle_cliente = '" + txtdetalle.Text.Replace(Environment.NewLine, "\n") + "', " +
            "observacion = '" + txtObservaciones.Text.Replace(Environment.NewLine, "\n") + "',num_reclamo= '" + txtNumReclamo.Text + "' ";

        if (actualizar.actualizarDatos(query, id))
        {
            if (ddlEstado.SelectedValue == "2")
            {
                cerrarReclamo();
                Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx",false);
            }

            Utils.ShowMessage(this.Page, "Datos actualizados", "Excelente..!", "success");
        }

        else
        {
            Utils.ShowMessage(this.Page, "No se pudieron actualizar los datos", "Error..!", "error");
        }

        lblDocumento.Text = String.IsNullOrEmpty(reclamo.documento) ? "" : reclamo.documento.Replace("\\", "/");
    }

    //guardar detalle de un gasto medico 
    protected void btnguardarDetalle_Click(object sender, EventArgs e)
    {
        GuardarDetalleGasto(id);
        Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 48, Constantes.USER());
    }

    private void GuardarDetalleGasto(int identificador)
    {
        if (txtAgregarGasto.Text != "0.00")
        {
            try
            {
                detalle_gasto_medico detalle = new detalle_gasto_medico();
                detalle.descripcion = ddlDetalleGasto.SelectedItem.Text;
                detalle.cantidad = Convert.ToDecimal(txtAgregarGasto.Text);
                detalle.num_factura = txtNumFactura.Text;
                detalle.fecha_gasto_medico = Convert.ToDateTime(txtFechaGasto.Text);
                detalle.moneda = "Q";
                detalle.id_reclamo_medico = identificador;
                DBReclamos.detalle_gasto_medico.Add(detalle);
                DBReclamos.SaveChanges();
                GridDetalleM.DataBind();
                totalDetalleGasto(id);
                Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + identificador,false);
            }
            catch (Exception)
            {
                Utils.ShowMessage(this.Page,"Al ingresar el detalle las cantidades no deben contenter comas solo puntos decimales..", "Nota..!", "warning");
            }
        }
        else
        {
            Utils.ShowMessage(this.Page, "Para el registro del detalle debe ingresar una cantidad mayor a 0.00, y sin ninguna coma ..", "Revisar..!", "warning");
        }
    }

    private void fechaChequeRecibido()
    {
        var reclamo = DBReclamos.reclamos_medicos.Find(id);

        if (reclamo.bandera_cheque == false)
        {
            try
            {
                var chequeRecibido = DBReclamos.reclamos_medicos.Find(id);
                chequeRecibido.fecha_recepcion_cheque = DateTime.Now;
                chequeRecibido.bandera_cheque = true;
                DBReclamos.SaveChanges();
                tiempos();
                DevolverDatos(id);
            }
            catch (Exception)
            {
            }
        }
    }

    //desabilitar textbox 
    public void inabilitarTextPago()
    {
        txtReclamado.Enabled = false;
        txtAprobado.Enabled = false;
        txtNoCubiertos.Enabled = false;
        txtDeducible.Enabled = false;
        ddlCoaseguro.Enabled = false;
        ddlTimbres.Enabled = false;
        ddlMoneda.Enabled = false;
        btnGuardarPago.Enabled = false;
    }

    //habilitar botones de pago
    public void habilitarTextPago()
    {
        txtReclamado.Enabled = true;
        txtAprobado.Enabled = true;
        txtNoCubiertos.Enabled = true;
        txtDeducible.Enabled = true;
        ddlCoaseguro.Enabled = true;
        ddlTimbres.Enabled = true;
        ddlMoneda.Enabled = true;
        btnGuardarPago.Enabled = true;
    }

    //metodo para aplicar la liquidacion de un reclamo
    private void aplicarLiquidacion()
    {
        montoReclamado = Convert.ToDouble(txtReclamado.Text);
        montoAprobado = Convert.ToDouble(txtAprobado.Text);
        montoNoCubierto = Convert.ToDouble(txtNoCubiertos.Text);
        deducible = Convert.ToDouble(txtDeducible.Text);

        iva = montoAprobado / 1.12;
        totalIva = iva;

        coaseguro = Convert.ToDouble(ddlCoaseguro.SelectedValue) * (iva - deducible);
        totalCoaseguro = coaseguro;
        timbres = Convert.ToDouble(ddlTimbres.SelectedValue) * (totalIva - deducible - coaseguro);
        totalTimbres = timbres;
        montoTotal = (iva - deducible - coaseguro - timbres);
    }

    protected void btnGuardarPago_Click(object sender, EventArgs e)
    {
        aplicarLiquidacion();
        fechaChequeRecibido();

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into detalle_pagos_reclamos_medicos (total_reclamado, total_aprobado, copago, total_no_cubierto, total_iva, deducible,coaseguro, timbres,total, no_cheque,porcen_coaseguro, porcen_timbres, moneda,monto,banco, id_reclamo_medico) values(" + txtReclamado.Text + ", " + txtAprobado.Text +", "+txtCopago.Text+", "+ txtNoCubiertos.Text+", "+totalIva+", "+deducible+","+totalCoaseguro+", "+totalTimbres+","+ montoTotal+",'"+ txtNumeroCheque.Text+"', "+ ddlCoaseguro.SelectedValue +", "+ddlTimbres.SelectedValue+", '"+ ddlMoneda.SelectedItem+"', '"+ txtMontoCheque.Text +"', '"+ddlBanco.SelectedItem+"', " + id + ")";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
            //actualizar la fecha del envio de cheque
            cmd.CommandText = "update reclamos_medicos set fecha_envio_cheque = '"+txtFechaEnvioCheque.Text+"', destino = '"+ddlDestino.SelectedItem+"' where id = "+ id +"";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
            Utils.ShowMessage(this.Page, "Cheque ingresado con exito..!", "Excelente", "success");
            llenado.llenarGrid(pagos, GridPagos);
            txtReclamado.Text = "0.00";
            txtAprobado.Text = "0.00";
            txtNoCubiertos.Text = "0.00";
            txtDeducible.Text = "0.00";
            txtNumeroCheque.Text = "";
            checkAgregar.Enabled = true;
            tiempos();
            inabilitarTextPago();
            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 20, Constantes.USER());
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al realzar el pago..", "Error", "error");
        }
    }

    //metodo para traer el total del gasto medico del reclamo
    public void totalDetalleGasto(int identificador)
    {
        try
        {
            String suma = "select sum(cantidad) from detalle_gasto_medico where id_reclamo_medico = " + identificador + " ";
            SqlDataAdapter da = new SqlDataAdapter(suma, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Double total = Convert.ToDouble(dt.Rows[0][0]);
            lblTotal.Text ="Total: " + total.ToString("N2");
            txtReclamado.Text = total.ToString();
            objeto.conexion.Close();
        }

        catch(Exception)
        {

        }
    }

    //guardar una fecha para que el reclamo aparezca
    protected void btnGuardarProximaFecha_Click(object sender, EventArgs e)
    {
        actualizar.actualizarDatos("update reclamos_medicos set fecha_visualizar = '" + txtProximaFecha.Text + "'", id);
        Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 22, Constantes.USER());
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);

    }

    //cerrar el reclamo
    private void cerrarReclamo()
    {
        try
        {
            var cierre = DBReclamos.reclamos_medicos.Find(id);
            if(cierre.bandera_cierre == false)
            {
                cierre.estado_unity = "Cerrado";
                cierre.id_estado = 2;
                cierre.fecha_cierre = DateTime.Now;
                cierre.hora_cierre = DateTimeOffset.Now.TimeOfDay;
                cierre.bandera_cierre = true;
                cierre.acs = false;
                DBReclamos.SaveChanges();
                Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 24, Constantes.USER());
            }
        }
        catch (Exception)
        {
        }
    }

    //Seleccionar un pago para generar el memo del cliente
    protected void GridPagos_SelectedIndexChanged(object sender, EventArgs e)
    {
       this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#modalPago').modal('show');", addScriptTags: true);
       habilitarTextPago();
       btnActualizarPago.Enabled = true;
       btnGuardarPago.Enabled = false;
       PanelDetalle.Visible = true;
       simboloMoneda();

       identificadorPago = Convert.ToInt32(GridPagos.SelectedRow.Cells[1].Text);

        try
        {
            var memo = DBReclamos.detalle_pagos_reclamos_medicos.Find(identificadorPago);
            Double reclamado, deducible, pagado, Nocubierto;
            txtReclamado.Text = memo.total_reclamado.ToString();
            txtAprobado.Text = memo.total_aprobado.ToString();
            txtCopago.Text = (memo.copago == null) ? "0.00" : memo.copago.ToString();
            txtNoCubiertos.Text = memo.total_no_cubierto.ToString();
            txtDeducible.Text = memo.deducible.ToString();
            ddlCoaseguro.SelectedValue = memo.porcen_coaseguro.ToString();
            ddlTimbres.SelectedValue = memo.porcen_timbres.ToString();
            txtNumeroCheque.Text = memo.no_cheque;
            txtTotalCoaseguro.Text = memo.coaseguro.ToString();
            txtTotalTimbres.Text = memo.timbres.ToString();
            txtMontoCheque.Text = memo.monto.ToString();
            ddlBanco.Text = memo.banco;
            lblMemoPagado.Text = memo.total.ToString();

            //asignar a variables para colocarles despues comas
            reclamado = Convert.ToDouble(memo.total_reclamado);
            deducible = Convert.ToDouble(memo.deducible);
            pagado = Convert.ToDouble(memo.total_aprobado);
            Nocubierto = Convert.ToDouble(memo.total_no_cubierto);

            //labels para la impresion del detalle del cliente
            lblNumeroDeCheque.Text = txtNumeroCheque.Text;
            lblMemoReclamado.Text = simbolo + " " + reclamado.ToString("N2");
            lblMemoDeducible.Text = simbolo + " " + deducible.ToString("N2");
            lblMemoPagado.Text = simbolo + " " + pagado.ToString("N2");
            lblMemoNocubierto.Text = simbolo + " " + Nocubierto.ToString("N2");
            lblCopago.Text = simbolo + " " + memo.copago.ToString();
        }
        catch(Exception ex)
        {
            Response.Write(ex);
            //Utils.ShowMessage(this.Page, "Error al seleccionar el pago", "Nota..!", "error");
        }
    }

    //obtener el simbolo de la moneda para colocarlo en el memo del cliente
    private void simboloMoneda()
    {
        try
        {
            var moneda = DBReclamos.detalle_gasto_medico.Select(m => new { m.moneda, m.id_reclamo_medico }).Where(mon => mon.id_reclamo_medico == id).First();
            simbolo = moneda.moneda;
        }

        catch (Exception)
        {
        }
    }

    //metodo para obtener la fecha de gasto y aplicarla al memo del cliente
    private void ObtenerFechaGasto()
    {
        try
        {
            string fechaMinima = "select convert(nvarchar(20), MIN(fecha_gasto_medico), 103)  from detalle_gasto_medico where id_reclamo_medico = " + id + "";
            SqlDataAdapter da = new SqlDataAdapter(fechaMinima, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            MinimaFechaGastoMedico = dt.Rows[0][0].ToString();
            objeto.conexion.Close();
        }

        catch (Exception)
        {
        }

        finally
        {
            objeto.DescargarConexion();
        }
    }

    //actualizar una liquidacion
    private void ActualizarLiquidacion()
    {
        identificadorPago = Convert.ToInt32(GridPagos.SelectedRow.Cells[1].Text);
        try
        {
            var pago = DBReclamos.detalle_pagos_reclamos_medicos.Find(identificadorPago);
            var reclamo = DBReclamos.reclamos_medicos.Find(id);

            pago.total_reclamado = Convert.ToDecimal(txtReclamado.Text);
            pago.total_aprobado = Convert.ToDecimal(txtAprobado.Text);
            pago.total_no_cubierto = Convert.ToDecimal(txtNoCubiertos.Text);
            pago.deducible = Convert.ToDecimal(txtDeducible.Text);
            pago.no_cheque = txtNumeroCheque.Text;
            pago.porcen_coaseguro = Convert.ToDecimal(ddlCoaseguro.SelectedValue);
            pago.porcen_timbres = Convert.ToDecimal(ddlTimbres.SelectedValue);
            pago.coaseguro = Convert.ToDecimal(txtTotalCoaseguro.Text);
            pago.timbres = Convert.ToDecimal(txtTotalTimbres.Text);
            pago.total = Convert.ToDecimal(txtTotal.Text);
            pago.copago = (PanelCopago.Visible == true) ? Convert.ToDecimal(txtCopago.Text) : Convert.ToDecimal(0.00);
            reclamo.fecha_envio_cheque = Convert.ToDateTime(txtFechaEnvioCheque.Text);
            reclamo.destino = ddlDestino.SelectedItem.Text;
            DBReclamos.SaveChanges();

            llenado.llenarGrid(pagos, GridPagos);
            GridPagos.DataBind();
            Utils.ShowMessage(this.Page, "Liquidacion actualizada con exito", "Excelente", "success");
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudo actualizar la liquidacion, revise que los campos no tengan comas, solo se permiten puntos decimales.", "Error", "error");
        }
    }

    //evento para actualizar una liquidacion
    protected void btnActualizarPago_Click(object sender, EventArgs e)
    {
        ActualizarLiquidacion();
        Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 21, Constantes.USER());
    }

    //carga las direcciones disponibles del asegurado segun el sistema
    private void cargarDirecciones()
    {
        try
        {
            string selectDireccion = "select direccion from direcciones_clientes_gm where poliza = '" + txtPoliza.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(selectDireccion, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlDirecciones.DataTextField = "direccion";
            ddlDirecciones.DataValueField = "direccion";
            ddlDirecciones.DataSource = dt;
            ddlDirecciones.DataBind();
            objeto.conexion.Close();
        }

        catch (Exception)
        {
        }

        finally
        {
            objeto.DescargarConexion();
        }
    }

    protected void btnEnviarCorreoElectronico_Click(object sender, EventArgs e)
    {
        enviarcorreo();
    }

    //habilitar el texbox que contiene el numero del reclamo brindado por la aseguradora
    protected void checkHabilitar_CheckedChanged(object sender, EventArgs e)
    {
        if(checkHabilitar.Checked)
        {
            txtNumReclamo.Enabled = true;
        }
        else
        {
            txtNumReclamo.Enabled = false;
        }
    }

    //regresar a los reclamos en seguimiento
    protected void Regresar_Click(object sender, EventArgs e)
    {
        actualizarReclamo();
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
    }

    //borra registros de detalles medicos
    protected void GridDetalleM_SelectedIndexChanged(object sender, EventArgs e)
    {
        int registro = Convert.ToInt32(GridDetalleM.SelectedRow.Cells[6].Text);
        try
        {
            var borrar = DBReclamos.detalle_gasto_medico.Find(registro);
            DBReclamos.detalle_gasto_medico.Remove(borrar);
            DBReclamos.SaveChanges();
            GridDetalleM.DataBind();
            totalDetalleGasto(id);
            GridDetalleGMAseguradora.DataBind();
            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 46, Constantes.USER());
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al borrar el registro", "Nota..!", "eroor");
        }
    }

    //generar memo para el cliente
    protected void checkAgregar_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            var RecMemoCliente = DBReclamos.reclamos_medicos.Find(id);
            if (checkAgregar.Checked)
            {
                ObtenerFechaGasto();
                string valor = (ddlEstado.SelectedValue == "2") ? "2" : "4";
                ddlEstado.SelectedValue = valor;
                actualizarMemos();
                lblMemoDetalleCliente.Text = txtdetalle.Text.Replace("\n", "<br/>");
                lblFechaGastoMedico.Text   = MinimaFechaGastoMedico;
                lblMemoContratante.Text    = txtContacto.Text + " <br /> " + RecMemoCliente.empresa;
                lblMemoAsunto.Text         = "Reclamo No. " + txtNumReclamo.Text;
                lblMemoDireccion.Text = ddlDirecciones.Items.Count > 0 ? ddlDirecciones.SelectedItem.Text : txtDireccion.Text;

                if(txtEjecutivo.Text != "")
                {
                    lblMemoDe.Text = txtEjecutivo.Text;
                    lblCartaEjecutivo2.Text =txtEjecutivo.Text;
                }
                else
                {
                    lblMemoDe.Text = RecMemoCliente.reg_reclamos_medicos.ejecutivo;
                    lblCartaEjecutivo2.Text = RecMemoCliente.reg_reclamos_medicos.ejecutivo;
                }
            }

            if (ddlEstado.SelectedValue == "4" && RecMemoCliente.bandera_asegurado == false)
            {
                try
                {
                    var updateFecha = DBReclamos.reclamos_medicos.Find(id);
                    DateTime fecha = Convert.ToDateTime(updateFecha.fecha_envio_cheque);
                    updateFecha.bandera_asegurado = true;
                    DBReclamos.SaveChanges();
                    tiempos();
                    
                    if (ddlDestino.SelectedValue == "1")
                    {
                        mensaje = "UNITY: Estimad@ cliente la liquidación de su reclamo, estará siendo enviada el " + fecha.ToString("dd/MM/yyyy") + " a su dirección registrada.";
                    }
                    else if(ddlDestino.SelectedValue == "2")
                    {
                        mensaje = "UNITY: Estimad@ cliente la liquidación de su reclamo ID: "+ updateFecha.id +" se encuentra lista en recepción.";
                    }
                    else if(ddlDestino.SelectedValue == "3")
                    {
                        mensaje = "UNITY: Estimad@ cliente su reclamo fue abonado a su deducible anual enviamos copia de la liquidación a su correo.";
                    }

                   // Utils.SMS_gastos_medicos(updateFecha.telefono, mensaje, userlogin, ddlEstado. SelectedItem.Text, id, updateFecha.reg_reclamos_medicos.tipo);
                    llenado.llenarGrid(comentarios,GridComentarios);
                }
                catch (Exception)
                {

                }
            }

            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 44, Constantes.USER());
        }

        catch(Exception)
        {
            lblMemoDireccion.Text = txtDireccion.Text;
            lblMemoDe.Text = txtEjecutivo.Text;
            lblCartaEjecutivo2.Text = txtEjecutivo.Text;
        }
    }

    //imprimir memo para aseguradora
    protected void CheckMemoAseguradora_CheckedChanged(object sender, EventArgs e)
    {
        var rec = DBReclamos.reclamos_medicos.Find(id);
 
        if (CheckMemoAseguradora.Checked)
        {
            lblTituloMemoAseguradora.Text = "Envío Aseguradora";
            lblCartaObservacion.Text = txtObservaciones.Text.Replace("\n", "<br/>");;
            lblCartaEjecutivo.Text   = rec.reg_reclamos_medicos.ejecutivo;
            lblCartaEjecutivo2.Text  = rec.reg_reclamos_medicos.ejecutivo;
            ddlEstado.SelectedValue = (ddlEstado.SelectedValue == "2") ? "2" : "5";
            actualizarMemos();
            tiempos();

            if (txtEjecutivo.Text != "")
            {
                lblCartaEjecutivo.Text = txtEjecutivo.Text;
                lblCartaEjecutivo2.Text = txtEjecutivo.Text;
            }
        }

        if (ddlEstado.SelectedValue == "5" && rec.bandera_aseguradora == false)
        {
            try
            {
                var reclamo = DBReclamos.reclamos_medicos.Find(id);
                string moneda = reclamo.reg_reclamos_medicos.moneda;

                int dias;

                dias = moneda.Equals("Quetzales") ? 15 : 35;

                var fechaEnvio = DBReclamos.reclamos_medicos.Find(id);
                fechaEnvio.fecha_envio_aseg = DateTime.Now;
                fechaEnvio.fecha_visualizar = DateTime.Now.AddDays(dias);
                fechaEnvio.bandera_aseguradora = true;
                DBReclamos.SaveChanges();
                tiempos();
                
                Utils.SMS_gastos_medicos(fechaEnvio.telefono, mensaje, userlogin, ddlEstado.SelectedItem.Text,id, fechaEnvio.reg_reclamos_medicos.tipo);
                GridComentarios.DataBind();
            }

            catch (Exception ex)
            {
                Utils.ShowMessage(this.Page, "Error al generar el memo" + ex.Message, "Nota..!", "warning");
            }
        }

        Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 45, Constantes.USER());
    }

    public void actualizarMemos()
    {
        var update = DBReclamos.reclamos_medicos.Find(id);
        update.observacion     = txtObservaciones.Text;
        update.detalle_cliente = txtdetalle.Text;
        update.id_estado       = Convert.ToInt32(ddlEstado.SelectedValue);
        update.num_reclamo     = txtNumReclamo.Text;
        if(txtDireccion.Text == "" && ddlDirecciones.Items.Count == 0)
        {
            //update.direccion = "";
        }
        else
        {
            update.direccion = (txtDireccion.Text == "") ? ddlDirecciones.SelectedItem.Text : txtDireccion.Text;
        }
       
        DBReclamos.SaveChanges();
    }

    //funcion para realizar una sumatoria y colocar el total en la parte de abajo del grid
    protected void GridDetalleGMAseguradora_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumaTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTAL:";
                e.Row.Cells[3].Text = sumaTotal.ToString("N2");
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
            }
        }
        catch (Exception)
        {
        }
    }
    //funcion para aplicar los saltos de linea a los registros en los comentarios
    protected void GridComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("\n", "<br/>");
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    //funcion que sirve para retornar las fechas en que a sido trabajado el reclamo
    //asi como tambien retorna el tiempo total que el reclamo tiene desde que entro a unity
    public void tiempos()
    {
        try
        {
            string seleccionar = "";
            string tiemposCerrado = "select DATEDIFF(SECOND, fecha_commit, fecha_cierre)," +
            "fecha_commit, fecha_asignacion, fecha_apertura, fecha_envio_aseg, fecha_recepcion_cheque, convert(nvarchar(20), fecha_envio_cheque, 103), fecha_cierre, destino" +
            " from reclamos_medicos where id = " + id + "";

            string tiemposAbierto = "select DATEDIFF(SECOND, fecha_commit, getdate())," +
            "fecha_commit, fecha_asignacion, fecha_apertura, fecha_envio_aseg, fecha_recepcion_cheque, convert(nvarchar(20), fecha_envio_cheque, 103), fecha_cierre, destino" +
            " from reclamos_medicos where id = "+id+"";

            seleccionar = (ddlEstado.SelectedItem.Text == "Cerrado") ? tiemposCerrado : tiemposAbierto;

            SqlDataAdapter da = new SqlDataAdapter(seleccionar, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtTiempo.Text = dt.Rows[0][0].ToString();

            lblFechaRecepcion.Text     = titulo_tiempo("recepcion", dt.Rows[0][1].ToString());
            lblfechaAsignacion.Text    = titulo_tiempo("asignacion", dt.Rows[0][2].ToString());
            lblFechaApertura.Text      = titulo_tiempo("apertura", dt.Rows[0][3].ToString());
            lblFechaAseguradora.Text   = titulo_tiempo("envio aseguradora", dt.Rows[0][4].ToString());
            lblFechaEnvioCheque.Text   = titulo_tiempo("cheque recibido", dt.Rows[0][5].ToString());
            lblEnvioCheque.Text        = titulo_tiempo("envio de cheque", dt.Rows[0][6].ToString());
            lblFechaCierreReclamo.Text = titulo_tiempo("cierre", dt.Rows[0][7].ToString());
            lblDestino.Text = "<b>Destino: </b>" + dt.Rows[0][8].ToString();
        }
        catch (Exception)
        {

        }
        finally
        {
            objeto.DescargarConexion();
        }
    }

    public string titulo_tiempo(string val, string condicion)
    {
        return "<b>Fecha de "+val+"</b><br/>" + (condicion == "" ? "En espera": condicion);
    }

    //cambiar el simbolo de la moneda en que se esta trabajando
    protected void checkMoneda_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            var simbolo = DBReclamos.detalle_gasto_medico.Where(s => s.id_reclamo_medico == id);

            foreach (var sim in simbolo)
            {
                sim.moneda = (checkMoneda.Checked) ? "$" : "Q";
            }

            DBReclamos.SaveChanges();
            GridDetalleM.DataBind();
            GridDetalleGMAseguradora.DataBind();
            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 47, Constantes.USER());
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page,"No se pudo cambiar el tipo de moneda", "Nota..!","warning");
        }
    }

    protected void btnCerrarReclamo_Click(object sender, EventArgs e)
    {
        cerrarReclamo();
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
    }
    //modal de confirmacion de notificacion sms para solicitud de documentos.
    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlEstado.SelectedValue == "4")
        {
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar-sms').modal('show');", addScriptTags: true);
        }
    }

    protected void btnEnviarSMS_Click(object sender, EventArgs e)
    {
        string smsAsegurado = "Estimad@ cliente le recordamos enviarnos la documentación pendiente para poder continuar con el proceso de su reclamo ID: "+id+"";
        Utils.SMS_gastos_medicos(txtTelefono.Text,smsAsegurado,userlogin,"Asegurado",id, lblTipo.Text );
        llenado.llenarGrid(comentarios, GridComentarios);

        var rec = DBReclamos.reclamos_medicos.Find(id);
        rec.fecha_espera_asegurado = DateTime.Now;
        rec.fecha_envio_notificacion = Convert.ToDateTime(rec.fecha_espera_asegurado).AddDays(5);
        rec.id_estado = 4;
        DBReclamos.SaveChanges();
    }

    protected void btnProductoNoConforme_Click(object sender, EventArgs e)
    {
        try
        {
            var noConforme = DBReclamos.reclamos_medicos.Find(id);

            if (ddlEstadoNoConforme.SelectedValue == "Abierto")
            {
                noConforme.no_conforme = true;
                noConforme.detalle_no_conforme = ddlNoConforme.SelectedValue;
                noConforme.fecha_no_conforme = DateTime.Now;
                noConforme.observacion_no_conforme = txtObservacionesNoConf.Text;
                DBReclamos.SaveChanges();
                agregarComentario("Este reclamo ha sido encontrado como no conforme, catalogado como " + ddlNoConforme.SelectedValue + ". " + txtObservacionesNoConf.Text);
                llenado.llenarGrid(comentarios, GridComentarios);
                Utils.ShowMessage(this.Page, "Reclamo Actualizado como producto no conforme.", "Excelente", "info");
            }

            else
            {
                noConforme.no_conforme = false;
                noConforme.fecha_cierre_no_conforme = DateTime.Now;
                DBReclamos.SaveChanges();
                agregarComentario("La incorformidad encontrada en el reclamo por: " + ddlNoConforme.SelectedValue + ", a sido solventada. ");
                llenado.llenarGrid(comentarios, GridComentarios);
                Utils.ShowMessage(this.Page, "Reclamo Actualizado como producto no conforme.", "Excelente", "info");
            }

            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 16, Constantes.USER());
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el reclamo como no conforme.", "Error", "error");
        }
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        //String path = @"C:\Reclamos\GastosMedicos";
        String path = @"E:\ReclamosScanner\files\GastosMedicos";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String RM;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String nombreArchivo = SubirArchivo.FileName;
        var reclamo = DBReclamos.reclamos_medicos.Find(id);

        try
        {
            if (SubirArchivo.HasFile)
            {
                if (String.IsNullOrEmpty(reclamo.documento))
                {
                    RM = anio + "\\" + mes + "\\" + "RM" + id;
                }

                else
                {
                    RM = reclamo.documento;
                }

                if (Directory.Exists(path + "\\" + RM))
                {
                    SubirArchivo.SaveAs(path + "\\" + RM + "\\" + nombreArchivo);
                    Utils.ShowMessage(this.Page, "Archivo Subido con exito ", "Excelente..", "success");
                    reclamo.documento = RM;
                    DBReclamos.SaveChanges();
                }

                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path + "\\" + RM);
                    SubirArchivo.SaveAs(path + "\\" + RM + "\\" + nombreArchivo);
                    Utils.ShowMessage(this.Page, "Archivo Subido con exito ", "Excelente..", "success");
                    reclamo.documento = RM;
                    DBReclamos.SaveChanges();
                }
            }

            Utils.actividades(id, Constantes.GASTOS_MEDICOS(), 17, Constantes.USER());
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido subir el archivo " + ex, "Error..", "error");
        }
    }

    protected void chGenerarMemoProductoNoConforme_CheckedChanged(object sender, EventArgs e)
    {
        lblTituloMemoAseguradora.Text = "Producto No Conforme";
        lblCartaObservacion.Text = txtObservacionesNoConf.Text;
    }
}
