﻿using System;
using EmailValidation;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_NoEnviadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String cuerpo;

    protected void Page_Load(object sender, EventArgs e)
    {
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
        Guardar.Enabled = true;
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridNoEnviadas.SelectedRow.Cells[1].Text);
            string correo = GridNoEnviadas.SelectedRow.Cells[8].Text;
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
                Utils.ShowMessage(this.Page, "No se pudo enviar el correo, puede que el correo electronico no exista", "Error", "error");
            }
        }

        catch(Exception ex)
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

        cuerpo = "Saludos Estimad@ asegurado </br>" +
            "<div style=\"text-align: justify\">" +
            "<p>El " + registro.vigf_acs + " vence la anualidad de su póliza " + registro.poliza_unity + ", la cual le brinda coberturas al " + registro.tipo_vehiculo + "  MARCA  " + registro.marca + " PLACA " + registro.placa + ".<p>" +
            "<p>Con el afán de realizar el proceso de renovación de una forma más conveniente para todas las partes, a partir de este año, Seguros El Roble realiza la renovación anticipada de su póliza, la cual encontrará adjunta y cuenta con las siguientes condiciones:</p>" +
            "<p><b>Valor Garantizado</b> de Q." + registro.suma_aseg_renov + "; el valor garantizado es fijo y le da la tranquilidad de contar con la suma asegurada adecuada. Por favor revise el Endoso de Valor Garantizado, donde se describen las condiciones que aplican a este beneficio.<p>" +
            "<p><b>Deducibles:</b> Los deducibles que aplican en la renovación, son: " + registro.deduc_min_danos + " para Daños Propios y " + registro.deduc_min_robo + " para Robo Total</p>" +
            "<p><b>Prima a pagar anual:</b> Q." + registro.prima_anual + ", fraccionada en " + registro.pagos + " pagos.</p>" +
            "<p>Las condiciones especiales con que cuenta su póliza, puede revisarlas en el endoso de “Beneficios adicionales Incluidos sin cobro de prima” y consultarnos por cualquier duda sobre las mismas.</p>" +
            "<p>Debe revisar y verificar que su renovación contenga las coberturas y condiciones contratadas e informarnos inmediatamente de cualquier modificación que debamos efectuar <b>(Artículo 673 del Código de Comercio de Guatemala)</b>.</p>" +
            "<p>Le recordamos que debe mantener al día sus pagos, para evitar situaciones de no cobertura en caso de ocurrir un siniestro (Artículo 892 del Código de Comercio de Guatemala).</p>" +
            "<p>Recuerde que, de ocurrir algún siniestro, debe notificarlo inmediatamente a nuestra cabina de emergencias a los teléfonos 2386-3737 o 2326-3737; si lo reporta directo a la Aseguradora, favor indicárnoslo al día hábil siguiente para dar seguimiento a su reclamo.</p>" +
            "<p>NOTA IMPORTANTE: En caso no recibamos confirmación escrita de que no desea esta renovación, como mínimo con 5 días de anticipación al vencimiento " + registro.vigf_acs + ", la Aseguradora asumirá que está de acuerdo con los términos y condiciones y procederá a realizar los cobros en las fechas pactadas en el Anexo de Pagos.<p>" +
            "<p>Agradecemos la confianza depositada en nuestros servicios para el manejo de sus seguros y estoy a las órdenes para cualquier aclaración o consulta.</p>" +
            "<p>" + registro.nombre_gestor + "</p>" +
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
                DB.SaveChanges();
                llenarGrid();
                estado = true;
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

        return estado;
    }
}