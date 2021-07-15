using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class Consultas_Caja_de_ahorro_ReclamosAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    Utils update = new Utils();
    DateTime thisDay = DateTime.Today;
    Email notificacion = new Email();
    bool prioritario = false;
    bool alquiler = false;
    bool perdidaTotal = false;
    bool complicado = false;
    bool compromiso_pago = false;
    bool cierre_interno = false;
    String estado = "Seguimiento";//esta variable es la que se utiliza para cambiar el estado a cerrado de un reclamo.
    string idRecibido, comentarios, pagos, llamadas, coberturas, datosAccidente, estados_autos;
    String cartaDeclinacionReclamo, cartaEnvioCheque, cartaCierreInterno, mensaje;
    int id, dias;
    //variables para calculos de pagos de reclamos
    Double iva, monto, timbres, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Session["id_ra_caja"].ToString();
        lblID.Text = idRecibido;
        id = Int32.Parse(idRecibido);

        //variables que contienen los formatos de las cartas a ser impresass
        cartaCierreInterno = "";

        cartaDeclinacionReclamo = "";

        //querys para llenandos de gridviews utilizados en esta vista

        pagos = "select cobertura_pagada as [Cobertura Pagada], monto as Monto, iva IVA, deducible as Deducible, timbres as Timbres, " +
                "primas as Primas, total as Total, fecha as Fecha from detalle_pagos_reclamos_autos where id_reclamo_auto = " + id + "";

        llamadas = "SELECT descripcion  as Descripcion,Convert(varchar(10), fecha_commit, 103) As Fecha, hora_commit as Hora, usuario as Usuario" +
                   " FROM bitacora_reclamo_auto WHERE id_reclamo = " + id + " ";

        coberturas = "SELECT cobertura as Cobertura, limite1 as [Limite 1], limite2  as [limite2], deducible as Deducible, prima as Prima" +
                   " from coberturas_afectadas where id_reclamo_auto = " + id + " ";

        datosAccidente = "select Campo, Dato from (select id,cast(tipo_servicio as varchar(1000)) as Tipo_Servicio,cast(reportante as varchar(1000)) as Reportante," +
            "cast(telefono as varchar(1000)) as Telefono,cast(ubicacion as varchar(1000)) as Ubicacion,cast(convert(varchar(20),fecha,103) as varchar(1000)) as Fecha," +
            "cast(hora as varchar(1000)) as Hora, cast(piloto as varchar(1000)) as Piloto, cast(edad as varchar(1000)) as Edad," +
            "cast(boleta as varchar(1000)) as Boleta, cast(ajustador as varchar(1000)) as Ajustador, cast(titular as varchar(1000)) as Titular, " +
            "cast(version as varchar(1000)) as Version from reclamo_auto where id = " + id + ") a unpivot " +
            "(Dato for  Campo in (Tipo_Servicio, Reportante, Telefono, Ubicacion, Fecha, Piloto, Edad, Boleta, Ajustador, Titular, Version)) up ";

        comentarios = "SELECT  descripcion as Descripcion, usuario as Usuario, fecha As Fecha" +
                      " from comentarios_reclamos_autos where id_reclamo_auto = " + id + "  order by fecha desc ";

        estados_autos = "Select distinct estado as Estado,fecha as Fecha from bitacora_estados_autos where id_reclamo_auto = " + id + " order by fecha";

        if (!IsPostBack)
        {
            DatosReclamo(id);
            datosContacto(id);
            SeleccionarCoberturas(id);
            //funciones para llenar los gridview utilizados
            llenado.llenarGrid(pagos, GridPagosReclamos);
            llenado.llenarGrid(llamadas, Gridllamadas);
            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            llenado.llenarGrid(datosAccidente, GridDatosAccidente);
            llenado.llenarGrid(comentarios, GridComentarios);
            llenado.llenarGrid(Consultas.ESTADOS_AUTOS(id), GridEstadosAuto);
            tiempo();
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
            txtPlaca.Text = reclamo.auto_reclamo.placa;
            txtMarca.Text = reclamo.auto_reclamo.marca;
            txtColor.Text = reclamo.auto_reclamo.color;
            txtModelo.Text = reclamo.auto_reclamo.modelo;
            txtChasis.Text = reclamo.auto_reclamo.chasis;
            txtMotor.Text = reclamo.auto_reclamo.motor;
            txtPropietario.Text = reclamo.auto_reclamo.propietario;
            //listado de detalle de poliza
            lblPoliza.Text = "<b>POLIZA :</b>             " + reclamo.auto_reclamo.poliza;
            lblAsegurado.Text = "<b>ASEGURADO :</b>       " + reclamo.auto_reclamo.asegurado;
            lblEjecutivo.Text = "<b>EJECUTIVO :</b>       " + reclamo.auto_reclamo.ejecutivo;
            lblAseguradora.Text = "<b>ASEGURADORA :</b>   " + reclamo.auto_reclamo.aseguradora;
            lblContratante.Text = "<b>CONTRATANTE :</b>   " + reclamo.auto_reclamo.contratante;
            lblEstado.Text = "<b>ESTADO :</b>             " + reclamo.auto_reclamo.estado_poliza;
            lblTitular.Text = "<b>TITULAR :</b>           " + reclamo.titular;
            lblMoneda.Text = "<b>Moneda :</b>             " + reclamo.auto_reclamo.moneda;
            txtObservaciones.Text = reclamo.observaciones;
            //listado de dropdowns
            ddlEstadoAuto.Text = reclamo.estado_auto_unity;
            ddlGestor.SelectedValue = reclamo.id_gestor.ToString();
            ddlTaller.SelectedValue = reclamo.id_taller.ToString();
            ddlAnalista.SelectedValue = reclamo.id_analista.ToString();
            //campos varios
            txtFrom.Text = reclamo.gestores.correo;
            txtEjecutivo.Text = reclamo.auto_reclamo.ejecutivo;
            txtGestor.Text = reclamo.gestores.nombre;
            txtGestorTelefono.Text = reclamo.gestores.telefono;
            txtFechaSiniestro.Text = reclamo.fecha.ToString();
            lblNumeroPoliza.Text = reclamo.auto_reclamo.poliza;
            lblNombreAsegurado.Text = reclamo.auto_reclamo.poliza;
            lblDireccionAsegurado.Text = reclamo.auto_reclamo.direccion;
            lblIdReclamo.Text = "<b>ID:</b>" + reclamo.id;
            txtNumReclamo.Text = reclamo.num_reclamo;
            lblEstadoAuto.Text = reclamo.estado_auto_unity;

            //opciones de checks
            checkPrioritario.Checked = reclamo.prioritario.Value;
            CheckComplicado.Checked = reclamo.complicado.Value;
            checkCompromiso.Checked = reclamo.compromiso_pago.Value;
            ChecKAutoAlquiler.Checked = reclamo.alquiler_auto.Value;
            CheckPerdida.Checked = reclamo.perdida_total.Value;
            checkCierreInterno.Checked = reclamo.cierre_interno.Value;

            //informacion del taller asignado
            txtNombreTaller.Text = reclamo.talleres.nombre;
            txtDireccionTaller.Text = reclamo.talleres.direccion;
            txtTelefonoTaller.Text = reclamo.talleres.telefono;
            txtCorreoTaller.Text = reclamo.talleres.correo;

            if (reclamo.estado_unity == "Cerrado")
            {
                checkCerrarReclamo.Checked = true;
            }
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "El id ingresado o seleccionado no es valido o no tiene seguimiento", "A ocurrido un error", "erorr");
        }
    }

    //selecciona el contacto que fue amarrado al reclamo este trae su informacion y la coloca en texbox 
    public void datosContacto(int id)
    {
        try
        {
            var contacto = DBReclamos.contacto_auto.Select(c => new { c.correo, c.telefono, c.contacto, c.id_reclamo_auto }).Where(contac => contac.id_reclamo_auto == id).First();
            txtContacto.Text = contacto.contacto;
            txtTelefono.Text = contacto.telefono;
            txtCorreoContacto.Text = contacto.correo;
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer los datos del contaco.", "Nota..", "warning");
        }
    }

    protected void btnGuardarComentario_Click(object sender, EventArgs e)
    {
        String Comen = WebUtility.HtmlDecode(txtComentarios.Text);
        agregarComentario(Comen);
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
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error Al ingresar el comentario", "Error..", "error");
        }
    }

    //metodo para enviar correo electronico y para insertar el correo en los comentarios del reclamo
    public void enviarcorreo()
    {
        bool insertar = true;
        try
        {
            string from = txtFrom.Text;
            string password = txtContrasena.Text;
            string to = txtDestinatario.Text;
            string mensaje = txtMensaje.Text;
            string asunto = txtAsunto.Text;
            Utils.ShowMessage(this.Page, "Correo enviado con exito", "Excelente", "success");
        }

        catch (SmtpException)
        {
            Utils.ShowMessage(this.Page, "Error de autenticacion", "Nota..", "error");
            insertar = false;
        }

        if (insertar == true)
        {
            agregarComentario(txtMensaje.Text);
            vaciarFormulario();
        }
    }

    //contiene el evento que tiene el boton de envio de correo electronico
    protected void btnEnviarCorreo_Click(object sender, EventArgs e)
    {
        agregarComentario("Para: " + txtDestinatario.Text + "  ,Asunto: " + txtAsunto.Text + "  ,Mensaje:" + txtMensaje.Text);
    }

    //metodo para verificar que opciones fueron seleccionadas o deseleccionadas para luego ser actualizadas
    private void opcionesChecked()
    {
        if (CheckComplicado.Checked)
        {
            complicado = true;
        }
        if (checkCompromiso.Checked)
        {
            compromiso_pago = true;
        }
        if (checkPrioritario.Checked)
        {
            prioritario = true;
        }
        if (ChecKAutoAlquiler.Checked)
        {
            alquiler = true;
        }
        if (CheckPerdida.Checked)
        {
            perdidaTotal = true;
        }
        if (checkCerrarReclamo.Checked)
        {
            estado = "Cerrado";
        }
        if (checkCierreInterno.Checked)
        {
            cierre_interno = true;
        }
    }

    //evento para actualizar la informacion del reclamo
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        opcionesChecked();

        if (lblEstadoAuto.Text != ddlEstadoAuto.SelectedItem.ToString())
        {
            bitacora_estados_autos bitacora = new bitacora_estados_autos();
            bitacora.estado = ddlEstadoAuto.SelectedItem.Text;
            bitacora.fecha = DateTime.Now;
            bitacora.id_reclamo_auto = id;
            DBReclamos.bitacora_estados_autos.Add(bitacora);
        }

        try
        {
            var total_dias = DBReclamos.estados_reclamos_unity.ToList().Where(d => d.descripcion == ddlEstadoAuto.SelectedItem.Text).First();
            dias = Convert.ToInt16(total_dias.dias_revision);

            var fecha = DBReclamos.reclamo_auto.Select(r => new { r.fecha_visualizar, r.id }).Where(re => re.id == id).First();
            DateTime fecha_v = Convert.ToDateTime(fecha.fecha_visualizar);

            var reclamo = DBReclamos.reclamo_auto.Find(id);
            reclamo.estado_unity = estado;
            reclamo.num_reclamo = txtNumReclamo.Text;
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.perdida_total = perdidaTotal;
            reclamo.alquiler_auto = alquiler;
            reclamo.id_gestor = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.estado_auto_unity = ddlEstadoAuto.SelectedItem.Text;
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.observaciones = txtObservaciones.Text;
            reclamo.cierre_interno = cierre_interno;
            reclamo.fecha_visualizar = fecha_v.AddDays(dias);
            DBReclamos.SaveChanges();
            DatosReclamo(id);
            Utils.ShowMessage(this.Page, "Datos actualizados", "Excelente...!", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el registro", "Nota..", "error");
            Email.ENVIAR_ERROR("Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex, "Error de reclamo en seguimiento de autos");
        }

        if (checkCerrarReclamo.Checked)
        {
            cerrarReclamo();
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx");
        }
    }

    private void cerrarReclamo()
    {
        try
        {
            var cerrar = DBReclamos.reclamo_auto.Find(id);
            cerrar.acs = false;
            cerrar.fecha_cierre_reclamo = DateTime.Now;
            DBReclamos.SaveChanges();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido cerrar el reclamo", "Nota..", "error");
        }
    }

    //envio de correo en caso de alquiler de un vehiculo al asegurado
    private void alquilerVehiculo()
    {
        txtDestinatario.Text = txtCorreoContacto.Text;
        //mensaje personalizado de un alquiler de vehiculo        
        txtMensaje.Text = " Reciba un cordial saludo \n\n " +
            "En relación al reclamo en la referencia, por este medio hacemos de su conocimiento que su póliza goza con la cobertura de alquiler de vehículo por colisión. \n\n " +
            "El límite diario es de Q.   hasta un máximo de __ días, equivalente a Q     .   Aplicable por medio de reembolso y sujeto a  presentar la factura correspondiente de un Arrendadora legalmente autorizada. \n\n " +
            "Dentro del reembolso no se contemplará el costo de los seguros incluidos  en el contrato de arrendamiento.No aplica para servicios de taxis, y está sujeto a un deducible de Q - diarios y el 3 % de timbres fiscales. \n\n" +
            "La factura deberá ser emitida a su nombre, nos deberá enviar copia de la misma y el contrato por está vía, para el trámite del reembolso.\n\n" +
            "Cualquier duda, estamos a la orden";
        txtAsunto.Text = "Alquiler De Vehiculo ";
    }

    //envio de correo al ejecutivo notificando que existe una perdida total del vehiculo
    private void envioPerdidaTotal()
    {
        try
        {
            String correoGestor = "select gst_correo from gestores where gst_nombre = '" + txtEjecutivo.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(correoGestor, objeto.ObtenerConexionSeguro());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDestinatario.Text = dt.Rows[0][0].ToString();
        }
        catch (Exception)
        {

        }

        //mensaje personalizado de una perdida total.           
        txtMensaje.Text = "Estimado Ejecutivo \n\n Por este medio hacemos de su conocimiento que recibimos notificación de pérdida total,  del vehículo Placa: " + txtPlaca.Text + ", Marca: " + txtMarca.Text + ", Modelo: " + txtModelo.Text + ",  propiedad del asegurado " + lblNombreAsegurado.Text + " póliza " + lblNumeroPoliza.Text + " . Saludos";
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

    //ejecucion de metodos en evento del check de perdida total
    protected void CheckPerdida_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckPerdida.Checked)
        {
            envioPerdidaTotal();
        }
        else
        {
            vaciarFormulario();
        }
    }

    //ejecucion del metodo alquiler de vehiculo del metodo alquilervehiculo
    protected void ChecKAutoAlquiler_CheckedChanged(object sender, EventArgs e)
    {
        if (ChecKAutoAlquiler.Checked)
        {
            alquilerVehiculo();
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
            if (txtCoberturaAfectada.Text != "")
            {
                coberturaAfectada = txtCoberturaAfectada.Text;
            }
            else
            {
                coberturaAfectada = ddlSeleccionarCobertura.SelectedItem.ToString();
            }

            coberturas_afectadas cobertura = new coberturas_afectadas();
            cobertura.cobertura = coberturaAfectada;
            cobertura.limite1 = Convert.ToDecimal(txtLimite1.Text);
            cobertura.limite2 = Convert.ToDecimal(txtlimite2.Text);
            cobertura.deducible = Convert.ToDecimal(txtDeducible.Text);
            cobertura.prima = Convert.ToDecimal(txtPrima.Text);
            cobertura.id_reclamo_auto = id;
            DBReclamos.coberturas_afectadas.Add(cobertura);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            SeleccionarCoberturas(id);
            Utils.ShowMessage(this.Page, "Cobertura insertada con exito", "Excelente..", "success");
            txtLimite1.Text = "0.00";
            txtlimite2.Text = "0.00";
            txtDeducible.Text = "0.00";
            txtPrima.Text = "0.00";
            txtCoberturaAfectada.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido agregar la cobertura", "Nota..!", "error");
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
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el contacto", "Error..!", "error");
        }
    }

    //metodo para seleccionar cobertura afectada para realizar un pago
    //este metodo llena un dropdown list llamado ddlCoberturas
    private void SeleccionarCoberturas(int id)
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

        if (checkIva.Checked == true)
        {
            iva = monto / 1.12 * 0.12;
            monto = monto - iva;
        }

        monto = (monto - Convert.ToDouble(txtPagoDeducible.Text));
        timbres = monto * 0.03;
        monto = monto - timbres;
        total = (monto - Convert.ToDouble(txtPrimasPago.Text));

        try
        {
            detalle_pagos_reclamos_autos pago = new detalle_pagos_reclamos_autos();
            pago.cobertura_pagada = ddlCoberturas.SelectedItem.Text;
            pago.monto = Convert.ToDecimal(txtMonto.Text);
            pago.iva = Convert.ToDecimal(iva);
            pago.deducible = Convert.ToDecimal(txtPagoDeducible.Text);
            pago.timbres = Convert.ToDecimal(timbres);
            pago.primas = Convert.ToDecimal(txtPrimasPago.Text);
            pago.total = Convert.ToDecimal(total);
            pago.fecha = DateTime.Now;
            pago.id_reclamo_auto = id;
            DBReclamos.detalle_pagos_reclamos_autos.Add(pago);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(pagos, GridPagosReclamos);
            lblPagoTotal.Text = "<b>TOTAL : </b>" + total.ToString("N2");
            Utils.ShowMessage(this.Page, "Pago realizado con exito", "Excelente", "success");
            txtPagoDeducible.Text = "0.00";
            txtPrimasPago.Text = "0.00";
            txtMonto.Text = "0.00";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido realizar el pago", "Nota..!", "error");
        }
    }

    //salir del reclamo y me redirecciona a los reclamos en seguimiento
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/Dashboard.aspx",false);
    }

    //seleccionar  el deducible de la cobertura afectada.
    protected void ddlCoberturas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var deducible = DBReclamos.coberturas_afectadas.ToList().Where(d => d.id_reclamo_auto == id).First();
            txtPagoDeducible.Text = deducible.deducible.ToString();
        }

        catch (Exception ex)
        {
            Response.Write(ex);
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
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosEnSeguimiento.aspx");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar la fecha a visualizar", "Nota..!", "warning");
        }
    }
    // scripts para enviar correos electronicos segun el estado al que se cambie el vehiculo
    protected void ddlEstadoAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEstadoAuto.SelectedItem.Text == "Asignacion" && txtCorreoContacto.Text != "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Presupuesto" && txtCorreoContacto.Text != "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Ajustes autos" && txtCorreoContacto.Text != "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Reparacion" && txtCorreoContacto.Text != "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Entrega" && txtCorreoContacto.Text != "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmar_envio_correo').modal('show');", addScriptTags: true);
        }
    }

    protected void chCartaCierre_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaCierre.Checked)
        {
            txtCarta.Text = cartaCierreInterno;
            chCartaDeclinado.Checked = false;
            chEnvioCarta.Checked = false;
        }
        else
        {
            txtCarta.Text = "";
        }
    }

    protected void chCartaDeclinado_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaDeclinado.Checked)
        {
            txtCarta.Text = cartaDeclinacionReclamo;
            chCartaCierre.Checked = false;
            chEnvioCarta.Checked = false;
        }

        else
        {
            txtCarta.Text = "";
        }
    }

    protected void chEnvioCarta_CheckedChanged(object sender, EventArgs e)
    {
        if (chEnvioCarta.Checked)
        {
            txtCarta.Text = cartaEnvioCheque;
            chCartaCierre.Checked = false;
            chCartaDeclinado.Checked = false;
        }
        else
        {
            txtCarta.Text = "";
        }
    }

    //metodo para habilitar la casilla del numero de reclamo que brinda la aseguradora
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

    //funcion para mostrar los comentarios con los saltos de lineas dentro del gridview
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

    //envio de notificacion automatica de correos electronicos por cambio de estado del reclamo
    public void enviarNotificacion()
    {
    }

    public void enviar_notificaciones_click(object sender, EventArgs e)
    {
        if (ddlEstadoAuto.SelectedItem.Text == "Asignacion" && txtCorreoContacto.Text != "")
        {
            mensaje = "Estimado asegurado: \n\n" +
                " Mi nombre es " + txtGestor.Text + ", soy la persona asignada para la atención del reclamo presentado por daños al vehículo" +
                " Placas: " + txtPlaca.Text + " Marca: " + txtMarca.Text + " Año: " + txtModelo.Text + ", " +
                " Mi teléfono directo es:   " + txtGestorTelefono.Text + " para que pueda contactarme en cualquier consulta. \n" +
                " Solicito de su amable apoyo a manera que pueda confirmarme si ya cuenta con fecha para el ingreso de su vehículo al taller y así poderle apoyar en el proceso de su reclamo. \n\n" +
                " Cualquier duda, estoy a la orden.";
            txtAsunto.Text = "Asignacion Reclamo";
            enviarNotificacion();
            agregarComentario("Correo automatico: " + mensaje);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Presupuesto" && txtCorreoContacto.Text != "")
        {
            mensaje = "Estimado Asegurado, \n" +
             "Reciba un cordial saludo! Actualmente su reclamo presentado por daños al vehículo " + txtMarca.Text + ", " + txtModelo.Text + ", con placas: " + txtPlaca.Text + ", se encuentra en elaboración de presupuesto y cotización de repuestos. \n\n " +
             "Saludos cordiales..";
            txtAsunto.Text = "Presupuesto";
            enviarNotificacion();
            agregarComentario("Correo Automatico: " + mensaje);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Ajustes autos" && txtCorreoContacto.Text != "")
        {
            mensaje = "Estimado Asegurado \n\n" +
               "Hacemos de su conocimiento que el vehículo está en proceso de ajuste de parte de la compañía de seguros. \n\n" +
               "Saludos Cordiales";
            txtAsunto.Text = "Ajuste Auto";
            enviarNotificacion();
            agregarComentario("Correo Automatico: " + mensaje);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Reparacion" && txtCorreoContacto.Text != "")
        {
            mensaje = "Estimado Asegurado,\n\n " +
                "Su vehículo actualmente está en proceso de reparación, con gusto se le estará retroalimentando sobre el proceso hasta su entrega. \n\n" +
                "Saludos Cordiales";
            txtAsunto.Text = "Reparacion";
            enviarNotificacion();
            agregarComentario("Correo Automatico: " + mensaje);
        }

        else if (ddlEstadoAuto.SelectedItem.Text == "Entrega" && txtCorreoContacto.Text != "")
        {
            txtMensaje.Text = "Estimado Asegurado: \n\n" +
                "Su vehículo está programado para fecha __________ , \n" +
                "Le recordamos realizar el pago de su deducible que corresponde. \n\n" +
                "Saludos Cordiales";
            txtAsunto.Text = "Entrega";
        }

        else
        {
            vaciarFormulario();
        }
    }

    protected void linkRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/Dashboard.aspx", false);
    }

    public void tiempo()
    {
        string tiemposAbierto = "select DATEDIFF(SECOND, fecha_apertura_reclamo, getdate()) from reclamo_auto where id = " + id + "";
        SqlDataAdapter da = new SqlDataAdapter(tiemposAbierto, objeto.ObtenerConexionReclamos());
        DataTable dt = new DataTable();
        da.Fill(dt);
        txtTiempo.Text = dt.Rows[0][0].ToString();
    }
}