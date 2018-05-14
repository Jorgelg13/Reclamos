using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdBitacora_wbFrmConsultaRautos : System.Web.UI.Page
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
        string tipo, filtro;
        tipo = "like";

        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            if (DDLTipo.SelectedItem.Text == "ID")
            {
                tipo = "=";
                filtro = arreglo[0];
            } 

            else
            {
                filtro = " '%"+ arreglo[0]+ "%' ";
            }

           
            sql = "SELECT reclamo_auto.id, " +
               " auto_reclamo.poliza as Poliza," +
               " auto_reclamo.asegurado as Asegurado, " +
               " auto_reclamo.placa as Placa," +
               " auto_reclamo.marca as Marca," +
               " auto_reclamo.color as Color, " +
               " auto_reclamo.modelo as Modelo," +
               " auto_reclamo.chasis as Chasis," +
               " auto_reclamo.motor as Motor, " +
               " auto_reclamo.propietario as Propietario, " +
               " auto_reclamo.ejecutivo as Ejecutivo," +
               " auto_reclamo.aseguradora as Aseguradora," +
               " auto_reclamo.contratante as Contratante, " +
               " auto_reclamo.estado_poliza as [Estado Poliza]," +
               " reclamo_auto.boleta as Boleta," +
               " reclamo_auto.titular  as Titular," +
               " reclamo_auto.hora as Hora," +
               " reclamo_auto.fecha as [Fecha Siniestro]," +
               //" reclamo_auto.fecha_commit as [Fecha Commit]," 21 +
               " reclamo_auto.ubicacion as Ubicacion," +
               " reclamo_auto.reportante as Reportante," +
               " reclamo_auto.piloto as Piloto," +
               " reclamo_auto.telefono as Telefono," +
               " reclamo_auto.ajustador as Ajustador," +
               " reclamo_auto.prioritario, " +
               " reclamo_auto.complicado as Complicado, " +
               " reclamo_auto.compromiso_pago as [Compromiso Pago], " +
               " reclamo_auto.alquiler_auto as [Alquiler Auto], " +
               " reclamo_auto.perdida_total as [Perdida Total], " +
               " reclamo_auto.estado_auto_unity as [Estado Auto]," +
               " gestores.nombre as [Gestor Reclamo], " +
               " reclamo_auto.num_reclamo, " +
                " talleres.nombre as Taller, " +
                " analistas.nombre as Analista, " +
                " cabina.nombre as Cabina," +
                " sucursal.nombre as Sucursal," +
                " empresa.nombre as Empresa," +
                " pais.nombre as Pais," +
                " usuario.nombre as [Usuario Cabina]" +
                " FROM auto_reclamo " +
                " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
                " INNER JOIN gestores on reclamo_auto.id_gestor = gestores.id" +
                " INNER JOIN talleres on reclamo_auto.id_taller = talleres.id" +
                " INNER JOIN analistas on reclamo_auto.id_analista = analistas.id" +
                " INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
                " INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
                " INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
                " INNER JOIN pais ON empresa.id_pais = pais.id " +
                " INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id " +
                " where " + DDLTipo.SelectedValue + " "+ tipo+ " " + filtro + " ";

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
        Response.Redirect("/MdBitacora/wbFrmConsultaSeguimientoAutos.aspx?ID_reclamo=" + id);
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/wbFrmReportesAutos.aspx");
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("/MdBitacora/DashboardUnity.aspx");
    }
}