using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_Caja_de_ahorro_ConsultarAsegurados : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String Consulta;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(buscador(txtBusqueda.Text), GridAsegurados);
    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT id, asegurado as Asegurado FROM vistaReclamosMedicos Where asegurado like '%" + arreglo[0] + "%' and poliza in ('GTVG-198018')";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and asegurado like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }

    protected void GridAsegurados_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridAsegurados.SelectedRow.Cells[1].Text);
        var dato = DBReclamos.vistaReclamosMedicos.Find(id);
        lblAseguradora.Text = dato.nombre;
        lblAsegurado.Text = dato.asegurado;
        lblCertificado.Text = dato.certificado;
        lblContratante.Text = dato.contratante;
        lblPoliza.Text = dato.poliza;
        lblEstado.Text = dato.estado_poliza;
        lblRamo.Text =  (dato.ramo == "123") ? "Colectivo Vida Y Gastos Médicos" : dato.ramo;
        lblClase.Text = dato.clase;
        lblTipo.Text = dato.tipo;
        lblVigi.Text = Convert.ToDateTime( dato.vigi).ToString("d");
        lblVigf.Text = Convert.ToDateTime(dato.vigf).ToString("d");
        lblMoneda.Text = dato.moneda;
        lblEjecutivo.Text = dato.gst_nombre;
    }
}