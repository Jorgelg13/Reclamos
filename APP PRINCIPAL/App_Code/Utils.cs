using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Net.Http;


public class Utils
{
    conexionBD conexion = new conexionBD();
    public static ReclamosEntities DBReclamos = new ReclamosEntities();

    public Utils()
    {
      
    }

    public string buscador(String search, String table,  String[] columSearch = null, String[] columView = null, string sWhere = null, String[] tJoin = null)
    {
        string[] arreglo = search.Split(" ".ToCharArray());
        string sql = "";
        string colSearch = "";
        string join = "";
        string colView = "*";

        if (arreglo.Length > 0)
        {
            if (columSearch.Length > 1)
            {
                colSearch = " CONCAT(" + String.Join(",", columSearch) + ") ";
            }
            else
            {
                colSearch = columSearch[0];
            }
            if(columView != null)
            {
               colView = String.Join(", ", columView);
            }

            sql = "SELECT " + colView + " FROM " + table + " WHERE " + colSearch + " LIKE '%" + arreglo[0] + "%' ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and  " + colSearch + " like '%" + arreglo[i] + "%' ";
                    }
                }
            }

            if(sWhere != null)
            {
                sql += sWhere;
            }
        }
       
        return sql;
    }

    public void llenarGrid(String Consulta, GridView tabla)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(Consulta, this.conexion.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            tabla.DataSource = dt;
            tabla.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            this.conexion.DescargarConexion();
        }
    }

    public static void ReporteCabina(TextBox fechainicio, TextBox fechafin, String reporte, GridView gridRepore)
    {
        try
        {
            conexionBD obj = new conexionBD();
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand(reporte, obj.ObtenerConexionReclamos());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaInicio", fechainicio.Text);
            comando.Parameters.AddWithValue("@fechaFin", fechafin.Text);
            comando.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            sda.Fill(dt);
            gridRepore.DataSource = dt;
            gridRepore.DataBind();
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void llenarGrid2(String Consulta, GridView tabla)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(Consulta, this.conexion.ObtenerConexionSeguro());
            DataTable dt = new DataTable();
            da.Fill(dt);
            tabla.DataSource = dt;
            tabla.DataBind();
            this.conexion.DescargarConexion();
        }
        catch (Exception)
        {
            //throw ex;
        }
        finally
        {
            this.conexion.DescargarConexion();
        }
    }

    public bool verificarUsuario(String usuario)
    {
        bool existe = false;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sdr;
        cmd.Connection = conexion.ObtenerConexionReclamos();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select nombre from usuario where nombre = '" + usuario + "' ";
        try
        {
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                existe = true;
            }

            else
            {
                existe = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conexion.DescargarConexion();
        }

        return existe;
    }

    public DataTable autocompletar(string query, int id)
    {
        try
        {
            query += query + " where id = " + id + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, this.conexion.ObtenerConexionReclamos());
            DataTable datosDevueltos = new DataTable();
            da.Fill(datosDevueltos);
            return datosDevueltos;
        }
        catch (Exception ex)
        {
           throw ex;
        }
        finally
        {
            this.conexion.DescargarConexion();
        }
    }

    public bool actualizarDatos(String actualizar, int identificador)
    {
        bool exito = true;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = actualizar + " where id =  " + identificador + " ";
            cmd.Connection = this.conexion.ObtenerConexionReclamos();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            exito = false;
        }
        finally
        {
            this.conexion.DescargarConexion();
        }

        return exito;
    }

    public static void ShowMessage(Page page, string message, string title, string type = "info")
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
              String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
    }

    public static void SMS_gastos_medicos(String telefono, String mensaje, String usuario, String estado, long id,string tipo)
    {
        int numero = Convert.ToInt32(telefono);

        if (numero > 30000000)
        {
            if (tipo == "I" && telefono != "")
            {
                HttpClient client = new HttpClient();
                var values = new System.Collections.Generic.Dictionary<string, string>
             {
               { "token", "Un!ty2018" },
               { "numero", telefono },
               { "mensaje", mensaje}
             };

                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync("http://192.168.81.225:9900/movistar/enviar", content);
                bool estado_envio = response.IsFaulted;

                comentarios_reclamos_medicos comentario = new comentarios_reclamos_medicos();
                comentario.descripcion = "Notificacion SMS: " + mensaje;
                comentario.fecha = DateTime.Now;
                comentario.usuario = usuario;
                comentario.estado = estado;
                comentario.id_reclamo_medico = id;
                DBReclamos.comentarios_reclamos_medicos.Add(comentario);
                DBReclamos.SaveChanges();
            }
        }
    }

    public static void SMS_reclamos_danios(String telefono, String mensaje, String usuario, int id)
    {
        int numero = Convert.ToInt32(telefono);

        if (numero > 30000000)
        {
            if (telefono != "")
            {
                HttpClient client = new HttpClient();
                var values = new System.Collections.Generic.Dictionary<string, string>
             {
               { "token", "Un!ty2018" },
               { "numero", telefono },
               { "mensaje", mensaje}
             };

                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync("http://192.168.81.225:9900/movistar/enviar", content);
                bool estado_envio = response.IsFaulted;

                comentarios_reclamos_varios comentario = new comentarios_reclamos_varios();
                comentario.descripcion = "Notificacion SMS: " + mensaje;
                comentario.fecha = DateTime.Now;
                comentario.usuario = usuario;
                comentario.id_reclamos_varios = id;
                DBReclamos.comentarios_reclamos_varios.Add(comentario);
                DBReclamos.SaveChanges();
            }
        }
    }

    public static void SMS_reclamos_autos(String telefono, String mensaje, String usuario, int id)
    {
        int numero = Convert.ToInt32(telefono);

        if (numero > 30000000)
        {
            if (telefono != "")
            {
                HttpClient client = new HttpClient();
                var values = new System.Collections.Generic.Dictionary<string, string>
             {
               { "token", "Un!ty2018" },
               { "numero", telefono },
               { "mensaje", mensaje}
             };

                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync("http://192.168.81.225:9900/movistar/enviar", content);
                bool estado_envio = response.IsFaulted;

                comentarios_reclamos_autos comentario = new comentarios_reclamos_autos();
                comentario.descripcion = "Notificacion SMS: " + mensaje;
                comentario.fecha = DateTime.Now;
                comentario.usuario = usuario;
                comentario.id_reclamo_auto = id;
                DBReclamos.comentarios_reclamos_autos.Add(comentario);
                DBReclamos.SaveChanges();
            }
        }
    }
}