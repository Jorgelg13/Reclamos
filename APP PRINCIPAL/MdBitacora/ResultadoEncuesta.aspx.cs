using System;
using System.Web.UI;

public partial class MdBitacora_ResultadoEncuesta : System.Web.UI.Page
{
    String encuesta, Total,recepcion;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        encuesta = "select id, empresa as Empresa, servicio as Servicio, pregunta1 as [Pregunta 1], case " +
            "when pregunta1 between 1 and 6 then 'Detractor' " +
            "when pregunta1 between 7 and 8 then 'Neutro' " +
            "when pregunta1 between 9 and 10 then 'Promotor' " +
            "end as resultado1, " +
            "clasificacion1 as " +
            "[Clasificacion Pregunta 1], " +
            "comentario1 as [Comentario Pregunta 1], " +
            "pregunta2 as [Pregunta 2], " +
            "case " +
            "when pregunta2 between 1 and 6 then 'Detractor' " +
            "when pregunta2 between 7 and 8 then 'Neutro' " +
            "when pregunta2 between 9 and 10 then 'Promotor' " +
            "end as resultado2, " +
            "clasificacion1 as [Clasificacion pregunta 2], " +
            "comentario2 as [Comentario pregunta 2], " +
            "pregunta3 as  [Pregunta 3], " +
            "case " +
            "when pregunta3 between 1 and 6 then 'Detractor' " +
            "when pregunta3 between 7 and 8 then 'Neutro' " +
            "when pregunta3 between 9 and 10 then 'Promotor' " +
            "end as resultado3, " +
            "clasificacion3 as [Clasificacion Pregunta 3], " +
            "comentario3 as [Comentario pregunta 3], " +
            "comentario as [Comentarios Extras], " +
            "fecha as [Fecha Registro] " +
            "from encuesta " +
            "where Convert(date, fecha, 112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' " ;
        Total = "select COUNT(*) as Total, empresa as Empresa from encuesta  where Convert (date, fecha, 112) between " +
            "'" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' group by empresa order by Total desc";

        recepcion = "select id, " +
            "empresa as Lugar, " +
            "pregunta1 as [Pregunta 1]," +
            "case " +
            "when pregunta1 between 1 and 6 then 'Detractor' " +
            "when pregunta1 between 7 and 8 then 'Neutro' " +
            "when pregunta1 between 9 and 10 then 'Promotor' " +
            "end as [Resultado 1], " +
            "clasificacion1 as [Clasificacion 1], " +
            "comentario1 as [Comentario 1], " +
            "tipo_servicio as Operacion," +
            "pregunta2 as [Pregunta 2]," +
            "case " +
            "when pregunta2 between 1 and 6 then 'Detractor' " +
            "when pregunta2 between 7 and 8 then 'Neutro' " +
            "when pregunta2 between 9 and 10 then 'Promotor' " +
            "end as [Resultado 2], " +
            "clasificacion2 as [Clasificacion 2]," +
            "comentario2 as [Comentario2]," +
            "pregunta3 as [Pregunta 3]," +
            "case " +
            "when pregunta3 between 1 and 6 then 'Detractor' " +
            "when pregunta3 between 7 and 8 then 'Neutro' " +
            "when pregunta3 between 9 and 10 then 'Promotor' " +
            "end as [Resultado 3]," +
            "fecha as Fecha " +
            " from encuesta_recepcion where Convert(date,fecha,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";
    }

    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        if(PnPrincipal.Visible== true)
        {
            if (ddlEmpresa.SelectedValue != "Todas")
            {
                encuesta = "select *from encuesta where Convert (date, fecha, 112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' and empresa = '" + ddlEmpresa.SelectedValue + "' ";
            }

            llenar.llenarGrid(encuesta, GridEncuestas);
            llenar.llenarGrid(Total, GridAgrupados);
            lblTotalEncuestas.Text = "Total de encuestas: " + GridEncuestas.Rows.Count.ToString();
            lblAgrupados.Text = "Total Agrupados: " + GridAgrupados.Rows.Count.ToString();
            linkDescargar.Visible = true;
        }

        else
        {
            llenar.llenarGrid(recepcion, GridRecepcion);
            lnEncuestaRecepcion.Visible = true;
            lblTotalRecepcion.Text = "Total de encuestas en Recepcion "+ GridRecepcion.Rows.Count.ToString();
        }
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnPrincipal,Response,"Resultado Encuesta del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void ddlTipoEncuesta_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlTipoEncuesta.SelectedValue == "1")
        {
            PnPrincipal.Visible = true;
            PnRecepcion.Visible = false;
        }

        else
        {
            PnPrincipal.Visible = false;
            PnRecepcion.Visible = true;
        }
    }

    protected void lnEncuestaRecepcion_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnRecepcion, Response, "Resultado Encuesta del Recepcion " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }
}