using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Renovadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();

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
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 4, txtFechaInicio.Text,
                  txtFechaFin.Text), GridRenovadas);
    }

    protected void btnGuardarCambios_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridRenovadas.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            int id = Convert.ToInt32(Convert.ToString(row.Cells[1].Text));
            if (checkAsig.Checked)
            {
                try
                {
                    var poliza = DB.renovaciones_polizas.Find(id);
                    poliza.estado = 7;
                    DB.SaveChanges();
                    Utils.ShowMessage(this.Page, "Polizas facturada exitosamente", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido facturar " + ex.Message, "Excelente", "success");
                }
            }
        }
        llenarGrid();
    }
}