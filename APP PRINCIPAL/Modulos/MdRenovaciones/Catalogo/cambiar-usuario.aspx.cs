using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Catalogo_cambiar_usuario : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String consulta;

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuarioLogin = HttpContext.Current.User.Identity.Name;
        var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

        if (user.rol == "E" || user.rol == "S" || user.rol == "F")
        {
            Response.Redirect("/Modulos/MdRenovaciones/Dashboard.aspx");
        }

        if (!IsPostBack)
        {
            ddlUsuario.DataSource = DBReclamos.usuario.ToList().Where(us => us.nombre_completo != "" && us.nombre_completo != null && us.id_cabina == 5 );
            ddlUsuario.DataTextField = "nombre_completo";
            ddlUsuario.DataValueField = "numero_gestor";
            ddlUsuario.DataBind();

            DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
            txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
        }
    }

    private void generarDatos()
    {
        consulta = "Select r.id as ID, " +
           "r.poliza as Poliza," +
            "r.ramo as Ramo," +
            "r.endoso_renov as Endoso," +
            "e.estado," +
            "(select top 1 nombre_completo from reclamos.dbo.usuario where numero_gestor = r.codigo_gestor) as Usuario," +
            "r.asegurado as Asegurado," +
            "r.marca as Marca," +
            "r.modelo as Modelo," +
            "r.placa as Placa," +
            "r.vigf as [Vigencia Final]," +
            "r.correo_cliente as [Correo Cliente]," +
            " (select top 1 fecha from renovaciones_log where poliza = r.id) as [Fecha Registro]" +
            "from renovaciones_polizas r " +
            "inner join estados as e on e.id = r.estado " +
            "where r.estado != 7 and convert(date, fecha_registro,103) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "' ";

        llenar.llenarGridRenovaciones(consulta, GridPolizas);
    }

    protected void btnGenerarTabla_Click(object sender, EventArgs e)
    {
        generarDatos();
    }

    protected void btnGuardarCambios_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridPolizas.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("chCambiarUsuario");
            int id = Convert.ToInt32(Convert.ToString(row.Cells[1].Text));
            if (checkAsig.Checked)
            {
                try
                {
                    var poliza = DB.renovaciones_polizas.Find(id);
                    poliza.nombre_gestor = ddlUsuario.SelectedItem.Text;
                    poliza.codigo_gestor = Convert.ToInt32(ddlUsuario.SelectedValue);
                    DB.SaveChanges();
                    Utils.ShowMessage(this.Page, "Polizas cambiadas de usuario con exito", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido reasignar la poliza " + ex.Message, "error", "error");
                }
            }
        }
        generarDatos();
    }
}