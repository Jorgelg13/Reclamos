using System;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_aperturar_reclamos : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string consulta;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        consulta = " select r.id as ID, reg.poliza as Poliza, reg.asegurado as Asegurado, r.estado_unity as Estado from reclamos_varios as r " +
            "inner join reg_reclamo_varios as reg on reg.id = r.id_reg_reclamos_varios where r.estado_unity = 'Cerrado' " +
            "and convert(date,fecha_cierre_reclamo,113) between '"+txtFechaInicio.Text+"' and '"+txtFechaFin.Text+"'";

        llenar.llenarGrid(consulta, GridReclamos);
    }

    protected void btnAperturar_Click(object sender, EventArgs e)
    {
        reaperturar();
    }

    private void reaperturar()
    {
        foreach (GridViewRow row in GridReclamos.Rows)
        {
            CheckBox checkAperturar = (CheckBox)row.FindControl("checkReaperturar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAperturar.Checked)
            {
                try
                {
                    var aperturar = DBReclamos.reclamos_varios.Find(id);
                    aperturar.estado_unity = "Seguimiento";
                    DBReclamos.SaveChanges();
                    GridReclamos.DataBind();
                    Utils.ShowMessage(this.Page, "Reclamos reaperturados con exito", "Excelente", "success");
                }
                catch (Exception)
                {
                    Utils.ShowMessage(this.Page, "No se pudieron reaperturar los reclamos", "Error..!", "error");
                }
            }
        }
    }
}