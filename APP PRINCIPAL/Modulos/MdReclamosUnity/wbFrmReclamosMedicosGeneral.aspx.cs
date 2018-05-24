using System;
using System.Web.UI;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosGeneral : System.Web.UI.Page
{
    Utils llenado = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();

        String seleccionarRegistros = "SELECT " +
          "dbo.reclamos_medicos.id as ID," + //1
          "dbo.reg_reclamos_medicos.asegurado as Asegurado," +
          "dbo.reg_reclamos_medicos.poliza as Poliza," +
          "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +
          "dbo.reclamos_medicos.telefono as Telefono," +
          "dbo.reclamos_medicos.correo as Correo," +
          "dbo.reclamos_medicos.empresa as Empresa," +
          "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
          "dbo.reg_reclamos_medicos.ramo as Ramo," +
          "dbo.reg_reclamos_medicos.tipo as Tipo," +
          "dbo.reg_reclamos_medicos.clase as Clase," +
          "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
          "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
          "dbo.reg_reclamos_medicos.vip as VIP," +
          "dbo.reg_reclamos_medicos.moneda as Moneda," +
          "dbo.cabina.nombre as Cabina," +
          "dbo.sucursal.nombre as Sucursal," +
          "dbo.empresa.nombre as Empresa," +
          "dbo.pais.nombre as Pais, " +
          "CASE WHEN CONVERT(date, reclamos_medicos.fecha_visualizar, 110) < CONVERT(date, GETDATE(), 110)  THEN 0 ELSE 1 END AS mostrar, " +
          "Convert(varchar(10),dbo.reclamos_medicos.fecha_visualizar, 103) As [Fecha Visualizar] " +
          "FROM " +
          " dbo.reg_reclamos_medicos " +
          "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
          "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id " +
          "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
          "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
          "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id ";

        if (idRecibido == "1")
        {
            seleccionarRegistros += " where reclamos_medicos.estado_unity = 'Seguimiento'";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }

        else if(idRecibido == "2")
        {
            seleccionarRegistros += " where reclamos_medicos.fecha_visualizar < GETDATE() and estado_unity != 'Cerrado' and tipo = 'I' ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
            GridGeneral.ForeColor = System.Drawing.Color.Red;
        }

        else if (idRecibido == "3")
        {
            seleccionarRegistros += " where reclamos_medicos.estado_unity = 'Seguimiento' and tipo = 'C'  ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
        }

        else if (idRecibido == "4")
        {
            seleccionarRegistros += " where reclamos_medicos.fecha_visualizar < GETDATE() and estado_unity != 'Cerrado' and tipo = 'C' ";
            llenado.llenarGrid(seleccionarRegistros, GridGeneral);
            GridGeneral.ForeColor = System.Drawing.Color.Red;
        }
        
        else if(idRecibido == "5")
        {
            seleccionarRegistros += "where reclamos_medicos.estado_unity = 'Seguimiento' and reclamos_medicos.id_estado = 4 and tipo = 'I' ";
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
}