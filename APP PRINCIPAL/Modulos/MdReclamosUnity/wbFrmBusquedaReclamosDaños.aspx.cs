using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Modulos_MdReclamosUnity_wbFrmBusquedaReclamosDaños : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
             sql = "SELECT " +
               "dbo.reclamos_varios.id as ID," +
               "dbo.reg_reclamo_varios.poliza as Poliza," +
               "dbo.reg_reclamo_varios.asegurado as Asegurado," +
               "dbo.reg_reclamo_varios.cliente as Cliente," +
               "dbo.reg_reclamo_varios.aseguradora as Aseguradora," + //4
               "dbo.reg_reclamo_varios.contratante as Contratante," +
               "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +//6
               "dbo.reg_reclamo_varios.ramo as Ramo," +
               "dbo.reg_reclamo_varios.status as Estatus," +//8
               "dbo.reg_reclamo_varios.tipo as Tipo," +
               "dbo.reg_reclamo_varios.direccion as Direccion," +//10
               "dbo.reg_reclamo_varios.vip as VIP," +
               "dbo.reg_reclamo_varios.suma_asegurada as [Suma Asegurada]," +//12
               "dbo.reg_reclamo_varios.moneda as Moneda," +
               "dbo.reclamos_varios.boleta as boleta," +
               "dbo.reclamos_varios.titular as Titular," +
               "dbo.reclamos_varios.reportante as Reportante," +
               "dbo.reclamos_varios.telefono as Telefono," +
               "dbo.reclamos_varios.ajustador as Ajustador," +
               //"dbo.reclamos_varios.version as Version," +
               "dbo.reclamos_varios.ubicacion as Ubicacion," +
               "dbo.reclamos_varios.hora as Hora," +
               "dbo.reclamos_varios.fecha as Fecha," +
               "dbo.reclamos_varios.hora_commit as [Hora Creacion]," +
               "dbo.reclamos_varios.fecha_commit as [Fecha Creacion] " +
               //"dbo.reclamos_varios.hora_cierre as [Hora Cierre]," +
               //"dbo.reclamos_varios.fecha_cierre as [Fecha Cierre]," +
               //"dbo.reclamos_varios.id_gestor as Gestor, " + //27
               //"dbo.reclamos_varios.id_taller as Taller, " +
               //"dbo.reclamos_varios.id_analista as Analista, " +
               //"dbo.reclamos_varios.observaciones as Observaciones," + //30
               //"dbo.reclamos_varios.estado_reclamo_unity as [Estado Reclamo], " + //31
               //"dbo.reclamos_varios.prioritario, " + //32
               //"dbo.reclamos_varios.complicado, " +//33
               //"dbo.reclamos_varios.compromiso_pago, " + //34
               //"dbo.reclamos_varios.num_reclamo, " +
               //"gestores.nombre," +//37
               //"gestores.telefono, " +//38
               //"gestores.correo, " +//39
               //"dbo.cabina.nombre as cabina," +
               //"dbo.sucursal.nombre as sucursal," +
               //"dbo.empresa.nombre as empresa," +
               //"dbo.pais.nombre as pais," +
               //"dbo.usuario.nombre as usuario, " +
               //"dbo.reclamos_varios.fecha_visualizar, " +
               //"CASE WHEN CONVERT(date, reclamos_varios.fecha_visualizar, 110) < CONVERT(date, GETDATE(), 110)  THEN 0 ELSE 1 END AS mostrar " +
               "FROM " +
               "dbo.reg_reclamo_varios " +
               "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
               //"INNER JOIN gestores on reclamos_varios.id_gestor = gestores.id " +
               //"INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
               //"INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
               //"INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
               //"INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
               //"INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id " +
               " where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and " + DDLTipo.SelectedValue + " like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }

    public void llenarGrid()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(buscador(txtBusqueda.Text.ToString()), objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridBusquedaGeneral.DataSource = dt;
            GridBusquedaGeneral.DataBind();
        }

        catch (Exception ex)
        {
             Response.Write(ex);
        }

        finally
        {
            objeto.DescargarConexion();
        }
    }

    protected void GridBusquedaGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        id = Convert.ToInt32(GridBusquedaGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }
}