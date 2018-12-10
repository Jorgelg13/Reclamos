using EmailValidation;
using System;
using System.Web;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
    String cuerpo;

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
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
    }

    protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), Convert.ToInt32(ddlEstado.SelectedValue), "", ""), GridElRoble);
    }

    public void ValidarCorreo(String correo)
    {
        EmailValidator emailValidator = new EmailValidator();
        EmailValidationResult resultado;
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[1].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);
        cuerpo = "Saludos Estimad@ asegurado </br>" +
            "El "+ registro.vigf+"";

        if (!emailValidator.Validate(correo.Trim(), out resultado))
        {
            Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
        }

        switch (resultado)
        {
            case EmailValidationResult.OK:
               // Console.WriteLine("Mailbox exists");
                Correos.Notificacion(correo.Trim(), "Renovacion de poliza", "Su poliza a sido renovada");
                registro.estado = 3;
                DBRenovaciones.SaveChanges();
                llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]),2, "",""), GridElRoble);
                break;

            case EmailValidationResult.MailboxUnavailable:
                //Console.WriteLine("Email server replied there is no such mailbox");
                registro.estado = 6;
                DBRenovaciones.SaveChanges();
                llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
                break;

            case EmailValidationResult.MailboxStorageExceeded:
                //Console.WriteLine("Mailbox overflow");
                registro.estado = 6;
                DBRenovaciones.SaveChanges();
                llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
                break;

            case EmailValidationResult.NoMailForDomain:
                //Console.WriteLine("Emails are not configured for domain (no MX records)");
                registro.estado = 6;
                DBRenovaciones.SaveChanges();
                llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
                break;
        }
    }

    protected void GridAllPolizas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}