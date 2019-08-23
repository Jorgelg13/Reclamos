using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Renovadas : System.Web.UI.Page
{
    Utils llenar = new Utils();

    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();

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
            int id = Convert.ToInt32(Convert.ToString(row.Cells[2].Text));
            if (checkAsig.Checked)
            {
                try
                {
                    var poliza = DB.renovaciones_polizas.Find(id);
                    String Poliza = (poliza.ramo + poliza.poliza + poliza.endoso_renov + ".pdf");
                    poliza.estado = 7;
                    DB.SaveChanges();
                    Utils.MoverArchivos(Poliza, "Archivo", "Renovadas");
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

    protected void GridRenovadas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            TableCell cell = GridRenovadas.Rows[e.RowIndex].Cells[2];
            var poliza = DB.renovaciones_polizas.Find(Convert.ToInt32(cell.Text));
            llenar.llenarGridRenovaciones(Consultas.REQ_POLIZAS_RENOVADAS(poliza.poliza,poliza.endoso_renov, poliza.poliza_unity), gridRequerimientos);
            Utils.ExportarExcel(pnlRequerimientos, Response, poliza.poliza_unity);
        }
        catch
        {

        }
    }
}