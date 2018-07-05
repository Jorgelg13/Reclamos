using System;

/// <summary>
/// Descripción breve de Cartas
/// </summary>
public class Cartas
{
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

    public static string SOLICITUD_DOCUMENTOS()

    {
        return "Datos de la póliza a afectar: \n\n" +
            "No.de Póliza: \n" +
            "Suma asegurada: \n" +
            "Bien asegurado: \n" +
            "Deducible: \n" +
            "Valuación: \n\n" +
            "RECOMENDACIONES EN CASO DE SINIESTRO: \n" +
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
        return "<p>Adjunto encontrará el cheque No. (Número de cheque) por la cantidad de Q. (Monto del cheque), cubriendo el reclamo por " + auto.version + ", evento ocurrido en fecha " + auto.fecha_commit.ToString() + ", amparado bajo la póliza No. " + auto.auto_reclamo.poliza + "  a  nombre de " + auto.auto_reclamo.asegurado + ". <p>" +
            "<p>La liquidación se efectuó de la siguiente manera</p>";
    }
}