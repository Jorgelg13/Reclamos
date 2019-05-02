using EmailValidation;
using System;
using System.Web;
using System.Linq;
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

        try
        {
            var user = DBReclamos.usuario.Where(U => U.nombre == userlogin).First();

            if (user.rol == "F")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Estados/Renovadas.aspx");
            }
        }
        catch { }

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
                    EnvioSms();
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

    protected void GridElRoble_SelectedIndexChanged(object sender, EventArgs e)
    {
        int identificador = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(identificador);
        var gestor = DBReclamos.usuario.Find(Convert.ToInt32(Session["CodigoGestor"]));
        String Poliza = registro.ramo + registro.poliza + registro.endoso_renov + ".pdf";
        txtTelefono.Text = registro.telefono_cliente;

        cuerpo = "Saludos Estimad@ asegurad@: \n" +
            "<div style=\"text-align: justify\">" +
                "</br>" +
                "<p>El " + Convert.ToDateTime(registro.vigf_acs).ToString("dd/MM/yyyy") + " vence la anualidad de su póliza " + registro.poliza_unity + ", la cual le brinda coberturas al " + registro.tipo_vehiculo + "  MARCA  " + registro.marca + " PLACA " + registro.placa + ".<p>" +
                "<p>Tanto Unity como El Roble, estamos comprometidos con el servicio al cliente y la protección del medio ambiente; por ello, se implementó el envío electrónico de pólizas desde hace un par de años para dar agilidad a la entrega de documentos y proteger los recursos, al no utilizar papel.</p>" +
                "<p>En nuestra búsqueda de mejoras en el servicio, usted está recibiendo <a href=\"http://52.34.115.100:5556/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Enviadas/" + Poliza + "\">adjunta</a> su renovación del período " + Convert.ToDateTime(registro.vigf).AddYears(-1).Year + "/" + Convert.ToDateTime(registro.vigf).Year + "; la cual cuenta con las siguientes condiciones:</p>" +
                "<p><b>Valor Garantizado</b> este valor es proporcionado por Seguros El Roble y le da la tranquilidad de contar con una suma asegurada adecuada; en la renovación, su vehículo tiene valor Asegurado de Q." + Convert.ToDecimal(registro.suma_aseg_renov).ToString("N2") + "; puede revisar todas las condiciones aplicables a este beneficio en el endoso incluido en su póliza</p>" +
                "<p><b>Deducibles:</b> "+ Convert.ToDecimal(registro.deduc_min_danos).ToString("N2") + " para daños y "+ Convert.ToDecimal(registro.deduc_min_robo).ToString("N2") + " por pérdida total. Deducible máximo si aplica:" +
                "<p><b>Prima a pagar anual:</b> Q." + Convert.ToDecimal(registro.prima_anual).ToString("N2") + ", fraccionada en " + registro.pagos + " pagos.</p>" +
                "<p>Las mejoras en límites de cobertura para esta renovación y sin costo adicional, son las siguientes:</p>" +

                "<table style=\"width: 100 %; text-align:center; border: 1px solid black; border-collapse: collapse; border-spacing: 0px !important;\">" +
                   "  <tr>" +
                   "    <th style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Cobertura</th>" +
                   "    <th style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Actual</th> " +
                   "    <th style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Renovacion 2019/2020</th>" +
                   "  </tr>" +
                   "  <tr>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Responsabilidad Civil ante Terceros</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.800,000.00</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.1,000,000.00</td>" +
                   "  </tr>" +
                   "  <tr>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Lesiones y Gastos Médicos a ocupantes (Máximo por persona y/o por accidente)</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q. 30,000.00 por persona Q.150,000.00 por Accidente</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q. 50,000.00 por persona Q.250,000.00 por Accidente</td>" +
                   "  </tr>" +
                   "  <tr>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Grúa en caso de accidente</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.7,500.00</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.10,000.00</td>" +
                   "  </tr>" +
                   "   <tr>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Muerte del Piloto a consecuencia del accidente (certificada por el INACIF)</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.150,000.00</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.250,000.00</td>" +
                   "  </tr>" +
                   "   <tr>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Fianza de Excarcelación</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.25,000.00</td>" +
                   "    <td style=\"border: 1px solid black; border-collapse: collapse; text-align:center;\">Q.50,000.00</td>" +
                   "  </tr>" +
                   "</table>" +
                   "</br>"+
                "<p>Las condiciones especiales con que cuenta su póliza, puede revisarlas en el endoso de “Beneficios adicionales incluidos sin cobro de prima” que forma parte de su renovación y consultarnos cualquier duda o aclaración sobre las mismas.</p>" +
                "<p>A partir de esta vigencia, se ha extendido la cobertura de Asistencia Vehicular a cubrir también la Asistencia Funeraria, cuyas condiciones están descritas en el “Endoso especial Roble asistencia funeraria” que forma parte de su renovación.</p>" +
                "<p>Actualmente la póliza cubre menores de 25 años, pero mayores de 21 sin cobro adicional de prima; favor indicar si algún menor de 21 años conduce el vehículo, para cotizarle la cobertura adecuada.</p>" +
                "<p>¿Qué coberturas adicionales tiene? Describir comenzando con:  Actualmente cuenta con las coberturas de Robo Parcial por Q. para el radio y bocinas xx; alquiler en caso de accidente. SI NO TIENE NINGUNA, BORRAR EL PÁRRAFO</p>" +
                "<p>Adicional a las coberturas con que cuenta actualmente, puede complementar su seguro por un costo adicional, e incluir alguna de las siguientes; contáctenos para una cotización: SI TIENE NINGUNA, BORRAR EL PÁRRAFO</p>" +
                "<li>Robo parcial de equipo especial (equipos de sonido o dvd instalados dentro del vehículo).</li>" +
                "<li>Renta de vehículo en caso de colisión</li>" +
                "</br>"+
                "<p>Recuerde actualizar su formulario de pago con Tarjeta de Crédito en caso de cambio de plástico, vencimiento, numeración, etc., para no afectar la continuidad de los pagos y evitar inconvenientes en caso de siniestro. " +
                "OTRO TEXTO Puede programar sus pagos con cargo a Tarjeta de Crédito, esto le dará beneficios conforme al programa de lealtad de su tarjeta, mantiene la continuidad de los pagos y evita inconvenientes en caso de siniestro; " +
                "puede solicitar el formulario respectivo, completarlo y devolvérnoslo para el envío a la Aseguradora.</p>" +
                "<p>Debe revisar y verificar que su renovación contenga las coberturas y condiciones contratadas, e informarnos inmediatamente de cualquier modificación que debamos efectuar (Artículo 673 Código de Comercio de Guatemala). " +
                "Adicionalmente, debe mantener al día sus pagos para evitar situaciones de no cobertura en caso de ocurrir un siniestro (Artículo 892 Código de Comercio de Guatemala).</p>" +
                "<p>IMPORTANTE:  Si usted no desea la renovación de la póliza, debe enviar el aviso por escrito como mínimo con 5 días de anticipación a su vencimiento "+ Convert.ToDateTime(registro.vigf_acs).ToString("dd/MM/yyyy")+"; de no recibir su solicitud, la Aseguradora tomará como aceptados los términos y condiciones, procediendo con el cobro de las primas en las fechas indicadas en el Anexo de Pagos.</p>" +
                "<p>Recuerde que de ocurrir algún siniestro, debe notificarlo inmediatamente a nuestra cabina de emergencia a los teléfonos 2386-3737 o 2326-3737; si lo reporta directamente a la Aseguradora, favor indicárnoslo al día hábil siguiente para dar seguimiento a su reclamo.</p>" +
                "<p>Agradecemos la confianza depositada en nuestros servicios para el manejo de sus seguros y estoy a las órdenes para cualquier aclaración o consulta.</p>" +
                "<p>" + registro.nombre_gestor + "</p>" +
            "</div>";

        txtCuerpo.Text = cuerpo;
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
    }

    //enviar correo electronico
    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        string correo = Convert.ToString(GridElRoble.SelectedRow.Cells[12].Text);
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);

        try
        {
            this.ValidarCorreo(correo, id);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
        }
    }

  
    //mover registros a invalidos
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

    private void EnvioSms()
    {
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);

        String mensaje = "Hemos enviado a su email registrado la renovacion " +  Convert.ToDateTime(registro.vigf).AddYears(-1).Year + "/" +  Convert.ToDateTime(registro.vigf).Year + " " +
            "de su poliza " + registro.poliza + " del " + registro.marca + " / " + registro.modelo +", favor revisar y cualquier duda contacte a " +
            "" + registro.nombre_gestor + " al " + Utils.TelefonoEjecutivo(Convert.ToInt32(registro.codigo_gestor));

        Utils.ENVIOSMS(registro.telefono_cliente.Trim(),mensaje);
    }
}