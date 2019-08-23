using System;
using EmailValidation;
using System.Web.UI;
using System.Web;
using System.Linq;

public partial class Modulos_MdRenovaciones_Estados_NoEnviadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String cuerpo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string usuarioLogin = HttpContext.Current.User.Identity.Name; 
            var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

            if (user.rol == "F")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Estados/Renovadas.aspx",false);
            }
        }
        catch { }


        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 6, txtFechaInicio.Text,
                 txtFechaFin.Text), GridNoEnviadas);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridNoEnviadas, Response, "NoEnviadas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 6, txtFechaInicio.Text,
              txtFechaFin.Text), GridNoEnviadas);
    }

    protected void GridNoEnviadas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridNoEnviadas.SelectedRow.Cells[1].Text);
        var registro = DB.renovaciones_polizas.Find(id);
        txtCorreo.Text = registro.correo_cliente;
        txtTelefono.Text = registro.telefono_cliente;

        cuerpo = Cartas.RENOVACIONES(id); 

        txtCuerpo.Text = cuerpo;
        Utils.ShowMessage(this.Page, "Ahora debe de ingresar el correo exacto del cliente ", "Excelente..", "success");
    }

    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridNoEnviadas.SelectedRow.Cells[1].Text);
            var registro = DB.renovaciones_polizas.Find(id);
            registro.correo_cliente = txtCorreo.Text;
            DB.SaveChanges();
            llenarGrid();

            if (ValidarCorreo(txtCorreo.Text, id))
            {
                Utils.ShowMessage(this.Page, "Se ha actualizado el correo y se ha enviado con exito la notificacion. ", "Excelente", "success");
            }

            else
            {
                Utils.EmailRenovacion("pa_envio_renovaciones", txtCorreo.Text, txtCuerpo.Text, registro.correo_gestor.Trim());
                //copia al ejecutivo
                Utils.EmailRenovacion("pa_envio_renovaciones", registro.correo_gestor, txtCuerpo.Text, registro.correo_gestor.Trim());
                registro.estado = 3;
                DB.SaveChanges();
                String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
                Utils.MoverArchivos(Poliza, "Enviadas", "Polizas");
                EnvioSms();
                llenarGrid();
            }
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se pudo actualizar y enviar el correo " + ex.Message, "Error", "error");
        }
    }

    public bool ValidarCorreo(String correo, int id)
    {
        bool estado = true;
        EmailValidator emailValidator = new EmailValidator();
        EmailValidationResult resultado;
        var registro = DB.renovaciones_polizas.Find(id);
        var gestor = DBReclamos.usuario.Find(Convert.ToInt32(Session["CodigoGestor"]));
        if (txtCorreo.Text != "")
        {
            if (!emailValidator.Validate(txtCorreo.Text.Trim(), out resultado))
            {
                Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
                registro.estado = 6;
                DB.SaveChanges();
                llenarGrid();
                estado = false;
            }

            switch (resultado)
            {
                case EmailValidationResult.OK:
                    // Console.WriteLine("Mailbox exists");
                    Utils.EmailRenovacion("pa_envio_renovaciones", txtCorreo.Text, txtCuerpo.Text, registro.correo_gestor.Trim());
                    //copia al ejecutivo
                    Utils.EmailRenovacion("pa_envio_renovaciones", registro.correo_gestor, txtCuerpo.Text, registro.correo_gestor.Trim());
                    registro.estado = 3;
                    DB.SaveChanges();
                    String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
                    Utils.MoverArchivos(Poliza, "Enviadas", "Polizas");
                    EnvioSms();
                    llenarGrid();
                    break;

                case EmailValidationResult.MailboxUnavailable:
                    //Console.WriteLine("Email server replied there is no such mailbox");
                    registro.estado = 6;
                    DB.SaveChanges();
                    llenarGrid();
                    estado = false;
                    break;

                case EmailValidationResult.MailboxStorageExceeded:
                    //Console.WriteLine("Mailbox overflow");
                    registro.estado = 6;
                    DB.SaveChanges();
                    llenarGrid();
                    estado = false;
                    break;

                case EmailValidationResult.NoMailForDomain:
                    //Console.WriteLine("Emails are not configured for domain (no MX records)");
                    registro.estado = 6;
                    DB.SaveChanges();
                    llenarGrid();
                    estado = false;
                    break;
            }
        }

        else
        {
            registro.estado = 6;
            DB.SaveChanges();
            llenarGrid();
        }

        return estado;
    }

    private void EnvioSms()
    {
        int id = Convert.ToInt32(GridNoEnviadas.SelectedRow.Cells[1].Text);
        var registro = DB.renovaciones_polizas.Find(id);

        String mensaje = "Hemos enviado a su email registrado la renovacion " + Convert.ToDateTime(registro.vigf).AddYears(-1).Year + "/" + Convert.ToDateTime(registro.vigf).Year + " " +
                         "de su poliza " + registro.poliza + " del " + registro.marca + " / " + registro.modelo + ", favor revisar y cualquier duda contacte a " +
                         "" + registro.nombre_gestor + " al " + Utils.TelefonoEjecutivo(Convert.ToInt32(registro.codigo_gestor));

        if(txtTelefono.Text == "")
        {
            txtTelefono.Text = "0";
        }

        Utils.ENVIOSMS(txtTelefono.Text, mensaje);
    }
}