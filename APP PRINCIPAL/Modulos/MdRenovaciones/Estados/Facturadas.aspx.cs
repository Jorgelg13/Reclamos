using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Facturadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string usuarioLogin = HttpContext.Current.User.Identity.Name;
            var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

            if (user.rol == "E" || user.rol == "S")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Dashboard.aspx");
            }
        }
        catch { }

        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 7, txtFechaInicio.Text,
                 txtFechaFin.Text), GridFacturadas);
        }
    }

    protected void GridFacturadas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridFacturadas, Response, "Facturadas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 7, txtFechaInicio.Text,
                 txtFechaFin.Text), GridFacturadas);
    }
}