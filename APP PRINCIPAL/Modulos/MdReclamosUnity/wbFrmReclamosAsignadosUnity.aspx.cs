using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;

public partial class Modulos_MdReclamos_wbFrmReclamosAsignadosUnity : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    Utils llenar = new Utils();
    Email notificacion = new Email();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    bool complicado = false;
    bool prioritario = false;
    bool compromiso_pago = false;
    bool alquiler = false;
    bool perdidaTotal = false;
    bool robo = false;
    int id, id_contacto;
    string id2;
    String poliza, correoGestor, correoVendedor, correoEjecutivo, cuerpo, asunto, fechaCreacion, asegurado, correoComentario, codigo;
    String correoReclamos = "reclamosgt@unitypromotores.com";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        if (!IsPostBack)
        {
            llenarListas();
            string reclamosAsignados = "SELECT " +
                   "reclamo_auto.id as ID," + //1
                   "reclamo_auto.usuario_unity as Usuario," +//2
                   "auto_reclamo.asegurado as Asegurado," +//3
                   "auto_reclamo.poliza as Poliza," +//4
                   "auto_reclamo.placa as Placa," +//5
                   "auto_reclamo.marca as Marca," +//6
                   "auto_reclamo.color as Color," +//7
                   "auto_reclamo.modelo as Modelo," +//8
                   "auto_reclamo.chasis as Chasis," +//9
                   "auto_reclamo.motor as Motor," +
                   "auto_reclamo.propietario as Propietario," +
                   "auto_reclamo.ejecutivo as Ejecutivo," +
                   "auto_reclamo.aseguradora as Aseguradora," +
                   "auto_reclamo.contratante as Contratante," +
                   "reclamo_auto.boleta as Boleta," +
                   "reclamo_auto.titular as Titular," +
                   "reclamo_auto.hora as Hora," +
                   "Convert(varchar,reclamo_auto.fecha, 103) as [Fecha Siniestro]," +
                   "Convert(varchar,reclamo_auto.fecha_commit,103) as [Fecha Creacion]," +
                   "reclamo_auto.reportante as Reportante," +
                   "reclamo_auto.piloto as Piloto," +
                   "reclamo_auto.telefono as Telefono," +
                   "reclamo_auto.ajustador as Ajustador, " +
                   "auto_reclamo.numero_gestor as Cod ," +
                   "auto_reclamo.vendedor as Cod_vendedor "+ //25
                   "FROM auto_reclamo " +
                   "INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
                   "where (usuario_unity = '" + userlogin + "') and(estado_unity = 'Sin Cerrar')";

            llenar.llenarGrid(reclamosAsignados, GridAsignacion);
        }
    }

    protected void GridAsignacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        var gestor = DBReclamos.gestores.ToList().Where(ge => ge.usuario == userlogin && ge.tipo == "autos" && ge.estado != false).First();
        ddlGestor.SelectedValue = gestor.id.ToString();
        id = Convert.ToInt32(GridAsignacion.SelectedRow.Cells[1].Text);
        actualizarFecha(id);

        string llamadas = "SELECT descripcion as Descripcion, Convert(varchar,fecha_commit, 103) as [Fecha Creacion], hora_commit as Hora, usuario as Usuario FROM bitacora_reclamo_auto WHERE id_reclamo = " + id + "";
        llenar.llenarGrid(llamadas, Gridllamadas);
    }

    public void llenarListas()
    {
        ddlTaller.DataSource = DBReclamos.talleres.ToList().Where(ta => ta.estado == true);
        ddlTaller.DataTextField = "nombre";
        ddlTaller.DataValueField = "id";
        ddlTaller.DataBind();

        ddlAnalista.DataSource = DBReclamos.analistas.ToList().Where(a => a.tipo == "Autos" && a.estado == true);
        ddlAnalista.DataTextField = "nombre";
        ddlAnalista.DataValueField = "id";
        ddlAnalista.DataBind();

        ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(ges => ges.tipo == "autos" && ges.estado == true);
        ddlGestor.DataTextField = "nombre";
        ddlGestor.DataValueField = "id";
        ddlGestor.DataBind();
    }

    //actualizar fecha a visualizar 
    private void actualizarFecha(int id)
    {
        try
        {
            var actualizar = DBReclamos.reclamo_auto.Find(id);
            lblChasis.Text = actualizar.auto_reclamo.chasis;
            actualizar.fecha_visualizar = DateTime.Now;
            DBReclamos.SaveChanges();
        }
        catch (Exception)
        {

        }
    }

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

    //metodo para guardar la apertura del reclamo
    protected void txtGuardar_Click(object sender, EventArgs e)
    {
        opcionesChecked();
        try
        {
            id = Convert.ToInt32(GridAsignacion.SelectedRow.Cells[1].Text);
            if (txtComentarios.Text != "")
            {
                agregarComentario(txtComentarios.Text);
            }

            insertarEstado(id);
            insertarCoberturas();

            contacto_auto contacAuto = new contacto_auto();
            contacAuto.contacto = txtContacto.Text.ToString();
            contacAuto.telefono = txtTelefono.Text.ToString();
            contacAuto.correo = txtCorreo.Text.ToString();
            contacAuto.id_reclamo_auto = id;
            DBReclamos.contacto_auto.Add(contacAuto);

            var reclamo = DBReclamos.reclamo_auto.Find(id);
            reclamo.estado_auto_unity = "Asignacion";
            reclamo.estado_unity = "Seguimiento";
            reclamo.num_reclamo = txtNumReclamo.Text.ToString();
            reclamo.id_gestor = Convert.ToInt16(ddlGestor.SelectedValue);
            reclamo.id_analista = Convert.ToInt16(ddlAnalista.SelectedValue);
            reclamo.observaciones = txtObservaciones.Text.ToString();
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.importacion = false;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.alquiler_auto = alquiler;
            reclamo.perdida_total = perdidaTotal;
            reclamo.robo = robo;
            reclamo.b_carta_cierre_interno = false;
            reclamo.b_carta_declinado = false;
            reclamo.b_carta_envio_cheque = false;
            reclamo.b_carta_alerta_tiempo = false;
            reclamo.problema_ajustador = false;
            reclamo.problema_cabina = false;
            reclamo.problema_taller = false;
            reclamo.problema_aseguradora = false;
            reclamo.problema_ejecutivo = false;
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.fecha_apertura_reclamo = DateTime.Now;
            reclamo.fecha_cierre_reclamo = DateTime.Now;
            DBReclamos.SaveChanges();
            Utils.actividades(id, Constantes.AUTOS(), 5, Constantes.USER());

            if (txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_autos(txtTelefono.Text, "UNITY: Mi nombre es " + ddlGestor.SelectedItem + " soy la persona asignada para la atencion del reclamo, segun ID " + reclamo.id + " presentado " +
                    "por daños al vehiculo " + reclamo.auto_reclamo.marca + " " + reclamo.auto_reclamo.modelo + " placas " + reclamo.auto_reclamo.placa + ", mi telefono directo es " + reclamo.gestores.telefono + ", correo " + reclamo.gestores.correo + " para que pueda contactarme para cualquier consulta.", userlogin, id);
            }
            if (txtCorreo.Text != "")
            {
                try
                {
                    enviarNotificacion();
                }
                catch (Exception)
                {

                }
            }

            NotificacionEjecutivo();
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id, false);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido ingresar ese registro..", "Nota..!", "error");
            Email.ENVIAR_ERROR("Error en apertura de reclamos de autos", "Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex.Message);
        }
    }

    //metodo para insertar las coberturas que fueron afectadas y que fueron seleccionadas por medio del check
    protected void insertarCoberturas()
    {
        foreach (GridViewRow row in GridCoberturas.Rows)
        {
            CheckBox CheckCoberturas = (CheckBox)row.FindControl("checkCoberturas");
            if (CheckCoberturas.Checked)
            {
                string cobertura = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[1].Text));
                Double limite1 = Convert.ToDouble(row.Cells[2].Text);
                Double limite2 = Convert.ToDouble(row.Cells[3].Text);
                Double deducible = Convert.ToDouble(row.Cells[4].Text);
                Double prima = Convert.ToDouble(row.Cells[5].Text);

                try
                {
                    coberturas_afectadas cober = new coberturas_afectadas();
                    cober.cobertura = cobertura.ToString();
                    cober.limite1 = Convert.ToDecimal(limite1);
                    cober.limite2 = Convert.ToDecimal(limite2);
                    cober.deducible = Convert.ToDecimal(deducible);
                    cober.prima = Convert.ToDecimal(prima);
                    cober.id_reclamo_auto = id;
                    DBReclamos.coberturas_afectadas.Add(cober);
                    DBReclamos.SaveChanges();
                }
                catch (Exception)
                {
                    //Response.Write(ex);
                }
            }
        }
    }

    //enviar notificacion al cliente de la apertura del reclamo
    public void enviarNotificacion()
    {
        var registro = DBReclamos.reclamo_auto.Find(id);
        string telefono = Utils.TelefonoGestor(ddlGestor);
        string mensaje = Constantes.ASIGNACION_AUTOS(ddlGestor, registro.auto_reclamo.placa, registro.auto_reclamo.marca, registro.auto_reclamo.modelo, telefono, id);

        //notificacion.NOTIFICACION(txtCorreo.Text.Trim(), mensaje, "Asignacion de Reclamo");
        Utils.notificacion_email("pa_notificacion", txtCorreo.Text.Trim(), mensaje, registro.gestores.correo, "Asignacion de Reclamo");
        agregarComentario("Registro de envio de correo de notificacion: \n\n" + mensaje);
    }

    //insertar el primero estado del auto su bitacora
    protected void insertarEstado(int id_estado)
    {
        try
        {
            bitacora_estados_autos estado = new bitacora_estados_autos();
            var sec_registro = DBReclamos.pa_sec_estados_autos();
            long? id_registro = sec_registro.Single();
            estado.id = Convert.ToInt64(id_registro);
            estado.estado = "Asignacion";
            estado.id_reclamo_auto = id_estado;
            estado.fecha = DateTime.Now;
            DBReclamos.bitacora_estados_autos.Add(estado);
            DBReclamos.SaveChanges();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar el estado", "Error", "error");
        }
    }

    public void NotificacionEjecutivo()
    {
        var registro = DBReclamos.reclamo_auto.Find(id);
        correoGestor = Utils.seleccionarCorreoGestor(userlogin);
        asunto = "Notificacion Siniestro Auto";
        cuerpo = Constantes.NOTIFICACION_EJECUTIVO_AUTOS(
          registro.fecha.ToString(), registro.auto_reclamo.asegurado, registro.auto_reclamo.poliza, ddlGestor,
          registro.auto_reclamo.placa, registro.auto_reclamo.marca, registro.auto_reclamo.modelo, id);

        
        codigo = GridAsignacion.SelectedRow.Cells[24].Text;
        if (codigo != "&nbsp;")
        {
            correoEjecutivo = Utils.seleccionarCorreo(Convert.ToInt32(codigo));
            if (!string.IsNullOrEmpty(correoEjecutivo))
            {
                Utils.notificacion_email("pa_notificacion", correoEjecutivo, cuerpo, correoGestor, asunto);
                agregarComentario("Registro de notificacion a ejecutivo: \n\n " + cuerpo);
            }
        }

        codigo = GridAsignacion.SelectedRow.Cells[25].Text;
        if (codigo != "&nbsp;")
        {
            correoVendedor = Utils.seleccionarCorreo(Convert.ToInt32(codigo));
            if (!string.IsNullOrEmpty(correoVendedor))
            {
                Utils.notificacion_email("pa_notificacion", correoVendedor, cuerpo, correoGestor, asunto);
            }
        }

        //Utils.notificacion_email("pa_notificacion", correoGestor, cuerpo, correoReclamos, asunto);

        //if (codigo == "&nbsp;" || codigo == null || codigo == "")
        //{

        //}

        //else
        //{
        //    correo = Utils.seleccionarCorreo(Convert.ToInt32(codigo));
        //    try
        //    {
        //        notificacion.NOTIFICACION_EJECUTIVO(correo.Trim(), cuerpo, asunto, correoGestor.Trim());
        //        correoComentario = HttpUtility.HtmlDecode("Destinatario: " + correo + " Asunto:" + asunto + " Cuerpo del mensaje: " + cuerpo);
        //        agregarComentario(correoComentario);
        //    }

        //    catch (SmtpException ex)
        //    {
        //        Utils.ShowMessage(this.Page, "No se a podido enviar la notificacion " + ex.Message, "Error..", "error");
        //    }
        //}
    }

    //agregar comentario a la bitacora de seguimiento del reclamo
    protected void agregarComentario(string descripcion)
    {
        try
        {
            comentarios_reclamos_autos comentario = new comentarios_reclamos_autos();
            comentario.descripcion = WebUtility.HtmlDecode(descripcion);
            comentario.usuario = userlogin;
            comentario.id_reclamo_auto = id;
            comentario.fecha = DateTime.Now;
            DBReclamos.comentarios_reclamos_autos.Add(comentario);
            DBReclamos.SaveChanges();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar el comentario", "Error", "error");
        }
    }
}
