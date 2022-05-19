using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdFlotillas_buscar_auto : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils comprobar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenar = new Utils();
    int id;
    string ultimoIdAuto, ultimoIdReclamo, idCabina, idUsuario, codigo;
    string metodo = "flotilla";

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
        idCabina = (string)(Session["id_cabina"]);
        idUsuario = (string)(Session["id_usuario"]);
        codigo = (string)(Session["codigo"]);
        int id1 = Convert.ToInt32(idCabina);
        int id2 = Convert.ToInt32(idUsuario);

        if (GridAutos.SelectedRow.Cells[1].Text == null)
        {
            Utils.ShowMessage(this.Page, "Debe seleccionar un auto", "Nota..!", "warning");
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

                auto_reclamo auto = new auto_reclamo();
                var sec_registro = DBReclamos.pa_sec_auto_reclamo();
                long? id_registro = sec_registro.Single();
                auto.id = Convert.ToInt64(id_registro);
                auto.placa = GridAutos.SelectedRow.Cells[10].Text;
                auto.color = GridAutos.SelectedRow.Cells[9].Text;
                auto.chasis = GridAutos.SelectedRow.Cells[6].Text;
                auto.motor = GridAutos.SelectedRow.Cells[7].Text;
                auto.marca = GridAutos.SelectedRow.Cells[4].Text;
                auto.aseguradora = GridAutos.SelectedRow.Cells[11].Text;
                auto.asegurado = GridAutos.SelectedRow.Cells[12].Text;
                auto.poliza = GridAutos.SelectedRow.Cells[13].Text;
                auto.ejecutivo = GridAutos.SelectedRow.Cells[14].Text;
                auto.propietario = GridAutos.SelectedRow.Cells[3].Text;

                reclamo_auto reclamo = new reclamo_auto();
                var resultado = DBReclamos.pa_sec_reclamo_auto();
                long? id_reclamo = resultado.Single();
                reclamo.id = Convert.ToInt64(id_reclamo);
                reclamo.boleta = txtBoleta.Text;
                reclamo.titular = txtTitular.Text;
                reclamo.ubicacion = txtUbicacion.Text;
                reclamo.hora = hora;
                reclamo.fecha = Convert.ToDateTime(txtFecha.Text);
                reclamo.hora_commit = DateTimeOffset.Now.TimeOfDay;
                reclamo.fecha_commit = DateTime.Now;
                reclamo.reportante = txtReportante.Text;
                reclamo.piloto = txtpiloto.Text;
                reclamo.telefono = txtTelefono.Text;
                reclamo.ajustador = txtAjustador.Text;
                reclamo.version = txtVersion.Text;
                reclamo.metodo = metodo.ToString();
                reclamo.id_estado = 1;
                reclamo.id_cabina = id1;
                reclamo.id_usuario = id2;
                reclamo.tipo_servicio = DDLTipo.SelectedItem.ToString();
                reclamo.codigo_pais = Convert.ToInt16(codigo);
                reclamo.estado_unity = "Sin Cerrar";
                reclamo.usuario_unity = "Sin Asignar";
                reclamo.auto_reclamo = auto;

                DBReclamos.reclamo_auto.Add(reclamo);
                DBReclamos.SaveChanges();
                ultimoIdAuto = auto.id.ToString();
                ultimoIdReclamo = reclamo.id.ToString();
                Response.Redirect("/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo=" + ultimoIdReclamo + "&ultimoAuto=" + ultimoIdAuto + "&placa=" + GridAutos.SelectedRow.Cells[10].Text);

            }
            catch (Exception ex)
            {
                Response.Write(ex);
                Utils.ShowMessage(this.Page, "A ocurrido un error inesperado intentelo de nuevo", "Error", "error");
            }
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string consulta = "SELECT " +
            "id," +
            "inciso as Inciso, " +
            "propietario as Propietario, " +
            "marca as Marca," +
            "linea as Linea," +
            "chasis as Chasis," +
            "motor as Motor," +
            "year as Año," +
            "color as Color," +
            "placa as Placa, " +
            "aseguradora as Aseguradora, " +
            "asegurado as Asegurado," +
            "poliza as Poliza," +
            "ejecutivo as Ejecutivo "+
            "FROM flotillas WHERE " +
            "(placa like '%" + txtBusqueda.Text + "%') " +
            "OR (propietario COLLATE Latin1_General_CI_AI like '%" + txtBusqueda.Text + "%') " +
            "OR (chasis like '%" + txtBusqueda.Text + "%' ) " +
            "OR (motor like '%" + txtBusqueda.Text + "%')";
        llenar.llenarGrid(consulta, GridAutos);
    }

    protected void GridAutos_SelectedIndexChanged(object sender, EventArgs e)
    {

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