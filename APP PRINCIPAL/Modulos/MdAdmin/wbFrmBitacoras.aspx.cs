using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdAdmin_wbFrmBitacoras : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    int id, id_estado;
    String bitacoraAutos,bitacorasDaños, bitacorasAutorizaciones, bitacoraMedicos, llamadas, nombreTabla, llaveForanea;

    protected void Page_Load(object sender, EventArgs e)
    {
        bitacoraAutos = "SELECT " +
         "dbo.reclamo_auto.id as ID," +
         "dbo.auto_reclamo.asegurado as Asegurado," +
         "dbo.auto_reclamo.poliza as Poliza," +
         "dbo.auto_reclamo.estado_poliza as [Estatus]," +
         "dbo.auto_reclamo.placa as Placa," +
         "dbo.auto_reclamo.marca as Marca," +
           "dbo.auto_reclamo.modelo as Modelo," +
           "dbo.auto_reclamo.color as Color," +
           "dbo.auto_reclamo.chasis as Chasis," +
           "dbo.auto_reclamo.motor as Motor," +
           "dbo.auto_reclamo.propietario as Propietario," +
           "dbo.auto_reclamo.ejecutivo as Ejecutivo," +
           "dbo.auto_reclamo.aseguradora as Aseguradora," +
           "dbo.auto_reclamo.contratante as Contratante," +
           "dbo.reclamo_auto.boleta as Boleta," +
           "dbo.reclamo_auto.titular as Titular," +
           "dbo.reclamo_auto.ubicacion as Ubicacion," +
           "dbo.reclamo_auto.hora as Hora," +
           "dbo.reclamo_auto.fecha as Fecha," +
           "dbo.reclamo_auto.reportante as Reportante," +
           "dbo.reclamo_auto.piloto as Piloto," +
           "dbo.reclamo_auto.edad as Edad," +
           "dbo.reclamo_auto.telefono as Telefono," +
           "dbo.reclamo_auto.ajustador as Ajustador," +
           "dbo.reclamo_auto.version as Version," +
           "dbo.reclamo_auto.tipo_servicio as [Tipo Servicio]," +
           "dbo.reclamo_auto.hora_commit as [Hora Commit]," +
           "Convert(varchar(10),dbo.reclamo_auto.fecha_commit, 103) as [Fecha Commit] ," +
           "dbo.reclamo_auto.hora_cierre as [Hora Cierre]," +
           "Convert(varchar(10),dbo.reclamo_auto.fecha_cierre, 103) as [Fecha Cierre]," +
           "dbo.reclamo_auto.usuario_unity as [Usuario Unity]," +
           "dbo.reclamo_auto.estado_unity as [Estado Unity]," +
           "dbo.cabina.nombre as Cabina," +
           "dbo.sucursal.nombre as Sucursal," +
           "dbo.empresa.nombre as Empresa," +
           "dbo.pais.nombre  as Pais," +
           "dbo.usuario.nombre as usuario " +
           "FROM " +
           "dbo.auto_reclamo " +
           "INNER JOIN dbo.reclamo_auto ON dbo.reclamo_auto.id_auto_reclamo = dbo.auto_reclamo.id " +
           "INNER JOIN dbo.cabina ON dbo.reclamo_auto.id_cabina = dbo.cabina.id " +
           "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
           "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
           "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
           "INNER JOIN dbo.usuario ON dbo.reclamo_auto.id_usuario = dbo.usuario.id " +
           "where(fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and (reclamo_auto.id_estado = 2)";

        bitacorasDaños = " SELECT " +
            "dbo.reclamos_varios.id as ID," +
            "dbo.reg_reclamo_varios.poliza as Poliza," +
            "dbo.reg_reclamo_varios.asegurado as Asegurado," +
            "dbo.reg_reclamo_varios.aseguradora as Aseguradora," +
            "dbo.reg_reclamo_varios.contratante as Contratante," +
            "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +
            "dbo.reg_reclamo_varios.ramo as Ramo," +
            "dbo.reg_reclamo_varios.status as Estatus," +
            "dbo.reg_reclamo_varios.tipo as Tipo," +
            "dbo.reg_reclamo_varios.direccion as Direccion," +
            "dbo.reclamos_varios.boleta as Boleta," +
            "dbo.reclamos_varios.titular as Titular," +
            "dbo.reclamos_varios.reportante as Reportante," +
            "dbo.reclamos_varios.telefono as Telefono," +
            "dbo.reclamos_varios.ajustador as Ajustador," +
            "dbo.reclamos_varios.version as Version," +
            "dbo.reclamos_varios.ubicacion as Ubicacion," +
            "dbo.reclamos_varios.hora as Hora," +
            "dbo.reclamos_varios.fecha as Fecha," +
            "dbo.reclamos_varios.hora_commit as [Hola Commit]," +
            "Convert(varchar(10),dbo.reclamos_varios.fecha_commit, 103) as [Fecha Commit]," +
            "dbo.reclamos_varios.hora_cierre as [Hora Cierre]," +
            "Convert(varchar(10),dbo.reclamos_varios.fecha_cierre, 103) as [Fecha Cierre]," +
            "dbo.cabina.nombre as Cabina," +
            "dbo.sucursal.nombre as Sucursal," +
            "dbo.empresa.nombre as Empresa," +
            "dbo.pais.nombre as Pais," +
            "dbo.usuario.nombre as Usuario " +
            "FROM " +
            "dbo.reg_reclamo_varios " +
            "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
            "INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
            "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
            "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
            "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
            "INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id " +
            "where (fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and (reclamos_varios.id_estado = 2) ";


        bitacorasAutorizaciones = "SELECT " +
            "dbo.autorizaciones.id AS ID," +
            "dbo.autorizaciones.reportante as Reportante," +
            "dbo.autorizaciones.tipo_consulta as [Tipo Consulta]," +
            "dbo.autorizaciones.tipo_estado as [Tipo Estado]," +
            "dbo.autorizaciones.correo as Correo," +
            "dbo.autorizaciones.telefono as Telefono," +
            "dbo.autorizaciones.metodo as Metodo," +
            "dbo.autorizaciones.hora_commit as [Hora Commit]," +
            "Convert(varchar(10),dbo.autorizaciones.fecha_commit, 103) as [Fecha Commit]," +
            "Convert(varchar(10),dbo.autorizaciones.fecha_cierre, 103) as [Fecha Cierre]," +
            "dbo.autorizaciones.hora_cierre as [Hora Cierre]," +
            "dbo.autorizaciones.tipo_estado as [Tipo Estado]," +
            "dbo.autorizaciones.total_tiempo as [Total Tiempo]," +
            "dbo.reg_reclamos_medicos.asegurado as Asegurado," +
            "dbo.reg_reclamos_medicos.poliza as Poliza," +
            "dbo.reg_reclamos_medicos.ramo as Ramo," +
            "dbo.reg_reclamos_medicos.tipo as Tipo," +
            "dbo.reg_reclamos_medicos.clase as Clase," +
            "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
            "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +
            "dbo.reg_reclamos_medicos.contratante as Contratante," +
            "dbo.cabina.nombre as Cabina," +
            "dbo.sucursal.nombre as Sucursal," +
            "dbo.empresa.nombre as Empresa," +
            "dbo.pais.nombre as Pais," +
            "dbo.usuario.nombre as Nombre " +
            "FROM " +
            "dbo.autorizaciones " +
            "INNER JOIN dbo.reg_reclamos_medicos ON dbo.autorizaciones.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
            "INNER JOIN dbo.cabina ON dbo.autorizaciones.id_cabina = dbo.cabina.id " +
            "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
            "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
            "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
            "INNER JOIN dbo.usuario ON dbo.autorizaciones.id_usuario = dbo.usuario.id " +
            "where (fecha_commit between '"+ fechaInicio.Text+"' and '"+fechaFinal.Text+"')";

        bitacoraMedicos = "SELECT " +
            "dbo.reclamos_medicos.id, " +
            "dbo.reg_reclamos_medicos.poliza, " +
            "dbo.reg_reclamos_medicos.asegurado, " +
            "dbo.reg_reclamos_medicos.aseguradora, " +
            "dbo.reg_reclamos_medicos.contratante, " +
            "dbo.reg_reclamos_medicos.ejecutivo, " +
            "dbo.reg_reclamos_medicos.ramo, " +
            "dbo.reg_reclamos_medicos.tipo, " +
            "dbo.reg_reclamos_medicos.clase, " +
            "dbo.reg_reclamos_medicos.estado_poliza, " +
            "dbo.reclamos_medicos.reportante, " +
            "dbo.reclamos_medicos.tipo_consulta, " +
            "dbo.reclamos_medicos.correo, " +
            "dbo.reclamos_medicos.telefono, " +
            "dbo.reclamos_medicos.hora_commit, " +
            "dbo.reclamos_medicos.fecha_commit, " +
            "dbo.reclamos_medicos.hora_cierre, " +
            "dbo.reclamos_medicos.fecha_cierre, " +
            "dbo.cabina.nombre as cabina, " +
            "dbo.sucursal.nombre as sucursal, " +
            "dbo.empresa.nombre as empresa, " +
            "dbo.pais.nombre as pais, " +
            "dbo.usuario.nombre as usuario " +
            "FROM " +
            "dbo.reg_reclamos_medicos " +
            "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
            "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id " +
            "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
            "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
            "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
            "INNER JOIN dbo.usuario ON dbo.reclamos_medicos.id_usuario = dbo.usuario.id " +
            "where (fecha_cierre between '" + fechaInicio.Text+"' and '"+ fechaFinal.Text +"') and (reclamos_medicos.id_estado = 2)";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    { 
        if(ddlTipoBitacora.SelectedValue == "1")
        {
            llenado.llenarGrid(bitacoraAutos, GridBitacoras);
        }

        else if (ddlTipoBitacora.SelectedValue == "2")
        {
            llenado.llenarGrid(bitacorasDaños, GridBitacoras);
        }

        else if(ddlTipoBitacora.SelectedValue == "3")
        {
            llenado.llenarGrid(bitacorasAutorizaciones, GridBitacoras);
        }

        else if(ddlTipoBitacora.SelectedValue == "4")
        {
            llenado.llenarGrid(bitacoraMedicos, GridBitacoras);
        }
    }

    protected void GridBitacoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridBitacoras.SelectedRow.Cells[1].Text);
        if (ddlTipoBitacora.SelectedValue == "1")
        {
            nombreTabla = "bitacora_reclamo_auto";
            llaveForanea = "id_reclamo";
            llamadas = "select descripcion as Descripcion, Convert(varchar(10),fecha_commit, 103)  as Fecha, hora_commit as Hora, usuario as Usuario from " + nombreTabla + "  where " + llaveForanea + " = " + id + " ";

            if(DDLTipo.SelectedItem.Text == "Abierto")
            {
                cambiarEstado(id);
            }
        }

        else if (ddlTipoBitacora.SelectedValue == "2")
        {
            nombreTabla = "bitacora_reclamos_varios";
            llaveForanea = "id_reclamos_varios";
            llamadas = "select descripcion as Descripcion, Convert(varchar(10),fecha_commit, 103)  as Fecha, hora_commit as Hora, usuario as Usuario from " + nombreTabla + "  where " + llaveForanea + " = " + id + " ";
        }

        else if (ddlTipoBitacora.SelectedValue == "3")
        {
            nombreTabla = "bitacora_autorizaciones";
            llaveForanea = "id_autorizaciones";
            llamadas = "select descripcion as Descripcion, estado as Estado, Convert(varchar(10),fecha_commit, 103)  as Fecha, hora_commit as Hora, usuario as Usuario from " + nombreTabla + "  where " + llaveForanea + " = " + id + " ";
        }

        else if (ddlTipoBitacora.SelectedValue == "4")
        {
            nombreTabla = "bitacora_reclamos_medicos";
            llaveForanea = "id_reclamos_medicos";
            llamadas = "select descripcion as Descripcion, Convert(varchar(10),fecha_commit, 103) as [Fecha Commit], hora_commit as [Hora Commit] from " +nombreTabla+" where " + llaveForanea + " = " +id+ "";
        }

        llenado.llenarGrid(llamadas, Gridllamadas);
    }


    private void cambiarEstado(int identificador)
    {
        try
        {
            if (DDLTipo.Text == "Cerrado")
            {
                id_estado = 2;
            }
            else
            {
                id_estado = 1;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE reclamo_auto SET id_estado = '" + id_estado + "' where id =  " + identificador + " ";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
            DDLTipo.Text = "Cerrado";
        }
        catch (Exception)
        {

        }
        finally
        {
            objeto.DescargarConexion();
        }
    }
}