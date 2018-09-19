using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public partial class Modulos_MdReclamos_wbFrmReclamoMedicoManual : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string ultimoIdRegMedico, ultimoIdReclamo, idCabina, idUsuario, codigo, mensaje;
    string metodo = "manual";

    protected void Page_Load(object sender, EventArgs e)
    {
        obtenerID();
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        if(!IsPostBack)
        {
            Aseguradoras();
        }
    }

    public void Aseguradoras()
    {
        ddlAseguradora.DataSource = DBReclamos.aseguradoras.ToList().OrderBy(a => a.aseguradora);
        ddlAseguradora.DataTextField = "aseguradora";
        ddlAseguradora.DataBind();
    }

    private void guardar()
    {
        try
        {
            idCabina = (string)(Session["id_cabina"]);
            idUsuario = (string)(Session["id_usuario"]);
            codigo = (string)(Session["codigo"]);
            int id1 = Convert.ToInt32(idCabina);
            int id2 = Convert.ToInt32(idUsuario);

            if (txtAseguradoTitular.Text == null)
            {
                Utils.ShowMessage(this.Page, "El campo asegurado es obligatorio", "info");
            }
            else
            {
                reg_reclamos_medicos registro = new reg_reclamos_medicos();
                var sec_registro = DBReclamos.pa_sec_registros_medicos();
                long? id_registro = sec_registro.Single();
                registro.id = Convert.ToInt64(id_registro);
                registro.asegurado = txtDependiente.Text;
                registro.poliza = txtPoliza.Text;
                registro.aseguradora = ddlAseguradora.SelectedItem.Text;
                registro.tipo = ddlTipoReclamo.SelectedValue;
                registro.clase = ddlTipoAsegurado.SelectedItem.Text;
                registro.moneda = ddlMoneda.SelectedValue;
                registro.tipo_registro = "Gasto Medico";

                reclamos_medicos reclamo = new reclamos_medicos();
                var results = DBReclamos.pa_sec_reclamos_medicos();
                long? resultado = results.Single();
                reclamo.id = Convert.ToInt64(resultado);
                reclamo.asegurado = txtDependiente.Text;
                reclamo.titular = txtAseguradoTitular.Text;
                reclamo.telefono = txtTelefono.Text.ToString();
                reclamo.correo = txtCorreo.Text.ToString();
                reclamo.empresa = txtEmpresa.Text.ToString();
                reclamo.metodo = "manual";
                reclamo.fecha_commit = DateTime.Now;
                reclamo.fecha_completa_commit = DateTime.Now;
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.id_estado = 1;
                reclamo.id_usuario = id2;
                reclamo.id_cabina = id1;
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.tipo_reclamo = DDLTipo.SelectedItem.Text;
                reclamo.usuario_unity = "Sin Asignar";
                reclamo.recepcion = txtRecepcion.Text.ToString();
                reclamo.estado_unity = "Sin Asignar";
                reclamo.bandera_asegurado = false;
                reclamo.bandera_aseguradora = false;
                reclamo.bandera_cheque = false;
                reclamo.bandera_cierre = false;

                reclamo.reg_reclamos_medicos = registro;

                DBReclamos.reclamos_medicos.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdReclamo = reclamo.id.ToString();
                insertar_documentos(Convert.ToInt32(ultimoIdReclamo));

                if(ddlTipoReclamo.SelectedValue == "I")
                {
                    if (ddlTipoAsegurado.SelectedItem.Text == "Principal")
                    {
                        mensaje = "UNITY: Estimad@ cliente recibimos la documentación para tramitar su reclamo a nombre de " + txtAseguradoTitular.Text + ", puedes hacer consultas a tu ejecutivo sobre los avances con el siguiente código ID: " + reclamo.id + ".";
                    }
                    else
                    {
                        mensaje = "UNITY: Estimad@ cliente recibimos la documentación para tramitar su reclamo, a nombre de " + txtDependiente.Text + " puedes hacer consultas a tu ejecutivo sobre los avances con el siguiente código ID: " + reclamo.id + ".";
                    }

                    Utils.SMS_gastos_medicos(txtTelefono.Text, mensaje, userlogin, "Apertura", reclamo.id, ddlTipoReclamo.SelectedValue);
                }

                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosMedicosEditar.aspx?ID_reclamo=" + ultimoIdReclamo, false);
            }
        }

        catch (Exception ex)
        {
            Response.Write(ex);
            //Utils.ShowMessage(this.Page, "A ocurrido un error al guardar el registro", "Nota..!", "error");
        }
    }

    protected void btnGuardarReclamo_Click(object sender, EventArgs e)
    {
        if (ddlTipoReclamo.SelectedValue == "I" && txtTelefono.Text == "")
        {
            Utils.ShowMessage(this.Page, "El campo asegurado y telefono son obligatorios", "info");
        }

        else
        {
            guardar();
        }
    }

    public void obtenerID()
    {
        try
        {
            var usuario = DBReclamos.usuario.Select(U => new { U.id, U.id_cabina, U.codigo, U.nombre }).Where(us => us.nombre == userlogin).First();
            Session.Add("id_usuario", usuario.id.ToString());
            Session.Add("id_cabina", usuario.id_cabina.ToString());
            Session.Add("codigo", usuario.codigo.ToString());
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al traer las variables de session", "Nota..!", "warning");
        }
    }

    private void insertar_documentos(int idReclamo)
    {
        foreach (GridViewRow row in GridRecibo.Rows)
        {
            CheckBox checkOpciones = (CheckBox)row.FindControl("checkOpciones");
            TextBox comentarios = row.FindControl("txtComentarios") as TextBox;
            TextBox cantidad = row.FindControl("txtCantidad") as TextBox;
            if (checkOpciones.Checked)
            {
                String descripcion = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[1].Text));

                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into recibos_medicos(descripcion, comentarios, cantidad, id_reclamo_medico) values('" + descripcion + "', '" + comentarios.Text + "', '" + cantidad.Text + "', " + idReclamo + ")";
                    cmd.Connection = obj.ObtenerConexionReclamos();
                    cmd.ExecuteNonQuery();
                    obj.conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    obj.DescargarConexion();
                }
            }
        }
    }
}