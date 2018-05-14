using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosDañosGeneral : System.Web.UI.Page
{
    Utils llenado = new Utils();
    protected void Page_Load(object sender, EventArgs e)
    {
       String selectGeneral = "SELECT " +
         "dbo.reclamos_varios.id as ID," +
         "dbo.reg_reclamo_varios.poliza as Poliza," +
         "dbo.reg_reclamo_varios.asegurado as Asegurado," +
         "dbo.reg_reclamo_varios.cliente as Cliente," +
         "dbo.reg_reclamo_varios.aseguradora as Aseguradora," + //4
         "dbo.reg_reclamo_varios.contratante as Contratante," +
         "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +//6
         "dbo.reg_reclamo_varios.ramo as Ramo," +
         "dbo.reg_reclamo_varios.status as Estatus," +//8
         "dbo.reg_reclamo_varios.tipo as Tipo," +
         "dbo.reg_reclamo_varios.direccion as Direccion," +//10
         "dbo.reg_reclamo_varios.vip as VIP," +
         "dbo.reg_reclamo_varios.suma_asegurada as [Suma Asegurada]," +//12
         "dbo.reg_reclamo_varios.moneda as Moneda," +
         "dbo.reclamos_varios.boleta as boleta," +
         "dbo.reclamos_varios.titular as Titular," +
         "dbo.reclamos_varios.reportante as Reportante," +
         "dbo.reclamos_varios.telefono as Telefono," +
         "dbo.reclamos_varios.ajustador as Ajustador," +
         "dbo.reclamos_varios.ubicacion as Ubicacion," +
         "dbo.reclamos_varios.hora as Hora," +
         "dbo.reclamos_varios.fecha as Fecha," +
         "dbo.reclamos_varios.hora_commit as [Hora Creacion]," +
         "dbo.reclamos_varios.fecha_commit as [Fecha Creacion]," +
         "dbo.reclamos_varios.id_gestor as Gestor, " + //27
         "dbo.reclamos_varios.id_taller as Taller, " +
         "dbo.reclamos_varios.id_analista as Analista, " +
         "dbo.reclamos_varios.estado_reclamo_unity as [Estado Reclamo], " + //31
         "dbo.reclamos_varios.num_reclamo, " +
         "gestores.nombre," +//37
         "gestores.telefono, " +//38
         "gestores.correo " +//39
         "FROM " +
         "dbo.reg_reclamo_varios " +
         "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
         "INNER JOIN gestores on reclamos_varios.id_gestor = gestores.id " +
         "INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
         "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
         "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
         "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
         "INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id "+
         " where (reclamos_varios.estado_unity = 'Seguimiento' ) ";

        //funciones que llenan los grid con los registros
        llenado.llenarGrid(selectGeneral, GridGeneral);
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id1;
        id1 = Convert.ToInt32(GridGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id1);
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Reporte_daños_seguimiento.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridGeneral.AllowPaging = false;
            GridGeneral.RenderControl(hw);
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