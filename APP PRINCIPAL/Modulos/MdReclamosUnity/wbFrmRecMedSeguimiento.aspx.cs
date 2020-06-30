using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmRecMedSeguimiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    String ReclamoSeguimiento, ReclamosPendientes, ReclamosGestor;
    Utils llenado = new Utils();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        String seleccionarRegistros = "SELECT " +
           "r.id as ID," + //1
           "reg.asegurado as Asegurado," +
           "reg.poliza as Poliza," +
           "reg.aseguradora as Aseguradora," +
           "r.telefono as Telefono," +
           //"dbo.reclamos_medicos.correo as Correo," +
           "r.empresa as Empresa," +
           "r.tipo_reclamo as [Tipo Reclamo]," +
           //"dbo.reg_reclamos_medicos.ramo as Ramo," +
           //"dbo.reg_reclamos_medicos.tipo as Tipo," +
           "reg.clase as Clase," +
           "reg.ejecutivo as Ejecutivo," +
           // "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
           "reg.vip as VIP," +
           "reg.moneda as Moneda," +
           "r.fecha_apertura as [Fecha Apertura]," +
           "r.fecha_envio_aseg as [Fecha Envio Aseguradora]," +
           // "CASE WHEN CONVERT(date, reclamos_medicos.fecha_visualizar, 110) < CONVERT(date, GETDATE(), 110)  THEN 0 ELSE 1 END AS mostrar, " +
           "Convert(varchar(10),r.fecha_visualizar, 103) As [Fecha Visualizar] " +
           "FROM reg_reclamos_medicos as reg " +
           "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id ";

        ReclamoSeguimiento = seleccionarRegistros +
          "where r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and r.fecha_visualizar <= GETDATE() and r.id_estado != " + 2 + "";

        ReclamosPendientes = seleccionarRegistros +
          " where r.usuario_unity = '" + userlogin + "' and r.estado_unity = 'Seguimiento' and r.id_estado != " + 2 + "";

        ReclamosGestor = seleccionarRegistros +
          " where r.usuario_unity = '" + ddlGestor.SelectedItem + "' and r.estado_unity = 'Seguimiento'";

        llenado.llenarGrid(ReclamoSeguimiento, GridReclamosSeguimiento);
        llenado.llenarGrid(ReclamosPendientes, GridPendientes);
    }

    //funcion que coloca en rojo los registros que no se an abierto en el dia
    protected void GridReclamosSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //    if (e.Row.Cells[20].Text == "0")
        //    {
        //        for (int _xCell = 0; _xCell <= e.Row.Cells.Count - 1; _xCell++)
        //        {
        //            e.Row.Cells[_xCell].ForeColor = System.Drawing.Color.Red;
        //        }
        //    }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dias = Convert.ToDateTime(e.Row.Cells[12].Text);

            if(e.Row.Cells[11].Text == "Quetzales")
            {
                if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[12].Text)).TotalDays >= 10)
                {
                    e.Row.Attributes.Add("style", "background-color: #FFFBD2"); //amarillos
                }

                if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[12].Text)).TotalDays >= 15)
                {
                    e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
                }

                if (e.Row.Cells[13].Text != "&nbsp;")
                {
                    if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[13].Text)).TotalDays < 10)
                    {
                        e.Row.Attributes.Add("style", "background-color: #8ace8e"); //verdes
                    }
                }
            }

            if (e.Row.Cells[11].Text == "Dolares")
            {
                if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[12].Text)).TotalDays >= 20)
                {
                    e.Row.Attributes.Add("style", "background-color: #FFFBD2"); //amarillos
                }

                if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[12].Text)).TotalDays >= 28)
                {
                    e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
                }

                if (e.Row.Cells[13].Text != "&nbsp;")
                {
                    if ((DateTime.Now - Convert.ToDateTime(e.Row.Cells[13].Text)).TotalDays < 20)
                    {
                        e.Row.Attributes.Add("style", "background-color: #8ace8e"); //verdes
                    }
                }
            }
        }
    }

    protected void GridReclamosSeguimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosSeguimiento.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo="+ id, false);
    }

    protected void GridPendientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridPendientes.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void GridReclamosPorGestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridReclamosPorGestor.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(ReclamosGestor, GridReclamosPorGestor);
    }
}