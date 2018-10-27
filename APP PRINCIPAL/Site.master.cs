using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Email Util = new Email();

    protected void Page_Load(object sender, EventArgs e)
    {
        Conteo();
    }

    public void Conteo()
    {
        try
        {
            var autos = DBReclamos.reclamo_auto.ToList().Where(a => a.id_estado == 1).Count();
            totalReclamosAutos.Text = autos.ToString();

            var danios = DBReclamos.reclamos_varios.ToList().Where(d => d.id_estado == 1).Count();
            totalReclamosDaños.Text = danios.ToString();

            var medicos = DBReclamos.reclamos_medicos.ToList().Where(m => m.estado_unity == "Sin Asignar").Count();
            totalReclamosMedicos.Text = medicos.ToString();

            var autorizaciones = DBReclamos.autorizaciones.ToList().Where(a => a.tipo_estado != "Cerrado").Count();
            totalAutorizaciones.Text = autorizaciones.ToString();
        }

        catch (Exception ex)
        {
            Email.ENVIAR_ERROR("Descripcion del error: " + ex, "Error en conteo de reclamos en cabina");
        }
    }
}