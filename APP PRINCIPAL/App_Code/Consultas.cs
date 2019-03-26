using System;

/// <summary>
/// Descripción breve de Consultas
/// </summary>
public class Consultas
{
    public Consultas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static string DATOS_SINIESTRO(int ID)
    {
       return  "select Campo, Dato from (select cast(reportante as varchar(1000)) as Reportante,cast(telefono as varchar(1000)) as Telefono," +
           "cast(ubicacion as varchar(1000)) as Ubicacion, cast(convert(varchar(20), fecha, 103) as varchar(1000)) as Fecha_Siniestro, cast(hora as varchar(1000)) as Hora, " +
           "cast(boleta as varchar(1000)) as Boleta, cast(ajustador as varchar(1000)) as Ajustador, cast(titular as varchar(1000)) as Titular, " +
           "cast(version as varchar(1000)) as Version from reclamos_varios where id = " + ID + ") a unpivot (Dato for  Campo in (Reportante, Telefono, Ubicacion, Fecha_Siniestro, Boleta, Ajustador, Titular, Version)) up ";
    }

    public static string COBERTURAS(int ID)
    {
        return "SELECT cobertura as Cobertura, limite1 as [Limite 1], limite2  as [limite 2], deducible as Deducible, prima as Prima" +
                  " from coberturas_afectadas_danios where id_reclamos_varios = " + ID + " ";
    }

    public static string LLAMADAS(int ID)
    {
        return "SELECT descripcion  as Descripcion,Convert(varchar(10), fecha_commit, 103) As Fecha, hora_commit as Hora, usuario as Usuario" +
                   " FROM bitacora_reclamos_varios WHERE id_reclamos_varios = " + ID + " ";
    }

    public static string ESTADOS(int ID)
    {
        return "SELECT ber.estado as Estado, ber.fecha as Fecha, " +
            "datediff(day, ber.fecha, (select top 1 fecha from bitacora_estados_reclamos_varios ber2 where ber2.id > ber.id and ber2.id_reclamos_varios = " + ID + ")) as Dias " +
            "FROM bitacora_estados_reclamos_varios as ber where id_reclamos_varios = " + ID + " ";
    }

    public static string COMENTARIOS(int ID)
    {
        return "SELECT descripcion as Descripcion, usuario, fecha As Fecha from comentarios_reclamos_varios where id_reclamos_varios = " + ID + " order by fecha desc ";
    }

    public static string  LIQUIDACIONES(int ID)
    {
        return "Select id as ID, cobertura_pagada as Cobertura, ramo as Ramo, monto_reclamado as [Monto Reclamado], destino as Destino from  detalle_pagos_reclamos_varios where id_reclamos_varios = " + ID + " ";
    }

    public static string PAGOS_DANOS(int ID)
    {
        return "select Campo, Dato from(" +
            "select " +
            "cast(cobertura_pagada as varchar(1000)) as Cobertura," +
            "cast(ramo as varchar(1000)) as Ramo, " +
            "cast(tipo_pago as varchar(1000)) as [Tipo Pago]," +
            "cast(monto_reclamado as varchar(1000)) as [Monto Reclamado]," +
            "cast(monto_ajustado as varchar(1000)) as [Monto Ajustado]," +
            "cast(mejora_tecnologica as varchar(1000)) as [Mejora Tecnologica], " +
            "cast(tiempo_uso as varchar(1000)) as [Tiempo Uso]," +
            "cast(infra_seguro as varchar(1000)) as Infraseguro," +
            "cast(perdida_final_ajustada as varchar(1000)) as [Perdida Final Ajustada]," +
            "cast(deducible as varchar(1000)) as Deducible, " +
            "cast(salvamento as varchar(1000)) as Salvamento," +
            "cast(iva as varchar(1000)) as Iva," +
            "cast(timbres as varchar(1000)) as Timbres," +
            "cast(valor_indemnizado as varchar(1000)) as [Valor Indemnizado]," +
            "cast(fecha as varchar(1000)) as Fecha " +
            "from detalle_pagos_reclamos_varios where id = " + ID + ") a unpivot " +
            "(Dato for  Campo in (Cobertura, Ramo, [Tipo Pago], [Monto Reclamado], [Monto Ajustado], [Mejora Tecnologica]," +
            "[Tiempo Uso], Infraseguro, [Perdida Final Ajustada], Deducible, Salvamento, Iva, Timbres,[Valor Indemnizado], Fecha)) up ";
    }


    //seccion de consultas de autos
    public static string PAGOS_AUTOS(int ID)
    {
        return "select id as ID, cobertura_pagada as Cobertura, destino as Destino, monto as Monto, iva IVA, deducible as Deducible, timbres as Timbres, " +
                "primas as Primas, total as Total, fecha as Fecha from detalle_pagos_reclamos_autos where id_reclamo_auto = " + ID + "";
    }

    public static string LLAMADAS_AUTOS(int ID)
    {
        return "SELECT descripcion  as Descripcion,Convert(varchar(10), fecha_commit, 103) As Fecha, hora_commit as Hora, usuario as Usuario" +
                   " FROM bitacora_reclamo_auto WHERE id_reclamo = " + ID + " ";
    }

    public static string COBERTURAS_AUTOS(int ID)
    {
        return "SELECT cobertura as Cobertura, limite1 as [Limite 1], limite2  as [limite2], deducible as Deducible, prima as Prima" +
                   " from coberturas_afectadas where id_reclamo_auto = " + ID + " ";
    }

    public static string DATOS_ACCIDENTE_AUTOS(int ID)
    {
        return "select Campo, Dato from (select id,cast(tipo_servicio as varchar(1000)) as Tipo_Servicio,cast(reportante as varchar(1000)) as Reportante," +
            "cast(telefono as varchar(1000)) as Telefono,cast(ubicacion as varchar(1000)) as Ubicacion,cast(convert(varchar(20),fecha,103) as varchar(1000)) as Fecha," +
            "cast(hora as varchar(1000)) as Hora, cast(piloto as varchar(1000)) as Piloto, cast(edad as varchar(1000)) as Edad," +
            "cast(boleta as varchar(1000)) as Boleta, cast(ajustador as varchar(1000)) as Ajustador, cast(titular as varchar(1000)) as Titular, " +
            "cast(version as varchar(1000)) as Version from reclamo_auto where id = " + ID + ") a unpivot " +
            "(Dato for  Campo in (Tipo_Servicio, Reportante, Telefono, Ubicacion, Fecha, Piloto, Edad, Boleta, Ajustador, Titular, Version)) up ";
    }

    public static string COMENTARIOS_AUTOS(int ID)
    {
        return "SELECT  descripcion as Descripcion, usuario as Usuario, fecha As Fecha" +
                      " from comentarios_reclamos_autos where id_reclamo_auto = " + ID + "  order by fecha desc ";
    }

    public static string ESTADOS_AUTOS(int ID)
    {
        return "SELECT ber.estado as Estado, ber.fecha as Fecha, datediff(day, ber.fecha, (select top 1 fecha from bitacora_estados_autos ber2 where ber2.id > ber.id and ber2.id_reclamo_auto = " + ID + ")) as Dias " + "FROM bitacora_estados_autos as ber where id_reclamo_auto = " + ID + " ";
    }

    public static string SOLICITUD_DOCUMENTOS(string tipo)
    {
        return "select id as ID, descripcion as Descripcion from tipo_documentos where tipo = '"+ tipo + "'";
    }

    public static string DOCUMENTOS_SOLICITADOS(int ID, string tipo)
    {
        return "select td.descripcion as Descripcion from documentos_solicitados as ds inner join tipo_documentos as td on td.id = ds.documento where id_reclamo = " + ID + " and ds.tipo = '"+tipo+"'";
    }

    public static string DOCUMENTOS_GM(int ID)
    {
        return "select descripcion as Descripcion, comentarios as Comentarios, cantidad as Cantidad " +
            "from recibos_medicos where id_reclamo_medico =" + ID + " ";
    }

    public static string COMENTARIOS_GM(int ID)
    {
        return "select descripcion as Descripcion, usuario, fecha as [Fecha Y Hora], estado as Estado " +
           "from comentarios_reclamos_medicos where id_reclamo_medico = " + ID + " order by fecha desc ";
    }

    public static string PAGOS_GM(int ID)
    {
        return "select id as ID, monto as [Monto Cheque], total_reclamado as [Total Reclamado], total_aprobado as [Total Aprobado]," +
            "total_no_cubierto as [Total no cubierto], deducible as Deducible, coaseguro as Coaseguro,  timbres as Timbres, no_cheque as [No. cheque], moneda as Moneda " +
            "from detalle_pagos_reclamos_medicos where id_reclamo_medico = " + ID + "";
    }

    public static string NPS_AUTOS(string inicio, string fin)
    {
        return "select r.id,a.asegurado as Asegurado,a.Poliza,r.fecha_cierre_reclamo as [Fecha Cierre],g.nombre as Gestor, Contacto = (select top 1 contacto from contacto_auto as c where c.id_reclamo_auto = r.id)," +
            "Telefono = (select top 1 telefono from contacto_auto as c where c.id_reclamo_auto = r.id) " +
            "from reclamo_auto as r " +
            "inner join auto_reclamo as a on r.id_auto_reclamo = a.id " +
            "inner join gestores as g on g.id = r.id_gestor " +
            "where r.fecha_cierre between '"+inicio+"' and '"+fin+"' order by a.poliza";
    }


    //seccion de renovaciones de polizas
    public static string POLIZAS_RENOVADAS(int codigo,  int ddlEstado, String fInicio, String fFin)
    {
        String sql = "Select " +
            "r.id as ID, " +
            "r.poliza as Poliza," +
            "r.ramo as Ramo," +
            "r.endoso_renov as Endoso," +
            "r.asegurado as Asegurado," +
            "r.marca as Marca," +
            "r.modelo as Modelo," +
            "r.placa as Placa," +
            "r.vigf as [Vigencia Final]," +
            "r.correo_cliente as [Correo Cliente]," +
            "  (select top 1 fecha from renovaciones_log where poliza = r.id) as [Fecha Registro]" +
            " from renovaciones_polizas r " +
            "where r.codigo_gestor =  " + codigo + " and r.estado = "+ ddlEstado;
            
        if(!String.IsNullOrEmpty(fFin.Trim()) && !String.IsNullOrEmpty(fInicio.Trim()))
        {
            sql += " and convert(date,fecha_registro,112) between '" + fInicio + "' and '" + fFin + "' ";
        }

        return sql;
    }

    public static string REQ_POLIZAS_RENOVADAS(string poliza, string secren, String polizaACS)
    {
        string sql = "SELECT " +
            "[FECHA DE PAGO] = fecha," +
            "POLIZA = '" + polizaACS + "', " +
            "MONTO = prima_total, " +
            "REQUERIMIENTO = requerimiento " +
            "FROM requerimientos where poliza ='" + poliza + "' and renovacion = " + secren;

        return sql;

    }
 }