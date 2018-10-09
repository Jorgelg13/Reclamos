using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmAutorizaciones : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    string ultimoIdRegMedico, ultimoIdAutorizacion, idCabina, idUsuario, codigo;
    string metodo = "sistema";
    public string asegurado, poliza, ramo, tipo, clase, ejecutivo, aseguradora, 
                  contratante, estado,vip, secren, cliente, moneda, certificado;
    bool tramiteDirecto = false;
    ReclamosEntities DBReclamos = new ReclamosEntities();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        obtenerID();
    }

    public void obtenerDatosPoliza()
    {
        try
        {
            poliza = GridAutorizaciones.SelectedRow.Cells[1].Text;
            asegurado = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[2].Text);
            vip = GridAutorizaciones.SelectedRow.Cells[3].Text;
            aseguradora = GridAutorizaciones.SelectedRow.Cells[4].Text;
            ejecutivo = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[5].Text);
            tipo = GridAutorizaciones.SelectedRow.Cells[8].Text;
            clase = GridAutorizaciones.SelectedRow.Cells[9].Text;
            ramo = GridAutorizaciones.SelectedRow.Cells[10].Text;
            contratante = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[11].Text);
            estado = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[12].Text);
            moneda = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[13].Text);
            certificado = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[14].Text);
            secren = GridAutorizaciones.SelectedRow.Cells[15].Text;
            cliente = GridAutorizaciones.SelectedRow.Cells[16].Text;
        }

        catch (Exception)
        {

        }
    }

    public void guardar()
    {
        obtenerDatosPoliza();

        if (poliza == null)
        {
            Utils.ShowMessage(this.Page, "Debe de seleccionar un asegurado", "Nota..!", "warning");
        }

        else
        {
            try
            {
                if (checkTramiteDirecto.Checked)
                {
                    tramiteDirecto = true;
                }
                idCabina = (string)(Session["id_cabina"]);
                idUsuario = (string)(Session["id_usuario"]);
                codigo = (string)(Session["codigo"]);

                int id1 = Convert.ToInt32(idCabina);
                int id2 = Convert.ToInt32(idUsuario);
                int codigoP = Convert.ToInt32(codigo);

                if (txtReportante.Text == "")
                {
                    Utils.ShowMessage(this.Page, "El campo reportante es obligatorio", "Nota..!", "warning");
                }

                else
                {
                    reg_reclamos_medicos reg = new reg_reclamos_medicos();
                    var sec_registro = DBReclamos.pa_sec_registros_medicos();
                    long? id_registro = sec_registro.Single();
                    reg.id = Convert.ToInt64(id_registro);
                    reg.asegurado = asegurado.ToString();
                    reg.poliza = poliza.ToString();
                    reg.ramo = ramo.ToString();
                    reg.tipo = tipo.ToString();
                    reg.clase = clase.ToString();
                    reg.ejecutivo = ejecutivo.ToString();
                    reg.aseguradora = aseguradora.ToString();
                    reg.contratante = contratante.ToString();
                    reg.estado_poliza = estado.ToString();
                    reg.vip = vip.ToString();
                    reg.secren = Convert.ToInt16(secren);
                    reg.tipo_registro = "Autorizacion";
                    reg.cliente = Convert.ToInt32(cliente);
                    reg.moneda = moneda.ToString();
                    reg.certificado = certificado.ToString();

                    autorizaciones autorizacion = new autorizaciones();
                    var results = DBReclamos.pa_sec_autorizaciones();
                    long? id_autorizacion = results.Single();
                    autorizacion.id = Convert.ToInt64(id_autorizacion);
                    autorizacion.reportante = txtReportante.Text;
                    autorizacion.tipo_consulta = DDLTipo.SelectedItem.ToString();
                    autorizacion.tipo_estado = DDLEstado.SelectedItem.ToString();
                    autorizacion.correo = txtCorreo.Text;
                    autorizacion.telefono = txtTelefono.Text;
                    autorizacion.metodo = metodo.ToString();
                    autorizacion.id_usuario = id2;
                    autorizacion.id_cabina = id1;
                    autorizacion.codigo_pais = Convert.ToInt16(codigoP);
                    autorizacion.tramite_directo = tramiteDirecto;
                    autorizacion.fecha_commit = DateTime.Now;
                    autorizacion.fecha_completa_commit = DateTime.Now;
                    autorizacion.hora_commit = DateTimeOffset.Now.TimeOfDay;
                    autorizacion.reg_reclamos_medicos = reg;
                    DBReclamos.autorizaciones.Add(autorizacion);
                    DBReclamos.SaveChanges();

                    ultimoIdRegMedico = reg.id.ToString();
                    ultimoIdAutorizacion = autorizacion.id.ToString();
                    Utils.ShowMessage(this.Page, "La autorizacion a sido guardada con exito, puede seguir agregando mas autorizaciones de este asegurado", "Excelente..", "success");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(this.Page, "Error en insercion.. " + ex.Message, "Nota..!", "error");
            }
        }
    }

    protected void btnGuardarAutorizacion_Click(object sender, EventArgs e)
    {
        guardar();
        Response.Redirect("/Modulos/MdReclamos/wbFrmAutorizacionesEditar.aspx?ID_reclamo=" + ultimoIdAutorizacion + "&ultimaAutorizacion=" + ultimoIdRegMedico + "&poliza=" + poliza);
    }

    protected void GridAutorizaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtReportante.Text = HttpUtility.HtmlDecode(GridAutorizaciones.SelectedRow.Cells[2].Text.ToString());
        if (GridAutorizaciones.SelectedRow.Cells[3].Text == "Si")
        {
            Utils.ShowMessage(this.Page, "Tomar en cuenta que este cliente es VIP", "Nota..!", "info");
        }
    }

    public void obtenerID()
    {
        try
        {
            var usuario = DBReclamos.usuario.Select(U => new { U.id, U.id_cabina, U.codigo, U.nombre } ).Where(us => us.nombre == userlogin).First();
            Session.Add("id_usuario", usuario.id.ToString());
            Session.Add("id_cabina", usuario.id_cabina.ToString());
            Session.Add("codigo", usuario.codigo.ToString());
        }

        catch (Exception)
        {

        }
    }

    //funcion para llenar el grid de forma manual
    public void llenarGrid()
    {
        try
        {
            llenado.llenarGrid(buscador(txtBusqueda.Text), GridAutorizaciones);
            GridAutorizaciones.DataBind();
        }

        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    //funcion para hacer una busqueda optima de los asegurados 
    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT poliza as Poliza, asegurado as Asegurado, vip as VIP, nombre as Aseguradora," +
                "gst_nombre as Gestor, vigi as Vigencia_Inicial, vigf as Vigencia_Final, tipo as Tipo, clase as Clase, ramo as Ramo, contratante as Contratante, " +
                "estado_poliza as Estado_Poliza, moneda as Moneda, certificado as Certificado, secren as [Secuencia Renovacion], cliente as Cliente FROM vistaReclamosMedicos Where asegurado like '%" + arreglo[0] + "%' ";

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

    protected void btnAgregarNueva_Click(object sender, EventArgs e)
    {
        guardar();
    }
}
