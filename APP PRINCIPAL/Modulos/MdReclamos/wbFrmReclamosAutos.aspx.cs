using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamos_wbFrmReclamosAutos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string ultimoIdAuto, ultimoIdReclamo, idCabina, idUsuario, codigo;
    string metodo = "sistema";
    public string auto, marca, estilo, color, chasis, motor, placa, contratante, propietario, ramo, modelo, 
        poliza, fechaInicial, fechaFinal, ejecutivo,aseguradora, estado, asegurado, vip, inciso, moneda, direccion, 
        cia, gestor, secren, numRamo, cliente, programa;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
      
        obtenerID();
    }

    public void obtenerAuto()
    {
        try
        {
            placa = GridAutos.SelectedRow.Cells[1].Text;
            propietario = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[2].Text);
            asegurado = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[3].Text);
            vip= GridAutos.SelectedRow.Cells[4].Text;
            poliza = GridAutos.SelectedRow.Cells[5].Text;
            aseguradora = GridAutos.SelectedRow.Cells[6].Text;
            marca = GridAutos.SelectedRow.Cells[7].Text;
            modelo = GridAutos.SelectedRow.Cells[8].Text;
            color = GridAutos.SelectedRow.Cells[9].Text;
            chasis = GridAutos.SelectedRow.Cells[10].Text;
            motor = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[11].Text);
            estado = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[12].Text);
            fechaInicial = GridAutos.SelectedRow.Cells[13].Text;
            fechaFinal = GridAutos.SelectedRow.Cells[14].Text;
            contratante = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[15].Text);
            ejecutivo = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[16].Text);
            inciso = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[17].Text);
            moneda = GridAutos.SelectedRow.Cells[19].Text;
            direccion = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[20].Text);
            cia = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[21].Text);
            secren = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[22].Text);
            gestor = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[23].Text);
            numRamo = HttpUtility.HtmlDecode(GridAutos.SelectedRow.Cells[24].Text);
            cliente = GridAutos.SelectedRow.Cells[25].Text;
            programa = GridAutos.SelectedRow.Cells[26].Text;

            if (GridAutos.SelectedRow.Cells[1].Text == "P-")
            {
                placa = "PENDIENTE";
            }
        }

        catch(Exception)
        {
            Utils.ShowMessage(this.Page,"No se pudieron obtener los datos", "Nota","warning");
        }
    }

    protected void txtGuardarReclamo_Click(object sender, EventArgs e)
    {
        obtenerAuto();
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (chasis == null)
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
                auto.placa = placa.ToString();
                auto.color = color.ToString();
                auto.chasis = chasis.ToString();
                auto.motor = motor.ToString();
                auto.propietario = propietario.ToString();
                auto.marca = marca.ToString();
                auto.poliza = poliza.ToString();
                auto.ejecutivo = ejecutivo.ToString();
                auto.aseguradora = aseguradora.ToString();
                auto.contratante = contratante.ToString();
                auto.estado_poliza = estado.ToString();
                auto.modelo = modelo.ToString();
                auto.asegurado = asegurado.ToString();
                auto.vip = vip.ToString();
                auto.inciso = inciso.ToString();
                auto.moneda = moneda.ToString();
                auto.direccion = direccion.ToString();
                auto.vigencia_inicial = Convert.ToDateTime(fechaInicial);
                auto.vigencia_final = Convert.ToDateTime(fechaFinal);
                auto.cia = Convert.ToInt16(cia);
                auto.secren = Convert.ToInt16(secren);
                auto.numero_gestor = Convert.ToInt16(gestor);
                auto.numRamo = Convert.ToInt16(numRamo);
                auto.cliente = Convert.ToInt32(cliente);
                auto.programa = programa.ToString();

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
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo=" + ultimoIdReclamo + "&ultimoAuto=" + ultimoIdAuto + "&placa=" + placa, false);
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
}
