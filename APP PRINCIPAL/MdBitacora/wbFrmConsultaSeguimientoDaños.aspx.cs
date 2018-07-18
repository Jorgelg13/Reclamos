using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class MdBitacora_wbFrmConsultaSeguimientoDaños : System.Web.UI.Page
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
    String poliza, placa, ejecutivo, ramo;
    string idRecibido, comentarios, pagos, llamadas, coberturas, datosSiniestro, estados;
    String estadoReclamo, cartaEnvioCheque, cartaCierreInterno, cartaDeclinado;
    int id, dias;
    //variables para calculos de pagos de reclamos
    Double iva, monto_reclamado, mejora_tecnologica, tiempo_uso, infra_seguro, perdida_final_ajustada, perdidaConDeducible, deducible, valor_indemnizado, timbres, total;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        id = Int32.Parse(idRecibido);
        cartaEnvioCheque = "";

        cartaCierreInterno = "";

        cartaDeclinado = "";

        datosSiniestro = "select Campo, Dato from (select cast(reportante as varchar(1000)) as Reportante,cast(telefono as varchar(1000)) as Telefono," +
            "cast(ubicacion as varchar(1000)) as Ubicacion, cast(convert(varchar(20), fecha, 103) as varchar(1000)) as Fecha_Siniestro, cast(hora as varchar(1000)) as Hora, " +
            "cast(boleta as varchar(1000)) as Boleta, cast(ajustador as varchar(1000)) as Ajustador, cast(titular as varchar(1000)) as Titular, " +
            "cast(version as varchar(1000)) as Version from reclamos_varios where id = " + id + ") a unpivot (Dato for  Campo in (Reportante, Telefono, Ubicacion, Fecha_Siniestro, Boleta, Ajustador, Titular, Version)) up ";

        coberturas = "SELECT cobertura as Cobertura, limite1 as [Limite 1], limite2  as [limite 2], deducible as Deducible, prima as Prima" +
                  " from coberturas_afectadas_danios where id_reclamos_varios = " + id + " ";

        llamadas = "SELECT descripcion  as Descripcion,Convert(varchar(10), fecha_commit, 103) As [Fecha Commit], hora_commit as [Hora Commit], usuario as Usuario" +
                   " FROM bitacora_reclamos_varios WHERE id_reclamos_varios = " + id + " ";

        comentarios = "SELECT descripcion as Descripcion, usuario, fecha As Fecha from comentarios_reclamos_varios where id_reclamos_varios = " + id + " order by fecha desc ";

        pagos = "select id as [ID Pago], cobertura_pagada as [Cobertura Pagada], ramo as Ramo, tipo_pago as [Tipo pago], monto_reclamado as [Monto Reclamado],monto_ajustado as [Monto Ajustado],  mejora_tecnologica as [Mejora Tecnologica], tiempo_uso as [Tiempo uso], infra_seguro as [Infra Seguro], perdida_final_ajustada as [Perdia Final Ajustada], deducible as Deducible,salvamento as Salvamento, iva as Iva, timbres as Timbres, valor_indemnizado as [Valor Indemnizado], fecha as Fecha from detalle_pagos_reclamos_varios where id_reclamos_varios = " + id + "";

        estados = "Select distinct estado as Estado,fecha as Fecha from bitacora_estados_reclamos_varios where id_reclamos_varios = " + id + " order by fecha";


        if (!IsPostBack)
        {
            llenar_dropdowns();
            datosContacto(id);
            datosReclamo(id);
            SeleccionarCoberturas(id);
            //funciones que llenan los gridviews
            llenado.llenarGrid(datosSiniestro, GridDatosAccidente);
            llenado.llenarGrid(coberturas, GridCoberturasAfectadas);
            llenado.llenarGrid(llamadas, Gridllamadas);
            llenado.llenarGrid(comentarios, GridComentarios);
            llenado.llenarGrid(pagos, GridPagosReclamos);
            llenado.llenarGrid(estados, GridEstados);
            Tiempo();
        }
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
    }

    public void datosReclamo(int id)
    {
        try
        {
            var reclamo = DBReclamos.reclamos_varios.Find(id);
            //detalle de la poliza
            lblIdReclamo.Text = "<b>ID :</b>                  " + reclamo.id;
            lblPoliza.Text = "<b>POLIZA :</b>                 " + reclamo.reg_reclamo_varios.poliza;
            lblAsegurado.Text = "<b>ASEGURADO :</b>         " + reclamo.reg_reclamo_varios.asegurado;
            lblAseguradora.Text = "<b>ASEGURADORA :</b>       " + reclamo.reg_reclamo_varios.aseguradora;
            lblContratante.Text = "<b>CONTRATANTE :</b>       " + reclamo.reg_reclamo_varios.contratante;
            lblEjecutivo.Text = "<b>EJECUTIVO :</b>         " + reclamo.reg_reclamo_varios.ejecutivo;
            lblEstado.Text = "<b>ESTADO :</b>            " + reclamo.reg_reclamo_varios.status;
            lblDireccion.Text = "<b>DIRECCION :</b>         " + reclamo.reg_reclamo_varios.direccion;
            lblVip.Text = "<b>VIP :</b>               " + reclamo.reg_reclamo_varios.vip;
            lblSumaAsegurada.Text = "<b>Suma Aseguarda :</b>  " + reclamo.reg_reclamo_varios.suma_asegurada;
            lblMoneda.Text = "<b>Moneda :</b>                 " + reclamo.reg_reclamo_varios.moneda;
            //listado de dropdown
            lblEstadoReclamo.Text = reclamo.estado_reclamo_unity;
            ddlTipoCierre.SelectedValue = reclamo.motivo_cierre;
            lblRamo.Text = reclamo.reg_reclamo_varios.ramo;
            ddlEstadoReclamo.Text = reclamo.estado_reclamo_unity;
            ddlGestor.SelectedValue = reclamo.id_gestor.ToString();
            ddlTaller.SelectedValue = reclamo.id_taller.ToString();
            ddlAnalista.SelectedValue = reclamo.id_analista.ToString();

            txtObservaciones.Text = reclamo.observaciones;
            txtNumReclamo.Text = reclamo.num_reclamo;
            txtFrom.Text = reclamo.gestores.correo;
            //varios
            lblfechaSiniestro.Text = reclamo.fecha.ToString();
            lblFechaCommit.Text = reclamo.fecha_commit.ToString();
            lblReportante.Text = reclamo.reportante;
            lblIDRec.Text = reclamo.num_reclamo;
            lblAseguradoRec.Text = reclamo.reg_reclamo_varios.asegurado;

            checkPrioritario.Checked = reclamo.prioritario.Value;
            CheckComplicado.Checked = reclamo.complicado.Value;
            checkCompromiso.Checked = reclamo.compromiso_pago.Value;

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
        agregarComentario("Para: " + txtDestinatario.Text + "  ,Asunto: " + txtAsunto.Text + "  ,Mensaje:" + txtMensaje.Text);
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
        if (checkCerrarReclamo.Checked)
        {
            estado = "Cerrado";
        }
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
        }

        //actualizacion general de la informacicon
        try
        {
            var dias_revision = DBReclamos.estados_reclamos_unity.Select(est => new { est.dias_revision, est.descripcion, est.tipo }).
            Where(es => es.descripcion == ddlEstadoReclamo.SelectedItem.Text && es.tipo == "daños").First();
            dias = Convert.ToInt32(dias_revision.dias_revision);

            var fecha = DBReclamos.reclamos_varios.Select(r => new { r.fecha_visualizar, r.id, }).Where(re => re.id == id).First();
            DateTime fecha_v = Convert.ToDateTime(fecha.fecha_visualizar);

            var reclamo = DBReclamos.reclamos_varios.Find(id);
            reclamo.estado_unity = estado;
            reclamo.num_reclamo = txtNumReclamo.Text.ToString();
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.id_gestor = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.estado_reclamo_unity = ddlEstadoReclamo.SelectedItem.Text;
            reclamo.observaciones = txtObservaciones.Text.ToString();
            reclamo.fecha_visualizar = fecha_v.AddDays(dias);
            DBReclamos.SaveChanges();
            Utils.ShowMessage(this.Page, "Reclamo Actualizado con exito", "Excelente..!", "success");
            datosReclamo(id);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar el reclamo", "Error..!", "error");
            Email.ENVIAR_ERROR("Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex, "Error en seguimiento de reclamos de daños");
        }
        if (checkCerrarReclamo.Checked)
        {
            cerrarReclamo();
        }
    }

    //Habilitar el check para agregar el numero de reclamo que brinda la aseguradora
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

    //funcion para habilitar el reclamo en una fecha seleccionada
    protected void btnGuardarProximaFecha_Click(object sender, EventArgs e)
    {
        try
        {
            var update_fecha = DBReclamos.reclamos_varios.Find(id);
            update_fecha.fecha_visualizar = Convert.ToDateTime(txtProximaFecha.Text);
            DBReclamos.SaveChanges();
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

        perdida_final_ajustada = monto_reclamado - (mejora_tecnologica + tiempo_uso + infra_seguro);
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
            DBReclamos.detalle_pagos_reclamos_varios.Add(pago);
            DBReclamos.SaveChanges();

            llenado.llenarGrid(pagos, GridPagosReclamos);
            lblPagoTotal.Text = "<b>TOTAL : </b>" + valor_indemnizado.ToString("N2");
            Utils.ShowMessage(this.Page, "Pago guardado con exito..!", "Excelete..!", "info");
            txtMejora.Text = "0.00";
            txtTiempoUso.Text = "0.00";
            txtInfraseguro.Text = "0.00";
            txtDeducible.Text = "0.00";
            txtMontoReclamado.Text = "0.00";
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
        Response.Redirect("/MdBitacora/DashboardUnity.aspx");
    }
    //metodo para cerar el reclamo
    protected void cerrarReclamo()
    {
        try
        {
            var reclamo_cerrado = DBReclamos.reclamos_varios.Find(id);
            reclamo_cerrado.estado_unity = "Cerrado";
            reclamo_cerrado.motivo_cierre = ddlTipoCierre.SelectedItem.Text;
            reclamo_cerrado.fecha_cierre_reclamo = DateTime.Now;
            reclamo_cerrado.acs = false;
            DBReclamos.SaveChanges();
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmRecDañosSeguimiento.aspx", false);
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido cerrar el reclamo..", "Nota..!", "error");
        }
    }

    //asignar valor al modelo de la carta
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
    protected void chCartaDeclinado_CheckedChanged(object sender, EventArgs e)
    {
        if (chCartaDeclinado.Checked)
        {
            txtCarta.Text = cartaDeclinado;
            chCartaCierre.Checked = false;
            chEnvioCarta.Checked = false;
        }

        else
        {
            txtCarta.Text = "";
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

    //mostrar los datos del pago seleccionado para ser editado
    protected void GridPagosReclamos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id_pago = Convert.ToInt32(GridPagosReclamos.SelectedRow.Cells[1].Text);
        String actualizar_pago = "select id as [ID Pago], cobertura_pagada as [Cobertura Pagada], ramo as Ramo, tipo_pago as [Tipo pago], monto_reclamado as [Monto Reclamado], mejora_tecnologica as [Mejora Tecnologica], tiempo_uso as [Tiempo uso], infra_seguro as [Infra Seguro], perdida_final_ajustada as [Perdia Final Ajustada], deducible as Deducible, timbres as Timbres, valor_indemnizado as [Valor Indemnizado], fecha as Fecha from detalle_pagos_reclamos_varios where id = " + id_pago + "";
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
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalActualizar').modal('show');", addScriptTags: true);
    }

    //funcion para actualizar un pago
    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
        monto_reclamado = Convert.ToDouble(txtMontoReclamado.Text);
        mejora_tecnologica = Convert.ToDouble(txtMejora.Text);
        tiempo_uso = Convert.ToDouble(txtTiempoUso.Text);
        infra_seguro = Convert.ToDouble(txtTiempoUso.Text);
        perdida_final_ajustada = Convert.ToDouble(txtPerdidaFinal.Text);
        deducible = Convert.ToDouble(txtDeducible2.Text);
        timbres = Convert.ToDouble(txtTimbres.Text);
        valor_indemnizado = Convert.ToDouble(txtValorTotal.Text);

        int id_pago = Convert.ToInt32(GridPagosReclamos.SelectedRow.Cells[1].Text);
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update detalle_pagos_reclamos_varios set cobertura_pagada = '" + ddlCoberturas.SelectedItem + "', ramo = '" + txtRamo.Text + "', tipo_pago = '" + ddlElegir.SelectedItem + "', monto_reclamado = " + monto_reclamado + ", mejora_tecnologica = " + mejora_tecnologica + ", tiempo_uso =  " + tiempo_uso + ", infra_seguro = " + infra_seguro + ", perdida_final_ajustada = " + perdida_final_ajustada + ", deducible = " + deducible + ", timbres = " + timbres + ", valor_indemnizado = " + valor_indemnizado + "  where id = " + id_pago + " ";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
            Utils.ShowMessage(this.Page, "Pago Actualizado con exito", "Excelente..!", "info");
            llenado.llenarGrid(pagos, GridPagosReclamos);

            txtRamo.Text = "";
            ddlElegir.Text = "";
            txtMontoReclamado.Text = "";
            txtMejora.Text = "";
            txtTiempoUso.Text = "";
            txtInfraseguro.Text = "";
            txtPerdidaFinal.Text = "";
            txtDeducible2.Text = "";
            txtTimbres.Text = "";
            txtValorTotal.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido actualizar la liquidacion", "Error..!", "error");
        }
    }

    protected void ddlEstadoReclamo_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDestinatario.Text = txtCorreoContacto.Text;

        if (ddlEstadoReclamo.SelectedItem.Text == "Asignacion")
        {
            txtMensaje.Text = "Estimado Asegurado, reciba un cordial saludo! Por medio del presente le informamos que hemos sido notificados sobre un nuevo evento ocurrido en fecha " + lblfechaSiniestro.Text + "  por ___________.Actualmente hemos informado a la aseguradora por esta eventualidad y posteriormente un asesor de nuestro de departamento de reclamos se estará comunicando para indicar el procedimiento a seguir. \n\n Recomendaciones:\n En caso de robo:\n  " +
              "• Informar inmediatamente a las autoridades competentes sobre lo ocurrido. \n " +
              "• De contar con algún dispositivo de localización reportar inmediatamente al proveedor que brinda dicho servicio para la pronta ubicación del bien robado.\n" +
              " En caso de daños:\n" +
              "• Mantener debidamente resguardados los bienes hasta que un ajustador asignado por la aseguradora realice la inspección correspondiente.";
            txtAsunto.Text = "Asignacion Reclamo";
        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Pendiente Asegurado")
        {
            txtMensaje.Text = "Estimado asegurado buen día! \n Brindando seguimiento al evento reportado por " + lblReportante.Text + ", de fecha " + lblFechaCommit.Text + ", le informo que me ha sido asignada su reclamación para la presentación de documentos, así como seguimiento y finalización del mismo.\n Para tal efecto, agradeceremos su valiosa colaboración enviando los documentos iniciales que describimos a continuación: \n\n(DESCRIPCIÓN DE DOCUMENTOS)\n\n Así también, es importante comentarle que hemos revisado las condiciones de su póliza, en la cual el deducible a superar para esta clase de eventos lee de la siguiente manera:\n RECOMENDACIONES:\n Es importante indicar que la aseguradora puede solicitar información y documentos adicionales a los solicitados.\n\n NOTA:  Es importante que tome en consideración que para el buen avance de su reclamación es indispensable presentar toda la documentación requerida.";

            txtAsunto.Text = "Pendiente Asegurado";
        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Pendiente Gestor Reclamos")
        {
            txtMensaje.Text = "Apreciable asegurado, un gusto saludarle!\n\n Sobre el reclamo No. " + lblIDRec.Text + ", en el cual fue notificado el " + lblFechaCommit.Text + ", confirmamos la recepción de documentos, los cuales se encuentran en revisión; de contar con alguna consulta o solicitud de información adicional, nos estaremos comunicando con usted y así resolver a la brevedad";
            txtAsunto.Text = "Revision Gestor Reclamos";
        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Ajuste")
        {
            txtMensaje.Text = "Estimado asegurado, \n\n En relación al reclamo No. " + lblIDRec.Text + ", a nombre de " + lblAseguradoRec.Text + ", le informamos que después de haber completado la documentación requerida en su reclamación, así como la revisión correspondiente, hemos compartido al ajustador la misma para el análisis respectivo.\n\n Estaremos brindando seguimiento con el ajustador y esperamos muy pronto notificar al respecto.";
            txtAsunto.Text = "Ajuste";
        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Pendiente Finiquito")
        {
            txtMensaje.Text = "Por este medio le informamos que su reclamación a nombre de " + lblAseguradoRec.Text + " por el ____________ está por finalizar, para ello hemos compartido propuesta de liquidación para su aprobación.\n\n En otra comunicación estaremos enviando detalle de la propuesta para su validación.\n\n";
            txtAsunto.Text = "Pendiente Finiquito";
        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Cheque")
        {
            txtMensaje.Text = "Por medio del presente le informo que después de su aceptación a la propuesta de liquidación del reclamo No. " + lblIDRec.Text + ", su caso se encuentra en proceso de emisión de cheque y/o escritura de pago, en cuanto tengamos conocimiento de disponibilidad de estos documentos, estaremos informando vía telefónica para coordinar la entrega.";
            txtAsunto.Text = "Cheque";

        }

        if (ddlEstadoReclamo.SelectedItem.Text == "Inactivo")
        {
            txtMensaje.Text = "Nuestro seguimiento consta de 60 días para la recepción de documentos, actualmente su reclamación ha superado este tiempo por lo que estaremos cerrando internamente su reclamo.  En caso reúna todos los documentos necesarios para el análisis puede enviarlos a nuestras oficinas para apertura nuevamente nuestros registros y así continuar el proceso normal de su reclamación.  Es importante indicar que ante la aseguradora el reclamo continúa apertura do, sin embargo una vez  la aseguradora notifique formalmente el cierre del reclamo por falta de documentos, estaremos compartiendo esta información para su conocimiento.\n\n Derivado que a la fecha no contamos con la información necesaria para el análisis de su reclamación de fecha " + lblFechaCommit.Text + " a causa de_______________, estamos procediendo al cierre interno de su reclamación.";
            txtAsunto.Text = "Inactivo";
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

        catch (Exception)
        {

        }
    }


}