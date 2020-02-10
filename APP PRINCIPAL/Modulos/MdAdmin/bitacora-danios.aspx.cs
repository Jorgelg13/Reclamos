using System;
using System.Data.SqlClient;
using System.Web;

public partial class Modulos_MdAdmin_bitacora_danios : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DB = new ReclamosEntities();
    Utils llenado = new Utils();
    int id;
    String bitacorasDaños,llamadas, nombreTabla, llaveForanea;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            fechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            fechaFinal.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }

        bitacorasDaños = " SELECT " +
          "r.id as ID," +
          "reg.poliza as Poliza," +
          "reg.asegurado as Asegurado," +
          "reg.aseguradora as Aseguradora," +
          "reg.ramo as Ramo," +
          "r.fecha as Fecha," +
          "Convert(varchar(10), r.fecha_cierre, 103) as [Fecha Cierre] " +
          " FROM reg_reclamo_varios as reg " +
          "INNER JOIN reclamos_varios as r ON r.id_reg_reclamos_varios = reg.id " +
          " where (r.fecha_cierre between '" + fechaInicio.Text + "' and '" + fechaFinal.Text + "') and (r.id_estado = 2) ";
    }

    protected void GridBitacoras_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridBitacoras.SelectedRow.Cells[1].Text);
        nombreTabla = "bitacora_reclamos_varios";
        llaveForanea = "id_reclamos_varios";
        llamadas = "select descripcion as Descripcion, Convert(varchar(10),fecha_commit, 103)  as Fecha, hora_commit as Hora, usuario as Usuario from " + nombreTabla + "  where " + llaveForanea + " = " + id + " ";
        llenado.llenarGrid(llamadas, Bitllamadas);
        llenado.llenarGrid(llamadas, Gridllamadas);

        var registro = DB.reclamos_varios.Find(id);
        lblPoliza.Text = registro.reg_reclamo_varios.poliza;
        lblId.Text = registro.id.ToString();
        lblAsegurado.Text = registro.reg_reclamo_varios.asegurado;
        lblEjecutivo.Text = registro.reg_reclamo_varios.ejecutivo;
        lblAseguradora.Text = registro.reg_reclamo_varios.aseguradora;
        lblContratante.Text = registro.reg_reclamo_varios.contratante;
        lblEstado.Text = registro.reg_reclamo_varios.estado_poliza;
        lblReportante.Text = registro.reportante;
        lblTelefonoReportante.Text = registro.telefono;
        lblTipoServicio.Text = registro.tipo_servicio;
        lblHora.Text = registro.fecha.ToString();
        lblBoleta.Text = registro.boleta;
        lblAjustador.Text = registro.ajustador;
        lblRamo.Text = registro.reg_reclamo_varios.ramo;
        lblUbicacion.Text = "<b>Ubicacion</b>" + registro.ubicacion;
        lblversion.Text = "<b>Version: </b>" + registro.version;

        ImpPoliza.Text = registro.reg_reclamo_varios.poliza;
        ImpId.Text = registro.id.ToString();
        ImpAsegurado.Text = registro.reg_reclamo_varios.asegurado;
        ImpEjecutivo.Text = registro.reg_reclamo_varios.ejecutivo;
        ImpAseguradora.Text = registro.reg_reclamo_varios.aseguradora;
        ImpContratante.Text = registro.reg_reclamo_varios.contratante;
        ImpEstado.Text = registro.reg_reclamo_varios.estado_poliza;
        ImpReportante.Text = registro.reportante;
        ImpTelefono.Text = registro.telefono;
        ImpTipo.Text = registro.tipo_servicio;
        ImpFecha.Text = registro.fecha.ToString();
        ImpBoleta.Text = registro.boleta;
        ImpAjustador.Text = registro.ajustador;
        ImpRamo.Text = registro.reg_reclamo_varios.ramo;
        impUbicacion.Text = "<b>Ubicacion</b>" + registro.ubicacion;
        impversion.Text = "<b>Version: </b>" + registro.version;

        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#bitacora').modal('show');", addScriptTags: true);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(bitacorasDaños, GridBitacoras);
    }


}