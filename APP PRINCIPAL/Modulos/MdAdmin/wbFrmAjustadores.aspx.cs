using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdAdmin_wbFrmAjustadores : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    conexionBD obj = new conexionBD();
    string mensaje2 = "ingrese los campos obligatorios obligatorios";
    string idCabina, idUsuario;
    SqlCommand cmd = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnguardar_Click(object sender, EventArgs e)
    {
        try
        {
            idCabina = (string)(Session["id_cabina"]);
            idUsuario = (string)(Session["id_usuario"]);
            int id1 = Convert.ToInt32(idCabina);
            int id2 = Convert.ToInt32(idUsuario);
            if (txtNombre.Text == "")
            {
                Response.Write("<Script>alert('" + mensaje2 + "')</script>");
            }
            else
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into ajustadores(nombre, aseguradora,telefono, correo, estado, id_usuario, id_cabina,tipo )" +
                "values('" + txtNombre.Text + "', '" + txtAseguradora.Text + "','" + txtTelefono.Text + "', '" + txtCorreo.Text + "', '" + DDLTipo.SelectedItem + "', " + id2 + ", " + id1 + ", '" + txtTipo.Text + "')";
                cmd.Connection = obj.ObtenerConexionReclamos();
                cmd.ExecuteNonQuery();
                obj.conexion.Close();
                GridAjustadores.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtTipo.Text = "";
                txtCorreo.Text = "";
                txtAseguradora.Text = "";
            }

        }

        catch (Exception)
        {
            Response.Write("<Script>alert('Error en insercion revise los campos que a digitado')</script>");
        }

        finally
        {
            obj.DescargarConexion();
        }
    }
}