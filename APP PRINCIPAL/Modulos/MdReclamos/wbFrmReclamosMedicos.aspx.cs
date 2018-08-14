using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmReclamosMedicos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string ultimoIdRegMedico, ultimoIdReclamo, idCabina, idUsuario, codigo, titularPoliza, titular;
    string metodo = "sistema";
    public string asegurado, poliza, ramo, tipo, clase, ejecutivo, aseguradora, 
    contratante,estado,vip,moneda, dependiente, certificado, secren, cliente, mensaje;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx",false); 
        }

        obtenerID();
    }

    public void obtenerDatosPoliza()
    {
        try
        {
            poliza = GridMedicos.SelectedRow.Cells[1].Text;
            asegurado = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[2].Text);
            vip = GridMedicos.SelectedRow.Cells[3].Text;
            aseguradora = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[4].Text);
            ejecutivo = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[5].Text);
            tipo = GridMedicos.SelectedRow.Cells[8].Text;
            clase = GridMedicos.SelectedRow.Cells[9].Text;
            ramo = GridMedicos.SelectedRow.Cells[10].Text;
            contratante = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[11].Text);
            estado = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[12].Text);
            moneda = GridMedicos.SelectedRow.Cells[13].Text;
            certificado = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[14].Text);
            secren = GridMedicos.SelectedRow.Cells[15].Text;
            cliente = GridMedicos.SelectedRow.Cells[16].Text;
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al obtener los datos seleccionados", "Nota..!", "Warning");
        }
    }

    protected void GridMedicos_SelectedIndexChanged(object sender, EventArgs e)
    {
        obtenerDatosPoliza();
       
        if (GridMedicos.SelectedRow.Cells[3].Text == "Si")
        {
            Utils.ShowMessage(this.Page,"Tome en cuenta que este asegurado es vip", "Excelente..!", "info");
        }

        if (clase == "Dependiente")
        {
            buscar_titular(asegurado, poliza,certificado);
            txtAsegurado.Text = titularPoliza;
            txtDependiente.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[2].Text);
            txtAseguradora.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[4].Text);
            txtpoliza.Text = GridMedicos.SelectedRow.Cells[1].Text;
            txtEmpresa.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[11].Text);
            clase = GridMedicos.SelectedRow.Cells[9].Text;
        }
        else
        {
            txtDependiente.Text = "";
            txtAsegurado.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[2].Text);
            txtAseguradora.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[4].Text);
            txtpoliza.Text = GridMedicos.SelectedRow.Cells[1].Text;
            txtEmpresa.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[11].Text);
            clase = GridMedicos.SelectedRow.Cells[9].Text;
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

    public void llenarGrid()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(buscador(txtBusqueda.Text.ToString()), obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridMedicos.DataSource = dt;
            GridMedicos.DataBind();
        }

        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al realizar la busqueda", "Nota..!", "error");
        }
    }

    //buscador inteligente que busca no importando el orden de los nombres
    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT poliza as Poliza, asegurado as Asegurado, vip as VIP, nombre as Aseguradora," +
                "gst_nombre as Gestor, vigi as [Vigencia Inicial], vigf as [Vigencia Final], tipo as Tipo, clase as Clase, ramo as Ramo, contratante as Contratante, estado_poliza as [Estado Poliza], moneda as Moneda, certificado as Certificado, secren as [Secuencia Renovacion], cliente as Cliente FROM vistaReclamosMedicos Where asegurado like '%" + arreglo[0] + "%' ";

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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenarGrid();
    }

    private void guardar()
    {
        try
        {
            obtenerDatosPoliza();
            idCabina = (string)(Session["id_cabina"]);
            idUsuario = (string)(Session["id_usuario"]);
            codigo = (string)(Session["codigo"]);
            int id1 = Convert.ToInt32(idCabina);
            int id2 = Convert.ToInt32(idUsuario);

            reg_reclamos_medicos registro = new reg_reclamos_medicos();
            var sec_registro = DBReclamos.pa_sec_registros_medicos();
            long? id_registro = sec_registro.Single();
            registro.id = Convert.ToInt64(id_registro);
            registro.asegurado = asegurado.ToString();
            registro.poliza = poliza.ToString();
            registro.ramo = ramo.ToString();
            registro.tipo = tipo.ToString();
            registro.clase = clase.ToString();
            registro.ejecutivo = ejecutivo.ToString();
            registro.aseguradora = aseguradora.ToString();
            registro.contratante = contratante.ToString();
            registro.estado_poliza = estado.ToString();
            registro.vip = vip.ToString();
            registro.moneda = moneda.ToString();
            registro.certificado = certificado.ToString();
            registro.secren = Convert.ToInt16(secren);
            registro.tipo_registro = "Gasto Medico";
            registro.cliente = Convert.ToInt32(cliente);

            reclamos_medicos reclamo = new reclamos_medicos();
            var results = DBReclamos.pa_sec_reclamos_medicos();
            long? resultado = results.Single();
            reclamo.id = Convert.ToInt64(resultado);
            reclamo.asegurado = asegurado.ToString();
            reclamo.titular = txtAsegurado.Text.ToString();
            reclamo.telefono = txtTelefono.Text.ToString();
            reclamo.correo = txtCorreo.Text.ToString();
            reclamo.empresa = txtEmpresa.Text.ToString();
            reclamo.metodo = "sistema";
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

            if(tipo == "I")
            {
                if (txtDependiente.Text == "")
                {
                    mensaje = "UNITY: Estimad@ cliente recibimos la documentación para tramitar su reclamo a nombre de " + txtAsegurado.Text.Trim() + ", puedes hacer consultas a tu ejecutivo sobre los avances con el siguiente código ID: " + reclamo.id + ".";
                }
                else
                {
                    mensaje = "UNITY: Estimad@ cliente recibimos la documentación para tramitar su reclamo a nombre de " + txtDependiente.Text.Trim() + ", puedes hacer consultas a tu ejecutivo sobre los avances con el siguiente código ID: " + reclamo.id + ".";
                }

                Utils.SMS_gastos_medicos(txtTelefono.Text, mensaje, userlogin, "Apertura", reclamo.id, tipo);
            }

            Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosMedicosEditar.aspx?ID_reclamo=" + ultimoIdReclamo, false);
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "A ocurrido un error al guardar el registro " + ex.Message, "Nota..!", "error");
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        obtenerDatosPoliza();

        if (poliza == "")
        {
            Utils.ShowMessage(this.Page, "Debes buscar y seleccionar un asegurado", "warning");
        }

        else
        {
            if (tipo == "I" && txtTelefono.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo asegurado y telefono son obligatorios", "info");
            }

            else
            {
                guardar();
            }
        }
    }

    //metodo para insertar los documentos que trae el asegurado y que son recibidos en recepcion
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

    private string buscar_titular(string buscarAsegurado, string buscarPoliza, string buscarCertificado)
    {
        try
        {
            titular = "SELECT asegurado from vistaReclamosMedicos where clase = 'Principal' and poliza = '"+ buscarPoliza + "' and certificado = '" + buscarCertificado + "' ";
            SqlDataAdapter da = new SqlDataAdapter(titular, obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            titularPoliza = HttpUtility.HtmlDecode(dt.Rows[0][0].ToString());
            obj.conexion.Close();
        }
        catch(Exception)
        {
            Utils.ShowMessage(this.Page, "No se encontro el titular de esta poliza", "Error..!", "error");
        }
        finally
        {
            obj.DescargarConexion();
        }

        return titularPoliza;
    }
}

