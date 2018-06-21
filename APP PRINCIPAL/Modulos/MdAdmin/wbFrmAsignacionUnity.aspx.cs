using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdAdmin_wbFrmAsignacionUnity : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    Utils comprobar = new Utils();
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
            Response.Redirect("/portada.aspx");
        }

        asignados = "select count(*) as Total, usuario_unity as Usuario from reclamo_auto  where convert(date, fecha_asignacion,112) between " +
            " '"+fechaInicio.Text+"' and '"+fechaFinal.Text+"' group by usuario_unity order by Total desc";

        datos = "SELECT reclamo_auto.id as ID," +
            "reclamo_auto.usuario_unity as Usuario," +
            "reclamo_auto.estado_unity as Estado," +
            "reclamo_auto.asignado_por as [Asignado por],"+
            "auto_reclamo.poliza as Poliza," +
            "auto_reclamo.placa as Placa," +
            "auto_reclamo.marca as Marca," +
            "auto_reclamo.color as Color," +
            "auto_reclamo.modelo as Modelo," +
            "auto_reclamo.chasis as Chasis," +
            "auto_reclamo.motor as Motor," +
            "auto_reclamo.propietario as Propietario," +
            "auto_reclamo.ejecutivo as Ejecutivo," +
            "auto_reclamo.aseguradora as Aseguradora," +
            "auto_reclamo.contratante as Contratante," +
            "auto_reclamo.estado_poliza," +
            "auto_reclamo.asegurado as Asegurado," +
            "reclamo_auto.boleta as Boleta," +
            "reclamo_auto.titular as Titular," +
            "reclamo_auto.hora as Hora," +
            "reclamo_auto.fecha as Fecha," +
            "reclamo_auto.fecha_commit as [Fecha Creacion]," +
            "reclamo_auto.fecha_cierre as [Fecha Cierre Cabina]," +
            "reclamo_auto.ubicacion as Ubicacion," +
            "reclamo_auto.reportante as Reportante," +
            "reclamo_auto.piloto as Piloto," +
            "reclamo_auto.edad as Edad," +
            "reclamo_auto.telefono as Telefono," +
            "reclamo_auto.ajustador as Ajustador," +
            "reclamo_auto.tipo_servicio as [Tipo Servicio]," +
            //"reclamo_auto.version," +
            "cabina.nombre as Cabina," +
            "sucursal.nombre as Sucursal," +
            "empresa.nombre as Empresa," +
            "pais.nombre as Pais," +
            "usuario.nombre as [usuario cabina] " +
            "FROM auto_reclamo " +
            "INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id " +
            "INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id " +
            "INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id " +
            "INNER JOIN empresa ON sucursal.id_empresa = empresa.id " +
            "INNER JOIN pais ON empresa.id_pais = pais.id " +
            "INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id " +
            "where(convert(date,fecha_cierre, 112) between '"+fechaInicio.Text+"' and '"+fechaFinal.Text+"') and(reclamo_auto.id_estado = 2) and " +
            "(tipo_servicio != 'Asistencia Vehicular') ";
    }

    private void asignar_reclamos()
    {
        foreach (GridViewRow row in GridAsignacionAutos.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAsig.Checked)
            {
                try
                {
                    var asignar = DBReclamos.reclamo_auto.Find(id);
                    asignar.usuario_unity = DDLusuario.SelectedValue;
                    asignar.fecha_asignacion = DateTime.Now;
                    asignar.asignado_por = userlogin;
                    DBReclamos.SaveChanges();
                    Utils.ShowMessage(this.Page, "Reclamos asignados exitosamente", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido asigar el reclamo" + ex.Message, "Excelente", "success");
                }
            }
        }

        llenado.llenarGrid(asignados, GridAsignados);
        llenado.llenarGrid(datos, GridAsignacionAutos);
    }


    protected void bntAsignar_Click(object sender, EventArgs e)
    {
        asignar_reclamos();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(datos, GridAsignacionAutos);
        llenado.llenarGrid(asignados, GridAsignados);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(PnPrincipal,Response, "Asignaciones autos del " + fechaInicio.Text + " al " + fechaFinal.Text);
    }
}