using System;
using System.Web;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();
    String consulta;
    int codigo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          codigo = Utils.CODIGO_GESTOR(userlogin);
        }

        PolizasRoble();
    }

    protected void GridElRoble_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridAllPolizas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void PolizasRoble()
    {
        llenar.llenarGridRenovaciones(
            "Select id as ID," +
            "poliza as Poliza," +
            "asegurado as Asegurado," +
            "marca as Marca," +
            "modelo as Modelo," +
            "placa as Placa," +
            "vigf as [Vigencia Final]," +
            "correo_cliente as [Correo Cliente]" +
            "from renovaciones_polizas where codigo_gestor = "+codigo+" and estado = 2 ", GridElRoble);
    }
}