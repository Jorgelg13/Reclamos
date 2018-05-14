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
               "dbo.reg_reclamo_varios.vip as VIP," +
               "dbo.reg_reclamo_varios.moneda as Moneda," +
               "dbo.reclamos_varios.boleta as boleta," +
               "dbo.reclamos_varios.titular as Titular," +
               "dbo.reclamos_varios.reportante as Reportante," +
               "dbo.reclamos_varios.telefono as Telefono," +
               "dbo.reclamos_varios.ajustador as Ajustador," +
               "dbo.reclamos_varios.hora as Hora," +
               "dbo.reclamos_varios.fecha as Fecha," +
               "dbo.reclamos_varios.hora_cierre as [Hora Cierre]," +
               "dbo.reclamos_varios.fecha_cierre as [Fecha Cierre]," +
               "dbo.reclamos_varios.estado_reclamo_unity as [Estado Reclamo], " + //31
               "dbo.reclamos_varios.num_reclamo " +
               "FROM " +
               "dbo.reg_reclamo_varios " +
               "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
               "INNER JOIN gestores on reclamos_varios.id_gestor = gestores.id " +
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
        Response.Redirect("/MdBitacora/wbFrmConsultaSeguimientoDaños.aspx?ID_reclamo=" + id);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    protected void btnReportes_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/wbFrmReportesDaños.aspx");
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/DashboardUnity.aspx");
    }
}