using System;
using System.Linq;
using System.Web;

public partial class MdBitacora_CabinaUnity_autos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    String marca, color, motor, chasis, placa, propietario;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int estado = 1;
    string idRecibido; //id de la ultima transaccion de la tabla reclamo_auto
    string idRecibido2;//id de la ultima transaccion de la tabla un auto_reclamo
    string placaRecibida;// numero de placa de la ultima inserccion en auto reclamo
    int id;
    int idAuto;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
        long idReclamo = Convert.ToInt64(idRecibido);
        var reclamo = DBReclamos.reclamo_auto.Where(a => a.id == idReclamo).First();
        idRecibido2 = reclamo.id_auto_reclamo.ToString();
        placaRecibida =reclamo.auto_reclamo.placa.ToString();
        txtBusquedaAuto.Text = placaRecibida;
        id = Int32.Parse(idRecibido);
        idAuto = Int32.Parse(idRecibido2);
        datosAutos(idAuto);
        txtIdRecibido.Text = idRecibido;

        var datos = DBReclamos.reclamo_auto.Find(id);
        fechaCreacion.Text = "Fecha Creacion: " + Convert.ToDateTime(datos.fecha_commit).ToString("dd/MM/yyyy");
        HoraCreacion.Text = datos.hora_commit.ToString();

        if (!IsPostBack)
        {
            DevolverDatos(id);
        }
    }

    protected void btnGuardarllamada_Click(object sender, EventArgs e)
    {
        try
        {
            var reclamo = DBReclamos.reclamo_auto.Find(id);
            reclamo.boleta = txtBoleta.Text;
            reclamo.titular = txtTitular.Text;
            reclamo.ubicacion = txtUbicacion.Text;
            reclamo.reportante = txtReportante.Text;
            reclamo.piloto = txtpiloto.Text;
            reclamo.telefono = txtTelefono.Text;
            reclamo.ajustador = txtAjustador.Text;
            reclamo.version = txtVersion.Text;
            reclamo.tipo_servicio = DDLTipo.SelectedItem.Text;
            reclamo.id_estado = Convert.ToInt32(ddlestado.SelectedValue);
            reclamo.fecha_cierre = DateTime.Now;
            reclamo.hora_cierre = DateTimeOffset.Now.TimeOfDay;

            bitacora_reclamo_auto bitacora = new bitacora_reclamo_auto();
            bitacora.descripcion = txtllamada.Text;
            bitacora.id_reclamo = id;
            bitacora.usuario = userlogin;
            bitacora.fecha_commit = DateTime.Now;
            bitacora.hora_commit = DateTimeOffset.Now.TimeOfDay;
            DBReclamos.bitacora_reclamo_auto.Add(bitacora);
            DBReclamos.SaveChanges();

            GridLLamadas.DataBind();
            txtllamada.Text = "";
            Utils.ShowMessage(this.Page, "Registro Actualizado con exito", "Exelente", "success");
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error en la actualizacion revise los campos que a digitado", "Error..!", "error");
        }

        if (ddlestado.SelectedValue == "2" || ddlestado.SelectedValue == "3")
        {
            Response.Redirect("/Modulos/Dashboard/DashboardCabina.aspx");
        }
    }


    public void DevolverDatos(int id)
    {
        try
        {
            var datos = DBReclamos.reclamo_auto.Find(id);
            txtBoleta.Text = datos.boleta.ToString();
            txtTitular.Text = datos.titular.ToString();
            txtUbicacion.Text = datos.ubicacion.ToString();
            txtReportante.Text = datos.reportante.ToString();
            txtpiloto.Text = datos.piloto.ToString();
            txtTelefono.Text = datos.telefono.ToString();
            txtAjustador.Text = datos.ajustador.ToString();
            txtVersion.Text = datos.version.ToString();
            DDLTipo.Text = datos.tipo_servicio.ToString();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos", "Error!", "error");
        }
    }

    public void datosAutos(int ida)
    {
        try
        {
            var auto = DBReclamos.auto_reclamo.Find(ida);
            lblPlaca.Text = "<b>Placa :</b> " + auto.placa;
            lblColor.Text = "<b>Color :</b> " + auto.color;
            lblMarca.Text = "<b>Marca :</b> " + auto.marca;
            lblModelo.Text = "<b>Modelo :</b> " + auto.modelo;
            lblChasis.Text = "<b>Chasis :</b> " + auto.chasis;
            lblMotor.Text = "<b>Motor :</b> " + auto.motor;
            lblPropietario.Text = "<b>Propietario :</b> " + auto.propietario;
            lblEjecutivo.Text = "<b>Ejecutivo :</b> " + auto.ejecutivo;
            lblAseguradora.Text = "<b>Aseguradora :</b> " + auto.aseguradora;
            lblContratante.Text = "<b>Contratante :</b> " + auto.contratante;
            lblEstadoPoliza.Text = "<b>Estado Poliza :</b>" + auto.estado_poliza;
            lblCliente.Text = "<b>Cliente Vip :</b>" + auto.vip;
            lblPrograma.Text = "<b>Programa :</b> " + auto.programa;
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer todos los datos porque es un registro de forma manual", "Ojo!", "Info");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
}