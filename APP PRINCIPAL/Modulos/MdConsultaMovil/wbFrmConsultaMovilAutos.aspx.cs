using System;
using System.Data;
using System.Data.SqlClient;
public partial class Modulos_MdReclamos_wbFrmConsultaMovilAutos : System.Web.UI.Page
{

    string poliza, chasis, id_consulta;
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        poliza = (string)(Session["poliza"]);
        if (!IsPostBack)
        {
            TextBox2.Text = poliza;
        }
        else
        {
            //instruccion vacia para q no carge nuevamente el metodo load
        }
    }

    protected void GridConsultaAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        id_consulta = Convert.ToString(Request.QueryString[0]).ToString();
        txtChasis.Text = GridConsultaAuto.SelectedRow.Cells[8].Text;
        chasis = GridConsultaAuto.SelectedRow.Cells[8].Text;
        datosAutos();

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update bitacora_consulta_movil set reviso_coberturas = '"+ true +"' where id = '" + Convert.ToInt32(id_consulta) + "'";
            cmd.Connection = objeto.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            objeto.conexion.Close();
        }
        catch(Exception)
        {

        }
        finally
        {
            objeto.DescargarConexion();
        }
    }

    public void datosAutos()
    {
        try
        {
            string selectAuto = " select  placa, color, marca ,modelo, chasis, motor, propietario, gst_nombre, nombre, contratante, vip, asegurado from ViewBusquedaAuto where chasis = '"+ chasis +"'";
            SqlDataAdapter da = new SqlDataAdapter(selectAuto, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblPlaca.Text = "Placa:               " + dt.Rows[0][0].ToString();
            lblColor.Text = "Color:               " + dt.Rows[0][1].ToString();
            lblMarca.Text = "Marca:               " + dt.Rows[0][2].ToString();
            lblModelo.Text = "Modelo:             " + dt.Rows[0][3].ToString();
            lblChasis.Text = "Chasis:             " + dt.Rows[0][4].ToString();
            lblMotor.Text = "Motor:               " + dt.Rows[0][5].ToString();
            lblPropietario.Text = "Propietario:   " + dt.Rows[0][6].ToString();
            lblEjecutivo.Text = "Ejecutivo:       " + dt.Rows[0][7].ToString();
            lblAseguradora.Text = "Aseguradora:   " + dt.Rows[0][8].ToString();
        }
        catch (Exception)
        {
            Response.Write("<Script>alert('Error al traer los datos')</script>");
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