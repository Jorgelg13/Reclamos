using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Reportes_email_enviados : System.Web.UI.Page
{
    string consulta;
    Utils llenar = new Utils();
    ReclamosEntities DB = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ddlUsuarios.Enabled = false;
            ddlUsuarios.DataSource = DB.ejecutivos.ToList();
            ddlUsuarios.DataTextField = "gestor";
            ddlUsuarios.DataValueField = "codigo";
            ddlUsuarios.DataBind();
        }
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        string grupo = (ddlArea.SelectedValue == "0") ? "" : " and grupo_economico = " + ddlArea.SelectedValue + " ";

        consulta = "select sec_mensaje as Secuencia, " +
                    "direcciones_email as Email, " +
                    "fechareg as [Fecha Registro]," +
                    "case when estado_envio = 1 then 'Enviado' else 'No enviado' end as Estado," +
                    "fecha_envio as [Fecha Envio], " +
                    "error_envio as [Detalle Error]," +
                    "remitente as Remitente," +
                    "subject as Asunto " +
                    "from seg_mensajes_enviar_por_email ";
                   

        if (checkUsuarios.Checked)
        {

            consulta += "where convert(date, fechareg,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' " +
                        "and subject like '%Renovación%' " +
                        "and direcciones_email like '%@%'" +
                        "and ejecutivo = " + ddlUsuarios.SelectedValue + " " +
                        grupo +
                        " order by sec_mensaje desc";
        }
        else
        {
            consulta += "where convert(date, fechareg,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' " +
                        "and subject like '%Renovación%' " +
                        "and direcciones_email like '%@%'" +
                        grupo +
                        " order by sec_mensaje desc";
        }

        llenar.llenarGrid2(consulta, GridReporte);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridReporte, Response, "Reporte de emails enviados");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void checkUsuarios_CheckedChanged(object sender, EventArgs e)
    {
        if (checkUsuarios.Checked)
        {
            ddlUsuarios.Enabled = true;
        }
        else
        {
            ddlUsuarios.Enabled = false;
        }
    }
}