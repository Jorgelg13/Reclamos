using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamosDaños : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String asegurado, poliza, fechaInicio, fechaFinal, ramo, cliente, status, tipo, direccion, ejecutivo, 
           aseguradora, contratante,vip, moneda,num_ramo,gestor,cia, secren ;
    String metodo = "sistema";
    String ultimoIdReclamoDano, ultimoIdRegDano, idCabina, idUsuario, codigo;
    Double sumaAsegurada;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }

        obtenerID();
        txtReportante.Focus();
    }

    public void obtenerDatos()
    {
        try
        {
            poliza = GridDaños.SelectedRow.Cells[1].Text.ToString();
            asegurado = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[2].Text);
            vip = GridDaños.SelectedRow.Cells[3].Text;
            aseguradora = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[4].Text);
            contratante = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[5].Text);
            ramo = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[6].Text);
            fechaInicio = GridDaños.SelectedRow.Cells[7].Text.ToString();
            fechaFinal = GridDaños.SelectedRow.Cells[8].Text.ToString();
            status = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[9].Text);
            direccion = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[10].Text);
            ejecutivo = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[11].Text);
            cliente = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[12].Text);
            tipo = HttpUtility.HtmlDecode(GridDaños.SelectedRow.Cells[13].Text);
            sumaAsegurada = Convert.ToDouble(GridDaños.SelectedRow.Cells[14].Text);
            moneda = GridDaños.SelectedRow.Cells[15].Text;
            num_ramo = GridDaños.SelectedRow.Cells[16].Text;
            gestor = GridDaños.SelectedRow.Cells[17].Text;
            cia = GridDaños.SelectedRow.Cells[18].Text;
            secren = GridDaños.SelectedRow.Cells[19].Text;
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudieron obtener los datos seleccionados", "Nota..!", "warning");
        }
    }

    protected void btnGuardarReclamo_Click(object sender, EventArgs e)
    {
        obtenerDatos();
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (poliza == null)
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
                registro.poliza = poliza.ToString();
                registro.asegurado = asegurado.ToString();
                registro.cliente = Convert.ToInt32(cliente);
                registro.status = status.ToString();
                registro.tipo = tipo.ToString();
                registro.direccion = direccion.ToString();
                registro.ramo = ramo.ToString();
                registro.ejecutivo = ejecutivo.ToString();
                registro.aseguradora = aseguradora.ToString();
                registro.contratante = contratante.ToString();
                registro.vip = vip.ToString();
                registro.suma_asegurada = Convert.ToDecimal(sumaAsegurada);
                registro.moneda = moneda.ToString();
                registro.num_ramo = Convert.ToInt16(num_ramo);
                registro.gestor = Convert.ToInt16(gestor);
                registro.cia = Convert.ToInt16(cia);
                registro.secren = Convert.ToInt16(secren);

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
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosDañosEditar.aspx?ID_reclamo=" + ultimoIdReclamoDano + "&ultimoIdRegistrosDaños=" + ultimoIdRegDano + "&poliza=" + poliza);
            }

            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "A ocurrido algo inesperado intentelo nuevamente", "Error", "error");
            }
        }
    }

    protected void GridDaños_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBusqueda.Text = GridDaños.SelectedRow.Cells[1].Text;

        if (GridDaños.SelectedRow.Cells[3].Text == "Si")
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
}