using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MdBitacora_CabinaUnity_Consultas : System.Web.UI.Page
{
    Utils llenarGrid = new Utils();
    String consulta, tipo;
    protected void Page_Load(object sender, EventArgs e)
    {
        tipo = Request.QueryString[0].ToString();

        if(tipo == "1")
        {
            consulta = "select r.id as ID, r.fecha_commit as Fecha, r.tipo_servicio as Tipo_Servicio, r.reportante as Reportante, r.telefono as Telefono, au.placa as Placa, " +
                "au.asegurado as Asegurado from reclamo_auto as r inner join auto_reclamo as au on r.id_auto_reclamo = au.id where id_estado = 1";
            llenarGrid.llenarGrid(consulta,GridReclamos);
        }


        if (tipo == "2")
        {
            consulta = "SELECT r.id as ID, r.reportante as Reportante, r.ubicacion as Ubicacion, r.telefono as Telefono, r.ajustador as Ajustador, r.fecha_commit as Fecha, reg.poliza as Poliza," +
                " reg.asegurado as Asegurado, reg.aseguradora as Aseguradora, reg.contratante as Contratante " +
                "FROM reclamos_varios as r INNER JOIN reg_reclamo_varios as reg ON r.id_reg_reclamos_varios = reg.id WHERE r.id_estado = 1 ";
            llenarGrid.llenarGrid(consulta, GridReclamos);
        }

    }

    protected void GridReclamos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        if (tipo == "1")
        {
            id = Convert.ToInt32(GridReclamos.SelectedRow.Cells[1].Text);
            Response.Redirect("/MdBitacora/CabinaUnity/autos.aspx?id=" + id + "");
        }

        else if(tipo=="2")
        {
            id = Convert.ToInt32(GridReclamos.SelectedRow.Cells[1].Text);
            Response.Redirect("/MdBitacora/CabinaUnity/danios.aspx?id=" + id + "");
        }
    }
}