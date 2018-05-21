using System;
using System.Web;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmAutorizacionesEditar : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int estado = 1;
    string metodo = "sistema";
    string idRecibido; //id de la ultima transaccion de la tabla reclamo_auto
    string idRecibido2;//id de la ultima transaccion de la tabla un auto_reclamo
    string polizaRecibida;// numero de placa de la ultima inserccion en auto reclamo
    int id;
    int idAutorizacion;


    private void Page_Error(object sender, EventArgs e)
    {
        Response.Write("<Script>alert('A ocurrido algo inesperado intentelo de nuevo')</script>");
        Server.ClearError();
        //Response.Redirect("/Defualt.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        Server.ScriptTimeout = 180;
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        idRecibido2 = Convert.ToString(Request.QueryString[1].ToString());
        polizaRecibida = Convert.ToString(Request.QueryString[2].ToString());
        id = Int32.Parse(idRecibido);
        idAutorizacion = Int32.Parse(idRecibido2);
        txtId.Text = idRecibido;

        if (!IsPostBack)
        {
            DevolverDatos(id);
            datosPoliza(idAutorizacion);
        }
    }

    public void DevolverDatos(int id)
    {
        try
        {
            var datos = DBReclamos.autorizaciones.Find(id);
            txtReportante.Text = datos.reportante.ToString();
            DDLTipo.Text = datos.tipo_consulta.ToString();
            DDLEstado.Text = datos.tipo_estado.ToString();
            txtCorreo.Text = datos.correo.ToString();
            txtTelefono.Text = datos.telefono.ToString();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos", "Error!", "error");
        }
    }

    public void datosPoliza(int ida)
    {
        try
        {
            var registro = DBReclamos.reg_reclamos_medicos.Find(ida);
            lblAsegurado.Text = "Asegurado: " + registro.asegurado;
            lblPoliza.Text = "Poliza: " + registro.poliza;
            lblRamo.Text = "Ramo: " + registro.ramo;
            lblTipo.Text = "Tipo: " + registro.tipo;
            lblClase.Text = "Clase: " + registro.clase;
            lblEjecutivo.Text = "Ejecutivo: " + registro.ejecutivo;
            lblAseguradora.Text = "Aseguradora: " + registro.aseguradora;
            lblContratante.Text = "Contratante: " + registro.contratante;
            lblEstadoPoliza.Text = "Estado Poliza: " + registro.estado_poliza;
            lblVip.Text = "Cliente Vip: " + registro.vip;
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron traer todos los datos porque es un registro de forma manual", "Ojo!", "Info");
        }
    }

    protected void btnGuardarEstado_Click1(object sender, EventArgs e)
    {
        try
        {
            var Autorizacion = DBReclamos.autorizaciones.Find(id);
            Autorizacion.tipo_estado = DDLEstado.SelectedValue;
            Autorizacion.reportante = txtReportante.Text;
            Autorizacion.tipo_consulta = DDLTipo.SelectedValue;
            Autorizacion.correo = txtCorreo.Text;
            Autorizacion.telefono = txtTelefono.Text;
            Autorizacion.fecha_cierre = DateTime.Now;
            Autorizacion.hora_cierre =  DateTimeOffset.Now.TimeOfDay;
            Autorizacion.fecha_completa_cierre = DateTime.Now;

            bitacora_autorizaciones b_autorizaciones = new bitacora_autorizaciones();
            b_autorizaciones.descripcion = txtRegistro.Text;
            b_autorizaciones.estado = DDLEstado.SelectedValue;
            b_autorizaciones.id_autorizaciones = id;
            b_autorizaciones.usuario = userlogin;
            b_autorizaciones.fecha_commit = DateTime.Now;
            b_autorizaciones.hora_commit = DateTimeOffset.Now.TimeOfDay;
            DBReclamos.bitacora_autorizaciones.Add(b_autorizaciones);
            DBReclamos.SaveChanges();

            gridEstados.DataBind();
            txtRegistro.Text = "";
            Utils.ShowMessage(this.Page, "Registro Actualizado con exito", "Exelente", "success");
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al actualizar revise los campos que a digitado", "Error", "error");
        }

        if (DDLEstado.SelectedValue == "Cerrado")
        {
            Response.Redirect("/Modulos/Dashboard/DashboardCabina.aspx");
        }

        else if(DDLEstado.SelectedValue == "Anulado")
        {
            Response.Redirect("/Default.aspx");
        }
    }
}