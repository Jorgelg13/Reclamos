using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamosAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenar = new Utils();
    int id;
    string ultimoIdAuto, ultimoIdReclamo, idCabina, idUsuario, codigo;
    string metodo = "sistema";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
      
        obtenerID();
    }

    protected void txtGuardarReclamo_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAutos.SelectedRow.Cells[1].Text);
        var registro = DBReclamos.ViewBusquedaAuto.Find(id);
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (registro.chasis == null)
        {
            Utils.ShowMessage(this.Page, "Debes seleccionar un auto", "Nota..!", "warning");
        }

        else
        {
            try
            {
                short edad = 0;
                TimeSpan hora = new TimeSpan(0,0,0);

                if(!String.IsNullOrEmpty(txtHora.Text))
                {
                    hora = TimeSpan.Parse(txtHora.Text);
                }

                if(!String.IsNullOrEmpty(txtEdad.Text))
                {
                    edad = Convert.ToInt16(txtEdad.Text);
                }

                auto_reclamo auto = new auto_reclamo();
                var sec_registro = DBReclamos.pa_sec_auto_reclamo();
                long? id_registro = sec_registro.Single();
                auto.id = Convert.ToInt64(id_registro);
                auto.placa = (registro.placa == "P-") ? "PENDIENTE" : registro.placa;
                auto.color = registro.color;
                auto.chasis =registro.chasis;
                auto.motor = registro.motor;
                auto.propietario = registro.propietario;
                auto.marca = registro.marca;
                auto.poliza = registro.poliza;
                auto.ejecutivo = registro.gst_nombre;
                auto.aseguradora = registro.nombre;
                auto.contratante = registro.contratante;
                auto.estado_poliza = registro.estado;
                auto.modelo = registro.modelo;
                auto.asegurado = registro.asegurado;
                auto.vip = registro.vip;
                auto.inciso = registro.inciso;
                auto.moneda = registro.moneda;
                auto.direccion = registro.direccion;
                auto.vigencia_inicial = registro.vigi;
                auto.vigencia_final = registro.vigf;
                auto.cia = Convert.ToInt16(registro.cia);
                auto.secren = Convert.ToInt16(registro.secren);
                auto.numero_gestor = Convert.ToInt16(registro.numero_gestor);
                auto.numRamo = Convert.ToInt16(registro.ramo);
                auto.cliente = Convert.ToInt32(registro.cliente);
                auto.programa = registro.programa;
                auto.vendedor = registro.vendedor.ToString();

                reclamo_auto reclamo = new reclamo_auto();
                var resultado = DBReclamos.pa_sec_reclamo_auto();
                long? id_reclamo = resultado.Single();
                reclamo.id = Convert.ToInt64(id_reclamo);
                reclamo.boleta = txtBoleta.Text;
                reclamo.titular = txtTitular.Text;
                reclamo.ubicacion = txtUbicacion.Text;
                reclamo.hora = hora;
                reclamo.fecha = Convert.ToDateTime(txtFecha.Text);
                reclamo.fecha_commit = DateTime.Now;
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.reportante = txtReportante.Text;
                reclamo.piloto = txtpiloto.Text;
                reclamo.telefono = txtTelefono.Text;
                reclamo.ajustador = txtAjustador.Text;
                reclamo.version = txtVersion.Text;
                reclamo.metodo = metodo.ToString();
                reclamo.id_estado = 1;
                reclamo.id_cabina = id1;
                reclamo.id_usuario = id2;
                reclamo.edad = edad;
                reclamo.tipo_servicio = DDLTipo.SelectedItem.ToString();
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.auto_reclamo = auto;
                reclamo.estado_unity = "Sin Cerrar";
                reclamo.usuario_unity = "Sin Asignar";

                DBReclamos.reclamo_auto.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdAuto = auto.id.ToString();
                ultimoIdReclamo = reclamo.id.ToString();
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo=" + ultimoIdReclamo + "&ultimoAuto=" + ultimoIdAuto + "&placa=" + registro.placa, false);
            }
            catch (Exception ex )
            {
               Utils.ShowMessage(this.Page, "A ocurrido un error inesperado intentelo de nuevo" + ex.Message, "Error", "error");
            }
        }
    }

    protected void GridAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBusqueda.Text = GridAutos.SelectedRow.Cells[10].Text;

        if (GridAutos.SelectedRow.Cells[4].Text == "Si")
        {
            Utils.ShowMessage(this.Page, "Tomar En cuenta que este cliente es VIP", "Nota..!", "info");
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalVip').modal('show');", addScriptTags: true);
        }
        if(GridAutos.SelectedRow.Cells[5].Text == "AUTO-249422")
        {
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#modal-recordatorio').modal('show');", addScriptTags: true);
        }
    }

    protected void btnResguardos_Click(object sender, EventArgs e)
    {
        Response.Redirect("wbFrmResguardosAutos.aspx");
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
        string consulta = "SELECT " +
            "id," +
            "placa as Placa, " +
            "propietario as Propietario, " +
            "asegurado as Asegurado," +
            "poliza as Poliza," +
            "nombre as Aseguradora, " +
            "gst_nombre as Ejecutivo,"+
            "inciso as Certificado,"+
            "marca as Marca," +
            "modelo as Modelo," +
            "color as Color,"+
            "chasis as Chasis," +
            "motor as Motor," +
            "estado as Estado," +
            "vigi as Vigencia_inicial," +
            "vigf as Vigencia_Final " +
            "FROM ViewBusquedaAuto WHERE " +
            "(placa like '%"+txtBusqueda.Text+"%') " +
            "OR (propietario COLLATE Latin1_General_CI_AI like '%"+txtBusqueda.Text+"%') " +
            "OR (poliza like '%"+txtBusqueda.Text+"%') " +
            "OR (chasis like '%"+txtBusqueda.Text+"%' ) " +
            "OR (contratante like '%"+txtBusqueda.Text+"%') " +
            "OR (asegurado COLLATE Latin1_General_CI_AI like '%"+txtBusqueda.Text+"%')";
        llenar.llenarGrid(consulta,GridAutos);
    }
}
