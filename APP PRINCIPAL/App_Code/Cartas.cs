using System;

/// <summary>
/// Descripción breve de Cartas
/// </summary>
public class Cartas
{
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();

    public Cartas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static string CARTA_ENVIO_CHEQUE_DANOS(reclamos_varios reg)
    {
        return "<p>Adjunto encontrará el cheque No. (Número de cheque) a nombre de (Nombre indicado en el cheque) por la cantidad de Q.(Monto del cheque), cubriendo el reclamo por " + reg.version + ", evento ocurrido en fecha " + reg.fecha_commit.ToString("dd/MM/yyyy") + ".<p>" +
            "<p>La liquidación se efectuó de la siguiente manera</p>";
    }

    public static string CARTA_CIERRE_INTERNO_DANOS(reclamos_varios reg)
    {
        return "<p>En relación al reclamo presentado en fecha " + reg.fecha_commit.ToString("dd/MM/yyyy") + " por " + reg.version + ", vemos con preocupación que a la presente fecha no hemos" +
            "recibido la documentación necesaria para proceder con el trámite del caso.</p>" +
            "<p> Debido a lo anterior, procederemos a cerrar internamente en nuestro sistema el caso, sin embargo, el mismo será aperturado nuevamente cuándo recibamos los documentos solicitados. " +
            "</p>" +
            "<p>La documentación requerida para el proceso, es la siguiente:</p>" +
            "<p>Es importante indicarle, que según las condiciones de la póliza indica que cualquier gestión de reclamo prescribirá en dos años contados a partir de la fecha del siniestro.</p> ";
    }


    public static string CARTA_DECLINADO_DANOS(reclamos_varios reg)
    {
        return "En relación al reclamo presentado por " + reg.tipo_servicio + ", a consecuencia de " + reg.version + " le manifestamos que Seguros " + reg.reg_reclamo_varios.aseguradora + " " +
            "analizó las características del siniestro, indicando que el mismo no cuenta con cobertura debido a (Exclusiones de la póliza, anexo, inciso, partes no asegurables, etc.)" +
            "<br />" +
            "<br />" +
            "De acuerdo a lo anterior, estamos en toda la disposición de reunirnos con su persona para explicarle como está contratada su póliza y cuales son las coberturas y exclusiones principales que ésta presenta. " +
            "<br />" +
            "<br />";
    }

    public static string CIERRE_DEDUCIBLE_ANUAL(reclamos_varios reg)
    {
        return "<p>Sobre el reclamo descrito en referencia, por este medio sírvase encontrar adjunta carta de cierre de reclamo emitida por la Aseguradora,  " +
               "por el robo de mercadería ocurrido el " + reg.fecha + ", debido a que la pérdida ajustada pasa a formar parte del deducible agregado anual, de acuerdo a condiciones " +
               "establecidas en la póliza, dónde se describen los siguientes deducibles:</p>" +
               "<ol>" +
               "<li>Robo de mercadería:</li>" +
               "<li>Deducible Agregado Anual:</li>" +
               "<li>Vigencia a afectar</li>" +
               "</ol>" +
               "<p>Por lo anterior, por cada reclamación, el deducible se aplicara de la siguiente manera:</p>" +
               "<ol>" +
               "<li>En cada reclamación se aplicarán deducibles establecidos en la póliza.</li>" +
               "<li>Después de establecer su deducible específico, se abonará al deducible agregado anual únicamente la parte cubierta de cada reclamo.</li>" +
               "<li>Al completar el deducible agregado anual, aplicarán únicamente los deducibles establecidos en la póliza.</li>" +
               "</ol>";
    }

    public static string SOLICITUD_DOCUMENTOS()

    {
        return "Datos de la póliza a afectar: \n\n" +
            "Nota: El requerimiento de documentos no debe interpretarse como una aceptación de cobertura u obligación de indemnización, la presentación de dichos documentos es para" +
            " el proceso de analisis de acuerdo a las condiciones de la poliza contratada y posible solicitud de documentos adicionales si es necesario \n\n"+
            "No.de Póliza: \n" +
            "Suma asegurada: \n" +
            "Bien asegurado: \n" +
            "Deducible: \n" +
            "Valuación: \n\n" +
            "RECOMENDACIONES:\n" +
            "1) Informar de inmediato a nuestra cabina de emergencia 2386 - 3737 que esta disponible las 24 horas del día y los 365 días del año.\n\n" +
            "2) Si la Aseguradora solicita visita de ajustador, indicar a las personas involucradas en la asistencia que no deben entregar ningún documento al ajustador; ya que éste procedimiento se hará  a través de su Corredor de Seguros Unity Promotores.\n\n" +
            "3) Es importante que este al día con el pago de primas convenido.\n\n" +
            "4) En todo aquel reclamo en el cual se reporten daños a bienes, éstos deberán ser resguardados por el asegurado, ya que en caso sea pagado el reclamo, los bienes pasaran a ser propiedad de la aseguradora.\n\n" +
            "5) Nuestro seguimiento consta de 60 días posteriores a la fecha de aviso, en caso se supere este tiempo y no se obtengan los documentos necesarios para la reclamación, se estarán cerrando los reclamos internamente, esperando que al contar con los documentos completos los haga llegar a nuestras oficinas para continuar la reclamación ante la aseguradora.\n\n" +
            "6) Si por falta de documentos se cierran los reclamos ante la aseguradora, muy importante que considere que toda gestión de reclamo tiene una prescripción de 2 años a partir de la fecha de siniestro.\n\n" +
            "7) En caso de necesitar  información y/ o documentación adicional se informará oportunamente.";
    }
    //cartas de reclamos de autos

    public static string CARTA_CIERRE_INTERNO_AUTOS(reclamo_auto auto )
    {
        return "<p>En relación al siniestro ocurrido el día " + Convert.ToDateTime(auto.fecha_commit).ToString("D") + ", por este medio hacemos de su conocimiento que a la fecha no hemos recibido documentos para el pago del reclamo.</p>" +
            "<p>Por lo anterior, estamos procediendo a cerrar el reclamo internamente en nuestro sistema y cuando recibamos la documentación solicitada procederemos a reaperturar el reclamo.</p>" +
            "<p>Es importante indicarle, que según las condiciones de la póliza de automóviles indica que cualquier gestión de reclamo prescribirá en dos años contados a partir de la fecha del siniestro.</p>" +
            "<p>Si necesita alguna información, adicional estamos a la orden</p>" +
            "<p>Sin otro particular,</p>" +
            "<p>Cordialmente,</p>";
    }

    public static string CARTA_DECLINACION_RECLAMOS_AUTOS(reclamo_auto auto)
    {
        return "En relación al reclamo presentado en " + Convert.ToDateTime(auto.fecha_commit).ToString("D") + ", lamentablemente por este medio adjuntamos carta de Seguros " + auto.auto_reclamo.aseguradora + ", en la cual confirman la declinación del reclamo debido a que el siniestro no está cubierto en las condiciones generales de la póliza, que lee lo siguiente:" +
            "<br />" +
            "<br />" +
            "<p>Esperamos poder servirle en otra oportunidad</p>" +
            "<p>Cordialmente,</p>";
    }

    public static string CARTA_ENVIO_CHEQUE_AUTOS(reclamo_auto auto)
    {
        return "<p>Adjunto encontrará el cheque No._______________ por a nombre de__________ por la cantidad de Q._____________, cubriendo el reclamo por " + auto.version + ", en evento ocurrido en fecha " + Convert.ToDateTime(auto.fecha_commit).ToString("D") + ", amparado bajo la póliza No. " + auto.auto_reclamo.poliza + ". <p>" +
            "<p>La liquidación se efectuó de la siguiente manera</p>";
    }


    public static string RENOVACIONES(int id)
    {
        Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);
        String Poliza = registro.ramo + registro.poliza + registro.endoso_renov + ".pdf";

        return "Saludos Estimad@ asegurad@: \n" +
            "<div style=\"text-align: justify\">" +
                "</br>" +
                "<p>El " + Convert.ToDateTime(registro.vigf_acs).ToString("dd/MM/yyyy") + " vence la anualidad de su póliza " + registro.poliza_unity + ", la cual le brinda coberturas a " + registro.tipo_vehiculo + "  MARCA  " + registro.marca + " PLACA " + registro.placa + " año " + registro.modelo + ".<p>" +
                "<p>Tanto Unity como El Roble, estamos comprometidos con el servicio al cliente y la protección del medio ambiente; por ello, se implementó el envío electrónico de pólizas desde hace un par de años para dar agilidad a la entrega de documentos y proteger los recursos, al no utilizar papel.</p>" +
                "<p>En nuestra búsqueda de mejoras en el servicio, <b><a href=\"https://archivos-reclamos.unitypromotores.com/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Enviadas/" + Poliza + "\">usted puede revisar aquí</a></b> su renovación del período " + Convert.ToDateTime(registro.vigf).Year + "/" + Convert.ToDateTime(registro.vigf).AddYears(1).Year + "; la cual cuenta con las siguientes condiciones:</p>" +
                "<p><b>Valor Garantizado</b> este valor es proporcionado por Seguros El Roble y le da la tranquilidad de contar con una suma asegurada adecuada; en la renovación, su vehículo tiene valor Asegurado de Q." + Convert.ToDecimal(registro.suma_aseg_renov).ToString("N2") + "; puede revisar todas las condiciones aplicables a este beneficio en el endoso incluido en su póliza</p>" +
                "<p><b>Deducibles:</b> Q." + Convert.ToDecimal(registro.deduc_min_danos).ToString("N2") + " para daños y Q." + Convert.ToDecimal(registro.deduc_min_robo).ToString("N2") + " por pérdida y/o robo total. Deducible máximo si aplica:" +
                "<p><b>Prima a pagar anual:</b> Q." + Convert.ToDecimal(registro.prima_anual).ToString("N2") + ", fraccionada en " + registro.pagos + " pagos.</p>" +
                /* "<p>Las mejoras en límites de cobertura para esta renovación y sin costo adicional, son las siguientes:</p>" +
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
                "</br>" +*/
                "<p>Las condiciones especiales con que cuenta su póliza, puede revisarlas en el endoso de “Beneficios adicionales incluidos sin cobro de prima” que forma parte de su renovación y consultarnos cualquier duda o aclaración sobre las mismas.</p>" +
                "<p>A partir de esta vigencia, se ha extendido la cobertura de Asistencia Vehicular a cubrir también la Asistencia Funeraria, cuyas condiciones están descritas en el “Endoso especial Roble asistencia funeraria” que forma parte de su renovación.</p>" +
                "<p>Actualmente la póliza cubre menores de 25 años, pero mayores de 21 sin cobro adicional de prima; favor indicar si algún menor de 21 años conduce el vehículo, para cotizarle la cobertura adecuada.</p>" +
                "<p>¿Qué coberturas adicionales tiene? Describir comenzando con:  Actualmente cuenta con las coberturas de Robo Parcial por Q. para el radio y bocinas xx; alquiler en caso de accidente. SI NO TIENE NINGUNA, BORRAR EL PÁRRAFO</p>" +
                "<p>Adicional a las coberturas con que cuenta actualmente, puede complementar su seguro por un costo adicional, e incluir alguna de las siguientes; contáctenos para una cotización: SI TIENE NINGUNA, BORRAR EL PÁRRAFO</p>" +
                "<li>Robo parcial de equipo especial (equipos de sonido o dvd instalados dentro del vehículo).</li>" +
                "<li>Renta de vehículo en caso de colisión</li>" +
                "</br>" +
                "<p>Recuerde actualizar su formulario de pago con Tarjeta de Crédito en caso de cambio de plástico, vencimiento, numeración, etc., para no afectar la continuidad de los pagos y evitar inconvenientes en caso de siniestro. " +
                "OTRO TEXTO Puede programar sus pagos con cargo a Tarjeta de Crédito, esto le dará beneficios conforme al programa de lealtad de su tarjeta, mantiene la continuidad de los pagos y evita inconvenientes en caso de siniestro; " +
                "puede solicitar el formulario respectivo, completarlo y devolvérnoslo para el envío a la Aseguradora.</p>" +
                "<p>Debe revisar y verificar que su renovación contenga las coberturas y condiciones contratadas, e informarnos inmediatamente de cualquier modificación que debamos efectuar (Artículo 673 Código de Comercio de Guatemala). " +
                "Adicionalmente, debe mantener al día sus pagos para evitar situaciones de no cobertura en caso de ocurrir un siniestro (Artículo 892 Código de Comercio de Guatemala).</p>" +
                "<p>IMPORTANTE:  Si usted no desea la renovación de la póliza, debe enviar el aviso por escrito como mínimo con 5 días de anticipación a su vencimiento " + Convert.ToDateTime(registro.vigf_acs).ToString("dd/MM/yyyy") + "; de no recibir su solicitud, la Aseguradora tomará como aceptados los términos y condiciones, procediendo con el cobro de las primas en las fechas indicadas en el Anexo de Pagos.</p>" +
                "<p>Recuerde que de ocurrir algún siniestro, debe notificarlo inmediatamente a nuestra cabina de emergencia a los teléfonos 2386-3737 o 2326-3737; si lo reporta directamente a la Aseguradora, favor indicárnoslo al día hábil siguiente para dar seguimiento a su reclamo.</p>" +
                "<p>Agradecemos la confianza depositada en nuestros servicios para el manejo de sus seguros y estoy a las órdenes para cualquier aclaración o consulta.</p>" +
                "<p>" + registro.nombre_gestor + "</p>" +
            "</div>";
    }
}