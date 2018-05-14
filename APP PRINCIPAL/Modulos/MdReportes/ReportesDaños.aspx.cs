using System;
using System.IO;
using System.Web.UI;

public partial class ReportesDaños : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Utils.ReporteCabina(txtFechaInicio, txtFechaFin, "pa_ReportesDaños", Gridvarios);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Reclamos Varios.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Gridvarios.AllowPaging = false;
            Gridvarios.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}