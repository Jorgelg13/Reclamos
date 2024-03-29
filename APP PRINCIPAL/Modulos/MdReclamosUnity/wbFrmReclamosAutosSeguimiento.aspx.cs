﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.IO;
using System.Activities.Expressions;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosAutosSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    Utils update = new Utils();
    DateTime thisDay = DateTime.Today;
    Email notificacion = new Email();
    bool importacion = false;
    bool prioritario = false;
    bool alquiler = false;
    bool perdidaTotal = false;
    bool complicado = false;
    bool compromiso_pago = false;
    bool cierre_interno = false;
    bool robo = false;
    String estado = "Seguimiento";//esta variable es la que se utiliza para cambiar el estado a cerrado de un reclamo.
    String idRecibido, comentarios, pagos, llamadas, coberturas, datosAccidente,estados_autos,documentos, doc_solicitados;
    String cartaDeclinacionReclamo, cartaEnvioCheque, cartaCierreInterno, mensaje;
    int id, dias; 
    //variables para calculos de pagos de reclamos
    Double iva, monto, timbres, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        lblID.Text = idRecibido;
        id = Int32.Parse(idRecibido);
        Session.Add("id_RA", id.ToString());
        var auto = DBReclamos.reclamo_auto.Find(id);

        //variables que contienen los formatos de las cartas a ser impresass
        cartaCierreInterno = Cartas.CARTA_CIERRE_INTERNO_AUTOS(auto);
        cartaDeclinacionReclamo = Cartas.CARTA_DECLINACION_RECLAMOS_AUTOS(auto);
        cartaEnvioCheque = Cartas.CARTA_ENVIO_CHEQUE_AUTOS(auto);

        // variables para llenandos de gridviews utilizados en esta vista
        pagos           = Consultas.PAGOS_AUTOS(id);
        llamadas        = Consultas.LLAMADAS_AUTOS(id);
        coberturas      = Consultas.COBERTURAS_AUTOS(id);
        datosAccidente  = Consultas.DATOS_ACCIDENTE_AUTOS(id);
        comentarios     = Consultas.COMENTARIOS_AUTOS(id);
        estados_autos   = Consultas.ESTADOS_AUTOS(id);
        documentos      = Consultas.SOLICITUD_DOCUMENTOS("Autos");
        doc_solicitados = Consultas.DOCUMENTOS_SOLICITADOS(id, "Autos");
        txtSolicitudDocumentos.Text = "Observaciones";

        if (!IsPostBack)
        {
            llenar_dropdowns();
            datosContacto(id);
            DatosReclamo(id);
            SeleccionarCoberturas(id);
            BitacoraReclamo();
            //funciones para llenar los gridview utilizados
            llenado.llenarGrid(pagos, GridPagosReclamos);
            llenado.llenarGrid(llamadas, Gridllamadas);
            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            llenado.llenarGrid(datosAccidente, GridDatosAccidente);
            llenado.llenarGrid(comentarios, GridComentarios);
            llenado.llenarGrid(estados_autos, GridEstadosAuto);
            llenado.llenarGrid(documentos, GridDocumentos);
            llenado.llenarGrid(doc_solicitados, GridDocSeleccionados);
            tiempo();
        }

        if (userlogin == "nsierra" || userlogin == "jlaj" || userlogin == "mbarrios" || userlogin =="cmejia")
        {
            btnGuardarProximaFecha.Enabled = true;
        }

        if(lblEstadoAuto.Text == "Congelado")
        {
            if(userlogin != "mbarrios" && userlogin != "jwiesner" && userlogin !="jlaj")
            {
                ddlEstadoAuto.Enabled = false;
                ddlEstadoAuto.SelectedItem.Text = "Congelado";
            }
        }
    }

    public void llenar_dropdowns()
    {
        ddlTipoCierre.DataSource = DBReclamos.motivos_cierre.ToList();
        ddlTipoCierre.DataTextField = "nombre";
        ddlTipoCierre.DataValueField = "id";
        ddlTipoCierre.DataBind();
        
        if(userlogin == "mbarrios" || userlogin =="jwiesner" || userlogin =="jlaj")
        {
            ddlEstadoAuto.DataSource = DBReclamos.estados_reclamos_unity.ToList().Where(au => au.tipo == "auto");
            ddlEstadoAuto.DataTextField = "descripcion";
            ddlEstadoAuto.DataValueField = "descripcion";
            ddlEstadoAuto.DataBind();
        }

        else
        {
            ddlEstadoAuto.DataSource = DBReclamos.estados_reclamos_unity.ToList().Where(au => au.tipo == "auto" && au.descripcion !="Congelado");
            ddlEstadoAuto.DataTextField = "descripcion";
            ddlEstadoAuto.DataValueField = "descripcion";
            ddlEstadoAuto.DataBind();
        }
    }

    //consulta que obtiene la maoyoria de datos de un reclamo
    //y aqui se asigna esos valores a variables y texbox que seran utilizadas para diferentes operaciones
    public void DatosReclamo(int id)
    {
        try
        {
            var reclamo = DBReclamos.reclamo_auto.Find(id);
            //detalle del vehiculo
            txtPlaca.Text  = reclamo.auto_reclamo.placa;
            txtMarca.Text  = reclamo.auto_reclamo.marca;
            txtColor.Text  = reclamo.auto_reclamo.color;
            txtModelo.Text = reclamo.auto_reclamo.modelo;
            txtChasis.Text = reclamo.auto_reclamo.chasis;
            txtMotor.Text  = reclamo.auto_reclamo.motor;
            txtPropietario.Text = reclamo.auto_reclamo.propietario;

            //listado de detalle de poliza
            lblPoliza.Text = "<b>POLIZA :</b>             " + reclamo.auto_reclamo.poliza;
            lblAsegurado.Text = "<b>ASEGURADO :</b>       " + reclamo.auto_reclamo.asegurado;
            lblcliente.Text = "<b>No.Cliente</b>:         " + reclamo.auto_reclamo.cliente;
            lblEjecutivo.Text = "<b>EJECUTIVO :</b>       " + reclamo.auto_reclamo.ejecutivo;
            lblAseguradora.Text = "<b>ASEGURADORA :</b>   " + reclamo.auto_reclamo.aseguradora;
            lblContratante.Text = "<b>CONTRATANTE :</b>   " + reclamo.auto_reclamo.contratante;
            lblEstado.Text = "<b>ESTADO :</b>             " + reclamo.auto_reclamo.estado_poliza;
            lblPrograma.Text = "<b>PROGRAMA :</b>         " + reclamo.auto_reclamo.programa;
            lblTitular.Text = "<b>TITULAR :</b>           " + reclamo.titular;
            lblMoneda.Text = "<b>Moneda :</b>             " + reclamo.auto_reclamo.moneda;
            lblVigi.Text = "<b>VIGENCIA INICIAL :</b>     " + Convert.ToDateTime( reclamo.auto_reclamo.vigencia_inicial).ToString("dd/MM/yyyy");
            lblVigf.Text = "<b>VIGENCIA FINAL: </b>       " + Convert.ToDateTime( reclamo.auto_reclamo.vigencia_final).ToString("dd/MM/yyyy");
            lblBanderaCierreInterno.Text =                    reclamo.b_carta_cierre_interno.Value.ToString();
            lblBanderaDeclinado.Text =                        reclamo.b_carta_declinado.Value.ToString();
            lblBanderaEnvioCheque.Text =                      reclamo.b_carta_envio_cheque.Value.ToString();
            lblBanderaAlertaTiempo.Text =                     reclamo.b_carta_alerta_tiempo.Value.ToString();
            lblProductoNoConforme.Text = "<b>Producto No Conforme Asignado: </b>" + reclamo.detalle_no_conforme;
            txtObservaciones.Text = reclamo.observaciones;
            txtObservacionesNoConf.Text = reclamo.observacion_no_conforme;
            //listado de dropdowns
            ddlEstadoAuto.Text          = reclamo.estado_auto_unity;
            ddlGestor.SelectedValue     = reclamo.id_gestor.ToString();
            ddlTaller.SelectedValue     = reclamo.id_taller.ToString();
            ddlAnalista.SelectedValue   = reclamo.id_analista.ToString();
            ddlTipoCierre.SelectedValue = String.IsNullOrEmpty(reclamo.id_motivo_cierre.ToString()) ? "1": reclamo.id_motivo_cierre.ToString();
            ddlNoConforme.SelectedValue = String.IsNullOrEmpty(reclamo.detalle_no_conforme) ? "" : reclamo.detalle_no_conforme;
            //campos varios
            txtFrom.Text            = reclamo.gestores.correo;
            txtEjecutivo.Text       = reclamo.auto_reclamo.ejecutivo;
            txtGestor.Text          = reclamo.gestores.nombre;
            txtGestorTelefono.Text  = reclamo.gestores.telefono;
            txtFechaSiniestro.Text  = reclamo.fecha.ToString();
            lblNumeroPoliza.Text    = reclamo.auto_reclamo.poliza;
            lblNombreAsegurado.Text = reclamo.auto_reclamo.poliza;
            lblIdReclamo.Text       = "<b>ID:</b>" + reclamo.id;
            txtNumReclamo.Text      = reclamo.num_reclamo;
            lblEstadoAuto.Text      = reclamo.estado_auto_unity;
            lblEstadoReclamo.Text   = reclamo.estado_unity;
            lblDireccionAsegurado.Text = reclamo.auto_reclamo.direccion;
            lblDocumento.Text = String.IsNullOrEmpty(reclamo.documentos) ? "" : reclamo.documentos.Replace("\\", "/");
            lblProximaFecha.Text = "Proxima Fecha:" + Convert.ToDateTime(reclamo.fecha_visualizar).ToString("dd/MM/yyyy");

            if (reclamo.estado_unity == "Cerrado")
            {
                lblEstadoReclamo.ForeColor = System.Drawing.Color.Red;
            }

            //opciones de checks
            checkImportacion.Checked   = reclamo.importacion.Value;
            checkPrioritario.Checked   = reclamo.prioritario.Value;
            CheckComplicado.Checked    = reclamo.complicado.Value;
            checkCompromiso.Checked    = reclamo.compromiso_pago.Value;
            ChecKAutoAlquiler.Checked  = reclamo.alquiler_auto.Value;
            CheckPerdida.Checked       = reclamo.perdida_total.Value;
            checkCierreInterno.Checked = reclamo.cierre_interno.Value;
            CheckRobo.Checked          = reclamo.robo.Value;
            txtReserva.Text            = reclamo.reserva.ToString();

            //informacion del taller asignado
            txtNombreTaller.Text      = reclamo.talleres.nombre;
            txtDireccionTaller.Text   = reclamo.talleres.direccion;
            txtTelefonoTaller.Text    = reclamo.talleres.telefono;
            txtCorreoTaller.Text      = reclamo.talleres.correo;

            //datos del analista
            txtNombreAnalista.Text   = reclamo.analistas.nombre;
            txtTelefonoAnalista.Text = reclamo.analistas.telefono;
            txtCorreoAnalista.Text   = reclamo.analistas.correo;

            //Problemas reportados de talleres, cabina y ajustadores
            chAnalista.Checked          = reclamo.problema_ajustador.Value;
            chCabina.Checked            = reclamo.problema_cabina.Value;
            chTaller.Checked            = reclamo.problema_taller.Value;
            ChAseguradora.Checked       = reclamo.problema_aseguradora.Value;
            chEjecutivo.Checked         = reclamo.problema_ejecutivo.Value;
            txtProblemaAjustador.Text   = reclamo.comentario_ajustador;
            txtProblemaCabina.Text      = reclamo.comentario_cabina;
            txtProblemaTaller.Text      = reclamo.comentario_taller;
            txtProblemaAseguradora.Text = reclamo.comentario_aseguradora;
            txtProblemaEjecutivo.Text   = reclamo.comentario_ejecutivo;

            if (reclamo.estado_unity == "Cerrado") checkCerrarReclamo.Checked = true;

            if (reclamo.no_conforme == false)
            {
                ddlEstadoNoConforme.SelectedItem.Text = "Cerrado";
                ddlEstadoNoConforme.Enabled = false;
                btnProductoNoConforme.Enabled = false;
            }
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "El id ingresado o seleccionado no es valido o no tiene seguimiento " + ex.Message , "A ocurrido un error", "erorr");
        }
    }

    //selecciona el contacto que fue amarrado al reclamo este trae su informacion y la coloca en texbox 
    public void datosContacto(int id)
    {
        try
        {
            var contacto = DBReclamos.contacto_auto.Where(contac => contac.id_reclamo_auto == id).First();
            txtContacto.Text = contacto.contacto;
            txtTelefono.Text = contacto.telefono;
            txtCorreoContacto.Text = contacto.correo;
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer los datos del contaco. " + ex.Message, "Nota..", "warning");
        }
    }

    protected void btnGuardarComentario_Click(object sender, EventArgs e)
    {
        String Comen = WebUtility.HtmlDecode(txtComentarios.Text);
        agregarComentario(Comen);
        Utils.actividades(id, Constantes.AUTOS(),3, Constantes.USER());
    }

    private void agregarComentario(String descripcion)
    {
        try
        {
            comentarios_reclamos_autos comentario = new comentarios_reclamos_autos();
            comentario.descripcion = descripcion;
            comentario.usuario = userlogin;
            comentario.fecha = DateTime.Now;
            comentario.id_reclamo_auto = id;
            DBReclamos.comentarios_reclamos_autos.Add(comentario);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(comentarios, GridComentarios);
            Utils.ShowMessage(this.Page, "Comentario ingresado con exito..", "Excelente..", "success");
            txtComentarios.Text = "";
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error Al ingresar el comentario " + ex.Message, "Error..", "error");
        }
    }

    //metodo para enviar correo electronico y para insertar el correo en los comentarios del reclamo
    public void enviarcorreo()
    {
        bool insertar = true;
        try
        {
            new Email().NOTIFICACION(txtDestinatario.Text, txtMensaje.Text, txtAsunto.Text);
            Utils.ShowMessage(this.Page, "Correo enviado con exito", "Excelente", "success");
        }

        catch(SmtpException)
        {
            Utils.ShowMessage(this.Page, "Error de autenticacion", "Nota..", "error");
            insertar = false;
        }

        if(insertar == true)
        {
            agregarComentario(txtMensaje.Text);
            vaciarFormulario();
        }
    }

    //contiene el evento que tiene el boton de envio de correo electronico
    protected void btnEnviarCorreo_Click(object sender, EventArgs e)
    {
        agregarComentario("Para: " + txtDestinatario.Text + "  , Asunto: " + txtAsunto.Text + "  , Mensaje: " + txtMensaje.Text);
    }

    //metodo para verificar que opciones fueron seleccionadas o deseleccionadas para luego ser actualizadas
    private void opcionesChecked()
    {
        if (checkImportacion.Checked) importacion      = true;
        if (CheckComplicado.Checked) complicado        = true;
        if (checkCompromiso.Checked) compromiso_pago   = true;
        if (checkPrioritario.Checked) prioritario      = true;
        if (ChecKAutoAlquiler.Checked) alquiler        = true;
        if (CheckPerdida.Checked) perdidaTotal         = true;
        if (checkCierreInterno.Checked) cierre_interno = true;
        if (CheckRobo.Checked) robo                    = true;
        if (checkCerrarReclamo.Checked) estado         = "Cerrado";
    }

    private void actualizar_fecha_seguimiento()
    {
        var seguimiento = DBReclamos.reclamo_auto.Find(id);
        var dias_revision = DBReclamos.estados_reclamos_unity.Where(es => es.descripcion == ddlEstadoAuto.SelectedItem.Text && es.tipo == "auto").First();
        dias = Convert.ToInt32(dias_revision.dias_revision);
        DateTime fecha = DateTime.Now;

        if(ddlEstadoAuto.SelectedItem.Text == "Reparacion" && seguimiento.auto_reclamo.poliza == "AUTO-366488")
        {
            dias = 3;
        }

        seguimiento.fecha_visualizar = fecha.AddDays(dias);
        DBReclamos.SaveChanges();
    }

    //evento para actualizar la informacion del reclamo
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        opcionesChecked();

        if (lblEstadoAuto.Text != ddlEstadoAuto.SelectedItem.ToString())
        {
            bitacora_estados_autos bitacora = new bitacora_estados_autos();
            var sec_registro = DBReclamos.pa_sec_estados_autos();
            long? id_registro = sec_registro.Single();
            bitacora.id = Convert.ToInt64(id_registro);
            bitacora.estado = ddlEstadoAuto.SelectedItem.Text;
            bitacora.fecha = DateTime.Now;
            bitacora.id_reclamo_auto = id;
            DBReclamos.bitacora_estados_autos.Add(bitacora);
            actualizar_fecha_seguimiento();
            Utils.actividades(id, Constantes.AUTOS(), 4, Constantes.USER());
        }

        try
        {
            var reclamo = DBReclamos.reclamo_auto.Find(id);
            if (reclamo.fecha_visualizar <= DateTime.Now) actualizar_fecha_seguimiento();
            reclamo.estado_unity      = estado;
            reclamo.num_reclamo       = txtNumReclamo.Text;
            reclamo.importacion       = importacion;
            reclamo.complicado        = complicado;
            reclamo.prioritario       = prioritario;
            reclamo.compromiso_pago   = compromiso_pago;
            reclamo.perdida_total     = perdidaTotal;
            reclamo.robo              = robo;
            reclamo.alquiler_auto     = alquiler;
            reclamo.id_gestor         = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista       = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.estado_auto_unity = ddlEstadoAuto.SelectedItem.Text;
            reclamo.id_taller         = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.observaciones     = txtObservaciones.Text;
            reclamo.cierre_interno    = cierre_interno;
            reclamo.reserva           = (txtReserva.Text == "" ) ? 0 : Convert.ToDecimal(txtReserva.Text);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(estados_autos,GridEstadosAuto);

            if (checkCierreInterno.Checked)
            {
                CierreInterno();
            }

            if (checkCerrarReclamo.Checked)
            {
                cerrarReclamo();
                Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx", false);
            }

            DatosReclamo(id);
            Utils.ShowMessage(this.Page, "Datos actualizados", "Excelente...!", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el registro", "Nota.. " + ex.Message, "error");
            Email.ENVIAR_ERROR("Error de reclamo en seguimiento de autos","Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex);
        }
    }

    protected void cerrarReclamo()
    {
        try
        {
            var cerrar = DBReclamos.reclamo_auto.Find(id);
            cerrar.acs = false;
            cerrar.id_motivo_cierre = Convert.ToInt32(ddlTipoCierre.SelectedValue);
            cerrar.fecha_cierre_reclamo = DateTime.Now;
            DBReclamos.SaveChanges();
            Utils.actividades(id, Constantes.AUTOS(), 24, Constantes.USER());
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido cerrar el reclamo " + ex.Message, "Nota..", "error");
        }
    }

    private void CierreInterno()
    {
        var cierreInterno = DBReclamos.reclamo_auto.Find(id);
        DateTime fecha_v = Convert.ToDateTime(cierreInterno.fecha_visualizar);
        cierreInterno.fecha_visualizar = fecha_v.AddDays(60);
        DBReclamos.SaveChanges();
        DatosReclamo(id);
    }

    //envio de correo en caso de alquiler de un vehiculo al asegurado
    private void alquilerVehiculo()
    {   
        txtDestinatario.Text = txtCorreoContacto.Text;
        txtMensaje.Text      = Constantes.ALQUILER_VEHICULO(); 
        txtAsunto.Text       = "Alquiler De Vehiculo ";
    }

    //envio de correo al ejecutivo notificando que existe una perdida total del vehiculo
    private void envioPerdidaTotal()
    {
        try
        {
            var ejecutivo = DBReclamos.ejecutivos.Where(co => co.gestor == txtEjecutivo.Text).First();
            txtDestinatario.Text = ejecutivo.correo;
        }
        catch (Exception){}

        txtMensaje.Text = Constantes.PERDIDA_TOTAL_AUTO(txtPlaca, txtMarca, txtModelo, lblNombreAsegurado, lblNumeroPoliza);
        txtAsunto.Text = "Perdida Total en vehiculo ";
    }

    //vaciar formulario de envio de correo electronico
    public void vaciarFormulario()
    {
        txtDestinatario.Text = "";
        txtMensaje.Text = "";
        txtContrasena.Text = "";
        txtAsunto.Text = "";
    }

    protected void ChecKAutoAlquiler_CheckedChanged(object sender, EventArgs e)
    {
        if (ChecKAutoAlquiler.Checked)
        {
            alquilerVehiculo();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
        }

        else
        {
            vaciarFormulario();
        }
    }

    protected void checkCierreInterno_CheckedChanged(object sender, EventArgs e)
    {
        if (checkCierreInterno.Checked)
        {
            ddlEstadoAuto.SelectedValue = "Inactivo";
        }

        else
        {
            vaciarFormulario();
        }
    }

    protected void checkCerrarReclamo_CheckedChanged(object sender, EventArgs e)
    {
        if (checkCerrarReclamo.Checked)
        {
            ddlEstadoAuto.SelectedValue = "Cerrado";
            ddlTipoCierre.Enabled = true;
        }

        else
        {
            vaciarFormulario();
        }
    }

    protected void CheckRobo_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckRobo.Checked)
        {
            try
            {
                var ejecutivo = DBReclamos.ejecutivos.Where(co => co.gestor == txtEjecutivo.Text).First();
                txtDestinatario.Text = ejecutivo.correo;
            }
            catch (Exception)
            {

            }
        }

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
        txtMensaje.Text = Constantes.ROBO_AUTO(txtPlaca, txtMarca, txtModelo, lblNombreAsegurado, lblNumeroPoliza);
        txtAsunto.Text = "Robo de vehiculo ";
    }

    //ejecucion de metodos en evento del check de perdida total
    protected void CheckPerdida_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckPerdida.Checked)
        {
            envioPerdidaTotal();
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
        }

        else
        {
            vaciarFormulario();
        }
    }

    //guardado de cobertura manualmente
    protected void btnGuardarCobertura_Click(object sender, EventArgs e)
    {
        string coberturaAfectada;
        try
        {
            coberturaAfectada = String.IsNullOrEmpty(txtCoberturaAfectada.Text) ? ddlSeleccionarCobertura.SelectedItem.ToString() : txtCoberturaAfectada.Text;
            coberturas_afectadas cobertura = new coberturas_afectadas();
            cobertura.cobertura = coberturaAfectada;
            cobertura.limite1   = Convert.ToDecimal(txtLimite1.Text);
            cobertura.limite2   = Convert.ToDecimal(txtlimite2.Text);
            cobertura.deducible = Convert.ToDecimal(txtDeducible.Text);
            cobertura.prima     = Convert.ToDecimal(txtPrima.Text);
            cobertura.id_reclamo_auto = id;
            DBReclamos.coberturas_afectadas.Add(cobertura);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            SeleccionarCoberturas(id);
            Utils.ShowMessage(this.Page, "Cobertura insertada con exito","Excelente..", "success");

            txtLimite1.Text   = "0.00";
            txtlimite2.Text   = "0.00";
            txtDeducible.Text = "0.00";
            txtPrima.Text     = "0.00";
            txtCoberturaAfectada.Text = "";

            Utils.actividades(id, Constantes.AUTOS(),23, Constantes.USER());
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido agregar la cobertura." + ex.Message, "Nota..!", "error");
        }
    }

    //actualizar contacto del reclamo
    protected void btnActualizarContacto_Click(object sender, EventArgs e)
    {
        try
        {
            var contacto = DBReclamos.contacto_auto.Where(c => c.id_reclamo_auto == id).First();
            contacto.contacto = txtContacto.Text;
            contacto.telefono = txtTelefono.Text;
            contacto.correo = txtCorreoContacto.Text;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Contacto actualizado con exito", "Excelente..!", "success");
            Utils.actividades(id, Constantes.AUTOS(), 14, Constantes.USER());
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el contacto. " + ex.Message, "Error..!", "error");
        }
    }

    //metodo para seleccionar cobertura afectada para realizar un pago
    //este metodo llena un dropdown list llamado ddlCoberturas
    private void SeleccionarCoberturas (int id)
    {
        try
        {
            ddlCoberturas.DataSource = DBReclamos.coberturas_afectadas.ToList().Where(cober => cober.id_reclamo_auto == id);
            ddlCoberturas.DataTextField = "cobertura";
            ddlCoberturas.DataBind();
        }
        catch (Exception)
        {
           
        }
    }

    //metodo para realizar el pago de un reclamo 
    //aqui se ingresa un monto luego se calcula y se restan algunas cantidades, iva, deducible, prima, timbres
    protected void btnPago_Click(object sender, EventArgs e)
    {
        monto = Convert.ToDouble(txtMonto.Text);

        if(checkIva.Checked == true)
        {
            iva   = monto / 1.12 * 0.12;
            monto = monto - iva;
        }
        
        monto   = (monto - Convert.ToDouble(txtPagoDeducible.Text));
        timbres = monto * 0.03;
        monto   = monto - timbres;
        total   = (monto - Convert.ToDouble(txtPrimasPago.Text));

        try
        {
            detalle_pagos_reclamos_autos pago = new detalle_pagos_reclamos_autos();
            pago.cobertura_pagada = ddlCoberturas.SelectedItem.Text;
            pago.monto            = Convert.ToDecimal(txtMonto.Text);
            pago.iva              = Convert.ToDecimal(iva);
            pago.deducible        = Convert.ToDecimal(txtPagoDeducible.Text);
            pago.timbres          = Convert.ToDecimal(timbres);
            pago.primas           = Convert.ToDecimal(txtPrimasPago.Text);
            pago.total            = Convert.ToDecimal(total);
            pago.fecha            = DateTime.Now;
            pago.destino          = ddlDestino.SelectedValue;
            pago.id_reclamo_auto  = id;
            DBReclamos.detalle_pagos_reclamos_autos.Add(pago);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(pagos, GridPagosReclamos);
            lblPagoTotal.Text = "<b>TOTAL : </b>" + total.ToString("N2");
            Utils.ShowMessage(this.Page, "Pago realizado con exito", "Excelente", "success");
            txtPagoDeducible.Text = "0.00";
            txtPrimasPago.Text    = "0.00";
            txtMonto.Text         = "0.00";

            Utils.actividades(id, Constantes.AUTOS(), 20, Constantes.USER());
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido realizar el pago", "Nota..!", "error");
        }
    }

    //editar una liquidacion
    protected void GridPagosReclamos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id_pago = Convert.ToInt32(GridPagosReclamos.SelectedRow.Cells[1].Text);

        var pago              = DBReclamos.detalle_pagos_reclamos_autos.Find(id_pago);
        txtMonto.Text         = pago.monto.ToString();
        txtIva.Text           = pago.iva.ToString();
        txtPagoDeducible.Text = pago.deducible.ToString();
        txtTimbres.Text       = pago.timbres.ToString();
        txtPrimasPago.Text    = pago.primas.ToString();
        txtTotal.Text         = pago.total.ToString();
        ddlDestino.SelectedValue = ddlDestino.SelectedValue = String.IsNullOrEmpty(pago.destino) ? "" : pago.destino;
        //txtIva.Enabled     = true;
        //txtTimbres.Enabled = true;
        //txtTotal.Enabled   = true;
        //btnPago.Enabled    = false;
        btnActualizarPagos.Enabled = true;

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#IngresarLiquidacion').modal('show');", addScriptTags: true);
    }

    protected void btnActualizarPagos_Click(object sender, EventArgs e)
    { 
        int id_pago    = Convert.ToInt32(GridPagosReclamos.SelectedRow.Cells[1].Text);
        var pago       = DBReclamos.detalle_pagos_reclamos_autos.Find(id_pago);
        pago.monto     = Convert.ToDecimal(txtMonto.Text);
        pago.iva       = Convert.ToDecimal(txtIva.Text);
        pago.deducible = Convert.ToDecimal(txtPagoDeducible.Text);
        pago.timbres   = Convert.ToDecimal(txtTimbres.Text);
        pago.primas    = Convert.ToDecimal(txtPrimasPago.Text);
        pago.total     = Convert.ToDecimal(txtTotal.Text);
        pago.destino   = ddlDestino.SelectedValue;
        DBReclamos.SaveChanges();
        llenado.llenarGrid(pagos, GridPagosReclamos);
        Utils.actividades(id, Constantes.AUTOS(), 21, Constantes.USER());
    }

    //salir del reclamo y me redirecciona a los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx", false);
    }

    //seleccionar  el deducible de la cobertura afectada.
    protected void ddlCoberturas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var deducible = DBReclamos.coberturas_afectadas.ToList().Where(d => d.id_reclamo_auto == id).First();
            txtPagoDeducible.Text = deducible.deducible.ToString();
        }

        catch (Exception)
        {
            //Response.Write(ex);
        }
    }
    //evento para cambiar la fecha que se desea q se muestre el reclamo
    protected void btnGuardarProximaFecha_Click(object sender, EventArgs e)
    {
        try
        {
            var update_fecha = DBReclamos.reclamo_auto.Find(id);
            update_fecha.fecha_visualizar = Convert.ToDateTime(txtProximaFecha.Text);
            DBReclamos.SaveChanges();
            DatosReclamo(id);
            Utils.actividades(id, Constantes.AUTOS(), 22, Constantes.USER());
        }
        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar la fecha a visualizar. " + ex.Message, "Nota..!", "warning");
        }
    }
    
    //datos para generar las cartas
    public void DatosCarta()
    {
        var registro = DBReclamos.reclamo_auto.Find(id);
        var contacto = DBReclamos.contacto_auto.ToList().Where(contac => contac.id_reclamo_auto == id).First();
        try
        {
            var ejecutivo = DBReclamos.ejecutivos.ToList().Where(ej => ej.codigo == registro.auto_reclamo.numero_gestor).First();
            lblCartaCorreoEjecutivo.Text = ejecutivo.correo;
        }

        catch(Exception )
        {

        }

        lblCartaFecha.Text     = DateTime.Now.ToString("D");
        lblCartaVehiculo.Text  = registro.auto_reclamo.placa + " " + registro.auto_reclamo.marca + " " + registro.auto_reclamo.modelo;
        lblCartaid.Text        = "ID :" + registro.id.ToString();
        lblCartaPoliza.Text    = registro.auto_reclamo.poliza;
        lblCartaAsegurado.Text = registro.auto_reclamo.asegurado;
        lblCartaEjecutivo.Text = registro.auto_reclamo.ejecutivo;
        lblAsesor.Text = registro.gestores.nombre;
        lblCorreoAsesor.Text = registro.gestores.correo;
    }

    //metodo para habilitar la casilla del numero de reclamo que brinda la aseguradora
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

    //funcion para mostrar los comentarios con los saltos de lineas dentro del gridview
    protected void GridComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("\n", "<br/>");
            }
        }
        catch (Exception)
        {

        }
    }

    //envio de notificacion automatica de correos electronicos por cambio de estado del reclamo
    public void enviarNotificacion()
    {
        notificacion.NOTIFICACION(txtCorreoContacto.Text.Trim(), mensaje, txtAsunto.Text);
    }

    public void Notificacion()
    {
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
    }

    // scripts para enviar correos electronicos segun el estado al que se cambie el vehiculo
    protected void ddlEstadoAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEstadoAuto.SelectedValue == "Asignacion")
        {
            Notificacion();
        }

        else if (ddlEstadoAuto.SelectedValue == "Presupuesto y ajuste")
        {
            Notificacion();
        }

        else if (ddlEstadoAuto.SelectedValue == "Reparacion")
        {
            Notificacion();
        }

        else if (ddlEstadoAuto.SelectedValue == "Entrega")
        {
            Notificacion();
        }

        else if(ddlEstadoAuto.SelectedValue == "Perdida Total")
        {
            Notificacion();
            chEnviarCorreo.Enabled = false;
        }

        else if(ddlEstadoAuto.SelectedValue == "Revision gestor autos")
        {
            Notificacion();
            chEnviarCorreo.Enabled = false;
        }

        else if (ddlEstadoAuto.SelectedValue == "Ajuste y liquidacion")
        {
            Notificacion();
        }

        else if(ddlEstadoAuto.SelectedValue == "Emision cheque")
        {
            Notificacion();
            chEnviarCorreo.Enabled = false;
        }

        else if(ddlEstadoAuto.SelectedValue == "Cheque por retirar")
        {
            try
            {
                var destino_cheque = DBReclamos.detalle_pagos_reclamos_autos.Select(d => new { d.destino, d.id_reclamo_auto }).Where(de => de.id_reclamo_auto == id).First();
                if (destino_cheque.destino == "Escritura de pago") txtSMS.Visible = true;
                txtSMS.Text = "UNITY: Estimad@ cliente reunion entrega de cheque/firma de escritura, " + id + " coordinada para el xx/xx/xx a las xxam/pm";
            }

            catch (Exception)
            {

            }

            Notificacion();
            chEnviarCorreo.Enabled = false;
        }
    }

    public void enviar_notificaciones_click(object sender, EventArgs e)
    {
        if (ddlEstadoAuto.SelectedValue == "Asignacion" && txtCorreoContacto.Text != "")
        {
            mensaje = Constantes.ASIGNACION_AUTOS(ddlGestor,txtPlaca.Text, txtMarca.Text,txtModelo.Text,txtGestorTelefono.Text,id); 
            txtAsunto.Text = "Asignacion Reclamo";
            enviarNotificacion();
            agregarComentario("Correo automatico: " + mensaje);
        }

        else if (ddlEstadoAuto.SelectedValue == "Presupuesto y ajuste")
        {
            if(chEnviarCorreo.Checked && txtCorreoContacto.Text !="")
            {
                mensaje = Constantes.PRESUPUESTO_AUTO(txtPlaca, txtMarca, txtModelo);
                txtAsunto.Text = "Presupuesto y ajuste";
                enviarNotificacion();
                agregarComentario("Correo Automatico: " + mensaje);
            }

            if(chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente ID "+id+" su vehículo en proceso de presupuesto y ajuste en taller de su elección", userlogin, id);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoAuto.SelectedValue == "Reparacion")
        {
            if(chEnviarCorreo.Checked && txtCorreoContacto.Text != "")
            {
                mensaje = Constantes.REPARACION_AUTOS();
                txtAsunto.Text = "Reparacion";
                enviarNotificacion();
                agregarComentario("Correo Automatico: " + mensaje);
            }

            if(chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente Reclamo ID "+id+" su vehiculo esta en proceso de reparacion le estaremos informando sobre avances.", userlogin, id);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoAuto.SelectedValue == "Entrega")
        {
            if(chEnviarCorreo.Checked && txtCorreoContacto.Text != "")
            {
                mensaje = Constantes.ENTREGA_AUTO();
                txtAsunto.Text = "Entrega";
                enviarNotificacion();
                agregarComentario("Correo Automatico: " + mensaje);
            }

            if(chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente Reclamo "+id+" su vehiculo esta en proceso final de reparacion le informaremos sobre la entrega.", userlogin, id);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoAuto.SelectedValue == "Perdida Total")
        {
            if (chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente Reclamo "+id+" su vehiculo fue declarado como perdida total, se envia solicitud de documentos.", userlogin, id);
                llenado.llenarGrid(comentarios,GridComentarios);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }
        }

        else if(ddlEstadoAuto.SelectedValue == "Revision gestor autos")
        {
            if (chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente hemos recibido documentacion para revision y envio a la Aseguradora, segun reclamo ID "+id+".", userlogin, id);
                llenado.llenarGrid(comentarios, GridComentarios);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }
        }

        else if (ddlEstadoAuto.SelectedValue == "Ajuste y liquidacion")
        {
            if(chEnviarCorreo.Checked && txtCorreoContacto.Text != "")
            {
                mensaje = Constantes.AJUSTES_AUTOS();
                txtAsunto.Text = "Ajuste Auto";
                enviarNotificacion();
                agregarComentario("Correo Automatico: " + mensaje);
            }

            if(chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente ID "+id+" esta en proceso de ajuste y liquidacion en la compañia de seguros.", userlogin, id);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios,GridComentarios);
        }

        else if(ddlEstadoAuto.SelectedValue == "Emision cheque")
        {
            if (chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente su ID "+id+" esta en proceso de emision de cheque en la compañia de seguros.", userlogin, id);
                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if(ddlEstadoAuto.SelectedValue == "Cheque por retirar")
        {
            if (chEnviarSMS.Checked && txtTelefono.Text != "")
            {
                var destino_cheque = DBReclamos.detalle_pagos_reclamos_autos.Select(d => new { d.destino, d.id_reclamo_auto }).Where(de => de.id_reclamo_auto == id).First();

                if (destino_cheque.destino == "Ruta")
                {
                    Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente cheque del reclamo ID " + id + " se encuentra en ruta para la entrega en direccion registrada.", userlogin, id);
                }

                else if(destino_cheque.destino == "Recepcion")
                {
                    Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Estimad@ cliente cheque del reclamo "+id+" se encuentra listo en recepcion Unity favor pasar a recogerlo.", userlogin, id);
                }

                else if (destino_cheque.destino == "Escritura de pago")
                {
                    Utils.SMS_reclamos_autos(txtTelefono.Text,txtSMS.Text, userlogin, id);
                }

                Utils.actividades(id, Constantes.AUTOS(), 26, Constantes.USER());
            }

            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else
        {
            vaciarFormulario();
        }
    }

    protected void linkRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx", false);
    }

    public void tiempo()
    {
        string tiemposAbierto = "select DATEDIFF(SECOND, fecha_apertura_reclamo, getdate()) from reclamo_auto where id = " + id + "";
        SqlDataAdapter da = new SqlDataAdapter(tiemposAbierto, objeto.ObtenerConexionReclamos());
        DataTable dt = new DataTable();
        da.Fill(dt);
        txtTiempo.Text = dt.Rows[0][0].ToString();
    }

    protected void checkDatosAutos_CheckedChanged(object sender, EventArgs e)
    {
        if(checkDatosAutos.Checked)
        {
            txtPlaca.Enabled   = true;
            txtMarca.Enabled   = true;
            txtColor.Enabled   = true;
            txtModelo.Enabled  = true;
            txtChasis.Enabled  = true;
            txtMotor.Enabled   = true;
            txtPropietario.Enabled = true;
        }

        else
        {
            txtPlaca.Enabled  = false;
            txtMarca.Enabled  = false;
            txtColor.Enabled  = false;
            txtModelo.Enabled = false;
            txtChasis.Enabled = false;
            txtMotor.Enabled  = false;
            txtPropietario.Enabled = false;
        }       
    }

    private void ActualizarAuto()
    {
        try
        {
            var auto = DBReclamos.reclamo_auto.Find(id);
            auto.auto_reclamo.placa  = txtPlaca.Text;
            auto.auto_reclamo.marca  = txtMarca.Text;
            auto.auto_reclamo.color  = txtColor.Text;
            auto.auto_reclamo.modelo = txtModelo.Text;
            auto.auto_reclamo.chasis = txtChasis.Text;
            auto.auto_reclamo.motor  = txtMotor.Text;
            auto.auto_reclamo.propietario = txtPropietario.Text;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Datos del auto actualizados", "Excelente..!", "success");
            Utils.actividades(id, Constantes.AUTOS(), 6, Constantes.USER());
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se pudieron actualizar los datos del auto. " + ex.Message, "Error..!", "error");
        }
    }

    protected void ActualizarDatos_Click(object sender, EventArgs e)
    {
        ActualizarAuto();
    }

    private void BitacoraReclamo()
    {
        var bitacora        = DBReclamos.reclamo_auto.Find(id);
        bitAsesor.Text      = bitacora.gestores.nombre;
        BitNumReclamo.Text  = bitacora.num_reclamo.ToString();
        BitPoliza.Text      = bitacora.auto_reclamo.poliza;
        BitAsegurado.Text   = bitacora.auto_reclamo.asegurado;
        BitEjecutivo.Text   = bitacora.auto_reclamo.ejecutivo;
        BitAseguradora.Text = bitacora.auto_reclamo.aseguradora;
        BitContratante.Text = bitacora.auto_reclamo.contratante;
        BitEstado.Text      = bitacora.auto_reclamo.estado_poliza;
        bitAnalista.Text    = bitacora.analistas.nombre;
        bitContacto.Text    = txtContacto.Text;

        BitPlaca.Text  = bitacora.auto_reclamo.placa;
        BitMarca.Text  = bitacora.auto_reclamo.marca;
        BitColor.Text  = bitacora.auto_reclamo.color;
        BitModelo.Text = bitacora.auto_reclamo.modelo;
        BitChasis.Text = bitacora.auto_reclamo.chasis;
        BitMotor.Text  = bitacora.auto_reclamo.motor;

        AseguradoraPNC.Text = bitacora.auto_reclamo.aseguradora;
        AseguradoPNC.Text = bitacora.auto_reclamo.asegurado;
        PolizaPNC.Text = bitacora.auto_reclamo.poliza;
        IdPNC.Text = bitacora.id.ToString();
        AsesorPNC.Text = bitacora.gestores.nombre;
        AsesorAsignadoPNC.Text = bitacora.gestores.nombre;

        llenado.llenarGrid(llamadas, Bitllamadas);
        llenado.llenarGrid(comentarios, BitSeguimiento);

       // Utils.actividades(id, Constantes.AUTOS(), 15, Constantes.USER());
    }

    protected void btnProductoNoConforme_Click(object sender, EventArgs e)
    {
        try
        {
            var noConforme = DBReclamos.reclamo_auto.Find(id);

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
                Utils.actividades(id, Constantes.AUTOS(), 16, Constantes.USER());
            }

            else
            {
                noConforme.no_conforme = false;
                noConforme.fecha_cierre_no_conforme = DateTime.Now;
                DBReclamos.SaveChanges();
                agregarComentario("La incorformidad encontrada en el reclamo por: " + ddlNoConforme.SelectedValue + ", ha sido solventada. ");
                llenado.llenarGrid(comentarios, GridComentarios);
                Utils.ShowMessage(this.Page, "Reclamo Actualizado como producto no conforme.", "Excelente", "info");
            }

        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el reclamo como no conforme. " + ex.Message, "Error", "error");
        }
    }

    //envio de sms manual
    protected void btnEnviarSMS_Click(object sender, EventArgs e)
    {
        if (txtTelefono.Text != "")
        {
            Utils.SMS_reclamos_autos(txtTelefono.Text, TxtEnvioSms.Text, userlogin, id);
            TxtEnvioSms.Text = "";
            llenado.llenarGrid(comentarios, GridComentarios);
            Utils.actividades(id, Constantes.AUTOS(), 12, Constantes.USER());
        }
    }

    protected void chAlertaTiempo_CheckedChanged(object sender, EventArgs e)
    {
        if (chAlertaTiempo.Checked)
        {
            chCartaDeclinado.Checked = false;
            chEnvioCarta.Checked = false;
            chCartaCierre.Checked = false;
            
            CodigoISO.Text = "RE-AU-F-07/Ver.02";
            var buscarCarta = DBReclamos.cartas.Where(ca => ca.tipo == "alerta tiempo" && ca.modulo == "autos" && ca.id_reclamo == id).Count();

            if (buscarCarta == 1)
            {
                var mostrar = DBReclamos.cartas.Where(ma => ma.id_reclamo == id && ma.tipo == "alerta tiempo" && ma.modulo == "autos").First();
                txtContenidoCarta.Text = mostrar.contenido;
                panelPrincipal.Visible = false;
                Panelsecundario.Visible = true;
                lblcarta.Text = txtContenidoCarta.Text;
            }
            else
            {
                PnDetallePago.Visible = false;
                DatosCarta();
                lblMemo.Text = cartaCierreInterno;
            }
        }
        else
        {
            lblMemo.Text = "";
            panelPrincipal.Visible = true;
            Panelsecundario.Visible = false;
        }

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#Editor').modal('show');", addScriptTags: true);
    }

    protected void chCartaCierre_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaCierre.Checked)
        {
            chCartaDeclinado.Checked = false;
            chEnvioCarta.Checked = false;
            CodigoISO.Text = "RE-AU-F-04/Ver.02";
            var buscarCarta = DBReclamos.cartas.Where(ca => ca.tipo == "cierre interno" && ca.modulo == "autos" && ca.id_reclamo == id).Count();

            if (buscarCarta == 1)
            {
                var mostrar = DBReclamos.cartas.Where(ma => ma.id_reclamo == id && ma.tipo == "cierre interno" && ma.modulo == "autos").First();
                txtContenidoCarta.Text = mostrar.contenido;
                panelPrincipal.Visible = false;
                Panelsecundario.Visible = true;
                lblcarta.Text = txtContenidoCarta.Text;
            }
            else
            {
                PnDetallePago.Visible = false;
                DatosCarta();
                lblMemo.Text = cartaCierreInterno;
            }
        }
        else
        {
            lblMemo.Text = "";
            panelPrincipal.Visible = true;
            Panelsecundario.Visible = false;
        }

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#Editor').modal('show');", addScriptTags: true);
    }

    protected void chCartaDeclinado_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaDeclinado.Checked)
        {
            chCartaCierre.Checked = false;
            chEnvioCarta.Checked = false;
            CodigoISO.Text = "RE-AU-F-05/Ver. 03";
            var buscarCarta = DBReclamos.cartas.Where(ca => ca.tipo == "declinado" && ca.modulo == "autos" && ca.id_reclamo == id).Count();

            if (buscarCarta == 1)
            {
                var mostrar = DBReclamos.cartas.Where(ma => ma.id_reclamo == id && ma.tipo == "declinado" && ma.modulo == "autos").First();
                txtContenidoCarta.Text = mostrar.contenido;
                panelPrincipal.Visible = false;
                Panelsecundario.Visible = true;
                lblcarta.Text = txtContenidoCarta.Text;
            }
            else
            {
                PnDetallePago.Visible = false;
                DatosCarta();
                lblMemo.Text = cartaDeclinacionReclamo;
            }
        }
        else
        {
            lblMemo.Text = "";
            panelPrincipal.Visible = true;
            Panelsecundario.Visible = false;
        }

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#Editor').modal('show');", addScriptTags: true);
    }

    protected void chEnvioCarta_CheckedChanged(object sender, EventArgs e)
    {
        if (chEnvioCarta.Checked)
        {
            chCartaCierre.Checked = false;
            chCartaDeclinado.Checked = false;
            CodigoISO.Text = "RE-AU-F-03/Ver.03";

            var buscarCarta = DBReclamos.cartas.Where(ca => ca.tipo == "envio cheque" && ca.modulo == "autos" && ca.id_reclamo == id).Count();

            if (buscarCarta == 1)
            {
                var mostrar = DBReclamos.cartas.Where(ma => ma.id_reclamo == id && ma.tipo == "envio cheque" && ma.modulo == "autos").First();
                txtContenidoCarta.Text = mostrar.contenido;
                panelPrincipal.Visible = false;
                Panelsecundario.Visible = true;
                lblcarta.Text = txtContenidoCarta.Text;
            }
            else
            {
                DatosCarta();
                lblMemo.Text = cartaEnvioCheque;
                PnDetallePago.Visible = true;
            }
        }
        else
        {
            lblMemo.Text = "";
            panelPrincipal.Visible = true;
            Panelsecundario.Visible = false;
        }

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#Editor').modal('show');", addScriptTags: true);
    }


    protected void lnkGuardarCarta_Click(object sender, EventArgs e)
    {
        try
        {
            if (chCartaCierre.Checked)
            {
                Utils.Guardar_cartas_autos(txtContenidoCarta, "cierre interno", "autos", id, chCartaCierre, chCartaDeclinado, chEnvioCarta, chAlertaTiempo);
                Utils.actividades(id, Constantes.AUTOS(), 9, Constantes.USER());
            }

            else if (chCartaDeclinado.Checked)
            {
                Utils.Guardar_cartas_autos(txtContenidoCarta, "declinado", "autos", id, chCartaCierre, chCartaDeclinado, chEnvioCarta, chAlertaTiempo);
                Utils.actividades(id, Constantes.AUTOS(), 10, Constantes.USER());
            }

            else if (chEnvioCarta.Checked)
            {
                Utils.Guardar_cartas_autos(txtContenidoCarta, "envio cheque", "autos", id, chCartaCierre, chCartaDeclinado, chEnvioCarta, chAlertaTiempo);
                Utils.actividades(id, Constantes.AUTOS(), 11, Constantes.USER());
            }

            else if (chAlertaTiempo.Checked)
            {
                Utils.Guardar_cartas_autos(txtContenidoCarta, "alerta tiempo", "autos", id, chCartaCierre, chCartaDeclinado, chEnvioCarta, chAlertaTiempo);
                Utils.actividades(id, Constantes.AUTOS(), 11, Constantes.USER());
            }

            chCartaCierre.Checked    = false;
            chCartaDeclinado.Checked = false;
            chEnvioCarta.Checked     = false;
            Utils.ShowMessage(this.Page, "Carta Guardada con exito", "Excelente", "success");
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al guardar la carta" + ex.Message, "Error", "error");
        }
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        //String path = @"C:\Reclamos\ReclamosAutos";
        String path = @"E:\ReclamosScanner\files\ReclamosAutos";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String RD;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String nombreArchivo = SubirArchivo.FileName;
        var reclamo = DBReclamos.reclamo_auto.Find(id);

        try
        {
            if (SubirArchivo.HasFile)
            {
                if (String.IsNullOrEmpty(reclamo.documentos))
                {
                    RD = anio + "\\" + mes + "\\" + "RD" + id;
                }

                else
                {
                    RD = reclamo.documentos;
                }

                if (Directory.Exists(path + "\\" + RD))
                {
                    SubirArchivo.SaveAs(path + "\\" + RD + "\\" + nombreArchivo);
                    Utils.ShowMessage(this.Page, "Archivo Subido con exito ", "Excelente..", "success");
                    reclamo.documentos = RD;
                    DBReclamos.SaveChanges();
                }

                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path + "\\" + RD);
                    SubirArchivo.SaveAs(path + "\\" + RD + "\\" + nombreArchivo);
                    Utils.ShowMessage(this.Page, "Archivo Subido con exito ", "Excelente..", "success");
                    reclamo.documentos = RD;
                    DBReclamos.SaveChanges();
                }

                Utils.actividades(id, Constantes.AUTOS(), 17, Constantes.USER());
            }
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido subir el archivo " + ex, "Error..", "error");
        }
    }

    //metodo para reasignar un reclamo
    protected void ddlGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var usuario = DBReclamos.gestores.Find(Convert.ToInt32(ddlGestor.SelectedValue));
            var reclamo = DBReclamos.reclamo_auto.Find(id);
            reclamo.usuario_unity = usuario.usuario;
            reclamo.id_gestor = usuario.id;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Reclamo Reasignado con exito a usuario "+ddlGestor.SelectedItem.Text+"", "Excelente..", "success");
            Utils.actividades(id, Constantes.AUTOS(), 8, Constantes.USER());
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "Este Reclamo No pudo ser Reasignado" + ex.Message, "ERROR..", "error");
        }
    }

    private void seleccionarDocumentos()
    {
        String documento ="";
        int idDocumento;
        foreach (GridViewRow row in GridDocumentos.Rows)
        {
            idDocumento = Convert.ToInt32(row.Cells[1].Text);
            CheckBox check = (CheckBox)row.FindControl("chElegir");
            if (check.Checked)
            {
                try
                {
                    documentos_solicitados nuevo = new documentos_solicitados();
                    var sec_registro = DBReclamos.pa_sec_documentos_solicitados();
                    long? id_registro = sec_registro.Single();
                    nuevo.id = Convert.ToInt32(id_registro);
                    nuevo.documento = idDocumento;
                    nuevo.id_reclamo = id;
                    nuevo.tipo = "Autos";
                    nuevo.fecha = DateTime.Now;
                    DBReclamos.documentos_solicitados.Add(nuevo);
                    DBReclamos.SaveChanges();
                    documento +=  Server.HtmlDecode(row.Cells[2].Text) + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se agregar los documentos seleccionados" + ex.Message, "Excelente", "success");
                }
            }
        }
        llenado.llenarGrid(doc_solicitados,GridDocSeleccionados);
        agregarComentario("Documentos Solicitados: \n\n" +documento);
        Utils.actividades(id, Constantes.AUTOS(), 18, Constantes.USER());
    }

    protected void btnGuardarDocumentos_Click(object sender, EventArgs e)
    {
        seleccionarDocumentos();
    }

    protected void lnEditarPoliza_Click(object sender, EventArgs e)
    {
        var reclamo = DBReclamos.reclamo_auto.Find(id);
        txtPoliza.Text = reclamo.auto_reclamo.poliza;
        txtAsegurado.Text = reclamo.auto_reclamo.asegurado;
        txtPrograma.Text = reclamo.auto_reclamo.programa;
        txtContratante.Text = reclamo.auto_reclamo.contratante;

        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList();
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataValueField = "aseguradora";
        ddlAseguradora.DataBind();

        ddlEjecutivos.DataSource = DBReclamos.ejecutivos.ToList().OrderBy(eje => eje.gestor);
        ddlEjecutivos.DataTextField = "gestor";
        ddlEjecutivos.DataValueField = "codigo";
        ddlEjecutivos.DataBind();
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#EditarPoliza').modal('show');", addScriptTags: true);
    }

    protected void btnActualizarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            var reclamo = DBReclamos.reclamo_auto.Find(id);

            reclamo.auto_reclamo.poliza = txtPoliza.Text;
            reclamo.auto_reclamo.asegurado = txtAsegurado.Text;
            reclamo.auto_reclamo.ejecutivo = ddlEjecutivos.SelectedItem.Text;
            reclamo.auto_reclamo.aseguradora = ddlAseguradora.SelectedValue;
            reclamo.auto_reclamo.estado_poliza = ddlStatus.SelectedItem.Text;
            reclamo.auto_reclamo.programa = txtPrograma.Text;
            reclamo.auto_reclamo.cliente = Convert.ToInt32(txtCliente.Text);
            reclamo.auto_reclamo.contratante = txtContratante.Text;
            reclamo.auto_reclamo.vigencia_inicial = Convert.ToDateTime(txtVigi.Text);
            reclamo.auto_reclamo.vigencia_final = Convert.ToDateTime(txtvigf.Text);
            DBReclamos.SaveChanges();

            Utils.ShowMessage(this.Page, "Datos actualizados con exito","Excelente..", "success");
            DatosReclamo(id);
            Utils.actividades(id, Constantes.AUTOS(), 7, Constantes.USER());
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error al actualizar los datos de la poliza " + ex.Message ,"Error.."," error");
        }
    }

    protected void btnProblema_Click(object sender, EventArgs e)
    {
        try
        {
            var reclamo = DBReclamos.reclamo_auto.Find(id);
            reclamo.problema_ajustador     = chAnalista.Checked;
            reclamo.problema_cabina        = chCabina.Checked;
            reclamo.problema_taller        = chCabina.Checked;
            reclamo.problema_aseguradora   = ChAseguradora.Checked;
            reclamo.problema_ejecutivo     = chEjecutivo.Checked;
            reclamo.comentario_taller      = txtProblemaTaller.Text;
            reclamo.comentario_ajustador   = txtProblemaAjustador.Text;
            reclamo.comentario_cabina      = txtProblemaCabina.Text;
            reclamo.comentario_aseguradora = txtProblemaAseguradora.Text;
            reclamo.comentario_ejecutivo   = txtProblemaEjecutivo.Text;
            reclamo.fecha_problema = DateTime.Now;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "observaciones agregadas con exito", "Excelente", "success");
        }

        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se pudieron grabar las observaciones " + ex.Message, "Error", "error");
        }
    }


}
