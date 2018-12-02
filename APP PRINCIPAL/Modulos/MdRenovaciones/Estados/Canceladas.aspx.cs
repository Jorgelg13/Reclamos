using System;

public partial class Modulos_MdRenovaciones_Estados_Canceladas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 5), GridCanceladas);
        }
    }

    protected void GridCanceladas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}