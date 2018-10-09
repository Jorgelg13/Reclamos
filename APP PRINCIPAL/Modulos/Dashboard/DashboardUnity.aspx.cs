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
    Double individualesFT,colectivosFT;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/portada.aspx", false);
        }

        ObtenerID();
        ReclamosMedicosFueraTiempo();
        Conteo();
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
            Double autos = DBReclamos.reclamo_auto.Where(c => c.estado_unity == "Seguimiento").Count();
            totalReclamosAutos.Text = autos.ToString();

            Double danios = DBReclamos.reclamos_varios.Where(d => d.estado_unity == "Seguimiento").Count();
            totalReclamosDaños.Text = danios.ToString();

            Double total = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento").Count();
            lnTotal.Text = total.ToString();

            //total de reclamos medicos por tiempo
            Double medicos = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento" && m.reg_reclamos_medicos.tipo == "I").Count();
            lnTotalIndividuales.Text = medicos.ToString();
            lbIndividualesFT.Text = " = " + ((1 - (individualesFT / medicos)) * 100).ToString("N2") + "%";

            Double medicosC = DBReclamos.reclamos_medicos.Where(m => m.estado_unity == "Seguimiento" && m.reg_reclamos_medicos.tipo == "C").Count();
            lnColectivos.Text =  medicosC.ToString();
            lbColectivosFT.Text = " = " + (( 1 - (colectivosFT / medicosC)) * 100).ToString("N2") + "%";

            Double TotalRecMedicos = medicos + medicosC;
            Double TotalFtMedicos = Convert.ToDouble(colectivosFT) + Convert.ToDouble(individualesFT);
            lnTotalGastosMedicos.Text =  TotalRecMedicos.ToString();
            LnTotalFtGastosMedios.Text = TotalFtMedicos.ToString();
            lbltotalFt.Text = " = " + ((1 - (TotalFtMedicos / TotalRecMedicos)) * 100).ToString("N2") + "%";

            Double estadoAsegurado = DBReclamos.reclamos_medicos.Where(m => m.id_estado == 4 && m.estado_unity == "Seguimiento"  && m.reg_reclamos_medicos.tipo == "I" ).Count();
            lnPendienteDocumentacion.Text = "E.A :  " + estadoAsegurado.ToString();

            //total de reclamos de autos por estado
            Double pendienteAseguradoAutos = DBReclamos.reclamo_auto.Where(a => a.estado_auto_unity == "Pendiente Asegurado" && a.estado_unity == "Seguimiento").Count();
            lnPendienteAseguradoAuto.Text = "P.A:  " + pendienteAseguradoAutos.ToString() + " = " + ((pendienteAseguradoAutos/autos) *100).ToString("N2") + "%";

            Double procesolegal = DBReclamos.reclamo_auto.Where(a => a.estado_auto_unity == "Proceso legal" && a.estado_unity == "Seguimiento").Count();
            lnlProcesoLegalAutos.Text = "P.L:  " + procesolegal.ToString() + " = " + ((procesolegal / autos) *100).ToString("N2") + "%";

            Double esperaAfectado = DBReclamos.reclamo_auto.Where(a => a.estado_auto_unity == "Espera afectado" && a.estado_unity == "Seguimiento").Count();
            lnlEsperaAfectado.Text = "E.A:  " + esperaAfectado.ToString() + " = " + ((esperaAfectado / autos) *100).ToString("N2") + "%";

            Double pendienteCompania = DBReclamos.reclamo_auto.Where(a => a.estado_auto_unity == "Reparacion" && a.estado_unity == "Seguimiento").Count();
            lnlPendienteCompania.Text = "RE:  " + pendienteCompania.ToString() + " = " + ((pendienteCompania / autos) * 100).ToString("N2") + "%";

            //total de reclamos de estado de daños
            Double pendiente = DBReclamos.reclamos_varios.Where(a => a.estado_reclamo_unity == "Pendiente asegurado" && a.estado_unity == "Seguimiento").Count();
            lnPendienteAsegurado.Text = "P.A:  " + pendiente.ToString() + " = " + ((pendiente / danios) * 100).ToString("N2") + "%";

            Double inactivo = DBReclamos.reclamos_varios.Where(a => a.estado_reclamo_unity == "Inactivo" && a.estado_unity == "Seguimiento").Count();
            lnInactivo.Text = "I:  " + inactivo.ToString() + " = " + ((inactivo / danios) * 100).ToString("N2") + "%";

            Double ajuste = DBReclamos.reclamos_varios.Where(a => a.estado_reclamo_unity == "Ajuste" && a.estado_unity == "Seguimiento").Count();
            lnAjuste.Text = "A:  " + ajuste.ToString() + " = " + ((ajuste / danios) * 100).ToString("N2") + "%";

            Double finiquito = DBReclamos.reclamos_varios.Where(a => a.estado_reclamo_unity == "Pendiente Finiquito" && a.estado_unity == "Seguimiento").Count();
            lnFiniquito.Text = "P.F:  " + finiquito.ToString() + " = " + ((finiquito / danios) * 100).ToString("N2") + "%";
        }

        catch (Exception ex)
        {
            Email.ENVIAR_ERROR("Error en conteo de reclamos de unity", ex.ToString());
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
                "where reclamos_medicos.fecha_visualizar < GETDATE() and estado_unity not in  ('Cerrado','Anulado') and reg.tipo = 'C' ) as Colectivos, " +
                "(select count(*) from reclamos_medicos where fecha_visualizar < GETDATE() and estado_unity != 'Cerrado') as Total from reclamos_medicos ";

            SqlDataAdapter da = new SqlDataAdapter(sql, obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lnIndividualesFueraTiempo.Text = dt.Rows[0][0].ToString();
            individualesFT = Convert.ToDouble(dt.Rows[0][0].ToString());
            lnColectivosFueraTiempo.Text = dt.Rows[0][1].ToString();
            colectivosFT = Convert.ToDouble(dt.Rows[0][1].ToString());
            //lnTotalFueraTiempo.Text = dt.Rows[0][2].ToString();
            obj.conexion.Close();
        }

        catch(Exception ex)
        {
            Email.ENVIAR_ERROR("Error en conteo de reclamos de unity fuera de tiempo ", ex.ToString());
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

    //autos
    protected void lnPendienteAseguradoAuto_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx?id=1", false);
    }

    protected void lnlProcesoLegalAutos_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx?id=2", false);
    }

    protected void lnlEsperaAfectado_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx?id=3", false);
    }

    protected void lnlPendienteCompania_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx?id=4", false);
    }

    //daños varios
    protected void lnPendienteAsegurado_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx?id=1", false);
    }

    protected void lnInactivo_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx?id=2", false);
    }

    protected void lnAjuste_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx?id=3", false);
    }

    protected void lnFiniquito_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx?id=4", false);
    }
}