using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosSeguimientos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    ReclamosEntities DBReclamos = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    Utils actualizar = new Utils();
    DateTime thisDay = DateTime.Today;
    string metodo = "sistema";
    string idRecibido; //id de la ultima transaccion de la tabla reclamo_auto
    String comentarios, Documentos, pagos, datosReclamos, detalle_gastos, detalle_gastos2, updateFecha, correo, simbolo, MinimaFechaGastoMedico;
    int id, totalDias, identificadorPago;
    Double total;
    Decimal sumaTotal;
    Double montoReclamado, montoAprobado, montoNoCubierto, montoConIva, montoConDeducible, deducible, iva, timbres, coaseguro, montoTotal, totalIva, totalCoaseguro, totalTimbres;
    bool bandera_asegurado;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        id = Int32.Parse(idRecibido);
        lblId.Text = "<b>No.</b>" + id.ToString();
        labelID.Text = "<b>ID: </b>" + id.ToString();
        lblFechaEnvioCliente.Text = thisDay.ToString("D");
        lblIdOculto.Text = idRecibido;

        Documentos = "select descripcion as Descripcion, comentarios as Comentarios, cantidad as Cantidad from recibos_medicos where id_reclamo_medico =" + id + " ";
        comentarios = "select descripcion as Descripcion, usuario, fecha as [Fecha Y Hora], estado as Estado from comentarios_reclamos_medicos where id_reclamo_medico = " + id + " order by fecha desc ";
        pagos = "select id as ID, monto as [Monto Cheque], total_reclamado as [Total Reclamado], total_aprobado as [Total Aprobado],total_no_cubierto as [Total no cubierto], deducible as Deducible, coaseguro as Coaseguro,  timbres as Timbres, no_cheque as [No. cheque], moneda as Moneda from detalle_pagos_reclamos_medicos where id_reclamo_medico = " + id + "";

        if (Verificar())
        {
            if (!IsPostBack)
            {
                DevolverDatos(id);
                llenado.llenarGrid(Documentos, GridRecibo);
                llenado.llenarGrid(comentarios, GridComentarios);
                llenado.llenarGrid(pagos, GridPagos);
                totalDetalleGasto(id);
                cargarDirecciones();
                tiempos();
            }
        }

        else
        {
            Utils.ShowMessage(this.Page, "Este reclamo no esta aperturado", "Nota..!", "error");
        }
    }

    public bool Verificar()
    {
        bool aperturado = true;
        try
        {
            var revisar = DBReclamos.reclamos_medicos.Select(f => new { f.fecha_apertura, f.fecha_asignacion, f.id }).Where(fe => fe.id == id).First();
            if (revisar.fecha_asignacion == null || revisar.fecha_apertura == null)
            {
                aperturado = false;
                panelPrincipal.Visible = false;
                panelInformacion.Visible = true;
            }
        }

        catch (Exception)
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
            txtAsegurado.Text = reclamo.reg_reclamos_medicos.asegurado;
            txtAseguradora.Text = reclamo.reg_reclamos_medicos.aseguradora;
            txtPoliza.Text = reclamo.reg_reclamos_medicos.poliza;
            txtCorreo.Text = reclamo.correo;
            txtTelefono.Text = reclamo.telefono;
            txtDestinatario.Text = reclamo.correo;
            DDLTipo.Text = reclamo.tipo_reclamo;
            ddlEstado.SelectedValue = reclamo.estado.id.ToString();
            txtValorEstado.Text = reclamo.estado.id.ToString();
            txtdetalle.Text = reclamo.detalle_cliente;
            txtObservaciones.Text = reclamo.observacion;
            txtObservaciones.Text.Replace("<br/>", "\n");
            txtNumReclamo.Text = reclamo.num_reclamo;

            if (ddlEstado.SelectedItem.Text == "Cerrado")
            {
                lblEstadoReclamo.ForeColor = System.Drawing.Color.Red;
            }

            lblEstadoReclamo.Text = ddlEstado.SelectedItem.Text;

            //Informacion lateral derecha
            lblAsegurado2.Text = "<b>Asegurado:</b>        " + reclamo.reg_reclamos_medicos.asegurado;
            lblPoliza2.Text = "<b>Poliza:</b>              " + reclamo.reg_reclamos_medicos.poliza;
            lblRamo.Text = "<b>Ramo:</b>                   " + reclamo.reg_reclamos_medicos.ramo;
            lblRamoMemo.Text = reclamo.reg_reclamos_medicos.ramo;
            lblTipo.Text = "<b>Tipo:</b>                   " + reclamo.reg_reclamos_medicos.tipo;
            lblClase.Text = "<b>Clase:</b>                 " + reclamo.reg_reclamos_medicos.clase;
            lblClaseOculto.Text = reclamo.reg_reclamos_medicos.clase;
            lblEjecutivo.Text = "<b>Ejecutivo:</b>         " + reclamo.reg_reclamos_medicos.ejecutivo;
            lblAseguradora2.Text = "<b>Aseguradora:</b>    " + reclamo.reg_reclamos_medicos.aseguradora;
            lblContratante.Text = "<b>Contratante:</b>     " + reclamo.empresa;
            lblEstado.Text = "<b>Estado:</b>               " + reclamo.reg_reclamos_medicos.estado_poliza;
            lblVip.Text = "<b>VIP:</b>                     " + reclamo.reg_reclamos_medicos.vip;
            lblMoneda.Text = "<b>Moneda:</b>               " + reclamo.reg_reclamos_medicos.moneda;

            //inabilitar text de pagos si la bandera de pago esta en true;
            if (reclamo.bandera_cheque == true)
            {
                inabilitarTextPago();
            }

            if (reclamo.bandera_cierre == true)
            {
                ddlEstado.Enabled = false;
            }

            //memo envio aseguradora
            lblCartaDestinatario.Text = "Depto de reclamos de " + reclamo.reg_reclamos_medicos.aseguradora;
            lblCartaEjecutivo.Text = reclamo.reg_reclamos_medicos.ejecutivo;
            lblCartaPoliza.Text = reclamo.reg_reclamos_medicos.poliza;
            lblCartaContratante.Text = reclamo.empresa;
            lblCartaId.Text = reclamo.id.ToString();
            lblCartaFechaCreacion.Text = reclamo.fecha_commit.ToString();
            lblCartaEjecutivo2.Text = reclamo.reg_reclamos_medicos.ejecutivo;
            lblCartaAseguradoPrincipal.Text = reclamo.titular;
            lblCartaCertificado.Text = reclamo.reg_reclamos_medicos.certificado;
            lblCartaDependiente.Text = reclamo.reg_reclamos_medicos.asegurado;
            lblCartaObservacion.Text = reclamo.observacion;
            lblNumeroClienteInterno.Text = reclamo.reg_reclamos_medicos.cliente.ToString();

            if (lblClaseOculto.Text == "Principal")
            {
                lblCartaDependiente.Text = "";
            }

            //memo al cliente
            if (lblClaseOculto.Text == "Dependiente")
            {
                lblMemoAsegurado.Text = lblCartaDependiente.Text;
            }
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
            lblMemoDetalleCliente.Text = reclamo.detalle_cliente;
            lblMemoPoliza.Text = reclamo.reg_reclamos_medicos.poliza;
            lblMemoCertificado.Text = reclamo.reg_reclamos_medicos.certificado;
            lblMemoTitular.Text = reclamo.titular;
            lblNumeroCliente.Text = reclamo.reg_reclamos_medicos.cliente.ToString();

            //seccion de fechas

            if (reclamo.fecha_modificacion.ToString() != "")
            {
                txtFechaModificado.Text = "Ultima Modificacion: " + reclamo.fecha_modificacion;
            }
            if (reclamo.fecha_envio_cheque.ToString() != "")
            {
                txtFechaEnvioCheque.Text = Convert.ToDateTime(reclamo.fecha_envio_cheque).ToString("yyyy/MM/dd").Replace("/", "-");
            }

            //datos imprimir formulario para aseguardo
            lblAsegurado.Text = "<ins>" + reclamo.reg_reclamos_medicos.asegurado + "</ins>";
            lblAseguradora.Text = "<ins>" + reclamo.reg_reclamos_medicos.aseguradora + "</ins>";
            lblpoliza.Text = "<ins>" + reclamo.reg_reclamos_medicos.poliza + "</ins>";
            lblEmpresa.Text = "<ins>" + reclamo.empresa + "</ins>";
            lblfechaCreacion.Text = "<ins>" + reclamo.fecha_commit + "</ins>";

        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos del asegurado", "Nota..!", "warning");
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
        seleccionarCorreo();

        bool insertar = true;
        try
        {
            string from = correo;
            string password = txtPassword.Text;
            string to = txtDestinatario.Text;
            string mensaje = txtMensaje.Text;
            string asunto = txtAsunto.Text;
           // new Email().enviarcorreo(from, password, to, mensaje, asunto);
            Utils.ShowMessage(this.Page, "Correo Enviado con exito", "Excelente..!", "success");
        }

        catch (SmtpException)
        {
            Utils.ShowMessage(this.Page, "Erorr de autenticacion digite bien su contraseña", "Nota..!", "warning");
            insertar = false;
        }

        if (insertar == true)
        {
            agregarComentario("Destinatario: " + txtDestinatario.Text + " Asunto: " + txtAsunto.Text + " Cuerpo del mensaje: " + txtMensaje.Text);
            varciarCorreo();
        }
    }
    //vaciar el correo electronico
    public void varciarCorreo()
    {
        txtMensaje.Text = "";
        txtPassword.Text = "";
        txtAsunto.Text = "";
        txtDestinatario.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
    //agregar un comentario nuevo
    private void agregarComentario(String descripcion)
    {
        try
        {
            comentarios_reclamos_medicos comentario = new comentarios_reclamos_medicos();
            comentario.descripcion = descripcion;
            comentario.estado = ddlEstado.SelectedItem.Text;
            comentario.usuario = userlogin;
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

        String query = "Update reclamos_medicos set asegurado = '" + txtAsegurado.Text + "', telefono = '" + txtTelefono.Text + "', correo = '" + txtCorreo.Text + "', tipo_reclamo = '" + DDLTipo.SelectedItem + "', id_estado = " + ddlEstado.SelectedValue + ", fecha_modificacion = getdate(), detalle_cliente = '" + txtdetalle.Text + "', observacion = '" + txtObservaciones.Text + "',num_reclamo= '" + txtNumReclamo.Text + "' ";

        if (actualizar.actualizarDatos(query, id))
        {
            if (ddlEstado.SelectedValue == "2")
            {
                cerrarReclamo();
                Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
            }

            DevolverDatos(id);
            Utils.ShowMessage(this.Page, "Datos actualizados", "Excelente..!", "success");
        }
        else
        {
            Utils.ShowMessage(this.Page, "No se pudieron actualizar los datos", "Error..!", "error");
        }
    }

    //guardar detalle de un gasto medico 
    protected void btnguardarDetalle_Click(object sender, EventArgs e)
    {
        GuardarDetalleGasto(id);
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
                Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + identificador);
            }
            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "Al ingresar el detalle las cantidades no deben contenter comas solo puntos decimales..", "Nota..!", "warning");
            }
        }
        else
        {
            Utils.ShowMessage(this.Page, "Para el registro del detalle debe ingresar una cantidad mayor a 0.00 ..", "Revisar..!", "warning");
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
            cmd.CommandText = "insert into detalle_pagos_reclamos_medicos (total_reclamado, total_aprobado, total_no_cubierto, total_iva, deducible,coaseguro, timbres,total, no_cheque,porcen_coaseguro, porcen_timbres, moneda,monto,banco, id_reclamo_medico) values(" + txtReclamado.Text + ", " + txtAprobado.Text + ", " + txtNoCubiertos.Text + ", " + totalIva + ", " + deducible + "," + totalCoaseguro + ", " + totalTimbres + "," + montoTotal + ",'" + txtNumeroCheque.Text + "', " + ddlCoaseguro.SelectedValue + ", " + ddlTimbres.SelectedValue + ", '" + ddlMoneda.SelectedItem + "', '" + txtMontoCheque.Text + "', '" + ddlBanco.SelectedItem + "', " + id + ")";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
            //actualizar la fecha del envio de cheque
            cmd.CommandText = "update reclamos_medicos set fecha_envio_cheque = '" + txtFechaEnvioCheque.Text + "', destino = '" + ddlDestino.SelectedItem + "' where id = " + id + "";
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
            tiempos();
            inabilitarTextPago();
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
            lblTotal.Text = "Total: " + total.ToString("N2");
            objeto.conexion.Close();
        }

        catch (Exception)
        {

        }
    }

    //guardar una fecha para que el reclamo aparezca
    protected void btnGuardarProximaFecha_Click(object sender, EventArgs e)
    {
        actualizar.actualizarDatos("update reclamos_medicos set fecha_visualizar = '" + txtProximaFecha.Text + "'", id);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
    }

    //cerrar el reclamo
    private void cerrarReclamo()
    {
        try
        {
            var cierre = DBReclamos.reclamos_medicos.Find(id);
            cierre.estado_unity = "Cerrado";
            cierre.id_estado = 2;
            cierre.fecha_cierre = DateTime.Now;
            cierre.hora_cierre = DateTimeOffset.Now.TimeOfDay;
            cierre.bandera_cierre = true;
            cierre.acs = false;
            DBReclamos.SaveChanges();
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
        lblTotalCoaseguro.Visible = true;
        lblTotalTimbres.Visible = true;
        txtTotalCoaseguro.Visible = true;
        txtTotalTimbres.Visible = true;
        lblTotalLiquidacion.Visible = true;
        txtTotal.Visible = true;
        simboloMoneda();

        identificadorPago = Convert.ToInt32(GridPagos.SelectedRow.Cells[1].Text);

        try
        {
            var memo = DBReclamos.detalle_pagos_reclamos_medicos.Find(identificadorPago);
            Double reclamado, deducible, pagado, Nocubierto;
            txtReclamado.Text = memo.total_reclamado.ToString();
            txtAprobado.Text = memo.total_aprobado.ToString();
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
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al seleccionar el pago", "Nota..!", "error");
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
        if (checkHabilitar.Checked)
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
        Response.Redirect("/MdBitacora/DashboardUnity.aspx", false);
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
                lblMemoDetalleCliente.Text = txtdetalle.Text;
                lblFechaGastoMedico.Text = MinimaFechaGastoMedico;

                if (ddlDirecciones.Items.Count > 0)
                {
                    lblMemoDireccion.Text = ddlDirecciones.Text;
                    lblMemoDe.Text = txtEjecutivo.Text;
                    lblCartaEjecutivo2.Text = txtEjecutivo.Text;
                }

                else
                {
                    lblMemoDireccion.Text = txtDireccion.Text;
                    lblMemoDe.Text = txtEjecutivo.Text;
                    lblCartaEjecutivo2.Text = txtEjecutivo.Text;
                }
            }

            if (ddlEstado.SelectedValue == "4" && RecMemoCliente.bandera_asegurado == false)
            {
                try
                {
                    var updateFecha = DBReclamos.reclamos_medicos.Find(id);
                    updateFecha.fecha_espera_asegurado = DateTime.Now;
                    updateFecha.bandera_asegurado = true;
                    DBReclamos.SaveChanges();
                    tiempos();
                }
                catch (Exception)
                {
                }
            }
        }

        catch (Exception)
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
            lblCartaObservacion.Text = txtObservaciones.Text;
            string valor = (ddlEstado.SelectedValue == "2") ? "2" : "5";
            ddlEstado.SelectedValue = valor;
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
                var dias = DBReclamos.aseguradoras.Select(d => new { d.total_dias_rc_medicos, d.aseguradora }).Where(t => t.aseguradora == txtAseguradora.Text).First();
                totalDias = Convert.ToInt32(dias.total_dias_rc_medicos);

                var fecha = DBReclamos.reclamos_medicos.Select(f => new { f.fecha_visualizar, f.id }).Where(fe => fe.id == id).First();
                DateTime fecha_v = Convert.ToDateTime(fecha.fecha_visualizar);

                var fechaEnvio = DBReclamos.reclamos_medicos.Find(id);
                fechaEnvio.fecha_envio_aseg = DateTime.Now;
                fechaEnvio.fecha_visualizar = fecha_v.AddDays(totalDias);
                fechaEnvio.bandera_aseguradora = true;
                DBReclamos.SaveChanges();
                tiempos();
            }
            catch (Exception)
            {
            }
        }
    }

    public void actualizarMemos()
    {
        var update = DBReclamos.reclamos_medicos.Find(id);
        update.observacion = txtObservaciones.Text;
        update.detalle_cliente = txtdetalle.Text;
        update.id_estado = Convert.ToInt32(ddlEstado.SelectedValue);
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
            " from reclamos_medicos where id = " + id + "";

            if (ddlEstado.SelectedItem.Text == "Cerrado")
            {
                seleccionar = tiemposCerrado;
            }
            else
            {
                seleccionar = tiemposAbierto;
            }

            SqlDataAdapter da = new SqlDataAdapter(seleccionar, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtTiempo.Text = dt.Rows[0][0].ToString();

            if (dt.Rows[0][1].ToString() == "")
            {
                lblFechaRecepcion.Text = "<b>Fecha de recepcion del reclamo</b><br /> En espera";
            }

            else
            {
                lblFechaRecepcion.Text = "<b>Fecha de recepcion del reclamo</b><br /> " + dt.Rows[0][1].ToString();
            }


            if (dt.Rows[0][2].ToString() == "")
            {
                lblfechaAsignacion.Text = "<b>Fecha de asignacion del reclamo</b><br />En espera ";
            }

            else
            {
                lblfechaAsignacion.Text = "<b>Fecha de asignacion del reclamo</b><br /> " + dt.Rows[0][2].ToString();
            }

            if (dt.Rows[0][3].ToString() == "")
            {
                lblFechaApertura.Text = "<b>Fecha de apertura del reclamo</b><br /> En espera";
            }
            else
            {
                lblFechaApertura.Text = "<b>Fecha de apertura del reclamo</b><br /> " + dt.Rows[0][3].ToString();
            }


            if (dt.Rows[0][4].ToString() == "")
            {
                lblFechaAseguradora.Text = "<b>Fecha de envio a aseguradora</b><br />En Espera";
            }
            else
            {
                lblFechaAseguradora.Text = "<b>Fecha de envio a aseguradora</b><br /> " + dt.Rows[0][4].ToString();
            }
            //fecha de recepcion del cheque
            if (dt.Rows[0][5].ToString() == "")
            {
                lblFechaEnvioCheque.Text = "<b>Fecha de cheque recibido</b><br /> En espera";
            }
            else
            {
                lblFechaEnvioCheque.Text = "<b>Fecha de cheque recibido</b><br /> " + dt.Rows[0][5].ToString();
            }

            //fecha envio cheque
            if (dt.Rows[0][6].ToString() == "")
            {
                lblEnvioCheque.Text = "<b>Fecha envio de cheque</b><br /> En espera";
            }
            else
            {
                lblEnvioCheque.Text = "<b>Fecha envio de cheque</b><br /> " + dt.Rows[0][6].ToString();
            }

            //fecha final de cierre del reclamo
            if (dt.Rows[0][7].ToString() == "")
            {
                lblFechaCierreReclamo.Text = "<b>Fecha de cierre</b><br /> En Espera";
            }
            else
            {
                lblFechaCierreReclamo.Text = "<b>Fecha de cierre</b><br /> " + dt.Rows[0][7].ToString();
                lblDestino.Text = "<b>Destino: </b>" + dt.Rows[0][8].ToString();
            }

        }
        catch (Exception ex)
        {
            //Response.Write(ex);
        }
        finally
        {
            objeto.DescargarConexion();
        }
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
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudo cambiar el tipo de moneda", "Nota..!", "warning");
        }
    }

    protected void btnCerrarReclamo_Click(object sender, EventArgs e)
    {
        cerrarReclamo();
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecMedSeguimiento.aspx", false);
    }
}