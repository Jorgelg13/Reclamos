using EmailValidation;
using System;
using System.Web;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    { 

        if (!IsPostBack)
        {
        }

        Session["CodigoGestor"] = Utils.CODIGO_GESTOR(userlogin);
        PolizasRoble();
    }

    protected void GridElRoble_SelectedIndexChanged(object sender, EventArgs e)
    {
        String CorreoCliente = GridElRoble.SelectedRow.Cells[8].Text;
        ValidarCorreo(CorreoCliente);
    }

    public void PolizasRoble()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), Convert.ToInt32(ddlEstado.SelectedValue)), GridElRoble);
    }

    protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), Convert.ToInt32(ddlEstado.SelectedValue)), GridElRoble);
    }

    public void ValidarCorreo(String correo)
    {
        EmailValidator emailValidator = new EmailValidator();
        EmailValidationResult resultado;

        if (!emailValidator.Validate(correo.Trim(), out resultado))
        {
            Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
        }

        switch (resultado)
        {
            case EmailValidationResult.OK:
                Console.WriteLine("Mailbox exists");
                Correos.Notificacion(correo, "Renovacion de poliza", "Su poliza a sido renovada");
                break;

            case EmailValidationResult.MailboxUnavailable:
                Console.WriteLine("Email server replied there is no such mailbox");
                break;

            case EmailValidationResult.MailboxStorageExceeded:
                Console.WriteLine("Mailbox overflow");
                break;

            case EmailValidationResult.NoMailForDomain:
                Console.WriteLine("Emails are not configured for domain (no MX records)");
                break;
        }
    }

    protected void GridAllPolizas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}