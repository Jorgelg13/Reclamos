using System;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Constantes
/// </summary>
public class Constantes
{
    public Constantes()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    //textos para reclamos de daños

    public static string Mensaje(Label fecha )
    {
        return "Nuestro seguimiento consta de 60 días para la recepción de documentos, actualmente su reclamación ha superado este tiempo por lo que estaremos cerrando internamente su reclamo. " +
            " En caso reúna todos los documentos necesarios para el análisis puede enviarlos a nuestras oficinas para apertura nuevamente nuestros registros y así " +
            "continuar el proceso normal de su reclamación.  Es importante indicar que ante la aseguradora el reclamo continúa apertura do, sin embargo una vez  la aseguradora " +
            "notifique formalmente el cierre del reclamo por falta de documentos, estaremos compartiendo esta información para su conocimiento.\n\n Derivado que a la fecha no contamos " +
            "con la información necesaria para el análisis de su reclamación de fecha " + fecha.Text + " a causa de_______________, estamos procediendo al cierre interno de su reclamación.";
    }

    public static string ASIGNACION_DAÑOS (Label fechaSiniestro)
    {
        return "Estimado Asegurado, reciba un cordial saludo! Por medio del presente le informamos que hemos sido notificados sobre un nuevo evento ocurrido en fecha " + fechaSiniestro.Text + "  por ___________.Actualmente hemos informado a la aseguradora por esta eventualidad y posteriormente un asesor de nuestro de departamento de reclamos se estará comunicando para indicar el procedimiento a seguir. \n\n Recomendaciones:\n En caso de robo:\n  " +
              "• Informar inmediatamente a las autoridades competentes sobre lo ocurrido. \n " +
              "• De contar con algún dispositivo de localización reportar inmediatamente al proveedor que brinda dicho servicio para la pronta ubicación del bien robado.\n" +
              " En caso de daños:\n" +
              "• Mantener debidamente resguardados los bienes hasta que un ajustador asignado por la aseguradora realice la inspección correspondiente.";
    }

    public static string PENDIENTE_ASEGURADO_DAÑOS(Label reportante, Label fecha)
    {
        return "Estimado asegurado buen día! \n Brindando seguimiento al evento reportado por " + reportante.Text + ", de fecha " + fecha.Text + ", le informo que me ha sido asignada su reclamación para la presentación de documentos, así como seguimiento y finalización del mismo.\n Para tal efecto, agradeceremos su valiosa colaboración enviando los documentos iniciales que describimos a continuación: \n\n(DESCRIPCIÓN DE DOCUMENTOS)\n\n Así también, es importante comentarle que hemos revisado las condiciones de su póliza, en la cual el deducible a superar para esta clase de eventos lee de la siguiente manera:\n RECOMENDACIONES:\n Es importante indicar que la aseguradora puede solicitar información y documentos adicionales a los solicitados.\n\n NOTA:  Es importante que tome en consideración que para el buen avance de su reclamación es indispensable presentar toda la documentación requerida.";
    }

    public static string PENDIENTE_GESTOR_RECLAMOS_DAÑOS(Label idrec, Label fecha)
    {
        return "Apreciable asegurado, un gusto saludarle!\n\n Sobre el reclamo No. " + idrec.Text + ", en el cual fue notificado el " + fecha.Text + ", confirmamos la recepción de documentos, los cuales se encuentran en revisión; de contar con alguna consulta o solicitud de información adicional, nos estaremos comunicando con usted y así resolver a la brevedad";
    }

    public static string AJUSTE_DAÑOS(Label idrec, Label aseguradora)
    {
        return "Estimado asegurado, \n\n En relación al reclamo No. " + idrec.Text + ", a nombre de " + aseguradora.Text + ", le informamos que después de haber completado la documentación requerida en su reclamación, así como la revisión correspondiente, hemos compartido al ajustador la misma para el análisis respectivo.\n\n Estaremos brindando seguimiento con el ajustador y esperamos muy pronto notificar al respecto.";
    }

    public static string PENDIENTE_FINIQUITO_DAÑOS(Label aseguradora)
    {
        return "Por este medio le informamos que su reclamación a nombre de " + aseguradora.Text + " por el ____________ está por finalizar, para ello hemos compartido propuesta de liquidación para su aprobación.\n\n En otra comunicación estaremos enviando detalle de la propuesta para su validación.\n\n";
    }

    public static string CHEQUE_DAÑOS(Label idrec)
    {
        return "Por medio del presente le informo que después de su aceptación a la propuesta de liquidación del reclamo No. " + idrec.Text + ", su caso se encuentra en proceso de emisión de cheque y/o escritura de pago, en cuanto tengamos conocimiento de disponibilidad de estos documentos, estaremos informando vía telefónica para coordinar la entrega.";
    }

    public static string NOTIFICACION_EJECUTIVO(string fecha, string asegurado, string poliza, DropDownList gestor, int id)
    {
        return "<p>Estimado Ejecutivo:</p>" +
           "<p> Hacemos de su conocimiento que con fecha " + fecha + " ingreso un reclamo del Asegurado " + asegurado + " " +
           "bajo la poliza No. " + poliza + ", favor tomar nota para solicitar la rehabilitacion de la suma asegurada correspondiente, siempre y cuando la misma si aplique.</p>" +
           "<p>el asesor de reclamos asignado es " + gestor.SelectedItem.Text + ".</p>" +
           "<p>Para mas detalles puede consultar el reclamo con este id : " + id + " en el siguiente link </p>" +
           "<a href= \"http://reclamosgt.unitypromotores.com/MdBitacora/DashboardUnity.aspx\">Consulta Reclamos</a>" +
        "<p>Cualquier duda y/ o comentario al respecto quedamos a sus ordenes.</p>";
    }

    public static string ASIGNACION_DANOS(DropDownList gestor, string poliza,string Telefono)
    {
        return "Estimado asegurado: \n\n" +
               " Mi nombre es " + gestor.SelectedItem + ", soy la persona asignada para la atención del reclamo presentado a la poliza "+poliza+"" +
               " Mi teléfono directo es: "+ Telefono +" para que pueda contactarme en cualquier consulta. \n" +
               " Cualquier duda, estoy a la orden.";
    }


    /////////////////////////////////////////////////////////
    //Textos para reclamos de autos 
    public static string ASIGNACION_AUTOS(DropDownList gestor, string placa, string marca, string modelo, string telefono)
    {
        return "Estimado asegurado: \n\n" +
                " Mi nombre es " + gestor.SelectedItem.Text + ", soy la persona asignada para la atención del reclamo presentado por daños al vehículo" +
                " Placas: " + placa + " Marca: " + marca + " Año: " + modelo + ", " +
                " Mi teléfono directo es:   " + telefono + " para que pueda contactarme en cualquier consulta. \n" +
                " Solicito de su amable apoyo a manera que pueda confirmarme si ya cuenta con fecha para el ingreso de su vehículo al taller y así poderle apoyar en el proceso de su reclamo. \n\n" +
                " Cualquier duda, estoy a la orden.";
    }
    
    public static string PRESUPUESTO_AUTO(TextBox placa, TextBox marca, TextBox modelo)
    {
        return "Estimado Asegurado, \n" +
             "Reciba un cordial saludo! Actualmente su reclamo presentado por daños al vehículo " + marca.Text + ", " + modelo.Text + ", con placas: " + placa.Text + ", se encuentra en elaboración de presupuesto y cotización de repuestos. \n\n " +
             "Saludos cordiales..";
    }

    public static string AJUSTES_AUTOS()
    {
        return "Estimado Asegurado \n\n" +
               "Hacemos de su conocimiento que el vehículo está en proceso de ajuste de parte de la compañía de seguros. \n\n" +
               "Saludos Cordiales";
    }

    public static string REPARACION_AUTOS()
    {
        return "Estimado Asegurado,\n\n " +
                "Su vehículo actualmente está en proceso de reparación, con gusto se le estará retroalimentando sobre el proceso hasta su entrega. \n\n" +
                "Saludos Cordiales";
    }

    public static string ENTREGA_AUTO()
    {
        return "Estimado Asegurado: \n\n" +
                "Su vehículo está programado para fecha __________ , \n" +
                "Le recordamos realizar el pago de su deducible que corresponde. \n\n" +
                "Saludos Cordiales";
    }

    public static string ALQUILER_VEHICULO()
    {
        return " Reciba un cordial saludo \n\n " +
            "En relación al reclamo en la referencia, por este medio hacemos de su conocimiento que su póliza goza con la cobertura de alquiler de vehículo por colisión. \n\n " +
            "El límite diario es de Q.   hasta un máximo de __ días, equivalente a Q     .Aplicable por medio de reembolso y sujeto a  presentar la factura correspondiente de un Arrendadora legalmente autorizada. \n\n " +
            "Dentro del reembolso no se contemplará el costo de los seguros incluidos  en el contrato de arrendamiento.No aplica para servicios de taxis, y está sujeto a un deducible de Q - diarios y el 3 % de timbres fiscales. \n\n" +
            "La factura deberá ser emitida a su nombre, nos deberá enviar copia de la misma y el contrato por está vía, para el trámite del reembolso.\n\n" +
            "Cualquier duda, estamos a la orden";
    }

    public static string PERDIDA_TOTAL_AUTO(TextBox placa, TextBox marca, TextBox modelo, Label asegurado, Label poliza)
    {
        return "Estimado Ejecutivo: \n\n Por este medio hacemos de su conocimiento que recibimos notificación de pérdida total, del vehículo Placa: " + placa.Text + ", " +
            "Marca: " + marca.Text + ", Modelo: " + modelo.Text + ", propiedad del asegurado " + asegurado.Text + " póliza " + poliza.Text + ". Saludos";
    }

    public static string ROBO_AUTO(TextBox placa, TextBox marca, TextBox modelo, Label asegurado, Label poliza)
    {
        return "Estimado Ejecutivo: \n\n Por este medio hacemos de su conocimiento que recibimos notificación de Robo, del vehículo Placa: " + placa.Text + ", " +
            "Marca: " + marca.Text + ", Modelo: " + modelo.Text + ",  propiedad del asegurado " + asegurado.Text + " póliza " + poliza.Text + " . Saludos";
    }

    public static string NOTIFICACION_EJECUTIVO_AUTOS(string fecha, string asegurado, string poliza, DropDownList gestor, string placa, string marca, string modelo, int id)
    {
        return "Estimado Ejecutivo: \n\n" +
           "Hacemos de su conocimiento que con fecha " + fecha + " ingreso un reclamo del Asegurado " + asegurado + " " +
           "por daños al vehiculo "+placa+ "  "+marca+ " "+modelo+ "  Según póliza No. " + poliza + "." +
           "el asesor de reclamos asignado es " + gestor.SelectedItem.Text + " \n" +
           "Para mas detalles puede consultar el reclamo con este id : " + id + " en el siguiente link \n\n" +
           "<a href= \"http://reclamosgt.unitypromotores.com/MdBitacora/DashboardUnity.aspx\">Consulta Reclamos</a>" +
        "Cualquier duda y/ o comentario al respecto quedamos a sus ordenes.";
    }

    //usuario logeado
    public static string USER()
    {
        String userlogin = HttpContext.Current.User.Identity.Name;
        return userlogin;
    }
}