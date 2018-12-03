using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Renovadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 4, txtFechaInicio.Text,
                 txtFechaFin.Text), GridRenovadas);
        }
    }

    protected void GridRenovadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridRenovadas, Response, "Renovadas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 4, txtFechaInicio.Text,
                 txtFechaFin.Text), GridRenovadas);
    }
}