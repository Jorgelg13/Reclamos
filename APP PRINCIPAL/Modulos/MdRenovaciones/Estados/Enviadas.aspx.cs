using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Enviadas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
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
            llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 3, txtFechaInicio.Text,
                 txtFechaFin.Text), GridEnviadas);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridEnviadas, Response, "Enviadas");
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 3, txtFechaInicio.Text,
               txtFechaFin.Text), GridEnviadas);
    }

    protected void chkCancelar_CheckedChanged(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#comentario').modal('show');", addScriptTags: true);
    }

    protected void chkRenovar_CheckedChanged(object sender, EventArgs e)
    { 
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#comentario').modal('show');", addScriptTags: true);
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridEnviadas.Rows)
        {
            CheckBox chkRenovar = (CheckBox)row.FindControl("chkRenovar");
            CheckBox chkCancelar = (CheckBox)row.FindControl("chkCancelar");
            int id = Convert.ToInt32(Convert.ToString(row.Cells[1].Text));

            if (chkRenovar.Checked)
            {
                try
                {
                    var poliza = DB.renovaciones_polizas.Find(id);
                    String Poliza = (poliza.ramo + poliza.poliza + poliza.endoso_renov + ".pdf");
                    poliza.estado = 4;
                    poliza.comentario_renovacion = txtComentario.Text;
                    DB.SaveChanges();
                    Utils.CopiarArchivos(Poliza, "Renovadas","Enviadas");
                    Utils.ShowMessage(this.Page, "Polizas renovadas exitosamente", "Excelente", "success");
                    txtComentario.Text = "";
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
                }
            }

            if (chkCancelar.Checked)
            {
                try
                {
                    var poliza = DB.renovaciones_polizas.Find(id);
                    String Poliza = (poliza.ramo + poliza.poliza + poliza.endoso_renov + ".pdf");
                    poliza.estado = 5;
                    poliza.comentario_invalida = txtComentario.Text;
                    DB.SaveChanges();
                    Utils.MoverArchivos(Poliza, "Canceladas", "Enviadas");
                    Utils.ShowMessage(this.Page, "Polizas renovadas exitosamente", "Excelente", "success");
                    txtComentario.Text = "";
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
                }
            }
        }

        llenarGrid();
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdRenovaciones/Estados/Enviadas.aspx");
    }
}