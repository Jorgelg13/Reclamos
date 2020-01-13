using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdAdmin_bitacora_autos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DB = new ReclamosEntities();
    Utils llenado = new Utils();
    int id, id_estado;
    String bitacoraAutos, bitacorasDaños, bitacorasAutorizaciones, bitacoraMedicos, llamadas, nombreTabla, llaveForanea;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            fechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            fechaFinal.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }

        bitacoraAutos = "SELECT " +
         "r.id as ID," +
         "au.asegurado as Asegurado," +
         "au.poliza as Poliza," +
         "au.placa as Placa," +
         "au.marca as Marca," +
           "au.modelo as Modelo," +
           "au.color as Color," +
           "au.chasis as Chasis," +
           "au.motor as Motor," +
           "au.propietario as Propietario," +
           "au.ejecutivo as Ejecutivo," +
           "au.aseguradora as Aseguradora," +
           "au.contratante as Contratante," +
           "r.boleta as Boleta," +
           "r.titular as Titular," +
           "r.ubicacion as Ubicacion," +
           "r.hora as Hora," +
           "r.fecha as Fecha," +
           "r.reportante as Reportante," +
           "r.piloto as Piloto," +
           "r.edad as Edad," +
           "r.telefono as Telefono," +
           "r.ajustador as Ajustador," +
           "r.version as Version," +
           "r.tipo_servicio as [Tipo Servicio]," +
           "r.hora_commit as [Hora Commit]," +
           "Convert(varchar(10),r.fecha_commit, 103) as [Fecha Commit] ," +
           "r.hora_cierre as [Hora Cierre]," +
           "Convert(varchar(10),r.fecha_cierre, 103) as [Fecha Cierre]," +
           "r.usuario_unity as [Usuario Unity]," +
           "r.estado_unity as [Estado Unity]," +
           "usuario.nombre as usuario " +
           "FROM " +
           " auto_reclamo as au " +
           "INNER JOIN reclamo_auto as r ON r.id_auto_reclamo = au.id " +
           "INNER JOIN usuario ON r.id_usuario = usuario.id " +
           "where(fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and (r.id_estado = 2)";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(bitacoraAutos, GridBitacoras);
    }

    protected void GridBitacoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridBitacoras.SelectedRow.Cells[1].Text);

        nombreTabla = "bitacora_reclamo_auto";
        llaveForanea = "id_reclamo";
        llamadas = "select descripcion as Descripcion, Convert(varchar(10),fecha_commit, 103)  as Fecha, hora_commit as Hora, usuario as Usuario from " + nombreTabla + "  where " + llaveForanea + " = " + id + " ";
        llenado.llenarGrid(llamadas, Bitllamadas);

        var registro = DB.reclamo_auto.Find(id);
        lblPoliza.Text = registro.auto_reclamo.poliza;
        lblId.Text = registro.id.ToString();
        lblAsegurado.Text = registro.auto_reclamo.asegurado;
        lblEjecutivo.Text = registro.auto_reclamo.ejecutivo;
        lblAseguradora.Text = registro.auto_reclamo.aseguradora;
        lblContratante.Text = registro.auto_reclamo.contratante;
        lblEstado.Text = registro.auto_reclamo.estado_poliza;
        lblPiloto.Text = registro.piloto;
        lblReportante.Text = registro.reportante;
        lblTipoServicio.Text = registro.tipo_servicio;
        lblHora.Text = registro.fecha.ToString();
        lblUbicacion.Text = "<b>Ubicacion</b>" + registro.ubicacion;
        lblversion.Text = "<b>Version: </b>" + registro.version;

        impPoliza.Text = registro.auto_reclamo.poliza;
        impId.Text = registro.id.ToString();
        impAsegurado.Text = registro.auto_reclamo.asegurado;
        impEjecutivo.Text = registro.auto_reclamo.ejecutivo;
        impAseguradora.Text = registro.auto_reclamo.aseguradora;
        impContratante.Text = registro.auto_reclamo.contratante;
        impEstado.Text = registro.auto_reclamo.estado_poliza;
        impPiloto.Text = registro.piloto;
        impReportante.Text = registro.reportante;
        impTipoServicio.Text = registro.tipo_servicio;
        impFecha.Text = registro.fecha.ToString();
        impUbicacion.Text = "<b>Ubicacion</b>" + registro.ubicacion;
        impversion.Text = "<b>Version: </b>" + registro.version;

        lblPlaca.Text = registro.auto_reclamo.placa;
        lblMarca.Text = registro.auto_reclamo.marca;
        lblColor.Text = registro.auto_reclamo.color;
        lblModelo.Text = registro.auto_reclamo.modelo;
        lblChasis.Text = registro.auto_reclamo.chasis;
        lblMotor.Text = registro.auto_reclamo.motor;

        impPlaca.Text = registro.auto_reclamo.placa;
        impMarca.Text = registro.auto_reclamo.marca;
        impColor.Text = registro.auto_reclamo.color;
        impModelo.Text = registro.auto_reclamo.modelo;
        impChasis.Text = registro.auto_reclamo.chasis;
        impMotor.Text = registro.auto_reclamo.motor;



        llenado.llenarGrid(llamadas, Gridllamadas);
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#bitacora').modal('show');", addScriptTags: true);
    }
}