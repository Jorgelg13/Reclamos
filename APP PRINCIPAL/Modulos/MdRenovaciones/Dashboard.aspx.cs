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
            "<div style=\"text-align: justify\">" +
            "<p>El (VigFin) vence la anualidad de su póliza (No, de póliza del ACS), la cual le brinda coberturas al TIPO_VEHICULO  MARCA  ANOVEHÍ PLACA (datos del reporte del Roble).<p>" +
            "<p>Con el afán de realizar el proceso de renovación de una forma más conveniente para todas las partes, a partir de este año, Seguros El Roble realiza la renovación anticipada de su póliza, la cual encontrará adjunta y cuenta con las siguientes condiciones:</p>" +
            "<p><b>Valor Garantizado</b> de Q.(SUMA_ASEG_RENOV  - del cuadro del Roble); el valor garantizado es fijo y le da la tranquilidad de contar con la suma asegurada adecuada. Por favor revise el Endoso de Valor Garantizado, donde se describen las condiciones que aplican a este beneficio.<p>" +
            "<p><b>Deducibles:</b> Los deducibles que aplican en la renovación, son: DEDUC_MIN_DANOS para Daños Propios y DEDUC_MIN_ROBO para Robo Total</p>" +
            "<p><b>Prima a pagar anual:</b> Q. PRIMATOTANUAL (del cuadro del Roble), fraccionada en NO_PAGOS pagos.</p>" +
            "<p>Las condiciones especiales con que cuenta su póliza, puede revisarlas en el endoso de “Beneficios adicionales Incluidos sin cobro de prima” y consultarnos por cualquier duda sobre las mismas.</p>" +
            "<p>Debe revisar y verificar que su renovación contenga las coberturas y condiciones contratadas e informarnos inmediatamente de cualquier modificación que debamos efectuar <b>(Artículo 673 del Código de Comercio de Guatemala)</b>.</p>" +
            "<p>Le recordamos que debe mantener al día sus pagos, para evitar situaciones de no cobertura en caso de ocurrir un siniestro (Artículo 892 del Código de Comercio de Guatemala).</p>" +
            "<p>Recuerde que, de ocurrir algún siniestro, debe notificarlo inmediatamente a nuestra cabina de emergencias a los teléfonos 2386-3737 o 2326-3737; si lo reporta directo a la Aseguradora, favor indicárnoslo al día hábil siguiente para dar seguimiento a su reclamo.</p>" +
            "<p>NOTA IMPORTANTE: En caso no recibamos confirmación escrita de que no desea esta renovación, como mínimo con 5 días de anticipación al vencimiento (VigFin), la Aseguradora asumirá que está de acuerdo con los términos y condiciones y procederá a realizar los cobros en las fechas pactadas en el Anexo de Pagos.<p>" +
            "<p>Agradecemos la confianza depositada en nuestros servicios para el manejo de sus seguros y estoy a las órdenes para cualquier aclaración o consulta.</p>" +
            "<p>Nombre y Credencial del Ejecutivo de Cuenta</p>" +
            "<p>Dirección de correo electrónico</p>" +
            "</div>";

        if (!emailValidator.Validate(correo.Trim(), out resultado))
        {
            Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
        }

        switch (resultado)
        {
            case EmailValidationResult.OK:
               // Console.WriteLine("Mailbox exists");
                Correos.Notificacion(correo.Trim(), "Renovacion de poliza", cuerpo);
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