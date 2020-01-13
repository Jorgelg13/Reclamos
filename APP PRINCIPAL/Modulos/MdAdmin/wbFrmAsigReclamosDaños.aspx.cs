using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

public partial class Modulos_MdAdmin_wbFrmAsigReclamosDaños : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils comprobar = new Utils();
    Utils llenado = new Utils();
    String Cuerpo;
    Email Notificacion = new Email();

    int id;
    string asignados, datos;

    private void Page_Error(object sender, EventArgs e)
    {
        Response.Write("<Script>alert('A ocurrido algo inesperado intentelo de nuevo')</script>");
        Server.ClearError();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        asignados = "select count(*) as Total, usuario_unity as Usuario from reclamos_varios  where convert(date, fecha_asignacion,112) between " +
            " '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "' group by usuario_unity order by Total desc";

        datos = "SELECT " +
            "r.id as ID," +
            "r.usuario_unity as Usuario, "+
            "r.asignado_por as [Asignado por],"+
            "r.estado_unity as Estado,"+
            "reg.poliza as Poliza," +
            "reg.asegurado as Asegurado," +
            "reg.[cliente] as Cliente," +
            "reg.tipo as Tipo," +
            "r.version as Version,"+
            //"reg.direccion as Direccion," +
            "reg.ramo as Ramo," +
            "reg.ejecutivo as Ejecutivo," +
            "reg.aseguradora as Aseguradora," +
            //"reg.contratante as Contratante," +
            //"r.boleta as Boleta," +
            //"r.titular as Titular," +
            //"r.ubicacion as Ubicacion," +
            //"r.hora as Hora," +
            "convert(date,r.fecha,112) as Fecha_Incidente," +
            "r.reportante as Reportante," +
            "r.telefono as Telefono " +
            //"r.ajustador as Ajustador," +
            //"r.fecha_commit as Fecha_Creacion," +
            //"r.fecha_cierre as Fecha_cierre " +
            "FROM reclamos_varios as r " +
            "INNER JOIN reg_reclamo_varios as reg ON r.id_reg_reclamos_varios = reg.id " +
            "INNER JOIN usuario ON r.id_usuario = usuario.id " +
            "where(r.fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and(r.id_estado = 2)";
    }
    private void asignar_reclamos()
    {
        var gestor = DBReclamos.gestores.Where(ges => ges.nombre == DDLusuario.SelectedItem.Text).First();

        foreach (GridViewRow row in GridAsigDaños.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAsig.Checked)
            {
                try
                {
                    var asignar = DBReclamos.reclamos_varios.Find(id);
                    Cuerpo = "Estimado Asesor se a asignado un reclamo con el ID " + id + " bajo la poliza " + asignar.reg_reclamo_varios.poliza + ", del asegurado " + asignar.reg_reclamo_varios.asegurado + ". ";
                    asignar.usuario_unity = DDLusuario.SelectedValue;
                    asignar.fecha_asignacion = DateTime.Now;
                    asignar.asignado_por = userlogin;
                    DBReclamos.SaveChanges();
                    GridAsigDaños.DataBind();
                    llenado.llenarGrid(asignados, GridAsignados);
                    llenado.llenarGrid(datos, GridAsigDaños);
                    Utils.ShowMessage(this.Page, "Reclamos asignados con exito", "Excelente..!", "success");

                    //Correos.Notificacion(gestor.correo, "Asignacion de reclamo", Cuerpo);
                    Notificacion.NOTIFICACION(gestor.correo, "Asignacion de reclamo", Cuerpo);
                }
                catch (Exception)
                {
                    Utils.ShowMessage(this.Page, "No se pudo asignar este reclamo", "Error..!", "error");
                }
            }
        }

        llenado.llenarGrid(asignados, GridAsignados);
        llenado.llenarGrid(datos, GridAsigDaños);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(asignados, GridAsignados);
        llenado.llenarGrid(datos, GridAsigDaños);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.actividades(id, Constantes.DANIOS(), 43, Constantes.USER());
        Utils.ExportarExcel(PnPrincipal, Response, "Asignaciones reclamos daños del " + fechaInicio.Text + " al " + fechaFinal.Text);
    }

    protected void bntAsignar_Click(object sender, EventArgs e)
    {
        asignar_reclamos();
        Utils.actividades(0, Constantes.DANIOS(), 41, Constantes.USER());
    }
}
