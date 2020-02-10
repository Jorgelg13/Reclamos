using System;
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
               "r.id as ID," +
               "reg.poliza as Poliza," +
               "reg.asegurado as Asegurado," +
               "reg.cliente as Cliente," +
               "reg.contratante as Contratante," +
               "reg.ramo as Ramo," +
               "r.titular as Titular," +
               "r.fecha_commit as [Fecha Creacion] " +
               "FROM " +
               "reg_reclamo_varios as reg " +
               "INNER JOIN reclamos_varios as r ON r.id_reg_reclamos_varios = reg.id " +
               " where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' and r.estado_unity = '"+ddlEstado.SelectedValue+"'";

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