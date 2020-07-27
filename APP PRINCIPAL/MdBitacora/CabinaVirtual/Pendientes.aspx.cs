using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MdBitacora_CabinaVirtual_Pendientes : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DB = new ReclamosEntities();
    Utils llenado = new Utils();
    String consulta;

    protected void Page_Load(object sender, EventArgs e)
    {
        consulta = "select id, " +
            "nombre as Nombre, " +
            "correo as Correo, " +
            "telefono as Telefono, " +
            "codigo as Codigo, " +
            "fechareg as Fecha, " +
            "estado as Estado " +
            "from cabina_virtual where estado = 0";

        if (!IsPostBack)
        {
            llenado.llenarGrid(consulta, GridPendientes);

            if (!IsPostBack)
            {
                DateTime primerDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
                txtFechaInicio.Text = primerDia.ToString("yyyy/MM/dd").Replace("/", "-");
                txtFechaFin.Text = ultimoDia.ToString("yyyy/MM/dd").Replace("/", "-");
            }
        }
    }

    protected void lnGuardar_Click(object sender, EventArgs e)
    {
        atender();
    }

    private void atender()
    {
        foreach (GridViewRow row in GridPendientes.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String registro = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(registro);
            if (checkAsig.Checked)
            {
                try
                {
                    var actualizar = DB.cabina_virtual.Find(id);
                    actualizar.estado = Convert.ToBoolean(ddlEstado.SelectedValue);
                    actualizar.fecha_atencion = DateTime.Now;
                    DB.SaveChanges();
                    Utils.ShowMessage(this.Page, "Registros actualizados exitosamente", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    //Response.Write(ex);
                    Utils.ShowMessage(this.Page, "No se han podido actualizar" + ex.Message, "error", "error");
                }
            }
        }

        llenado.llenarGrid(consulta, GridPendientes);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        consulta = "select id, nombre as Nombre, correo as Correo, telefono as Telefono, codigo as Codigo, fechareg as Fecha, estado as Estado from cabina_virtual where estado in (" + ddlFiltro.SelectedValue + ") " +
           " and convert(date,fechareg,112) between '" + txtFechaInicio.Text + "' and '" + txtFechaFin.Text + "'";
        llenado.llenarGrid(consulta, GridPendientes);
    }

    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridPendientes, Response, "Reporte Cabina Virtual");
    }
}