using System;
using System.Data.SqlClient;

public partial class Consultas_Caja_de_ahorro_ConsultarAutos : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String Consulta;

    protected void Page_Load(object sender, EventArgs e)
    {
        Consulta = "select " +
            "id," +
            "propietario as Propietario," +
            "placa as Placa, " +
            "marca as Marca, " +
            "modelo as Modelo, " +
            "Color as Color, " +
            "chasis as Chasis " +
            "from ViewBusquedaAuto where " +
            "(placa like '%"+txtBusqueda.Text+ "%') " +
            "or (propietario like '%" + txtBusqueda.Text + "%' or inciso like '%" + txtBusqueda.Text + "%') " +
          //  "or (inciso like '%" + txtBusqueda.Text + "%') " +
            " and poliza in ('AUTO-366487','AUTO-366488')";
    }

    protected void GridAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBusqueda.Text = GridAutos.SelectedRow.Cells[7].Text;
        int id = Convert.ToInt32(GridAutos.SelectedRow.Cells[1].Text);
        var dato = DBReclamos.ViewBusquedaAuto.Find(id);
        lblAseguradora.Text = dato.nombre;
        lblAsegurado.Text = dato.asegurado;
        lblPropietario.Text = dato.propietario;
        lblPoliza.Text = dato.poliza;
        lblValorAuto.Text = "Q " + Convert.ToDouble(dato.valorauto).ToString("N0");
        lblprima.Text = "Q " + Convert.ToDouble(dato.prima).ToString("N0");
        lblEstado.Text = dato.estado;
        lblVigi.Text = Convert.ToDateTime(dato.vigi).ToString("d");
        lblVigf.Text = Convert.ToDateTime(dato.vigf).ToString("d");
        lblplaca.Text = dato.placa;
        lblmarca.Text = dato.marca;
        lblmodelo.Text = dato.modelo;
        lblcolor.Text = dato.color;
       // lblSumaAsegurada.Text = dato.suma_aseg.ToString();
        lblMoneda.Text = dato.moneda;
        lblEjecutivo.Text = dato.gst_nombre;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(Consulta,GridAutos);
    }
}