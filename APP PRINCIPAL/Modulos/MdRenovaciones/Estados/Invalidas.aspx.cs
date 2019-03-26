using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Invalidas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String Cargadas;

    protected void Page_Load(object sender, EventArgs e)
    {
        Cargadas = "Select " +
          "r.id as ID, " +
          "r.poliza as Poliza," +
          "r.ramo as Ramo," +
          "r.endoso_renov as Endoso," +
          "r.asegurado as Asegurado," +
          "r.marca as Marca," +
          "r.modelo as Modelo," +
          "r.placa as Placa," +
          "r.vigf as [Vigencia Final]," +
          "r.correo_cliente as [Correo Cliente]," +
          "  (select top 1 fecha from renovaciones_log where poliza = r.id) as [Fecha Registro]" +
          "from renovaciones_polizas r " +
          "where  r.estado = 8 ";

        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Cargadas, GridInvalidas);
        }
    }

    protected void GridInvalidas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int identificador = Convert.ToInt32(GridInvalidas.SelectedRow.Cells[3].Text);
        var registro = DB.renovaciones_polizas.Find(identificador);
        registro.estado = 2;
        DB.SaveChanges();

        Cargadas = "Select " +
          "r.id as ID, " +
          "r.poliza as Poliza," +
          "r.ramo as Ramo," +
          "r.endoso_renov as Endoso," +
          "r.asegurado as Asegurado," +
          "r.marca as Marca," +
          "r.modelo as Modelo," +
          "r.placa as Placa," +
          "r.vigf as [Vigencia Final]," +
          "r.correo_cliente as [Correo Cliente]," +
          "  (select top 1 fecha from renovaciones_log where poliza = r.id) as [Fecha Registro]" +
          "from renovaciones_polizas r " +
          "where  r.estado = 8 ";

        llenar.llenarGridRenovaciones(Cargadas, GridInvalidas);

    }
}