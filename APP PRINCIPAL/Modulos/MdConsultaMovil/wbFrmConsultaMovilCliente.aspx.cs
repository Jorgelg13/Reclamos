using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmConsultaMovilCliente : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    string poliza, codigoPoliza;
    Utils util = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBuscar.Text == "")
        {
            Response.Write("<Script>setTimeout(function () { toastr.success('Debe ingresar una poliza o un asegurado..', 'Revisar!');  }, 200);</script>");
        }
        else
        {
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into bitacora_consulta_movil (campo_busqueda, usuario) values('" + txtBuscar.Text + "', '" + userlogin + "')";
                cmd.Connection = obj.ObtenerConexionReclamos();
                cmd.ExecuteNonQuery();
                obj.conexion.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                obj.DescargarConexion();
            }

            string selecid = "SELECT IDENT_CURRENT('bitacora_consulta_movil')";
            SqlDataAdapter da = new SqlDataAdapter(selecid, obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblId.Text = dt.Rows[0][0].ToString();
            obj.conexion.Close();
            llenarGrid();

        }
    }

    protected void GridBusquedaCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtRamo.Text = GridBusquedaCliente.SelectedRow.Cells[15].Text;
        codigoPoliza = GridBusquedaCliente.SelectedRow.Cells[1].Text;
        lblPoliza.Text = GridBusquedaCliente.SelectedRow.Cells[1].Text;
        Session.Add("poliza", codigoPoliza);
        Response.Write("<Script>alert('Error al traer los datos ')</script>");

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update bitacora_consulta_movil  set poliza = '" + codigoPoliza + "' where id = " + Convert.ToInt32(lblId.Text) + " ";
            cmd.Connection = obj.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
            obj.conexion.Close();

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            obj.DescargarConexion();
        }

        //si la fila seleccionada es de ramo 2 se envia a esta vista
        if (txtRamo.Text == "2")
        {
            Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultaMovilAutos.aspx?id_consulta=" + lblId.Text);
        }

        //si la fila seleccionada es de ramo 7 se envia a esta vista
        else if (txtRamo.Text == "7")
        {
            Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultasMedicasIndividualMovil.aspx?id_consulta="+ lblId.Text);
        }
        //si la fila seleccionada es de ramo 123 o 9 e envia a esta vista
        else if (txtRamo.Text == "9" || txtRamo.Text == "123")
        {
            Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultaMovilMedicos.aspx?id_consulta=" + lblId.Text);
        }

        else if (txtRamo.Text != "7" || txtRamo.Text != "9" || txtRamo.Text != "2" || txtRamo.Text != "123")
        {
            Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultaMovilDaños.aspx?id_consulta="+ lblId.Text);
        }
    }


    public void llenarGrid()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(buscador(txtBuscar.Text.ToString()), obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridBusquedaCliente.DataSource = dt;
            GridBusquedaCliente.DataBind();
        }

        catch (Exception)
        {
           // Response.Write(ex);
        }

        finally
        {
            obj.DescargarConexion();
        }
    }

    //funcion para hacer una busqueda optima de los asegurados 
    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT poliza as Poliza, Asegurado, ramo as Ramo, aseguradora as Aseguradora,contratante as Contratante, gst_nombre as Gestor,sumaaseg as [Suma Asegurada], direccion as Direccion, cliente as Cliente, status as Estatus, vigi as [Vigencia Inicial], vigf as [Vigencia Final], tipo as Tipo, tipoPol, NumRamo  from vistaBusquedaPolizaMovil  Where " + DDLTipo.SelectedItem + " like '%" + arreglo[0] + "%' ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and " + DDLTipo.SelectedItem + " like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }
}