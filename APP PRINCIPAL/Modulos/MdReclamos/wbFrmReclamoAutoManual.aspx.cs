using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_wbFrmInsertarAutoManual : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string ultimoIdAuto, ultimoIdReclamo, idCabina, idUsuario, codigo;
    string metodo = "manual";
    Email notificacion = new Email();

    private void Page_Error(object sender, EventArgs e)
    {
        Response.Write("A ocurrido un error intentelo de nuevo.");
        Server.ClearError();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx", false);
        }
        obtenerID();

        if (!IsPostBack)
        {
            Aseguradoras();
        }
    }

    public void Aseguradoras()
    {
        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList().OrderBy(a => a.aseguradora);
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataValueField = "aseguradora";
        ddlAseguradora.DataBind();
    }
    protected void txtGuardarReclamo_Click(object sender, EventArgs e)
    {
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (txtPropietario == null)
        {
            Utils.ShowMessage(this.Page, "Debe agregar un propietario", "Nota..!", "warning");
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

                auto_reclamo auto = new auto_reclamo();
                var sec_registro = DBReclamos.pa_sec_auto_reclamo();
                long? id_registro = sec_registro.Single();
                auto.id = Convert.ToInt64(id_registro);
                auto.placa = txtPlaca.Text.ToString();
                auto.color = txtColor.Text.ToString();
                auto.chasis = txtChasis.Text.ToString();
                auto.motor = txtMotor.Text.ToString();
                auto.marca = txtMarca.Text.ToString();
                if(ddlEmpresa.SelectedItem.Text == "Fábrica de Productos Alimenticios René")
                {
                    auto.poliza = "AUTO-249422";
                    auto.propietario = "Fábrica de Productos Alimenticios René";
                } else
                {
                    auto.poliza = txtPoliza.Text.ToString(); 
                    auto.propietario = txtPropietario.Text.ToString();
                }
                auto.ejecutivo = txtEjecutivo.Text.ToString();
                auto.aseguradora = ddlAseguradora.SelectedItem.Text;
                auto.asegurado = txtEmpresa.Text;

                reclamo_auto reclamo = new reclamo_auto();
                var resultado = DBReclamos.pa_sec_reclamo_auto();
                long? id_reclamo = resultado.Single();
                reclamo.id = Convert.ToInt64(id_reclamo);
                reclamo.boleta = txtBoleta.Text;
                reclamo.titular = txtTitular.Text;
                reclamo.ubicacion = txtUbicacion.Text;
                reclamo.hora = hora;
                reclamo.fecha = Convert.ToDateTime(txtFecha.Text);
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.fecha_commit = DateTime.Now;
                reclamo.reportante = txtReportante.Text;
                reclamo.piloto = txtpiloto.Text;
                reclamo.telefono = txtTelefono.Text;
                reclamo.ajustador = txtAjustador.Text;
                reclamo.version = txtVersion.Text;
                reclamo.metodo = metodo.ToString();
                reclamo.id_estado = 1;
                reclamo.id_cabina = id1;
                reclamo.id_usuario = id2;
                reclamo.tipo_servicio = DDLTipo.SelectedItem.ToString();
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.estado_unity = "Sin Cerrar";
                reclamo.usuario_unity = "Sin Asignar";
                reclamo.auto_reclamo = auto;

                DBReclamos.reclamo_auto.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdAuto = auto.id.ToString();
                ultimoIdReclamo = reclamo.id.ToString();
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo=" + ultimoIdReclamo + "&ultimoAuto=" + ultimoIdAuto + "&placa=" + txtPlaca.Text.ToString());

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Utils.ShowMessage(this.Page, "A ocurrido un error inesperado intentelo de nuevo", "Error", "error");
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

    protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlEmpresa.SelectedItem.Text == "Fábrica de Productos Alimenticios René") {
            txtPoliza.Text = "AUTO-249422";
            txtPropietario.Text = "Fábrica de Productos Alimenticios René";
            txtEmpresa.Text = "";
            txtEmpresa.Enabled = true;
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#modal-recordatorio').modal('show');", addScriptTags: true);

        }
        else if (ddlEmpresa.SelectedItem.Text == "La Vision")
        {
            txtEmpresa.Text = "LA VISIÓN";
            txtEmpresa.Enabled = false;
        }
      
        else
        {
            txtEmpresa.Text = "";
            txtEmpresa.Enabled = true;
        }
    }
}