using System;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamosDañosEditar : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    String nombre, apellido, poliza, fechaInicio, fechaFinal, ramo, cliente, status, tipo, direccion;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string idRecibido; //id de la ultima transaccion de la tabla reclamos_varios
    string idRecibido2;//id de la ultima transaccion de la tabla un reg_reclamos
    string polizaRecibida;// numero de poliza de la ultima insercion en reg_reclamos_daños
    int id;
    int idregReclamosVarios;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        idRecibido2 = Convert.ToString(Request.QueryString[1]).ToString();
        polizaRecibida = Convert.ToString(Request.QueryString[2]).ToString();
        id = Int32.Parse(idRecibido);
        idregReclamosVarios = Int32.Parse(idRecibido2);
        txtBusquedaAuto.Text = polizaRecibida;
        datosPoliza(idregReclamosVarios);
        TextBox1.Text = idRecibido;
        txtBusquedaAuto.Text = polizaRecibida;
      
        if(!IsPostBack)
        {
            DevolverDatos();
        }
    }

    public void DevolverDatos()
    {
        try
        {
            var datos = DBReclamos.reclamos_varios.Find(id);
            txtBoleta.Text = datos.boleta.ToString();
            txtTitular.Text = datos.titular.ToString();
            txtUbicacion.Text = datos.ubicacion.ToString();
            txtReportante.Text = datos.reportante.ToString();
            txtTelefono.Text = datos.telefono.ToString();
            txtAjustador.Text = datos.ajustador.ToString();
            txtVersion.Text = datos.version.ToString();
            fechaCreacion.Text = Convert.ToDateTime(datos.fecha_commit).ToString("dd/MM/yyyy");
            HoraCreacion.Text = datos.hora_commit.ToString();
            ddlTipoServicio.Text = datos.tipo_servicio.ToString();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos", "Error!", "error");
        }
    }

    public void datosPoliza( int idreg)
    {
        try
        {
            var dato = DBReclamos.reg_reclamo_varios.Find(idreg);
            Label1.Text = "Poliza:        " + dato.poliza;
            Label2.Text = "Asegurado:     " + dato.asegurado;
            Label4.Text = "Cliente:       " + dato.cliente;
            Label5.Text = "Estatus:       " + dato.status;
            Label6.Text = "Tipo:          " + dato.tipo;
            Label7.Text = "Direccion:     " + dato.direccion;
            Label8.Text = "Ramo:          " + dato.ramo;
            Label9.Text = "Ejecutivo:     " + dato.ejecutivo;
            Label10.Text = "Aseguradora:  " + dato.aseguradora;
            Label11.Text = "Contratante:  " + dato.contratante;
            Label12.Text = "Cliente Vip:  " + dato.cliente;
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer todos los datos porque es un registro de forma manual", "Ojo!", "Info");
        }
    }

    protected void btnGuardarllamada_Click(object sender, EventArgs e)
    {
        try
        {
            var reclamo = DBReclamos.reclamos_varios.Find(id);
            reclamo.boleta = txtBoleta.Text;
            reclamo.titular = txtTitular.Text;
            reclamo.ubicacion = txtUbicacion.Text;
            reclamo.reportante = txtReportante.Text;
            reclamo.telefono = txtTelefono.Text;
            reclamo.ajustador = txtAjustador.Text;
            reclamo.version = txtVersion.Text;
            reclamo.id_estado = Convert.ToInt32(ddlestado.SelectedValue);
            reclamo.fecha_cierre = DateTime.Now;
            reclamo.hora_cierre = DateTimeOffset.Now.TimeOfDay;
            reclamo.tipo_servicio = ddlTipoServicio.SelectedItem.Text;

            bitacora_reclamos_varios bitacora = new bitacora_reclamos_varios();
            bitacora.descripcion = txtllamada.Text;
            bitacora.id_reclamos_varios = id;
            bitacora.usuario = userlogin;
            bitacora.hora_commit = DateTimeOffset.Now.TimeOfDay;
            bitacora.fecha_commit = DateTime.Now;

            DBReclamos.bitacora_reclamos_varios.Add(bitacora);
            DBReclamos.SaveChanges();
            GridLLamadas.DataBind();
            txtllamada.Text = "";
            Utils.ShowMessage(this.Page, "Registro Actualizado con exito", "Exelente", "success");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al actualizar los datos revise los campos actualizados", "Error", "error");
        }

        if (ddlestado.SelectedValue == "2" || ddlestado.SelectedValue == "3")
        {
            Response.Redirect("/Modulos/Dashboard/DashboardCabina.aspx");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
}