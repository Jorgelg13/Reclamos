using System;
using System.Data.SqlClient;
using System.Configuration;


public class conexionBD
{
    public SqlConnection conexion = new SqlConnection();

    public SqlConnection ObtenerConexionReclamos()
    {
        ConnectionStringSettings cadena1 = ConfigurationManager.ConnectionStrings["reclamosConnectionString"];
        conexion.ConnectionString = cadena1.ConnectionString;
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public SqlConnection ObtenerConexionSeg_Reclamos()
    {

        ConnectionStringSettings cadena2 = ConfigurationManager.ConnectionStrings["SEG_RECLAMOSConnectionString"];
        conexion.ConnectionString = cadena2.ConnectionString;
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public SqlConnection ObtenerConexionSeguro()
    {

        ConnectionStringSettings cadena2 = ConfigurationManager.ConnectionStrings["seguroConnectionString"];
        conexion.ConnectionString = cadena2.ConnectionString;
        try
        {
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool DescargarConexion()
    {
        conexion.Close();
        conexion.Dispose();
        return true;
    }

    public void procedimiento()
    {

    }
}