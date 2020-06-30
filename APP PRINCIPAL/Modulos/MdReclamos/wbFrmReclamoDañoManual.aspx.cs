using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamoDañoManual : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    String metodo = "manual";
    String ultimoIdReclamoDano, ultimoIdRegDano, idCabina, idUsuario, codigo;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx",false);
        }
        obtenerID();
        txtReportante.Focus();

        if(!IsPostBack)
        {
            Aseguradoras();
        }
    }

    protected void btnGuardarReclamo_Click(object sender, EventArgs e)
    {
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (txtNombre.Text == null)
        {
            Utils.ShowMessage(this.Page, "Debes Agregar un nombre de empresa", "Nota..!", "warning");
        }

        else
        {
            try
            {
                TimeSpan hora = new TimeSpan(0, 0, 0);

                if (!String.IsNullOrEmpty(txtHora.Text))
                {
                    hora = TimeSpan.Parse(txtHora.Text);
                }

                reg_reclamo_varios registro = new reg_reclamo_varios();
                var sec_registro = DBReclamos.pa_sec_reg_reclamos_danios_varios();
                long? id_registro = sec_registro.Single();
                registro.id = Convert.ToInt32(id_registro);
                registro.poliza = txtPoliza.Text.ToString();
                registro.direccion = txtDireccion.Text.ToString();
                registro.ejecutivo = txtEjecutivo.Text.ToString();
                registro.asegurado = txtNombre.Text.ToString();
                registro.aseguradora = ddlAseguradora.SelectedValue;

                if (txtReportante.Text == "" || txtTelefono.Text == "" || txtFecha.Text == "")
                {
                    Utils.ShowMessage(this.Page, "Los campos reportantes, telefono, y fecha son requeridos", "Nota..!", "warning");
                }

                reclamos_varios reclamo = new reclamos_varios();
                var reclamo_id = DBReclamos.pa_sec_reclamos_varios();
                long? id_reclamo = reclamo_id.Single();
                reclamo.id = Convert.ToInt32(id_reclamo);
                reclamo.boleta = txtBoleta.Text;
                reclamo.titular = txtTitular.Text;
                reclamo.ubicacion = txtUbicacion.Text;
                reclamo.hora = hora;
                reclamo.fecha = Convert.ToDateTime(txtFecha.Text);
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.fecha_commit = DateTime.Now;
                reclamo.reportante = txtReportante.Text;
                reclamo.telefono = txtTelefono.Text;
                reclamo.ajustador = txtAjustador.Text;
                reclamo.version = txtVersion.Text;
                reclamo.metodo = metodo;
                reclamo.id_estado = 1;
                reclamo.id_usuario = id2;
                reclamo.id_cabina = id1;
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.estado_unity = "Sin Cerrar";
                reclamo.usuario_unity = "Sin Asignar";
                reclamo.reg_reclamo_varios = registro;

                DBReclamos.reclamos_varios.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdReclamoDano = reclamo.id.ToString();
                ultimoIdRegDano = registro.id.ToString();
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosDañosEditar.aspx?ID_reclamo=" + ultimoIdReclamoDano + "&ultimoIdRegistrosDaños=" + ultimoIdRegDano + "&poliza=" + txtPoliza.Text.ToString());
            }

            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "A ocurrido algo inesperado intentelo nuevament", "Error", "error");
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
            Utils.ShowMessage(this.Page, "A ocurrido un error al traer las variables de session", "Nota..!", "warning");
        }
    }

    public void Aseguradoras()
    {
        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList().OrderBy(a => a.aseguradora);
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataValueField = "aseguradora";
        ddlAseguradora.DataBind();
    }
}