using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public partial class DashboardUnity : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Email util = new Email();
    Utils comprobar = new Utils();
    conexionBD obj = new conexionBD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/portada.aspx");
        }

        ObtenerID();
        Conteo();
        ReclamosMedicosFueraTiempo();
    }

    public void ObtenerID()
    {
        try
        {
            var usuario = DBReclamos.usuario.Select(U => new { U.id, U.id_cabina, U.codigo, U.nombre }).Where(us => us.nombre == userlogin).First();
            Session.Add("id_usuario", usuario.id.ToString());
            Session.Add("id_cabina", usuario.id_cabina.ToString());
            Session.Add("codigo", usuario.codigo.ToString());
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al traer las variables de session", "Nota..!", "warning");
        }
    }

    public void Conteo()
    {
        try
        {
            var autos = DBReclamos.reclamo_auto.Where(c => c.estado_unity == "Seguimiento").Count();
            totalReclamosAutos.Text = autos.ToString();

            var danios = DBReclamos.reclamos_varios.Where(d => d.estado_unity == "Seguimiento").Count();
            totalReclamosDaños.Text = danios.ToString();

            var medicos = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento" && m.reg_reclamos_medicos.tipo == "I").Count();
            lnTotalIndividuales.Text = "Individuales: " + medicos.ToString();

            var medicosC = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento" && m.reg_reclamos_medicos.tipo == "C").Count();
            lnColectivos.Text = "Colectivos:  " + medicosC.ToString();

            var total = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento").Count();
            lnTotal.Text = "Total:  " + total.ToString();

            var estadoAsegurado = DBReclamos.reclamos_medicos.Where(m => m.id_estado == 4 && m.estado_unity == "Seguimiento"  && m.reg_reclamos_medicos.tipo == "I" ).Count();
            lnPendienteDocumentacion.Text = "E. Asegurado:  " + estadoAsegurado.ToString();
        }

        catch (Exception ex)
        {
            util.enviarcorreo("reclamosgt@unitypromotores.com", "123$456R", "jorge.laj@unitypromotores.com", "Descripcion del error: " + ex, "Error en conteo de reclamos en unity");
        }
    }

    public void ReclamosMedicosFueraTiempo()
    {
        try
        {
            String sql;
            sql = "select top 1 (select count(*) from reclamos_medicos " +
                "inner join reg_reclamos_medicos reg on reg.id = reclamos_medicos.id_reg_reclamos_medicos " +
                "where reclamos_medicos.fecha_visualizar < GETDATE() and estado_unity != 'Cerrado' and reg.tipo = 'I') as Individuales, " +
                "(select count(*) from reclamos_medicos " +
                "inner join reg_reclamos_medicos reg on reg.id = reclamos_medicos.id_reg_reclamos_medicos " +
                "where reclamos_medicos.fecha_visualizar < GETDATE() and estado_unity != 'Cerrado' and reg.tipo = 'C' ) as Colectivos, " +
                "(select count(*) from reclamos_medicos where fecha_visualizar < GETDATE() and estado_unity != 'Cerrado') as Total from reclamos_medicos ";

            SqlDataAdapter da = new SqlDataAdapter(sql, obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lnIndividualesFueraTiempo.Text = dt.Rows[0][0].ToString();
            lnColectivosFueraTiempo.Text = dt.Rows[0][1].ToString();
            lnTotalFueraTiempo.Text = dt.Rows[0][2].ToString();
            obj.conexion.Close();
        }

        catch(Exception ex)
        {
            Response.Write(ex);
        }
    }

    protected void lnTotalIndividuales_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=1", false);
    }

    protected void lnIndividualesFueraTiempo_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=2", false);
    }

    protected void lnColectivos_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=3", false);
    }

    protected void lnColectivosFueraTiempo_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=4", false);
    }

    protected void lnPendienteDocumentacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=5", false);
    }
}