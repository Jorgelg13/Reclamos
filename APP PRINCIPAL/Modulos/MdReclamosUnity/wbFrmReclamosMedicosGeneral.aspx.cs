using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosGeneral : System.Web.UI.Page
{
    Utils llenado = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();

        String seleccionarRegistros = "SELECT " +
          "r.id as ID," + //1
          "reg.asegurado as Asegurado," +
          "reg.poliza as Poliza," +
          "reg.aseguradora as Aseguradora," +
          "reg.ejecutivo as Ejecutivo,"+
          "r.telefono as Telefono," +
          "r.empresa as Empresa," +
          "r.tipo_reclamo as [Tipo Reclamo]," +
          "r.usuario_unity as Usuario,"+
          "Convert(varchar(10), r.fecha_visualizar, 103) As [Fecha Visualizar] " +
          "FROM " +
          "reg_reclamos_medicos as reg " +
          "INNER JOIN reclamos_medicos as r ON r.id_reg_reclamos_medicos = reg.id ";

        if (idRecibido == "1")
        {
            seleccionarRegistros += " where r.estado_unity = 'Seguimiento'";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }

        else if(idRecibido == "2")
        {
            seleccionarRegistros += " where r.fecha_visualizar < GETDATE() and r.estado_unity != 'Cerrado' and reg.tipo = 'I' ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }

        else if (idRecibido == "3")
        {
            seleccionarRegistros += " where r.estado_unity = 'Seguimiento' and reg.tipo = 'C'  ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }

        else if (idRecibido == "4")
        {
            seleccionarRegistros += " where r.fecha_visualizar < convert(date,getdate(),103) and r.estado_unity not in ('Cerrado','Anulado') and reg.tipo = 'C' ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }
        
        else if(idRecibido == "5")
        {
            seleccionarRegistros += "where r.estado_unity = 'Seguimiento' and r.id_estado = 4 and reg.tipo = 'I' ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id1;
        id1 = Convert.ToInt32(GridGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id1);
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridGeneral, Response, "Reclamos Medicos en seguimiento");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void GridGeneral_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (Convert.ToDateTime(e.Row.Cells[10].Text) <= DateTime.Today)
            {
                e.Row.Attributes.Add("style", "background-color: #f7c6be"); //rojos
            }
    }
}