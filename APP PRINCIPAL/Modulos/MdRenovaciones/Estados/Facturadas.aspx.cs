using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Facturadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 7), GridFacturadas);
        }
    }

    protected void GridFacturadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}