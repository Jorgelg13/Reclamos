using System;
using System.IO;
using System.Web.UI;

public partial class MdBitacora_ResultadoEncuesta : System.Web.UI.Page
{
    String encuesta, Total;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        encuesta = "select *from encuesta where Convert (date, fecha, 112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' " ;
        Total = "select COUNT(*) as Total,empresa from encuesta  where Convert (date, fecha, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' group by empresa order by Total desc";
    }

    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        if(ddlEmpresa.SelectedValue != "Todas")
        {
            encuesta = "select *from encuesta where Convert (date, fecha, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' and empresa = '"+ddlEmpresa.SelectedValue+"' ";
        }

        llenar.llenarGrid(encuesta, GridEncuestas);
        llenar.llenarGrid(Total, GridAgrupados);
        lblTotalEncuestas.Text = "Total de encuestas: "+ GridEncuestas.Rows.Count.ToString();
        lblAgrupados.Text = "Total Agrupados: " + GridAgrupados.Rows.Count.ToString();
        linkDescargar.Visible = true;
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Resultados Encuestas.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridEncuestas.AllowPaging = false;
            GridEncuestas.RenderControl(hw);
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