using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmBusquedaReclamosMedicos : System.Web.UI.Page
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
           "dbo.reclamos_medicos.id as ID," + //1
           "dbo.reclamos_medicos.asegurado as Asegurado," +
           "dbo.reclamos_medicos.telefono as Telefono," +
           "dbo.reclamos_medicos.correo as Correo," +
           "dbo.reclamos_medicos.empresa as Empresa," +
           "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
           "dbo.reg_reclamos_medicos.poliza as Poliza,"+
           "dbo.reg_reclamos_medicos.ramo as Ramo," +
           "dbo.reg_reclamos_medicos.tipo as Tipo," +
           "dbo.reg_reclamos_medicos.clase as Clase," +
           "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
           "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
           "dbo.reg_reclamos_medicos.vip as VIP," +
           "dbo.reg_reclamos_medicos.moneda as Moneda," +
           "dbo.reg_reclamos_medicos.id," + //16
           "dbo.cabina.nombre as Cabina," +
           "dbo.sucursal.nombre as Sucursal," +
           "dbo.empresa.nombre as Empresa," +
           "dbo.pais.nombre as Pais " +
           "FROM " +
           " dbo.reg_reclamos_medicos " +
           "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
           "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id " +
           "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
           "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
           "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
           "where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' ";

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

        catch (Exception)
        {
            Response.Write("<Script>setTimeout(function () { toastr.error('No se pudo encontrar ese registro..', 'Error!');  }, 200);</script>");
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
        Response.Redirect("/MdBitacora/wbFrmConsultaSeguimientoRmedicos.aspx?ID_reclamo=" + id);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    protected void btnReportes_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/wbFrmReportesMedicos.aspx");
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/DashboardUnity.aspx");
    }
}