using System;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosDañosGeneral : System.Web.UI.Page
{
    Utils llenado = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();

        String selectGeneral = "SELECT " +
          "dbo.reclamos_varios.id as ID," +
          "dbo.reg_reclamo_varios.poliza as Poliza," +
          "dbo.reg_reclamo_varios.asegurado as Asegurado," +
          "dbo.reg_reclamo_varios.cliente as Cliente," +
          "dbo.reg_reclamo_varios.aseguradora as Aseguradora," + //4
          "dbo.reg_reclamo_varios.ramo as Ramo," +
          "dbo.reclamos_varios.fecha_commit as [Fecha Creacion]," +
          "dbo.reclamos_varios.estado_reclamo_unity as [Estado Reclamo] " + //31
          "FROM " +
          "dbo.reg_reclamo_varios " +
          "INNER JOIN dbo.reclamos_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id ";

        if (idRecibido == "1")
        {
            selectGeneral += " where reclamos_varios.estado_reclamo_unity = 'Pendiente asegurado' and reclamos_varios.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(selectGeneral, GridGeneral);
        }

        else if (idRecibido == "2")
        {
            selectGeneral += " where reclamos_varios.estado_reclamo_unity = 'Inactivo' and reclamos_varios.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(selectGeneral, GridGeneral);
        }

        else if (idRecibido == "3")
        {
            selectGeneral += " where reclamos_varios.estado_reclamo_unity = 'Ajuste' and reclamos_varios.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(selectGeneral, GridGeneral);
        }

        else if (idRecibido == "4")
        {
            selectGeneral += " where reclamos_varios.estado_reclamo_unity = 'Pendiente Finiquito' and reclamos_varios.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(selectGeneral, GridGeneral);
        }

        if (idRecibido == "6")
        {
            selectGeneral += " where (reclamos_varios.estado_unity = 'Seguimiento')";
            llenado.llenarGrid(selectGeneral, GridGeneral);
        }
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
        Utils.ExportarExcel(GridGeneral,Response,"Reporte daños en seguimiento");
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}