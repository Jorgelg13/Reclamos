using System;
using System.Web.UI;

public partial class MdBitacora_ResultadoEncuesta : System.Web.UI.Page
{
    String encuesta, Total;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        encuesta = "select id, empresa as Empresa, servicio as Servicio, pregunta1 as [Pregunta 1], clasificacion1 as [Clasificacion Pregunta 1], comentario1 as [Comentario Pregunta 1]," +
            "pregunta2 as [Pregunta 2], clasificacion1 as [Clasificacion pregunta 2], comentario2 as [Comentario pregunta 2], pregunta3 as  [Pregunta 3], clasificacion3 as [Clasificacion Pregunta 3]," +
            "comentario3 as [Comentario pregunta 3], comentario as [Comentarios Extras], fecha as [Fecha Registro] from encuesta where Convert (date, fecha, 112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' " ;
        Total = "select COUNT(*) as Total, empresa as Empresa from encuesta  where Convert (date, fecha, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' group by empresa order by Total desc";
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
        Utils.ExportarExcel(PnPrincipal,Response,"Resultado Encuesta del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}