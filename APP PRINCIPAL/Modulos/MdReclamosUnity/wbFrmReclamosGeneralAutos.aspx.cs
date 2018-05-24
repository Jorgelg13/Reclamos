using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosGeneralAutos : System.Web.UI.Page
{
    Utils llenado = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
        string reclamosSeguimiento = "SELECT reclamo_auto.id, " +
             " reclamo_auto.estado_unity as [Estado Unity]," +
             " reclamo_auto.usuario_unity as [Usuario Unity]," +
             " auto_reclamo.poliza as Poliza," +
             " auto_reclamo.asegurado as Asegurado, " +
             " auto_reclamo.placa as Placa," +
             " auto_reclamo.marca as Marca," +
             " auto_reclamo.color as Color, " +
             " auto_reclamo.modelo as Modelo," +
             " auto_reclamo.chasis as Chasis," +
             " auto_reclamo.motor as Motor, " +
             " auto_reclamo.propietario as Propietario, " +
             " auto_reclamo.ejecutivo as Ejecutivo," +
             " auto_reclamo.aseguradora as Aseguradora," +
             " auto_reclamo.contratante as Contratante, " +
             " auto_reclamo.estado_poliza as [Estado Poliza]," +
             " reclamo_auto.boleta as Boleta," +
             " reclamo_auto.titular  as Titular," +
             " Convert(varchar(10),reclamo_auto.fecha, 103) As [Fecha Siniestro]," +
             " reclamo_auto.fecha_commit as [Fecha Creacion]," +
             " reclamo_auto.ubicacion as Ubicacion," +
             " reclamo_auto.reportante as Reportante," +
             " reclamo_auto.piloto as Piloto," +
             " reclamo_auto.telefono as Telefono," +
             " reclamo_auto.ajustador as Ajustador," +
             " reclamo_auto.estado_auto_unity as [Estado Auto]," +
             " gestores.nombre as [Gestor Reclamo], " +
             " talleres.nombre as Taller, " +
             " analistas.nombre as Analista" +
             " FROM auto_reclamo " +
             " INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
             " INNER JOIN gestores on reclamo_auto.id_gestor = gestores.id" +
             " INNER JOIN talleres on reclamo_auto.id_taller = talleres.id" +
             " INNER JOIN analistas on reclamo_auto.id_analista = analistas.id";
             //" INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
             //" INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
             //" INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
             // " INNER JOIN pais ON empresa.id_pais = pais.id " +
             //" INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id ";


        if (idRecibido == "1")
        {
            reclamosSeguimiento += " where reclamo_auto.estado_auto_unity = 'Pendiente Asegurado'  and  reclamo_auto.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "2")
        {
            reclamosSeguimiento += " where reclamo_auto.estado_auto_unity = 'Proceso Legal'  and  reclamo_auto.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "3")
        {
            reclamosSeguimiento += " where reclamo_auto.estado_auto_unity = 'Espera afectado'  and  reclamo_auto.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "4")
        {
            reclamosSeguimiento += " where reclamo_auto.estado_auto_unity = 'Reparacion'  and  reclamo_auto.estado_unity = 'Seguimiento' ";
            llenado.llenarGrid(reclamosSeguimiento, GridGeneral);
        }

        else if (idRecibido == "5")
        {
            reclamosSeguimiento += " where reclamo_auto.estado_unity = 'Seguimiento' ";
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