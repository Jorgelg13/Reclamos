using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmAutorizacionManual : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string ultimoIdRegMedico, ultimoIdAutorizacion, idCabina, idUsuario, codigo;
    public string asegurado, poliza, ramo, tipo, clase, ejecutivo, aseguradora;
    string metodo = "manual";
    bool tramiteDirecto = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
        if(!IsPostBack)
        {
            aseguradoras();
        }
    }

    public void aseguradoras()
    {
        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList();
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataValueField = "aseguradora";
        ddlAseguradora.DataBind();
    }

    protected void btnGuardarAutorizacion_Click(object sender, EventArgs e)
    {
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (checkTramiteDirecto.Checked)
        {
            tramiteDirecto = true;
        }

        if (txtAsegurado.Text == "")
        {
            Utils.ShowMessage(this.Page, "El nombre del asegurado es obligatorio", "Error..!", "warning");
        }

        else
        {
            try
            {
                if (txtReportante.Text == "")
                {
                    Utils.ShowMessage(this.Page, "El campo reportante es obligatorio", "Error..!", "error");
                }

                else
                {
                    reg_reclamos_medicos registro = new reg_reclamos_medicos();
                    var sec_registro = DBReclamos.pa_sec_registros_medicos();
                    long? id_registro = sec_registro.Single();
                    registro.id = Convert.ToInt64(id_registro);
                    registro.poliza = txtPoliza.Text.ToString();
                    registro.asegurado = txtAsegurado.Text.ToString();
                    registro.ejecutivo = txtEjecutivo.Text.ToString();
                    registro.aseguradora = ddlAseguradora.SelectedValue;
                    registro.tipo_registro = "Autorizacion";

                    autorizaciones autorizacion = new autorizaciones();
                    var results = DBReclamos.pa_sec_autorizaciones();
                    long? resultado = results.Single();
                    autorizacion.id = Convert.ToInt64(resultado);
                    autorizacion.reportante = txtReportante.Text;
                    autorizacion.tipo_consulta = DDLTipo.SelectedItem.ToString();
                    autorizacion.tipo_estado = DDLEstado.SelectedItem.ToString();
                    autorizacion.correo = txtCorreo.Text;
                    autorizacion.telefono = txtTelefono.Text;
                    autorizacion.metodo = metodo.ToString();
                    autorizacion.id_usuario = id2;
                    autorizacion.id_cabina = id1;
                    autorizacion.codigo_pais = Convert.ToInt16(codigo);
                    autorizacion.tramite_directo = tramiteDirecto;
                    autorizacion.fecha_commit = DateTime.Now;
                    autorizacion.fecha_completa_commit = DateTime.Now;
                    autorizacion.hora_commit = DateTimeOffset.Now.TimeOfDay;
                    autorizacion.reg_reclamos_medicos = registro;
                    DBReclamos.autorizaciones.Add(autorizacion);
                    DBReclamos.SaveChanges();

                    ultimoIdRegMedico = registro.id.ToString();
                    ultimoIdAutorizacion = autorizacion.id.ToString();
                    Response.Redirect("/Modulos/MdReclamos/wbFrmAutorizacionesEditar.aspx?ID_reclamo=" + ultimoIdAutorizacion + "&ultimaAutorizacion=" + ultimoIdRegMedico + "&poliza=" + poliza);
                }
            }

            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "No se a podido ingresar el registro", "Error..!", "error");
            }
        }
    }

    public void obtenerID()
    {
        try
        {
            var usuario = DBReclamos.usuario.Select(U => new { U.id, U.id_cabina, U.codigo, U.nombre }).Where(us => us.nombre == userlogin).First();
            Session.Add("id_usuario", usuario.id.ToString());
            Session.Add("id_cabina", usuario.id_cabina.ToString());
            Session.Add("codigo", usuario.codigo.ToString());
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se an podido obtener las variables de sesion", "Error", "error");
        }
    }
}