using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

public partial class Implants_asegurados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    ReclamosEntities DB = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    String Consulta,contenidoCorreo, correoUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarDropDown();
            llenarGrid();
        }
    }

    private void llenarGrid()
    {
        Consulta = "select id, asegurado as Asegurado, " +
            "telefono as Telefono, " +
            "correo as Correo, " +
            "empresa as Empresa, " +
            "motivo AS Motivo," +
            "comentario AS Comentario, " +
            "fechareg as [Fecha Registro] " +
            "from asegurados_implants " +
            "where estado = 0 and usuario = '" + userlogin+"' ";

        llenado.llenarGrid(Consulta,GridRegistros);
    }

    private void llenarDropDown()
    {
        ddlEmpresa.DataSource = DB.empresas_implants.ToList();
        ddlEmpresa.DataValueField = "id";
        ddlEmpresa.DataTextField = "nombre";
        ddlEmpresa.DataBind();
    }

    private void limpiarCampos()
    {
        txtNombre.Text = "";
        txtEmail.Text = "";
        txtTelefono.Text = "";
        txtObservaciones.Text = "";
    }

    protected void GuardarConsulta_Click(object sender, EventArgs e)
    {
        try
        {
            if(txtNombre.Text.Length > 3)
            {
                asegurados_implants nuevo = new asegurados_implants();
                nuevo.asegurado = txtNombre.Text;
                nuevo.correo = txtEmail.Text;
                nuevo.telefono = txtTelefono.Text;
                nuevo.empresa = ddlEmpresa.SelectedItem.Text;
                nuevo.comentario = txtObservaciones.Text;
                nuevo.motivo = ddlMotivo.SelectedItem.Text;
                nuevo.usuario = userlogin;
                nuevo.fechareg = DateTime.Now;
                nuevo.estado = false;
                DB.asegurados_implants.Add(nuevo);
                DB.SaveChanges();
                llenarGrid();
                limpiarCampos();
                Utils.ShowMessage(this.Page, "Registro ingresado con exito..", "Excelente..", "success");
            }
            else
            {
                Utils.ShowMessage(this.Page, "El campo nombre es requerido.", "Info..", "info");
            }
           
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Error Al ingresar el registro " + ex.Message, "Error..", "error");
        }
    }

    protected void CerrarConsulta_Click(object sender, EventArgs e)
    {
        correoUsuario = Utils.seleccionarCorreoGestor(userlogin);
        contenidoCorreo = "<p>Estimado asegurado, fue un gusto haber atendido su consulta personalmente, estamos a sus órdenes.</p>";
        foreach (GridViewRow row in GridRegistros.Rows)
        {
            CheckBox chConsulta = (CheckBox)row.FindControl("chConsulta");
            int id = Convert.ToInt32(Convert.ToString(row.Cells[1].Text));

            if (chConsulta.Checked)
            {
                try
                {
                    var registro = DB.asegurados_implants.Find(id);
                    registro.estado = true;
                    registro.fechafin = DateTime.Now;
                    DB.SaveChanges();
                    llenarGrid();
                    Utils.EmailRenovacion("pa_email_implant", registro.correo, contenidoCorreo, correoUsuario,0,0);
                    Utils.ShowMessage(this.Page, "Registro cerrado con exito", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se pudo cerrar el o los registros " + ex.Message, "Excelente", "error");
                }
            }
        }
    }
}