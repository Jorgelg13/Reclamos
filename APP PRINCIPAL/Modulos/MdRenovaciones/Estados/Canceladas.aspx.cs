using System;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Modulos_MdRenovaciones_Estados_Canceladas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string usuarioLogin = HttpContext.Current.User.Identity.Name;
            var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

            if (user.rol == "F")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Estados/Renovadas.aspx");
            }
        }
        catch { }


        if (!IsPostBack)
        {
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 5, txtFechaInicio.Text,
                 txtFechaFin.Text), GridCanceladas);
        }
    }

    protected void GridCanceladas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridCanceladas, Response, "Canceladas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 5, txtFechaInicio.Text,
                txtFechaFin.Text), GridCanceladas);
    }
}