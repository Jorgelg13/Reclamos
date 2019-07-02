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
               "dbo.reclamos_varios.id as ID," +
               "dbo.reg_reclamo_varios.poliza as Poliza," +
               "dbo.reg_reclamo_varios.asegurado as Asegurado," +
               "dbo.reg_reclamo_varios.cliente as Cliente," +
               "dbo.reg_reclamo_varios.contratante as Contratante," +
               "dbo.reg_reclamo_varios.ramo as Ramo," +
               "dbo.reclamos_varios.titular as Titular," +
               "dbo.reclamos_varios.fecha_commit as [Fecha Creacion] " +
               "FROM " +
               "dbo.reg_reclamo_varios " +
               "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
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