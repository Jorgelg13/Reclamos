using System;
using System.Linq;
using System.Web.UI.WebControls;

public partial class MdBitacora_ControlMaternidad : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenar = new Utils();
    Email envio = new Email();
    String correo;
    String pendientes = "select id as ID, poliza as Poliza, asegurado as Asegurado, " +
        "ejecutivo as Ejecutivo, cod_ejecutivo as Codigo, fecha_parto as [Fecha de Parto] from maternidad where estado = 0";
    String contenido;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ejecutivos();
            llenar.llenarGrid(pendientes, GridPendientes);
        }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        PanelSeleccionar.Visible = true;
        llenar.llenarGrid(buscador(txtbuscar.Text), GridAsegurados);
    }

    private void Ejecutivos()
    {
        ddlEjecutivos.DataSource = DBReclamos.ejecutivos.ToList();
        ddlEjecutivos.DataTextField = "gestor";
        ddlEjecutivos.DataValueField = "codigo";
        ddlEjecutivos.DataBind();
    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT poliza as Poliza, asegurado as Asegurado, nombre as Aseguradora," +
                "gst_nombre as Gestor, vigi as Vigencia_Inicial, vigf as Vigencia_Final, tipo as Tipo, clase as Clase,contratante as Contratante, " +
                "moneda as Moneda, certificado as Certificado, secren as [Secuencia Renovacion] FROM vistaReclamosMedicos Where asegurado like '%" + arreglo[0] + "%' ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and asegurado like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }


    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if(txtbuscar.Text == "" || txtNombre.Text == "")
            {
                Utils.ShowMessage(this.Page, "Los campos Nombre, y poliza son obligatorios", "Excelente", "warning");
            }

            else
            {
                maternidad nuevo = new maternidad();
                nuevo.poliza = txtPoliza.Text;
                nuevo.asegurado = txtNombre.Text;
                nuevo.cod_ejecutivo = Convert.ToInt32(ddlEjecutivos.SelectedValue);
                nuevo.ejecutivo = ddlEjecutivos.SelectedItem.Text;
                nuevo.fecha = DateTime.Now;
                nuevo.fecha_parto = Convert.ToDateTime(txtFechaAprox.Text);
                nuevo.estado = false;
                DBReclamos.maternidad.Add(nuevo);
                DBReclamos.SaveChanges();
                llenar.llenarGrid(pendientes, GridPendientes);
                limpiar();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente", "success");
            }
        }
        catch(Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se pudo guardar el registro " + ex.Message, "Error", "error");
        }
    }

    protected void GridAsegurados_SelectedIndexChanged(object sender, EventArgs e)
    {
        PanelSeleccionar.Visible = false;
        txtPoliza.Text = GridAsegurados.SelectedRow.Cells[1].Text;
        txtNombre.Text = GridAsegurados.SelectedRow.Cells[2].Text;
        ddlEjecutivos.SelectedItem.Text = GridAsegurados.SelectedRow.Cells[4].Text;
    }

    private void limpiar()
    {
        txtPoliza.Text = "";
        txtbuscar.Text = "";
        txtNombre.Text = "";
    }

    private void atendidos()
    {
        foreach (GridViewRow row in GridPendientes.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("ChAtendido");
            String registro = Convert.ToString(row.Cells[1].Text);
            String poliza = Convert.ToString(row.Cells[2].Text);
            String fecha = row.Cells[6].Text;
            int codigo = Convert.ToInt32(row.Cells[5].Text);

            contenido = "Recuerde que la fecha probable de parto de su asegurado en la póliza "+poliza+" es el "+Convert.ToDateTime(fecha).ToString("dd/MM/yyyy") +"; recuerde enviarle los formularios de adición de " +
                        "dependientes para realizar los trámites respectivos.";

            int id = Convert.ToInt32(registro);
            if (check.Checked)
            {
                try
                {
                    var atender = DBReclamos.maternidad.Find(id);
                    atender.estado = true;
                    DBReclamos.SaveChanges();
                    correo = Utils.seleccionarCorreo(codigo);
                    envio.NOTIFICACION(correo,contenido, "Inclusion de asegurado");
                }
                catch (Exception)
                {
                    Utils.ShowMessage(this.Page, "No marcar como atendidos los registros", "Error..!", "error");
                }
            }
        }

        llenar.llenarGrid(pendientes, GridPendientes);
    }

    protected void lnAtendidos_Click(object sender, EventArgs e)
    {
        atendidos();
    }
}