using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmConsultaMovilMedicos : System.Web.UI.Page
{
    string poliza, id_consulta;
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        poliza = (string)(Session["poliza"]);


        if (!IsPostBack)
        {
            txtPoliza.Text = poliza;
        }
        else
        {
            //instruccion vacia para q no carge nuevamente el metodo load
        }
    }

    protected void GridConsultasMedicas_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_consulta = Convert.ToString(Request.QueryString[0]).ToString();
        txtRamo.Text = GridConsultasMedicas.SelectedRow.Cells[10].Text;
        txtSecren.Text = GridConsultasMedicas.SelectedRow.Cells[13].Text;

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update bitacora_consulta_movil set reviso_coberturas = '" + true + "' where id = '" + Convert.ToInt32(id_consulta) + "'";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
        }
        catch (Exception)
        {

        }
        finally
        {
            objeto.DescargarConexion();
        }
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultaMovilCliente.aspx");
    }
}