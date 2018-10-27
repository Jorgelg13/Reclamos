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
            "dbo.reclamos_varios.id as ID," +
            "dbo.reclamos_varios.usuario_unity as Usuario, "+
            "dbo.reclamos_varios.asignado_por as [Asignado por],"+
            "dbo.reclamos_varios.estado_unity as Estado,"+
            "dbo.reg_reclamo_varios.poliza as Poliza," +
            "dbo.reg_reclamo_varios.asegurado as Asegurado," +
            "dbo.reg_reclamo_varios.[cliente] as Cliente," +
            "dbo.reg_reclamo_varios.tipo as Tipo," +
            "dbo.reg_reclamo_varios.direccion as Direccion," +
            "dbo.reg_reclamo_varios.ramo as Ramo," +
            "dbo.reg_reclamo_varios.ejecutivo as Ejecutivo," +
            "dbo.reg_reclamo_varios.aseguradora as Aseguradora," +
            "dbo.reg_reclamo_varios.contratante as Contratante," +
            "dbo.reclamos_varios.boleta as Boleta," +
            "dbo.reclamos_varios.titular as Titular," +
            "dbo.reclamos_varios.ubicacion as Ubicacion," +
            "dbo.reclamos_varios.hora as Hora," +
            "dbo.reclamos_varios.fecha as Fecha_Incidente," +
            "dbo.reclamos_varios.reportante as Reportante," +
            "dbo.reclamos_varios.telefono as Telefono," +
            "dbo.reclamos_varios.ajustador as Ajustador," +
            //"dbo.reclamos_varios.version as Version," +
            "dbo.reclamos_varios.fecha_commit as Fecha_Creacion," +
            "dbo.reclamos_varios.fecha_cierre as Fecha_cierre," +
           // "dbo.cabina.nombre as Cabina," +
            //"dbo.sucursal.nombre as Sucursal," +
            //"dbo.empresa.nombre as Empresa," +
            //"dbo.pais.nombre as Pais," +
            "dbo.usuario.nombre as Usuario_cabina " +
            "FROM dbo.reclamos_varios " +
            "INNER JOIN dbo.reg_reclamo_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id " +
            //"INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id " +
            //"INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
            //"INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
            //"INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
            "INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id " +
            "where(fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and(reclamos_varios.id_estado = 2)";
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
                    Correos.Notificacion(gestor.correo, "Asignacion de reclamo", Cuerpo);
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
