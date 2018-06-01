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
    String poliza, correoGestor, cuerpo, asunto, fechaCreacion, asegurado, correoComentario, codigo;
    String correo = "reclamosgt@unitypromotores.com";
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        ReclamosAsignados = "SELECT " +
           "dbo.reclamos_varios.id as ID," +//1
           "dbo.reg_reclamo_varios.poliza as Poliza," +//2
           "dbo.reg_reclamo_varios.asegurado as Asegurado," + //3
           "dbo.reg_reclamo_varios.cliente as Cliente," +
           "dbo.reg_reclamo_varios.status as Status," +
           "dbo.reg_reclamo_varios.tipo as Tipo," +
           "dbo.reg_reclamo_varios.direccion as Direccion," +
           "dbo.reg_reclamo_varios.ramo as Ramo," +
           "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +
           "dbo.reg_reclamo_varios.aseguradora as Aseguradora," +//10
           "dbo.reg_reclamo_varios.contratante as Contratante," +
           "dbo.reclamos_varios.usuario_unity as [Usuario Unity]," +
           "dbo.reclamos_varios.estado_unity as [Estado Unity]," +
           "dbo.reclamos_varios.boleta as Boleta," +
           "dbo.reclamos_varios.titular as Titular," +
           "dbo.reclamos_varios.ubicacion as Ubicacion," +
           "dbo.reclamos_varios.hora as Hora," +
           "Convert(varchar(10),dbo.reclamos_varios.fecha, 103) as [Fecha Siniestro]," +
           "dbo.reclamos_varios.reportante as Reportante," +//19
           "dbo.reclamos_varios.telefono as Telefono," +
           "dbo.reclamos_varios.ajustador as Ajustador," +
           "dbo.reclamos_varios.version as Version," +
           "Convert(varchar(10),dbo.reclamos_varios.fecha_commit, 103) as [Fecha Creacion]," +//23
           //"dbo.cabina.nombre as Cabina," +
           //"dbo.sucursal.nombre as Sucursal," +
           //"dbo.empresa.nombre as Empresa," +
           //"dbo.pais.nombre as Pais," +
           "dbo.usuario.nombre as Usuario, " +
           "dbo.reg_reclamo_varios.id as id_registro," + //29
           "dbo.reg_reclamo_varios.gestor as [Codigo Ejecutivo] " +//30
           "FROM dbo.reclamos_varios " +
           "INNER JOIN dbo.reg_reclamo_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
           "INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
           //"INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
           //"INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
           //"INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
           "INNER JOIN dbo.usuario ON dbo.usuario.id_cabina = dbo.cabina.id AND dbo.reclamos_varios.id_usuario = dbo.usuario.id " +
           "where(usuario_unity = '" + userlogin + "') and(estado_unity = 'Sin Cerrar')";

        llenado.llenarGrid(ReclamosAsignados, GridReclamosDaños); 

        if(!IsPostBack)
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

        ddlGestor.DataSource = DBReclamos.gestores.ToList().Where(gestores => gestores.tipo == "Daños varios");
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

    //seleccionar el correo electronico del ejecutivo que tiene asignada la poliza
    //private void seleccionarCorreo(short cod)
    //{
    //    try
    //    {
    //        var selectCorreo = DBReclamos.ejecutivos.Where(e => e.codigo == Convert.ToInt16(codigo)).First();
    //        correo = selectCorreo.correo;
    //    }

    //    catch (Exception)
    //    {
    //    }
    //}

    //seleccionar el correo del gestor asignado
    //private void seleccionarCorreoGestor()
    //{
    //    try
    //    {
    //        var correo_gestor = DBReclamos.gestores.Select(g => new { g.correo, g.usuario }).Where(usu => usu.usuario == userlogin).First();
    //        correoGestor = correo_gestor.correo.ToString();
    //    }

    //    catch (Exception)
    //    {
    //        Utils.ShowMessage(this.Page, "No se a podido seleccionar el correo del Gestor", "Nota..!", "warning");
    //    }
    //}

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
        var gestor = DBReclamos.gestores.ToList().Where(ge => ge.usuario == userlogin && ge.tipo == "Daños varios").First();
        ddlGestor.SelectedValue = gestor.id.ToString();

        id = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[1].Text);
        poliza = GridReclamosDaños.SelectedRow.Cells[2].Text.ToString();

        String coberturas = "SELECT descr as Descripcion, limite1 as Limite1, limite2 as Limite2, deducible as Deducible FROM busqCoberturasPolizasDaños WHERE poliza = '" + poliza + "' ";
        String llamadas = "SELECT descripcion as Descripcion, convert(varchar(20),fecha_commit, 103)   as Fecha, hora_commit as Hora, usuario as Usuario FROM bitacora_reclamos_varios WHERE (id_reclamos_varios = " + id + ")";

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

                if(row.Cells[2].Text == "&nbsp;")
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
                    cmd.CommandText = "insert into coberturas_afectadas_danios(cobertura, limite1, limite2, deducible, id_reclamos_varios) values('" + cobertura + "', " + limite1 + ", " + limite2 + ", " + deducible + ", " + id_reclamo + ")";
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
            txtComentarios.Text = "";
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar los comentarios..", "Nota..!", "error");
        }
    }

    public void enviarNotificacion()
    {
        string telefono = Utils.TelefonoGestor(ddlGestor);
        string mensaje = Constantes.ASIGNACION_DANOS(ddlGestor, poliza, telefono);

        notificacion.CorreoReclamos(txtCorreo.Text.Trim(), mensaje, "Asignacion de Reclamo");
        insertarComentarios("Registro de envio de correo de notificacion: \n\n" + mensaje);
    }

    //guardar informacion del reclamo para aperturarlo y darle despues seguimiento
    protected void txtGuardar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[1].Text);
        poliza = GridReclamosDaños.SelectedRow.Cells[2].Text.ToString();
        fechaCreacion = GridReclamosDaños.SelectedRow.Cells[23].Text;
        asegurado = GridReclamosDaños.SelectedRow.Cells[3].Text;
        opcionesChecked();

        try
        {
            insertarCoberturas(id);

            bitacora_estados_reclamos_varios bitacora = new bitacora_estados_reclamos_varios();
            bitacora.estado = "Asignacion";
            bitacora.id_reclamos_varios = id;
            bitacora.fecha = DateTime.Now;
            DBReclamos.bitacora_estados_reclamos_varios.Add(bitacora);

            if (txtComentarios.Text != "") insertarComentarios(txtComentarios.Text);
            if (txtCorreo.Text != "") enviarNotificacion();

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
            reclamo.complicado = complicado;
            reclamo.prioritario = prioritario;
            reclamo.compromiso_pago = compromiso_pago;
            reclamo.b_carta_cierre_interno = false;
            reclamo.b_carta_declinado = false;
            reclamo.b_carta_envio_cheque = false;
            reclamo.id_taller = Convert.ToInt16(ddlTaller.SelectedValue);
            reclamo.fecha_visualizar = DateTime.Now;
            reclamo.fecha_apertura_reclamo = DateTime.Now;  
            DBReclamos.SaveChanges();
            enviarNoficacion();

            if(txtTelefono.Text != "")
            {
                Utils.SMS_reclamos_danios(txtTelefono.Text, "UNITY: Estimad@ cliente recibimos su aviso de siniestro, su asesor asignado " +
                    "es " + ddlGestor.SelectedItem + " Tel " + reclamo.gestores.telefono + " número de ID " + id + " ", userlogin, id);
            }

            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al insertar los datos", "Nota..!", "error");
            Email.EnviarERROR("Error en apertura de reclamos de daños","Error ocasionado al usuario: " + userlogin + " en el registro con el id: " + id + "\n\n" + ex.Message);
        }
    }

    //actualizar datos de un reclamo que se ingreso de forma manual y por lo tanto no tiene todos sus datos completos
    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
        try
        {
            int id_reg = Convert.ToInt32(GridReclamosDaños.SelectedRow.Cells[29].Text);
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
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al actualizar el registro", "Error..!", "error");
        }
    }

    //enviar notificacion al correo electronico del ejecutivo
    public void enviarNoficacion()
    {
        codigo = GridReclamosDaños.SelectedRow.Cells[26].Text;
        bool insertar = true;
        correoGestor = Utils.seleccionarCorreoGestor(userlogin);
        cuerpo = Constantes.NOTIFICACION_EJECUTIVO(fechaCreacion, asegurado, poliza, ddlGestor, id);
        asunto = "Notificacion Siniestro";

        if (codigo == "&nbsp;")
        {
          
        }
        else
        {
            correo = Utils.seleccionarCorreo(Convert.ToInt16(codigo));
        }

        try
        {
            notificacion.enviarcorreo2(correo, cuerpo, asunto, correoGestor);
        }

        catch (SmtpException)
        {
            insertar = false;
        }

        if (insertar == true)
        {
            correoComentario = HttpUtility.HtmlDecode("Destinatario: " + correo + " Asunto:" + asunto + " Cuerpo del mensaje: " + cuerpo);
            insertarComentarios(correoComentario);
            DBReclamos.SaveChanges();
        }
    }

    //regresar a la pantalla principal
    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
}