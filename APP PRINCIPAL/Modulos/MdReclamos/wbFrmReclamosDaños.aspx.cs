using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamosDaños : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils util = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;
    String metodo = "sistema";
    String ultimoIdReclamoDano, ultimoIdRegDano, idCabina, idUsuario, codigo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!util.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        obtenerID();
        txtReportante.Focus();
    }


    protected void btnGuardarReclamo_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridDaños.SelectedRow.Cells[1].Text);
        var reg = DBReclamos.vistaReclamosDaños.Find(id);
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (reg.poliza == null)
        {
            Utils.ShowMessage(this.Page, "Debes seleccionar una poliza", "Nota..!", "warning");
        }

        else
        {
            try
            {
                TimeSpan hora = new TimeSpan(0, 0, 0);

                if (!String.IsNullOrEmpty(txtHora.Text))
                {
                    hora = TimeSpan.Parse(txtHora.Text);
                }

                reg_reclamo_varios registro = new reg_reclamo_varios();
                var sec_registro = DBReclamos.pa_sec_reg_reclamos_danios_varios();
                long? id_registro = sec_registro.Single();
                registro.id = Convert.ToInt32(id_registro);
                registro.poliza = reg.poliza;
                registro.asegurado = reg.asegurado;
                registro.cliente = Convert.ToInt32(reg.cliente);
                registro.status = reg.status;
                registro.tipo = reg.tipo;
                registro.direccion = reg.direccion;
                registro.ramo = reg.ramo;
                registro.ejecutivo = reg.gst_nombre;
                registro.aseguradora = reg.aseguradora;
                registro.contratante = reg.contratante;
                registro.vip = reg.vip;
                registro.suma_asegurada = Convert.ToDecimal(reg.suma_aseg);
                registro.moneda = reg.moneda;
                registro.num_ramo = Convert.ToInt16(reg.num_ramo);
                registro.gestor = Convert.ToInt16(reg.numero_gestor);
                registro.cia = Convert.ToInt16(reg.cia);
                registro.secren = Convert.ToInt16(reg.secren);
                registro.vendedor = reg.vendedor.ToString();
                registro.contacto = reg.contacto;
                registro.telefono_contacto = reg.telefono_contacto;
                registro.correo_contacto = reg.correo;

                if (txtReportante.Text == "" || txtTelefono.Text == "" || txtFecha.Text == "")
                {
                    Utils.ShowMessage(this.Page, "Los campos reportantes, telefono, y fecha son requeridos", "Nota..!", "warning");
                }

                reclamos_varios reclamo = new reclamos_varios();
                var reclamo_id = DBReclamos.pa_sec_reclamos_varios();
                long? id_reclamo = reclamo_id.Single();
                reclamo.id = Convert.ToInt32(id_reclamo);
                reclamo.boleta = txtBoleta.Text;
                reclamo.titular = txtTitular.Text;
                reclamo.ubicacion = txtUbicacion.Text;
                reclamo.tipo_servicio = ddlTipoServicio.SelectedItem.Text;
                reclamo.hora = hora;
                reclamo.fecha = Convert.ToDateTime(txtFecha.Text);
                reclamo.fecha_commit = DateTime.Now;
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.reportante = txtReportante.Text;
                reclamo.telefono = txtTelefono.Text;
                reclamo.ajustador = txtAjustador.Text;
                reclamo.version = txtVersion.Text;
                reclamo.metodo = metodo;
                reclamo.id_estado = 1;
                reclamo.id_usuario = id2;
                reclamo.id_cabina = id1;
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.estado_unity = "Sin Cerrar";
                reclamo.usuario_unity = "Sin Asignar";
                reclamo.reg_reclamo_varios = registro;

                DBReclamos.reclamos_varios.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdReclamoDano = reclamo.id.ToString();
                ultimoIdRegDano = registro.id.ToString();
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosDañosEditar.aspx?ID_reclamo=" + ultimoIdReclamoDano + "&ultimoIdRegistrosDaños=" + ultimoIdRegDano + "&poliza=" + reg.poliza);
            }

            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "A ocurrido algo inesperado intentelo nuevamente", "Error", "error");
            }
        }
    }

    protected void GridDaños_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridDaños.SelectedRow.Cells[1].Text);
        var registro = DBReclamos.vistaReclamosDaños.Find(id);
        txtBusqueda.Text = registro.poliza;

        if (registro.vip == "Si")
        {
            Utils.ShowMessage(this.Page, "Tome en cuenta que este asegurado en VIP", "Nota.. !", "Info");
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string consulta = "SELECT id, " +
            "poliza as Poliza, " +
            "asegurado as Asegurado," +
            "aseguradora as Aseguradora, " +
            "contratante as Contratante, " +
            "ramo as Ramo,"+
            "vip as Vip," +
            "vigi as Vigencia_Inicial, " +
            "vigf as Vigencia_Final, " +
            "status as Estado, " +
            "gst_nombre as Gestor, " +
            "moneda as Moneda " +
            "FROM vistaReclamosDaños " +
            "where (poliza like '%"+txtBusqueda.Text+"%') " +
            "or (asegurado COLLATE Latin1_General_CI_AI like '%"+txtBusqueda.Text+"%') " +
            "or (contratante like '%"+txtBusqueda.Text+"%')";

        util.llenarGrid(consulta,GridDaños);
    }
}