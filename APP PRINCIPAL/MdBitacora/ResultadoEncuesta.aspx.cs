using System;
using System.Web.UI;

public partial class MdBitacora_ResultadoEncuesta : System.Web.UI.Page
{
    String encuesta, Total,recepcion,egresos_hospitalarios, cabina;
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

        egresos_hospitalarios = "select * from [encuesta-egresos] where convert(date,fecha,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' " ;

        cabina = "select c.codigo, c.nombre, c.telefono, c.correo, e.id, e.empresa, e.pregunta1, e.comentario1, e.pregunta2, e.comentario2, e.pregunta3," +
            "e.comentario3, e.comentario, e.fecha from encuesta as e " +
            "inner join cabina_virtual as c on c.codigo = e.codigo " +
            "where empresa = 'Cabina' and convert(date,e.fecha,112) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"' ";
    }

    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        if(ddlTipoEncuesta.SelectedValue == "1")
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


        if (ddlTipoEncuesta.SelectedValue == "2")
        {
            llenar.llenarGrid(recepcion, GridRecepcion);
            lnEncuestaRecepcion.Visible = true;
            lblTotalRecepcion.Text = "Total de encuestas en Recepcion " + GridRecepcion.Rows.Count.ToString();
        }

        else if (ddlTipoEncuesta.SelectedValue == "3")
        {
            llenar.llenarGrid(egresos_hospitalarios, GridEgresosHospitalarios);
            lnEgresosHispilarios.Visible = true;
            lbltotalegresos.Text = "Total de encuestas de egresos Hospitalarios " + GridEgresosHospitalarios.Rows.Count.ToString();
        }

        else if (ddlTipoEncuesta.SelectedValue == "4")
        {
            llenar.llenarGrid(cabina, GridCabina);
            lnCabina.Visible = true;
            lblTotalCabina.Text = "Total de encuestas de cabina virtual " + GridCabina.Rows.Count.ToString();
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
            PnCabina.Visible = false;
            PnEgresosHospitalarios.Visible = false;
        }

        else if(ddlTipoEncuesta.SelectedValue == "2")
        {
            PnPrincipal.Visible = false;
            PnEgresosHospitalarios.Visible = false;
            PnCabina.Visible = false;
            PnRecepcion.Visible = true;
        }

        else if (ddlTipoEncuesta.SelectedValue == "3")
        {
            PnPrincipal.Visible = false;
            PnRecepcion.Visible = false;
            PnCabina.Visible = false;
            PnEgresosHospitalarios.Visible = true;
        }

        else if (ddlTipoEncuesta.SelectedValue == "4")
        {
            PnPrincipal.Visible = false;
            PnRecepcion.Visible = false;
            PnCabina.Visible = false;
            PnCabina.Visible = true;
        }
    }

    protected void lnEncuestaRecepcion_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnRecepcion, Response, "Resultado Encuesta del Recepcion " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    protected void lnEgresosHispilarios_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnEgresosHospitalarios, Response, "Resultado Encuesta Hospitalarias del " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }

    protected void lnCabina_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnCabina, Response, "Resultado Encuesta del Cabina " + txtFechaInicio.Text + " al " + txtFechaFin.Text);
    }
}