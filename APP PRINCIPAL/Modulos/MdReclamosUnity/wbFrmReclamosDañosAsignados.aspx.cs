using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Modulos_MdReclamos_wbFrmReclamosDañosAsignados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    Utils llenado = new Utils();
    Email notificacion = new Email();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String ReclamosAsignados;
    bool complicado = false;
    bool prioritario = false;
    bool compromiso_pago = false;
    String correoGestor, correoEjecutivo, correoVendedor, cuerpo, asunto, correoComentario, codigo;
    String correoReclamos = "reclamosgt@unitypromotores.com";
    String gerente= "jennifer.wiesner @unitypromotores.com";
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        ReclamosAsignados = "SELECT " +
           "r.id as ID," +//1
           "reg.poliza as Poliza," +//2
           "reg.asegurado as Asegurado," + //3
           "reg.cliente as Cliente," +
           "reg.status as Status," +
           "reg.tipo as Tipo," +
           "reg.direccion as Direccion," +
           "reg.ramo as Ramo," +
           "reg.ejecutivo as Ejecutivo," +
           "reg.aseguradora as Aseguradora," +//10
           "reg.contratante as Contratante," +
           "r.usuario_unity as [Usuario Unity]," +
           "r.estado_unity as [Estado Unity]," +
           "r.boleta as Boleta," +
           "r.titular as Titular," +
           "r.ubicacion as Ubicacion," +
           "r.hora as Hora," +
           "Convert(varchar(10), r.fecha, 103) as [Fecha Siniestro]," +
           "r.reportante as Reportante," +//19
           "r.telefono as Telefono," +
           "r.ajustador as Ajustador," +
           "r.version as Version," +
           "Convert(varchar(10), r.fecha_commit, 103) as [Fecha Creacion]," +//23
           "usuario.nombre as Usuario, " +
           "reg.id as id_registro," + //25
           "reg.gestor as [Codigo Ejecutivo], " +//26
           "reg.vendedor as Vendedor " +//27
           "FROM reclamos_varios as r " +
           "INNER JOIN reg_reclamo_varios as reg ON r.id_reg_reclamos_varios = reg.id " +
           "INNER JOIN cabina ON r.id_cabina = cabina.id " +
           "INNER JOIN usuario ON usuario.id_cabina = cabina.id AND r.id_usuario = usuario.id " +
           "where(r.usuario_unity = '" + userlogin + "') and(r.estado_unity = 'Sin Cerrar')";

        llenado.llenarGrid(ReclamosAsignados, GridReclamosDaños);

        if (!IsPostBack)
        {
            llenar_dropdowns();
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

        ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(gestores => gestores.tipo == "Daños varios" && gestores.estado == true);
        ddlGestor.DataTextField = "nombre";
        ddlGestor.DataValueField = "id";
        ddlGestor.DataBind();

        ddlRamo.DataSource = DBReclamos.ramos.ToList();
        ddlRamo.DataTextField = "descripcion";
        ddlRamo.DataValueField = "ramo";
        ddlRamo.DataBind();

        ddlEjecutivos.DataSource = DBReclamos.ejecutivos.ToList();
        ddlEjecutivos.DataTextField = "gestor";
        ddlEjecutivos.DataValueField = "codigo";
        ddlEjecutivos.DataBind();

        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList();
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataValueField = "id";
        ddlAseguradora.DataBind();
    }

    //seleccionar los checks y darles valor a las variables para ser almacenadas
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
    }

    //carga de coberturas y llamadas al seleccionar un registro de la tabla de asignaciones de reclamos
    protected void GridReclamosDaños_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[1].Text);
        var registro = DBReclamos.reclamos_varios.Find(id);
        var gestor = DBReclamos.gestores.ToList().Where(ge => ge.usuario == userlogin && ge.tipo == "Daños varios").First();
        ddlGestor.SelectedValue = gestor.id.ToString();

        String coberturas = "SELECT descr as Descripcion, limite1 as Limite1, limite2 as Limite2, deducible as Deducible FROM busqCoberturasPolizasDaños WHERE poliza = '" + registro.reg_reclamo_varios.poliza + "' ";
        String llamadas = "SELECT descripcion as Descripcion, convert(varchar(20),fecha_commit, 103) as Fecha, hora_commit as Hora, usuario as Usuario FROM bitacora_reclamos_varios WHERE (id_reclamos_varios = " + id + ")";

        llenado.llenarGrid(llamadas, GridLlamadas);
        llenado.llenarGrid(coberturas, GridCoberturas);
    }

    //metodo para ingresar las coberturas seleccionadas
    protected void insertarCoberturas(int id_reclamo)
    {
        Double limite1, limite2, deducible;
        foreach (GridViewRow row in GridCoberturas.Rows)
        {
            CheckBox CheckCoberturas = (CheckBox)row.FindControl("checkCoberturas");
            if (CheckCoberturas.Checked)
            {
                string cobertura = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[1].Text));

                if (row.Cells[2].Text == "&nbsp;")
                {
                    limite1 = 0;
                }
                else
                {
                    limite1 = Convert.ToDouble(row.Cells[2].Text);
                }

                if (row.Cells[3].Text == "&nbsp;")
                {
                    limite2 = 0;
                }
                else
                {
                    limite2 = Convert.ToDouble(row.Cells[3].Text);
                }

                if (row.Cells[4].Text == "&nbsp;")
                {
                    deducible = 0;
                }
                else
                {
                    deducible = Convert.ToDouble(row.Cells[4].Text);
                }

                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into coberturas_afectadas_danios(cobertura, limite1, limite2, deducible, id_reclamos_varios) " +
                        "values('" + cobertura + "', " + limite1 + ", " + limite2 + ", " + deducible + ", " + id_reclamo + ")";
                    cmd.Connection = obj.ObtenerConexionReclamos();
                    cmd.ExecuteNonQuery();
                    obj.conexion.Close();
                }
                catch (Exception)
                {
                    Response.Write("<Script>setTimeout(function () { toastr.error('A ocurrido un error al insertar las coberturas..', 'Error!');  }, 200);</script>");
                }
                finally
                {
                    obj.DescargarConexion();
                }
            }
        }
    }

    //insertar los comentarios del reclamo
    protected void insertarComentarios(string descripcion)
    {
        try
        {
            comentarios_reclamos_varios comentario = new comentarios_reclamos_varios();
            comentario.descripcion = descripcion;
            comentario.usuario = userlogin;
            comentario.id_reclamos_varios = id;
            comentario.fecha = DateTime.Now;
            DBReclamos.comentarios_reclamos_varios.Add(comentario);
            DBReclamos.SaveChanges();
            txtComentarios.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar los comentarios..", "Nota..!", "error");
        }
    }

    //guardar informacion del reclamo para aperturarlo y darle despues seguimiento
    protected void txtGuardar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[1].Text);
        opcionesChecked();

        try
        {
            insertarCoberturas(id);

            bitacora_estados_reclamos_varios bitacora = new bitacora_estados_reclamos_varios();
            bitacora.estado = "Asignacion";
            bitacora.id_reclamos_varios = id;
            bitacora.fecha = DateTime.Now;
            DBReclamos.bitacora_estados_reclamos_varios.Add(bitacora);

            contactos_reclamos_varios contacto = new contactos_reclamos_varios();
            contacto.nombre = txtContacto.Text.ToString();
            contacto.telefono = txtTelefono.Text.ToString();
            contacto.correo = txtCorreo.Text.ToString();
            contacto.id_reclamos_varios = id;
            DBReclamos.contactos_reclamos_varios.Add(contacto);

            var reclamo = DBReclamos.reclamos_varios.Find(id);
            reclamo.estado_unity = "Seguimiento";
            reclamo.num_reclamo = txtNumReclamo.Text.ToString();
            reclamo.estado_reclamo_unity = "Asignacion";
            reclamo.id_gestor = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.observaciones = txtObservaciones.Text.ToString();
            reclamo.reaseguro = false;
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.b_carta_cierre_interno = false;
            reclamo.b_carta_declinado = false;
            reclamo.b_carta_envio_cheque = false;
            reclamo.b_carta_deducible_anual = false;
            reclamo.b_carta_alerta_tiempo = false;
            reclamo.b_carta_cierre_reclamo = false;
            reclamo.problema_ajustador = false;
            reclamo.problema_aseguradora = false;
            reclamo.problema_cabina = false;
            reclamo.problema_ejecutivo = false;
            reclamo.problema_taller = false;
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.fecha_visualizar = DateTime.Now;
            reclamo.fecha_apertura_reclamo = DateTime.Now;
            reclamo.reserva = 0;
            reclamo.reserva_final = 0;
            reclamo.deducible_reserva = 0;
            DBReclamos.SaveChanges();
            if (txtComentarios.Text != "") insertarComentarios(txtComentarios.Text);
            if (txtCorreo.Text != "") enviarNotificacion();

            if (txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente recibimos su aviso de siniestro, su asesor asignado " +
                    "es " + ddlGestor.SelectedItem + " Tel " + reclamo.gestores.telefono + " número de ID " + id + " ", userlogin, id);
            }

            NoficacionEjecutivo();
            Utils.actividades(id, Constantes.DANIOS(), 5, Constantes.USER());
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar los datos " + ex.Message, "Nota..!", "error");
            Email.ENVIAR_ERROR("Error en apertura de reclamos de daños", "Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n " + ex.Message);
        }
    }

    //actualizar datos de un reclamo que se ingreso de forma manual y por lo tanto no tiene todos sus datos completos
    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
        try
        {
            int id_reg = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[25].Text);
            var registro = DBReclamos.reg_reclamo_varios.Find(id_reg);
            registro.poliza = txtPoliza.Text.ToString();
            registro.cliente = Convert.ToInt32(txtCliente.Text);
            registro.status = ddlStatus.SelectedItem.Text;
            registro.ramo = ddlRamo.SelectedItem.Text;
            registro.ejecutivo = ddlEjecutivos.SelectedItem.Text;
            registro.aseguradora = ddlAseguradora.SelectedItem.Text;
            registro.contratante = txtContratante.Text.ToString();
            registro.moneda = ddlMoneda.SelectedItem.Text;
            registro.suma_asegurada = Convert.ToDecimal(txtSumaAsegurada.Text);
            registro.gestor = Convert.ToInt16(ddlEjecutivos.SelectedValue);
            DBReclamos.SaveChanges();
            llenado.llenarGrid(ReclamosAsignados, GridReclamosDaños);
            txtCliente.Text = "";
            txtPoliza.Text = "";
            txtSumaAsegurada.Text = "";
            txtContratante.Text = "";
            Utils.ShowMessage(this.Page, "Datos actualizados con exito", "Excelente..!", "success");
            Utils.actividades(id, Constantes.DANIOS(), 7, Constantes.USER());
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al actualizar el registro " + ex.Message, "Error..!", "error");
        }
    }

    public void enviarNotificacion()
    {
        id = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[1].Text);
        var registro = DBReclamos.reclamos_varios.Find(id);

        string telefono = Utils.TelefonoGestor(ddlGestor);
        string mensaje = Constantes.ASIGNACION_DANOS(ddlGestor, registro.reg_reclamo_varios.poliza, telefono);

        //notificacion.NOTIFICACION(txtCorreo.Text.Trim(), mensaje, "Asignacion de Reclamo");
        Utils.notificacion_email("pa_notificacion", txtCorreo.Text, mensaje, registro.gestores.correo, "Asignacion de Reclamo");
        insertarComentarios("Registro de envio de correo de notificacion: \n\n" + mensaje);
    }

    //enviar notificacion al correo electronico del ejecutivo
    public void NoficacionEjecutivo()
    {
        var registro = DBReclamos.reclamos_varios.Find(id);
        correoGestor = Utils.seleccionarCorreoGestor(userlogin);
        cuerpo = Constantes.NOTIFICACION_EJECUTIVO(registro.fecha.ToString(), registro.reg_reclamo_varios.asegurado, registro.reg_reclamo_varios.poliza, ddlGestor, id);
        asunto = "Notificacion de siniestro";

        codigo = GridReclamosDaños.SelectedRow.Cells[26].Text;
        if (codigo != "&nbsp;")
        {
            correoEjecutivo = Utils.seleccionarCorreo(Convert.ToInt32(codigo));

            if (!string.IsNullOrEmpty(correoEjecutivo))
            {
                Utils.notificacion_email("pa_notificacion", correoEjecutivo, cuerpo, correoGestor, asunto);
                Utils.notificacion_email("pa_notificacion", gerente, cuerpo, correoGestor, asunto);
                insertarComentarios("Registro de notificacion a ejecutivo: \n\n" + cuerpo);
            }
        }

        Utils.notificacion_email("pa_notificacion", correoGestor, cuerpo, correoReclamos, asunto);

        codigo = GridReclamosDaños.SelectedRow.Cells[27].Text;
        if (codigo != "&nbsp;")
        {
            correoVendedor = Utils.seleccionarCorreo(Convert.ToInt32(codigo));

            if (!string.IsNullOrEmpty(correoVendedor))
            {
                Utils.notificacion_email("pa_notificacion", correoVendedor, cuerpo, correoGestor, asunto);
            }
        }

        //if (codigo == "&nbsp;")
        //{

        //}
        //else
        //{
        //    correoReclamos = Utils.seleccionarCorreo(Convert.ToInt16(codigo));
        //    try
        //    {
        //        notificacion.NOTIFICACION_EJECUTIVO(correoReclamos, cuerpo, asunto, correoGestor);
        //        correoComentario = HttpUtility.HtmlDecode("Destinatario: " + correoReclamos + " Asunto:" + asunto + " Cuerpo del mensaje: " + cuerpo);
        //        insertarComentarios(correoComentario);
        //        DBReclamos.SaveChanges();
        //    }

        //    catch (SmtpException)
        //    {

        //    }
        //}
    }

    //regresar a la pantalla principal
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx", false);
    }
}