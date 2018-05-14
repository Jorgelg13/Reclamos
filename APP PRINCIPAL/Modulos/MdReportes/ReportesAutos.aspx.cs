using System;
using System.IO;
using System.Web.UI;

public partial class ReportesAutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Utils.ReporteCabina(txtFechaInicio, txtFechaFin, "pa_ReportesAutos", GridAutos);
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Default.aspx");
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Reporte de autos.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridAutos.AllowPaging = false;
            GridAutos.RenderControl(hw);
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