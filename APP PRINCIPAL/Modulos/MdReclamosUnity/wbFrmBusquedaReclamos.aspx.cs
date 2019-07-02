using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmBusquedaReclamos : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridBusquedaGeneral_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridBusquedaGeneral.PageIndex = e.NewPageIndex;
        llenarGrid();
    }

    //funcion para hacer una busqueda optima de los asegurados 
    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT reclamo_auto.id, " +
               " auto_reclamo.poliza as Poliza," +
               " auto_reclamo.asegurado as Asegurado, " +
               " auto_reclamo.placa as Placa," +
               " auto_reclamo.marca as Marca," +
               " auto_reclamo.modelo as Modelo," +
               " auto_reclamo.propietario as Propietario " +
                " FROM auto_reclamo " +
                " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id ";

            if (ddlEstado.SelectedItem.Text == "Todos")
            {
                sql += " where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%'";
            }

            else if (ddlEstado.SelectedItem.Text == "Seguimiento" || ddlEstado.SelectedItem.Text == "Cerrado")
            {
                sql += " where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' and estado_unity = '"+ ddlEstado.SelectedItem +"'";
            }
                
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
            // Response.Write(ex);
        }

        finally
        {
            objeto.DescargarConexion();
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    protected void GridBusquedaGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        id = Convert.ToInt32(GridBusquedaGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id,false);
    }
}