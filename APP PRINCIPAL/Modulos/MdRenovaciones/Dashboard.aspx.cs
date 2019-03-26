using EmailValidation;
using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String cuerpo;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CodigoGestor"] = Utils.CODIGO_GESTOR(userlogin);

        if (!IsPostBack)
        {
            PolizasRoble();
        }
    }


    public void PolizasRoble()
    {
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
    }
    public void ValidarCorreo(String correo, int id)
    {
        EmailValidator emailValidator = new EmailValidator();
        EmailValidationResult resultado;
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);
        var gestor = DBReclamos.usuario.Find(Convert.ToInt32(Session["CodigoGestor"]));
        if(registro.correo_cliente != "")
        {
            if (!emailValidator.Validate(correo.Trim(), out resultado))
            {
                Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
            }

            switch (resultado)
            {
                case EmailValidationResult.OK:
                    // Console.WriteLine("Mailbox exists");
                    // Correos.Notificacion(correo.Trim(), "Renovacion de poliza", txtCuerpo.Text);
                    Utils.EmailRenovacion("pa_envio_renovaciones", correo, txtCuerpo.Text, registro.correo_gestor.Trim());
                    registro.estado = 3;
                    DBRenovaciones.SaveChanges();
                    String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
                    Utils.MoverArchivos(Poliza, "Enviadas");
                    llenarGrid();
                    break;

                case EmailValidationResult.MailboxUnavailable:
                    //Console.WriteLine("Email server replied there is no such mailbox");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;

                case EmailValidationResult.MailboxStorageExceeded:
                    //Console.WriteLine("Mailbox overflow");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;

                case EmailValidationResult.NoMailForDomain:
                    //Console.WriteLine("Emails are not configured for domain (no MX records)");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;
            }
        }

        else if (registro.correo_cliente == "")
        {
            registro.estado = 6;
            DBRenovaciones.SaveChanges();
            llenarGrid();
        }
    }

    protected void GridAllPolizas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridElRoble_SelectedIndexChanged(object sender, EventArgs e)
    {
        int identificador = Convert.ToInt32(GridElRoble.SelectedRow.Cells[1].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(identificador);
        var gestor = DBReclamos.usuario.Find(Convert.ToInt32(Session["CodigoGestor"]));
        String Poliza = registro.ramo + registro.poliza + registro.endoso_renov + ".pdf";

        cuerpo = "Saludos Estimad@ asegurado \n" +
            "<div style=\"text-align: justify\">" +
            "<p>El " + Convert.ToDateTime(registro.vigf_acs).ToString("dd/MM/yyyy") + " vence la anualidad de su póliza " + registro.poliza_unity + ", la cual le brinda coberturas al " + registro.tipo_vehiculo + "  MARCA  " + registro.marca + " PLACA " + registro.placa + ".<p>" +
            "<p>Con el afán de realizar el proceso de renovación de una forma más conveniente para todas las partes, a partir de este año, Seguros El Roble realiza la renovación anticipada de su póliza, la cual encontrará adjunta y cuenta con las siguientes condiciones:</p>" +
            "<p><b>Valor Garantizado</b> de Q." + registro.suma_aseg_renov + "; el valor garantizado es fijo y le da la tranquilidad de contar con la suma asegurada adecuada. Por favor revise el Endoso de Valor Garantizado, donde se describen las condiciones que aplican a este beneficio.<p>" +
            "<p><b>Deducibles:</b> Los deducibles que aplican en la renovación, son: " + registro.deduc_min_danos + " para Daños Propios y " + registro.deduc_min_robo + " para Robo Total</p>" +
            "<p><b>Prima a pagar anual:</b> Q." + registro.prima_anual + ", fraccionada en " + registro.pagos + " pagos.</p>" +
            "<p>Las condiciones especiales con que cuenta su póliza, <a href=\"http://52.34.115.100:5556/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Enviadas/" + Poliza +"\"> puede revisarlas aqui</a>, en el endoso de “Beneficios adicionales Incluidos sin cobro de prima” y consultarnos por cualquier duda sobre las mismas.</p>" +
            "<p>Debe revisar y verificar que su renovación contenga las coberturas y condiciones contratadas e informarnos inmediatamente de cualquier modificación que debamos efectuar <b>(Artículo 673 del Código de Comercio de Guatemala)</b>.</p>" +
            "<p>Le recordamos que debe mantener al día sus pagos, para evitar situaciones de no cobertura en caso de ocurrir un siniestro (Artículo 892 del Código de Comercio de Guatemala).</p>" +
            "<p>Recuerde que, de ocurrir algún siniestro, debe notificarlo inmediatamente a nuestra cabina de emergencias a los teléfonos 2386-3737 o 2326-3737; si lo reporta directo a la Aseguradora, favor indicárnoslo al día hábil siguiente para dar seguimiento a su reclamo.</p>" +
            "<p>NOTA IMPORTANTE: En caso no recibamos confirmación escrita de que no desea esta renovación, como mínimo con 5 días de anticipación al vencimiento " + registro.vigf_acs + ", la Aseguradora asumirá que está de acuerdo con los términos y condiciones y procederá a realizar los cobros en las fechas pactadas en el Anexo de Pagos.<p>" +
            "<p>Agradecemos la confianza depositada en nuestros servicios para el manejo de sus seguros y estoy a las órdenes para cualquier aclaración o consulta.</p>" +
            "<p>" + registro.nombre_gestor + "</p>" +
            "</div>";

        txtCuerpo.Text = cuerpo;
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
    }

    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        string correo = Convert.ToString(GridElRoble.SelectedRow.Cells[8].Text);
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[1].Text);

        try
        {
            this.ValidarCorreo(correo, id);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
        }
    }

  

    protected void GridElRoble_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridElRoble.Rows[e.RowIndex];
        int ID = Convert.ToInt32(row.Cells[3].Text);

        var registro = DBRenovaciones.renovaciones_polizas.Find(ID);
        registro.estado = 8;

        String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
        Utils.MoverArchivos(Poliza, "Invalidas");

        DBRenovaciones.SaveChanges();
        llenarGrid();
    }
}