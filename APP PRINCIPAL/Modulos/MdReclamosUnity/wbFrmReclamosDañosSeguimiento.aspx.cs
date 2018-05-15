using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosDañosSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    DateTime thisDay = DateTime.Today;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Email notificacion = new Email();
    bool prioritario = false;
    bool complicado = false;
    bool compromiso_pago = false;
    String estado = "Seguimiento"; //esta variable es la que se utiliza para cambiar el estado a cerrado de un reclamo.
    String poliza;
    String idRecibido, comentarios, pagos, llamadas, coberturas, datosSiniestro, estados, liquidaciones;
    String estadoReclamo, cartaEnvioCheque, cartaCierreInterno, cartaDeclinado;
    int id, dias, idPago=0;
    //variables para calculos de pagos de reclamos
    Double iva, monto_reclamado, mejora_tecnologica,tiempo_uso, infra_seguro, perdida_final_ajustada, perdidaConDeducible, deducible, valor_indemnizado, timbres, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        id = Int32.Parse(idRecibido);
        var reg = DBReclamos.reclamos_varios.Find(id);

        cartaEnvioCheque   = Cartas.CARTA_ENVIO_CHEQUE_DANOS(reg);
        cartaCierreInterno = Cartas.CARTA_CIERRE_INTERNO_DANOS(reg);
        cartaDeclinado     = Cartas.CARTA_DECLINADO_DANOS(reg); 

        datosSiniestro = Consultas.DATOS_SINIESTRO(id);
        coberturas     = Consultas.COBERTURAS(id);
        llamadas       = Consultas.LLAMADAS(id);
        comentarios    = Consultas.COMENTARIOS(id);
        estados        = Consultas.ESTADOS(id);
        liquidaciones  = Consultas.LIQUIDACIONES(id);

        if (!IsPostBack)
        {
            txtSMS.Visible = false;
            llenar_dropdowns();
            datosContacto(id);
            datosReclamo(id);
            SeleccionarCoberturas(id);
            //funciones que llenan los gridviews
            llenado.llenarGrid(datosSiniestro, GridDatosAccidente);
            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            llenado.llenarGrid(llamadas, Gridllamadas);
            llenado.llenarGrid(comentarios, GridComentarios);
            llenado.llenarGrid(estados, GridEstados);
            llenado.llenarGrid(liquidaciones, GridLiquidaciones);
            Tiempo();
            BitacoraReclamo();
            btnActualizarPagos.Enabled = false;
        }
    }

    public void MostrarLiquidacion(int identificador)
    {
        pagos = Consultas.PAGOS_DANOS(identificador);
        llenado.llenarGrid(pagos, GridPagosReclamos);
    }

    public void llenar_dropdowns()
    {
        ddlAnalista.DataSource = DBReclamos.analistas.ToList().Where(analistas => analistas.tipo == "Daños varios");
        ddlAnalista.DataTextField = "nombre";
        ddlAnalista.DataValueField = "id";
        ddlAnalista.DataBind();

        ddlTaller.DataSource = DBReclamos.talleres.ToList();
        ddlTaller.DataTextField = "nombre";
        ddlTaller.DataValueField = "id";
        ddlTaller.DataBind();

        ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(gestores => gestores.tipo == "Daños varios");
        ddlGestor.DataTextField = "nombre";
        ddlGestor.DataValueField = "id";
        ddlGestor.DataBind();

        ddlTipoCierre.DataBind();
    }

    public void datosReclamo(int id)
    {
        try
        {
            var reclamo = DBReclamos.reclamos_varios.Find(id);
            //detalle de la poliza
            lblIdReclamo.Text = "<b>ID :</b>                  " + reclamo.id;
            lblPoliza.Text = "<b>POLIZA :</b>                 " + reclamo.reg_reclamo_varios.poliza;
            lblAsegurado.Text =   "<b>ASEGURADO :</b>         " + reclamo.reg_reclamo_varios.asegurado;
            lblAseguradora.Text = "<b>ASEGURADORA :</b>       " + reclamo.reg_reclamo_varios.aseguradora;
            lblContratante.Text = "<b>CONTRATANTE :</b>       " + reclamo.reg_reclamo_varios.contratante;
            lblEjecutivo.Text =   "<b>EJECUTIVO :</b>         " + reclamo.reg_reclamo_varios.ejecutivo;
            lblEstado.Text =      "<b>ESTADO :</b>            " + reclamo.reg_reclamo_varios.status;
            lblDireccion.Text =   "<b>DIRECCION :</b>         " + reclamo.reg_reclamo_varios.direccion;
            lblVip.Text =         "<b>VIP :</b>               " + reclamo.reg_reclamo_varios.vip;
            lblSumaAsegurada.Text = "<b>Suma Aseguarda :</b>  " + reclamo.reg_reclamo_varios.suma_asegurada;
            lblMoneda.Text = "<b>Moneda :</b>                 " + reclamo.reg_reclamo_varios.moneda;
            lblProductoNoConforme.Text = "<b>Producto No Conforme Asignado: </b>" + reclamo.detalle_no_conforme;
            txtObservacionesNoConf.Text =                         reclamo.observacion_no_conforme;

            //listado de dropdown
            lblEstadoReclamo.Text        = reclamo.estado_reclamo_unity;
            ddlTipoCierre.SelectedValue  = reclamo.motivo_cierre;
            lblRamo.Text                 = reclamo.reg_reclamo_varios.ramo;
            ddlEstadoReclamo.Text        = reclamo.estado_reclamo_unity;
            ddlGestor.SelectedValue      = reclamo.id_gestor.ToString();
            ddlTaller.SelectedValue      = reclamo.id_taller.ToString();
            ddlAnalista.SelectedValue    = reclamo.id_analista.ToString();
            ddlTipoCierre.SelectedValue = String.IsNullOrEmpty(reclamo.motivo_cierre) ? "" : reclamo.motivo_cierre;
            ddlNoConforme.SelectedValue = String.IsNullOrEmpty(reclamo.detalle_no_conforme) ? "" : reclamo.detalle_no_conforme;
            txtObservaciones.Text        = reclamo.observaciones;
            txtNumReclamo.Text           = reclamo.num_reclamo;
            txtContrato.Text             = reclamo.num_contrato;
            txtFrom.Text                 = reclamo.gestores.correo;

            //varios
            lblfechaSiniestro.Text       = reclamo.fecha.ToString();
            lblFechaCommit.Text          = reclamo.fecha_commit.ToString();
            lblReportante.Text           = reclamo.reportante;
            lblIDRec.Text                = reclamo.num_reclamo;
            lblAseguradoRec.Text         = reclamo.reg_reclamo_varios.asegurado;
            lblProximaFecha.Text         = "Proxima Fecha:" + Convert.ToDateTime(reclamo.fecha_visualizar).ToString("dd/MM/yyyy");
            lblEstadoR.Text              =  reclamo.estado_unity;

            if (reclamo.estado_unity == "Cerrado")
            {
                lblEstadoR.ForeColor = System.Drawing.Color.Red;
                btnPago.Enabled = false;
            }

            if (reclamo.estado_unity == "Cerrado") checkCerrarReclamo.Checked = true;
            checkPrioritario.Checked = reclamo.prioritario.Value;
            CheckComplicado.Checked = reclamo.complicado.Value;
            checkCompromiso.Checked = reclamo.compromiso_pago.Value;

            //informacion del taller asignado
            txtNombreTaller.Text = reclamo.talleres.nombre;
            txtDireccionTaller.Text = reclamo.talleres.direccion;
            txtTelefonoTaller.Text = reclamo.talleres.telefono;
            txtCorreoTaller.Text = reclamo.talleres.correo;

            //datos del analista
            txtNombreAnalista.Text = reclamo.analistas.nombre;
            txtEmpresaAnalista.Text = reclamo.analistas.Empresa;
            txtTelefonoAnalista.Text = reclamo.analistas.telefono;
            txtCorreoAnalista.Text = reclamo.analistas.correo;

            if (reclamo.no_conforme == false)
            {
                ddlEstadoNoConforme.SelectedItem.Text = "Cerrado";
                ddlEstadoNoConforme.Enabled = false;
                btnProductoNoConforme.Enabled = false;
            }
        }
        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "El id seleccionado no tiene ningun seguimiento", "Error.. !", "error");
        }
    }

    //metodo que obtiene los datos del contacto asociado al reclamo
    public void datosContacto(int id)
    {
        try
        {
            var contacto = DBReclamos.contactos_reclamos_varios.Select(c => new { c.correo, c.telefono, c.nombre, c.id_reclamos_varios }).Where(contac => contac.id_reclamos_varios == id).First();
            txtContacto.Text = contacto.nombre; 
            txtTelefono.Text = contacto.telefono;
            txtCorreoContacto.Text = contacto.correo;
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer los datos del contaco.", "Nota..", "warning");
        }
    }

    //metodo que actualiza los datos del contacto
    protected void btnActualizarContacto_Click(object sender, EventArgs e)
    {
        try
        {
            var actualizar_contacto = DBReclamos.contactos_reclamos_varios.Where(c => c.id_reclamos_varios == id).First();
            actualizar_contacto.nombre = txtContacto.Text;
            actualizar_contacto.telefono = txtTelefono.Text;
            actualizar_contacto.correo = txtCorreoContacto.Text;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Contacto Actualizado con exito", "Excelente..!", "success");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el contacto", "Nota..", "warning");
        }
    }

    //agregar una cobertura de forma manual
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
            coberturas_afectadas_danios cobertura = new coberturas_afectadas_danios();
            cobertura.cobertura = coberturaAfectada;
            cobertura.limite1 = Convert.ToDecimal(txtLimite1.Text);
            cobertura.limite2 = Convert.ToDecimal(txtlimite2.Text);
            cobertura.deducible = Convert.ToDecimal(txtDeducible.Text);
            cobertura.prima = Convert.ToDecimal(txtPrima.Text);
            cobertura.id_reclamos_varios = id;
            DBReclamos.coberturas_afectadas_danios.Add(cobertura);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            Utils.ShowMessage(this.Page, "Cobertura insertada con exito", "Nota..!", "success");
            txtLimite1.Text = "0.00";
            txtlimite2.Text = "0.00";
            txtDeducible.Text = "0.00";
            txtPrima.Text = "0.00";
            txtCoberturaAfectada.Text = "";
            SeleccionarCoberturas(id);
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido insertar la cobertura", "Nota..!", "error");
        }
    }

    //agregar un comentario nuevo
    private void agregarComentario(String descripcion)
    {
        try
        {
            comentarios_reclamos_varios comentario = new comentarios_reclamos_varios();
            comentario.descripcion = descripcion;
            comentario.usuario = userlogin;
            comentario.fecha = DateTime.Now;
            comentario.id_reclamos_varios = id;
            DBReclamos.comentarios_reclamos_varios.Add(comentario);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(comentarios, GridComentarios);
            Utils.ShowMessage(this.Page, "Comentario ingresado con exito", "Excelente..!", "info");
            txtComentarios.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al ingresar el comentario", "Error..!", "error");
        }
    }

    protected void btnEnviarCorreo_Click(object sender, EventArgs e)
    {
        agregarComentario("Para: " + txtDestinatario.Text + "  ,Asunto: " +txtAsunto.Text + "  ,Mensaje:" + txtMensaje.Text);
    }

    //envento donde se llama al metodo para agregar el comentario
    protected void btnGuardarComentario_Click(object sender, EventArgs e)
    {
        agregarComentario(txtComentarios.Text);
    }

    //metodo para llenar el dropdown que tiene las coberturas afectadas
    private void SeleccionarCoberturas(int id)
    {
        try
        {
            ddlCoberturas.DataSource = DBReclamos.coberturas_afectadas_danios.ToList().Where(coberturas_afectadas_danios => coberturas_afectadas_danios.id_reclamos_varios == id);
            ddlCoberturas.DataTextField = "cobertura";
            ddlCoberturas.DataValueField = "id";
            ddlCoberturas.DataBind();
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido traer las coberturas para realizar la liquidacion", "Nota..!", "warning");
        }
    }

    //metodo que verifica los check que fueron o estan seleccionados para actualizar la informacion
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
        //if (checkCerrarReclamo.Checked)
        //{
        //    estado = "Cerrado";
        //}
    }

    private void actualizar_fecha_seguimiento()
    {
        var seguimiento = DBReclamos.reclamos_varios.Find(id);

        var dias_revision = DBReclamos.estados_reclamos_unity.Select(est => new { est.dias_revision, est.descripcion, est.tipo }).
        Where(es => es.descripcion == ddlEstadoReclamo.SelectedItem.Text && es.tipo == "daños").First();
        dias = Convert.ToInt32(dias_revision.dias_revision);

        var fecha = DBReclamos.reclamos_varios.Select(r => new { r.fecha_visualizar, r.id, }).Where(re => re.id == id).First();
        DateTime fecha_v = Convert.ToDateTime(fecha.fecha_visualizar);

        seguimiento.fecha_visualizar = fecha_v.AddDays(dias);
        DBReclamos.SaveChanges();
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        opcionesChecked();

        if (lblEstadoReclamo.Text != ddlEstadoReclamo.SelectedItem.ToString())
        {
            bitacora_estados_reclamos_varios bitacora = new bitacora_estados_reclamos_varios();
            bitacora.estado = ddlEstadoReclamo.SelectedItem.Text;
            bitacora.fecha = DateTime.Now;
            bitacora.id_reclamos_varios = id;
            DBReclamos.bitacora_estados_reclamos_varios.Add(bitacora);
            actualizar_fecha_seguimiento();
        }

        //actualizacion general de la informacicon
        try
        {
            var reclamo = DBReclamos.reclamos_varios.Find(id);
            reclamo.estado_unity = estado;
            reclamo.num_reclamo = txtNumReclamo.Text.ToString();
            reclamo.num_contrato = txtContrato.Text;
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.id_taller = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.estado_reclamo_unity = ddlEstadoReclamo.SelectedItem.Text;
            reclamo.observaciones = txtObservaciones.Text.ToString();
          

            if (checkCerrarReclamo.Checked)
            {
                if (reclamo.estado_unity != "Cerrado")
                {
                    cerrarReclamo();
                }
            }

            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Reclamo Actualizado con exito", "Excelente..!", "success");
            datosReclamo(id);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el reclamo", "Error..!", "error");
            notificacion.enviarcorreo("reclamosgt@unitypromotores.com", "123$456R", "jorge.laj@unitypromotores.com", "Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex, "Error en seguimiento de reclamos de daños");
        }
    }

    //Habilitar el check para agregar el numero de reclamo que brinda la aseguradora
    protected void checkHabilitar_CheckedChanged(object sender, EventArgs e)
    {
        if (checkHabilitar.Checked)
        {
            txtNumReclamo.Enabled = true;
            txtContrato.Enabled = true;
        }
        else
        {
            txtNumReclamo.Enabled = false;
            txtContrato.Enabled = false;
        }
    }

    //funcion para habilitar el reclamo en una fecha seleccionada
    protected void btnGuardarProximaFecha_Click(object sender, EventArgs e)
    {
        try
        {
            var update_fecha = DBReclamos.reclamos_varios.Find(id);
            update_fecha.fecha_visualizar = Convert.ToDateTime(txtProximaFecha.Text);
            DBReclamos.SaveChanges();
            datosReclamo(id);
            Utils.ShowMessage(this.Page, "la fecha para mostrar el reclamo en su seguimiento se a modificado", "Nota..!", "info");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar la fecha", "Nota..!", "warning");
        }
    }
    //funcion para aplicar pagos a un reclamo

    protected void btnPago_Click(object sender, EventArgs e)
    {
        monto_reclamado = Convert.ToDouble(txtMontoReclamado.Text);
        mejora_tecnologica = Convert.ToDouble(txtMejora.Text);
        tiempo_uso = Convert.ToDouble(txtTiempoUso.Text);
        infra_seguro = Convert.ToDouble(txtInfraseguro.Text);
        deducible = Convert.ToDouble(txtDeducible2.Text);

        perdida_final_ajustada = monto_reclamado - ( mejora_tecnologica + tiempo_uso + infra_seguro);
        perdidaConDeducible = perdida_final_ajustada - deducible;
        timbres = perdidaConDeducible * 0.03;
        valor_indemnizado = perdidaConDeducible - timbres;

        try
        {
            detalle_pagos_reclamos_varios pago = new detalle_pagos_reclamos_varios();
            pago.cobertura_pagada = ddlCoberturas.SelectedItem.Text;
            pago.ramo = lblRamo.Text;
            pago.tipo_pago = ddlElegir.SelectedItem.Text;
            pago.monto_reclamado = Convert.ToDecimal(monto_reclamado);
            pago.monto_ajustado = Convert.ToDecimal(txtMontoAjustado.Text);
            pago.mejora_tecnologica = Convert.ToDecimal(mejora_tecnologica);
            pago.tiempo_uso = Convert.ToDecimal(tiempo_uso);
            pago.infra_seguro = Convert.ToDecimal(infra_seguro);
            pago.perdida_final_ajustada = Convert.ToDecimal(perdida_final_ajustada);
            pago.deducible = Convert.ToDecimal(deducible);
            pago.salvamento = Convert.ToDecimal(txtSalvamento.Text);
            pago.iva = Convert.ToDecimal(txtIva.Text);
            pago.timbres = Convert.ToDecimal(timbres);
            pago.valor_indemnizado = Convert.ToDecimal(valor_indemnizado);
            pago.fecha = DateTime.Now;
            pago.id_reclamos_varios = id;
            pago.destino = ddlDestinoCheque.SelectedValue;
            DBReclamos.detalle_pagos_reclamos_varios.Add(pago);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(liquidaciones, GridLiquidaciones);
            lblPagoTotal.Text = "<b>TOTAL : </b>" + valor_indemnizado.ToString("N2");
            Utils.ShowMessage(this.Page, "Pago guardado con exito..!", "Excelete..!", "info");
            txtMejora.Text = "0.00";
            txtTiempoUso.Text = "0.00";
            txtInfraseguro.Text = "0.00";
            txtDeducible2.Text = "0.00";
            txtMontoReclamado.Text = "0.00";
            txtSalvamento.Text = "0.00";
            txtIva.Text = "0.00";

        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Utils.ShowMessage(this.Page, "No se a podido efectuar el pago", "Nota..!", "error");
        }
    }

    //link para salir del reclamo
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecDañosSeguimiento.aspx");
    }
    //metodo para cerar el reclamo
    protected void cerrarReclamo()
    {
       try
        {
            var reclamo_cerrado = DBReclamos.reclamos_varios.Find(id);
            reclamo_cerrado.estado_unity = "Cerrado";
            reclamo_cerrado.motivo_cierre = ddlTipoCierre.SelectedValue;
            reclamo_cerrado.fecha_cierre_reclamo = DateTime.Now;
            reclamo_cerrado.acs = false;
            DBReclamos.SaveChanges();
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecDañosSeguimiento.aspx",false);
        }
        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido cerrar el reclamo..", "Nota..!", "error");
        }
    }

    //asignar valor al modelo de la carta
    protected void chEnvioCarta_CheckedChanged(object sender, EventArgs e)
    {
        if (chEnvioCarta.Checked)
        {
            DatosCarta();
            PnDetallePago.Visible = true;
            lblMemo.Text = cartaEnvioCheque;
            chCartaCierre.Checked = false;
            chCartaDeclinado.Checked = false;
        }
        else
        {
            lblMemo.Text = "";
            PnDetallePago.Visible = false;
        }
    }
    protected void chCartaDeclinado_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaDeclinado.Checked)
        {
            PnDetallePago.Visible = false;
            DatosCarta();
            lblMemo.Text = cartaDeclinado;
            chCartaCierre.Checked = false;
            chEnvioCarta.Checked = false;
        }

        else
        {
            lblMemo.Text = "";
        }
    }
    protected void chCartaCierre_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaCierre.Checked)
        {
            PnDetallePago.Visible = false;
            DatosCarta();
            lblMemo.Text = cartaCierreInterno;
            chCartaDeclinado.Checked = false;
            chEnvioCarta.Checked = false;
        }
        else
        {
            lblMemo.Text = "";
        }
    }

    //funcion para actualizar un pago
    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
        try
        {
            idPago = Convert.ToInt32(GridLiquidaciones.SelectedRow.Cells[1].Text);
            var pago = DBReclamos.detalle_pagos_reclamos_varios.Find(idPago);
            pago.cobertura_pagada = ddlCoberturas.SelectedItem.Text;
            pago.ramo = txtRamo.Text;
            pago.tipo_pago = ddlElegir.SelectedItem.Text;
            pago.monto_reclamado = Convert.ToDecimal(txtMontoReclamado.Text);
            pago.monto_ajustado = Convert.ToDecimal(txtMontoAjustado.Text);
            pago.mejora_tecnologica = Convert.ToDecimal(txtMejora.Text);
            pago.tiempo_uso = Convert.ToDecimal(txtTiempoUso.Text);
            pago.infra_seguro = Convert.ToDecimal(txtInfraseguro.Text);
            pago.perdida_final_ajustada = Convert.ToDecimal(txtPerdidaFinal.Text);
            pago.deducible = Convert.ToDecimal(txtDeducible2.Text);
            pago.salvamento = Convert.ToDecimal(txtSalvamento.Text);
            pago.timbres = Convert.ToDecimal(txtTimbres.Text);
            pago.valor_indemnizado = Convert.ToDecimal(txtValorTotal.Text);
            pago.iva = Convert.ToDecimal(txtIva.Text);
            pago.destino = ddlDestinoCheque.SelectedValue;
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Pago Actualizado con exito", "Excelente..!", "info");
            MostrarLiquidacion(idPago);
            llenado.llenarGrid(liquidaciones, GridLiquidaciones);

            txtRamo.Text = "";
            ddlElegir.Text = "";
            txtMontoReclamado.Text = "0.00";
            txtMejora.Text = "0.00";
            txtTiempoUso.Text = "0.00";
            txtInfraseguro.Text = "0.00";
            txtPerdidaFinal.Text = "0.00";
            txtDeducible2.Text = "0.00";
            txtTimbres.Text = "0.00";
            txtValorTotal.Text = "0.00";
            txtIva.Text = "0.00";
            txtTimbres.Text = "0.00";
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            Utils.ShowMessage(this.Page, "No se a podido actualizar la liquidacion", "Error..!", "error");
        }
    }

    protected void ddlEstadoReclamo_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDestinatario.Text = txtCorreoContacto.Text;

        if (ddlEstadoReclamo.SelectedValue == "Asignacion")
        {
            txtMensaje.Text = Constantes.ASIGNACION_DAÑOS(lblfechaSiniestro);
            txtAsunto.Text = "Asignacion Reclamo";
        }

        if (ddlEstadoReclamo.SelectedValue == "Pendiente Asegurado")
        {
            txtMensaje.Text = Constantes.PENDIENTE_ASEGURADO_DAÑOS(lblReportante, lblFechaCommit);
            txtAsunto.Text = "Pendiente Asegurado";
        }

        if (ddlEstadoReclamo.SelectedValue == "Ajuste" && txtTelefono.Text != "" )
        {
            txtMensaje.Text = Constantes.AJUSTE_DAÑOS(lblIDRec,lblAseguradoRec); 
            txtAsunto.Text = "Ajuste";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmacion_sms').modal('show');", addScriptTags: true);
        }

        if (ddlEstadoReclamo.SelectedValue == "Pendiente Finiquito" && txtTelefono.Text != "")
        {
            txtMensaje.Text = Constantes.PENDIENTE_FINIQUITO_DAÑOS(lblAseguradoRec);
            txtAsunto.Text = "Pendiente Finiquito";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmacion_sms').modal('show');", addScriptTags: true);
        }

        if (ddlEstadoReclamo.SelectedValue == "Cheque Entrega")
        {
            txtMensaje.Text = Constantes.CHEQUE_DAÑOS(lblIDRec);
            txtAsunto.Text = "Cheque";
        }

        if (ddlEstadoReclamo.SelectedValue == "Inactivo")
        {
            txtMensaje.Text = Constantes.Mensaje(lblFechaCommit);
            txtAsunto.Text = "Inactivo";
        }

        if (ddlEstadoReclamo.SelectedValue == "Cheque Entrega" && txtTelefono.Text != "")
        {
            var destino_cheque = DBReclamos.detalle_pagos_reclamos_varios.Select(d => new { d.destino, d.id_reclamos_varios }).Where(de => de.id_reclamos_varios == id).First();
            if (destino_cheque.destino == "Escritura de pago")
            {
                txtSMS.Visible = true;
            }

            else
            {
                txtSMS.Visible = false;
            }
            
            txtSMS.Text = "UNITY: Estimad@ cliente reunión entrega de cheque/firma de escritura, del ID " + id + " coordinada para el xx/xx/xxxx a las xx am/pm";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmacion_sms').modal('show');", addScriptTags: true);
        }

        if (ddlEstadoReclamo.SelectedValue == "Revisión Gestor Reclamos" && txtTelefono.Text != "" )
        {
            txtMensaje.Text = Constantes.PENDIENTE_GESTOR_RECLAMOS_DAÑOS(lblIDRec, lblFechaCommit);
            txtAsunto.Text = "Revision Gestor Reclamos";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#confirmacion_sms').modal('show');", addScriptTags: true);
        }
    }

    protected void btnEnviarNotificacion_Click(object sender, EventArgs e)
    {
        if (ddlEstadoReclamo.SelectedValue == "Revisión Gestor Reclamos")
        {
            Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente hemos recibido la documentacion de su reclamo ID " + id + ", se revisara para enviar al ajustador.", userlogin, id);
            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoReclamo.SelectedValue == "Ajuste")
        {
            Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente la documentacion del reclamo " + id + " esta siendo analizada por la aseguradora.", userlogin, id);
            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoReclamo.SelectedValue == "Pendiente Finiquito")
        {
            Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente la propuesta de liquidación/convenio de ajuste del reclamo ID " + id + " fue enviada a su e-mail para revisión.", userlogin, id);
            llenado.llenarGrid(comentarios, GridComentarios);
        }

        else if (ddlEstadoReclamo.SelectedValue == "Cheque Entrega")
        {
            var destino_cheque = DBReclamos.detalle_pagos_reclamos_varios.Select(d => new { d.destino, d.id_reclamos_varios }).Where(de => de.id_reclamos_varios == id).First();

            if (destino_cheque.destino == "Ruta")
            {
                Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente el cheque del reclamo " + id + " se encuentra en ruta para la entrega a su dirección registrada.", userlogin, id);
                llenado.llenarGrid(comentarios, GridComentarios);
            }

            else if (destino_cheque.destino == "Recepcion")
            {
                Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente el cheque del reclamo " + id + " se encuentra listo recepcion Unity favor pasar a recogerlo.", userlogin, id);
                llenado.llenarGrid(comentarios, GridComentarios);
            }

            else if (destino_cheque.destino == "Escritura de pago")
            {
                Utils.SMS_reclamos_danios(txtTelefono.Text, txtSMS.Text, userlogin, id);
                llenado.llenarGrid(comentarios, GridComentarios);
            }
        }
    }

    protected void GridComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("\n", "<br/>");
            }
        }
        catch (Exception err)
        {
            Response.Write(err);
        }
    }

    public void Tiempo()
    {
        try
        {
            string tiemposAbierto = "select DATEDIFF(SECOND, fecha_apertura_reclamo, getdate()) from reclamos_varios where id = " + id + "";
            SqlDataAdapter da = new SqlDataAdapter(tiemposAbierto, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtTiempo.Text = dt.Rows[0][0].ToString();
        }

        catch( Exception)
        {

        }
    }

    private void BitacoraReclamo()
    {
        var bitacora = DBReclamos.reclamos_varios.Find(id);
        BitPoliza.Text = bitacora.reg_reclamo_varios.poliza;
        BitAsegurado.Text = bitacora.reg_reclamo_varios.asegurado;
        BitEjecutivo.Text = bitacora.reg_reclamo_varios.ejecutivo;
        BitAseguradora.Text = bitacora.reg_reclamo_varios.aseguradora;
        BitEstado.Text = bitacora.reg_reclamo_varios.status;

        BitId.Text = bitacora.id.ToString();
        BitReportante.Text = bitacora.reportante;
        BitFecha.Text = Convert.ToDateTime(bitacora.fecha).ToString("dd/MM/yyyy");
        BitNumeroReclamo.Text = bitacora.num_reclamo;

        llenado.llenarGrid(llamadas, Bitllamadas);
        llenado.llenarGrid(comentarios, BitSeguimiento);
    }

    protected void GridLiquidaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        idPago = Convert.ToInt32(GridLiquidaciones.SelectedRow.Cells[1].Text);

        String actualizar_pago = "select id, cobertura_pagada, ramo, tipo_pago, monto_reclamado, mejora_tecnologica, tiempo_uso, infra_seguro," +
            " perdida_final_ajustada, deducible, timbres, valor_indemnizado , iva,salvamento, destino from detalle_pagos_reclamos_varios where id = " + idPago + "";
        SqlDataAdapter da = new SqlDataAdapter(actualizar_pago, objeto.ObtenerConexionReclamos());
        DataTable dt = new DataTable();
        da.Fill(dt);

        txtRamo.Text = dt.Rows[0][2].ToString();
        ddlElegir.Text = dt.Rows[0][3].ToString();
        txtMontoReclamado.Text = dt.Rows[0][4].ToString();
        txtMejora.Text = dt.Rows[0][5].ToString();
        txtTiempoUso.Text = dt.Rows[0][6].ToString();
        txtInfraseguro.Text = dt.Rows[0][7].ToString();
        txtPerdidaFinal.Text = dt.Rows[0][8].ToString();
        txtDeducible2.Text = dt.Rows[0][9].ToString();
        txtTimbres.Text = dt.Rows[0][10].ToString();
        txtValorTotal.Text = dt.Rows[0][11].ToString();
        txtIva.Text = dt.Rows[0][12].ToString();
        txtSalvamento.Text = dt.Rows[0][13].ToString();
        ddlDestinoCheque.SelectedValue = String.IsNullOrEmpty(dt.Rows[0][14].ToString()) ? "" : dt.Rows[0][14].ToString();
        btnPago.Enabled = false;
        btnActualizarPagos.Enabled = true;
        MostrarLiquidacion(idPago);

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalActualizar').modal('show');", addScriptTags: true);
    }

    public void DatosCarta()
    {
        var registro = DBReclamos.reclamos_varios.Find(id);
        var contacto = DBReclamos.contactos_reclamos_varios.Select(c => new { c.correo, c.telefono, c.nombre, c.id_reclamos_varios }).Where(contac => contac.id_reclamos_varios == id).First();
        lblCartaFecha.Text = DateTime.Now.ToString("D") ;
        lblCartaid.Text = "ID :" + registro.id.ToString(); 
        lblCartaCliente.Text = contacto.nombre;
        lblCartaEmpresa.Text = registro.reg_reclamo_varios.contratante;
        lblCartaDireccion.Text = registro.reg_reclamo_varios.direccion;
        lblCartaPoliza.Text = registro.reg_reclamo_varios.poliza;
        lblCartaNumeroReclamo.Text = registro.num_reclamo;
        lblCartaAsegurado.Text = registro.reg_reclamo_varios.asegurado;
        lblCartaEjecutivo.Text = registro.reg_reclamo_varios.ejecutivo;
        lblCartaAsesorReclamo.Text = registro.gestores.nombre;
    }

    protected void lnkGuardarCarta_Click(object sender, EventArgs e)
    {
        //cartas carta = new cartas();
        //carta.contenido = txtContenidoCarta.Text;
        //carta.tipo = "rv_cierre_interno";
        //carta.id_reclamo = id;
        //DBReclamos.cartas.Add(carta);
        //DBReclamos.SaveChanges();
    }

    protected void btnProductoNoConforme_Click(object sender, EventArgs e)
    {
        try
        {
            var noConforme = DBReclamos.reclamos_varios.Find(id);

            if(ddlEstadoNoConforme.SelectedValue == "Abierto")
            {
                noConforme.no_conforme = true;
                noConforme.detalle_no_conforme = ddlNoConforme.SelectedValue;
                noConforme.fecha_no_conforme = DateTime.Now;
                noConforme.observacion_no_conforme = txtObservacionesNoConf.Text;
                DBReclamos.SaveChanges();
                agregarComentario("Este reclamo a sido encontrado como no conforme, catalogado como " + ddlNoConforme.SelectedValue + ". " + txtObservacionesNoConf.Text);
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
 
        }
        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el reclamo como no conforme.", "Error", "error");
        }
    }

    protected void checkCerrarReclamo_CheckedChanged(object sender, EventArgs e)
    {
        ddlTipoCierre.Enabled = true;
        ddlEstadoReclamo.SelectedValue = "Cierre";
    }

    protected void checkmostrar_CheckedChanged(object sender, EventArgs e)
    {
        //if(checkmostrar.Checked)
        //{

        //    var mostrar = DBReclamos.cartas.Select(m => new { m.contenido, m.id_reclamo }).Where(ma => ma.id_reclamo == id).First();
        //    txtContenidoCarta.Text = mostrar.contenido;
        //    panelPrincipal.Visible = false;
        //    Panelsecundario.Visible = true;
        //    lblcarta.Text = txtContenidoCarta.Text;
        //}
        //else
        //{
        //    panelPrincipal.Visible = true;
        //    Panelsecundario.Visible = false;
        //}

    }
}