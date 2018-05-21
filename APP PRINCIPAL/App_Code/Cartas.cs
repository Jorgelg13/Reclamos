using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        return "<p>Adjunto encontrará el cheque No. (Número de cheque) por la cantidad de Q. (Monto del cheque), cubriendo el reclamo por " + reg.version + ", evento ocurrido en fecha " + reg.fecha_commit.ToString("dd/MM/yyyy") + ", amparado bajo la póliza No. " + reg.reg_reclamo_varios.poliza + "  a  nombre de " + reg.reg_reclamo_varios.asegurado + ". <p>" +
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