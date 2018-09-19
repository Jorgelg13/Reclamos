using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Consultas_Caja_de_ahorro_Dashboard : System.Web.UI.Page
{
    String Pendientes;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    Utils llenado = new Utils();
    String Consulta;
    protected void Page_Load(object sender, EventArgs e)
    {
        conteo();
        String PendientesMedicos = "SELECT " +
        "dbo.reclamos_medicos.id as ID," + //1
        "dbo.reg_reclamos_medicos.asegurado as Asegurado," +
        "dbo.reg_reclamos_medicos.poliza as Poliza," +
        "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +
        "dbo.reclamos_medicos.telefono as Telefono," +
        "dbo.reclamos_medicos.correo as Correo," +
        "dbo.reclamos_medicos.empresa as Empresa," +
        "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
        "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
        "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza] " +
        "FROM " +
        " dbo.reg_reclamos_medicos " +
        "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
        " where reclamos_medicos.empresa like '%Caja de ahorro%' and reclamos_medicos.estado_unity = 'Seguimiento'";
        llenado.llenarGrid(PendientesMedicos,GridMedicos);


        Pendientes = "SELECT reclamo_auto.id, " +
            " auto_reclamo.poliza as Poliza," +
            " auto_reclamo.placa as Placa," +
            " auto_reclamo.marca as Marca," +
            " auto_reclamo.color as Color, " +
            " auto_reclamo.modelo as Modelo," +
            " auto_reclamo.chasis as Chasis," +
            " auto_reclamo.motor as Motor, " +
            " auto_reclamo.propietario as Propietario, " +
            " auto_reclamo.ejecutivo as Ejecutivo," +
            " auto_reclamo.aseguradora as Aseguradora," +
            " auto_reclamo.estado_poliza as [Estado Poliza]," +
            " reclamo_auto.boleta as Boleta," +
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
            " INNER JOIN analistas on reclamo_auto.id_analista = analistas.id " +
            " where auto_reclamo.poliza in ('AUTO-366487','AUTO-366488') and reclamo_auto.estado_unity = 'Seguimiento'";

        llenado.llenarGrid(Pendientes,GridGeneral);
    }

    protected void ConsultarReclamos_Click(object sender, EventArgs e)
    {
        PanelPrincipal.Visible = false;
        PanelReclamos.Visible = true;
    }

    protected void TotalReclamosAutos_Click(object sender, EventArgs e)
    {
        PanelReclamos.Visible = false;
        PanelReclamosAutos.Visible = true;
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridGeneral,Response,"Reclamos Autos Pendientes Caja de Ahorro");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void lnDescargarGastosMedicos_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridMedicos, Response, "Reclamos Medicos Pendientes Caja de Ahorro");
    }

    protected void TotalReclamosMedicos_Click(object sender, EventArgs e)
    {
        PanelReclamos.Visible = false;
        PanelReclamosAutos.Visible = false;
        PanelReclamosMedicos.Visible = true;
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["id_ra_caja"] = GridGeneral.SelectedRow.Cells[1].Text;
        Response.Redirect("/Consultas/caja-de-ahorro/ReclamosAutos.aspx",false);
    }

    protected void GridMedicos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["id_rm_caja"] = GridMedicos.SelectedRow.Cells[1].Text;
        Response.Redirect("/Consultas/caja-de-ahorro/ReclamosGM.aspx", false);
    }

    public void conteo()
    {
        string total = " select count(*) from reclamo_auto as r inner join auto_reclamo as reg on r.id_auto_reclamo = reg.id " +
            "and reg.poliza in ('AUTO-366487', 'AUTO-366488') and r.estado_unity = 'Seguimiento'";
        SqlDataAdapter da = new SqlDataAdapter(total, objeto.ObtenerConexionReclamos());
        DataTable dt = new DataTable();
        da.Fill(dt);
        TotalAutos.Text = dt.Rows[0][0].ToString();
        objeto.conexion.Close();

        string totalrm = " select count(*) from reclamos_medicos as r inner join reg_reclamos_medicos as reg on r.id_reg_reclamos_medicos = reg.id " +
            " where (reg.contratante like '%caja de ahorro%' or reg.poliza= 'GTVG-198018') and r.estado_unity = 'Seguimiento'";
        SqlDataAdapter DA = new SqlDataAdapter(totalrm, objeto.ObtenerConexionReclamos());
        DataTable DT = new DataTable();
        DA.Fill(DT);
        TotalRM.Text = DT.Rows[0][0].ToString();
        objeto.conexion.Close();
    }

    protected void scb_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://colectivos.unitypromotores.com",false);
    }

    protected void ReportesAutos_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/ReportesAutos.aspx");
    }

    protected void ReportesMedicos_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Consultas/Caja-de-ahorro/ReportesMedicos.aspx");
    }
}