using System;
using System.Web;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmReclamosMedicosAsignados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Email notificacion = new Email();
    ReclamosEntities DB = new ReclamosEntities();
    Utils comprobar = new Utils();
    Utils llenado = new Utils();
    Utils update = new Utils();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    String ReclamosAsignados, sql;
    String correoEjecutivo, contenido;
    int totalDias = 10;


    protected void Page_Load(object sender, EventArgs e)
    {
        ReclamosAsignados = "SELECT "+
           "dbo.reclamos_medicos.id as ID,"+ //1
           "dbo.reg_reclamos_medicos.asegurado as Asegurado,"+
           "dbo.reg_reclamos_medicos.poliza as Poliza,"+
           "dbo.reg_reclamos_medicos.aseguradora as Aseguradora,"+
           "dbo.reclamos_medicos.correo as Correo,"+
           "dbo.reclamos_medicos.empresa as Empresa,"+
           "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo],"+
           "dbo.reg_reclamos_medicos.tipo as Tipo,"+
           "dbo.reg_reclamos_medicos.clase as Clase,"+
           "dbo.reg_reclamos_medicos.vip as VIP,"+
           "dbo.reg_reclamos_medicos.moneda as Moneda " +
           "FROM "+
           " dbo.reg_reclamos_medicos "+
           "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id "+
           "where usuario_unity = '" + userlogin + "' and estado_unity = 'Asignado' ";


        llenado.llenarGrid(ReclamosAsignados, GridMedicosAsignados);
    }

    protected void GridMedicosAsignados_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id_reclamo_medico;
        string actualizarFecha = "update reclamos_medicos set fecha_revision = getdate() , fecha_apertura = getdate(), estado_unity = 'Seguimiento', id_estado= "+ 8 + ", fecha_visualizar = getdate() +3  ";
        id_reclamo_medico = Convert.ToInt32(GridMedicosAsignados.SelectedRow.Cells[1].Text);
        var asignar = DB.reclamos_medicos.Find(id_reclamo_medico);

        if (asignar.reg_reclamos_medicos.tipo == "I")
        {
            contenido = "Se ha aperturado un nuevo reclamo de gastos medicos bajo la poliza " + asignar.reg_reclamos_medicos.poliza + " " +
                "que pertenece al asegurado  " + asignar.reg_reclamos_medicos.asegurado + " para mas detalle puede consultarlo en el siguiente " +
                "link: \n\n https://reclamosgt.unitypromotores.com/MdBitacora/wbFrmConsultaSeguimientoRmedicos.aspx?ID_reclamo="+id_reclamo_medico+" ";
            correoEjecutivo = Utils.CORREO_GESTOR(asignar.reg_reclamos_medicos.ejecutivo);
            notificacion.NOTIFICACION(correoEjecutivo, contenido, "Nuevo Reclamo Aperturado");
        }

        update.actualizarDatos(actualizarFecha, id_reclamo_medico);
        Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 5, Constantes.USER());
        Utils.insertarComentario(id_reclamo_medico, "Reclamo aperturado con fecha: " + DateTime.Now, "Apertura");
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id_reclamo_medico,false);
    }
}