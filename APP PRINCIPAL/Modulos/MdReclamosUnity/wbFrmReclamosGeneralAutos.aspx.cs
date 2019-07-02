using System;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosGeneralAutos : System.Web.UI.Page
{
    Utils llenado = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
        string reclamosSeguimiento = "SELECT a.id, " +
             " a.poliza as Poliza," +
             " a.asegurado as Asegurado, " +
             " a.placa as Placa," +
             " a.marca as Marca," +
             " a.color as Color, " +
             " a.modelo as Modelo," +
             " a.propietario as Propietario, " +
             " Convert(varchar(10),r.fecha, 103) As [Fecha Siniestro]," +
             " r.fecha_commit as [Fecha Creacion]," +
             " r.estado_auto_unity as [Estado Auto]" +
             " FROM auto_reclamo as a" +
             " INNER JOIN reclamo_auto as r on r.id_auto_reclamo = a.id ";


        if (idRecibido == "1")
        {
            reclamosSeguimiento += " where r.estado_auto_unity = 'Pendiente Asegurado' and r.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "2")
        {
            reclamosSeguimiento += " where r.estado_auto_unity = 'Proceso Legal' and r.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "3")
        {
            reclamosSeguimiento += " where r.estado_auto_unity = 'Espera afectado' and r.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "4")
        {
            reclamosSeguimiento += " where r.estado_auto_unity = 'Reparacion' and r.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "5")
        {
            reclamosSeguimiento += " where r.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id1;
        id1 = Convert.ToInt32(GridGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id1);
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridGeneral, Response, "Reclamos Autos en seguimiento");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}