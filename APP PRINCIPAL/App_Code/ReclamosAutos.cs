using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ReclamosAutos
/// </summary>
public class ReclamosAutos
{
    public ReclamosAutos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    public void obtenerUsuario()
    {
        string resultado;
        string userlogin = HttpContext.Current.User.Identity.Name;
        string cadenaConexion = "Data Source =DESKTOP-3T8Q1VK; Initial Catalog = SEG_RECLAMOS; Integrated Security = True";
        string selectUser = "SELECT UserId FROM Users where UserName = '" + userlogin + "' ";
        SqlDataAdapter da = new SqlDataAdapter(selectUser, cadenaConexion);
        DataTable dt = new DataTable();
        da.Fill(dt);
        int count = dt.Rows.Count;
        resultado = dt.Rows[0][0].ToString();
        //return resultado;

    }
}