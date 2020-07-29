using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_autorizaciones : System.Web.UI.Page
{
    Utils Cargar = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFinal.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Cargar.llenarGrid(buscador(txtBuscar.Text), GridAutorizaciones);
    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
           sql = "SELECT a.id as ID, " +
          "r.poliza as Poliza," +
          "a.reportante as Reportante," +
          "a.tipo_consulta as [Tipo Consulta]," +
          "a.tipo_estado as [Estado], " +
          "a.correo as Correo," +
          "a.telefono as Telefono," +
          "a.fecha_completa_commit as [Fecha]," +
          "a.fecha_completa_cierre as [Fecha Cierre] " +
          " FROM autorizaciones as a " +
          "inner join reg_reclamos_medicos as r on a.id_reg_reclamos_medicos = r.id " +
          "where a.reportante like '%" + arreglo[0] + "%' and convert(date, a.fecha_commit,112) " +
          "between '" + txtFechaInicio.Text + "' and '" + txtFechaFinal.Text + "'";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and a.reportante like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }

    protected void GridAutorizaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}