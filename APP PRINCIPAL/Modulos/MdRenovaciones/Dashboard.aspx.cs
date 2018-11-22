using System;
using System.Web;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();
    int codigo;

    protected void Page_Load(object sender, EventArgs e)
    {
        codigo = Utils.CODIGO_GESTOR(userlogin);

        if (!IsPostBack)
        {
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
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(codigo,ddlEstado), GridElRoble);
    }

    protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(codigo,ddlEstado), GridElRoble);
    }
}