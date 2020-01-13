using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Modulos_Consultas_consultas : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en session
    ReclamosEntities DB = new ReclamosEntities();
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    String Consulta, contenidoCorreo, correoUsuario, coberturas;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        vaciarGrid();
        PnAsegurados.Visible = false;
        PnDanios.Visible = false;
        PnAutos.Visible = false;
        llenado.llenarGrid(buscador(txtBuscar.Text), GridRegistros);
    }

    protected void GridRegistros_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridRegistros.SelectedRow.Cells[1].Text);
        int tipo = Convert.ToInt32(GridRegistros.SelectedRow.Cells[2].Text);
        lblTipo.Text = tipo.ToString();

        if (tipo == 1)
        {
            PnAsegurados.Visible = false;
            PnDanios.Visible = false;
            PnAutos.Visible = true;
            var registro = DB.ViewBusquedaAuto.Find(id);
            lblPoliza.Text = registro.poliza;
            lblAsegurado.Text = registro.asegurado;
            lblCliente.Text = registro.cliente.ToString();
            lblEjecutivo.Text = registro.gst_nombre;
            lblAseguradora.Text = registro.nombre;
            lblContratante.Text = registro.contratante;
            lblEstado.Text = registro.estado;
            lblPrograma.Text = registro.programa;
            lblVigi.Text = registro.vigi.ToString();
            lblVigf.Text = registro.vigf.ToString();

            lblPlaca.Text = registro.placa;
            lblMarca.Text = registro.marca;
            lblColor.Text = registro.color;
            lblModelo.Text = registro.modelo;
            lblChasis.Text = registro.chasis;
            lblMotor.Text = registro.motor;

            lblVigencia.Text = vigencia(Convert.ToDateTime(registro.vigf)).ToString();
            lblVigencia.ForeColor = (vigencia(Convert.ToDateTime(registro.vigf)) > 0)
            ? System.Drawing.Color.Green
            : System.Drawing.Color.Red;

            coberturas = "select top 40 descr as Nombre,limite1 as [Limite 1], limite2 as[Limite 2],deducible as Deducible, prima as Prima, sumaaseg as [Suma Asegurada] from viewCoberturasAutos WHERE (chasis like '%" + registro.chasis + "%')";
            llenado.llenarGrid(coberturas, GridCoberturas);

            reclamosAutos(registro.placa);

            Consulta = "select count(*) from reclamo_auto as r " +
                "inner join auto_reclamo as a on a.id = r.id_auto_reclamo " +
                "where a.placa = '" + registro.placa + "' and r.estado_unity = 'Seguimiento'";
            lblTotalReclamos.Text = conteo(Consulta);

            Consulta = "select count(*) from reclamo_auto as r inner join auto_reclamo as a on a.id = r.id_auto_reclamo" +
                " where a.placa = '" + registro.placa + "' and YEAR(r.fecha_apertura_reclamo) = YEAR(GETDATE())";
            lblTotalAnio.Text = conteo(Consulta);

            //Consulta = "select DATEDIFF(DAY, fecha_commit, GETDATE()) from reclamos_medicos where id = "+id+" ";
            //lblDiasAbierto.Text = conteo(Consulta);
        }

        if (tipo == 2)
        {
            PnAsegurados.Visible = false;
            PnAutos.Visible = false;
            PnDanios.Visible = true;
            var registro = DB.vistaReclamosDaños.Find(id);
            lblPolizaDanios.Text = registro.poliza;
            lblAseguradoDanios.Text = registro.asegurado;
            lblClienteDanios.Text = registro.cliente.ToString();
            lblEjecutivoDanios.Text = registro.gst_nombre;
            lblAseguradoraDanios.Text = registro.aseguradora;
            lblContratanteDanios.Text = registro.contratante;
            lblEstatoDanios.Text = registro.status;
            lblDireccionDanios.Text = registro.direccion;
            lblVigiDanios.Text = registro.vigi.ToString();
            lblVigfDanios.Text = registro.vigf.ToString();

            lblVigenciaDanios.Text = vigencia(Convert.ToDateTime(registro.vigf)).ToString();
            lblVigenciaDanios.ForeColor = (vigencia(Convert.ToDateTime(registro.vigf)) > 0)
            ? System.Drawing.Color.Green
            : System.Drawing.Color.Red;

            coberturas = "SELECT descr as Nombre, poliza as Poliza, sumaaseg as [Suma Asegurada], limite1 as [Limite 1]," +
                "limite2 as [Limite 2],deducible as Deducible, prima as Prima FROM busqCoberturasPolizasDaños WHERE ( poliza like '%" + registro.poliza + "%')";
            llenado.llenarGrid(coberturas, GridCoberturas);

            reclamosDanios(registro.poliza);

            Consulta = "select count(*) from reclamos_varios as r " +
               "inner join reg_reclamo_varios as reg on reg.id = r.id_reg_reclamos_varios " +
               "where reg.poliza = '" + registro.poliza + "' and r.estado_unity = 'Seguimiento'";
            lblTotalReclamos.Text = conteo(Consulta);

            Consulta = "select count(*) from reclamos_varios as r " +
                "inner join reg_reclamo_varios as reg on reg.id = r.id_reg_reclamos_varios" +
                " where reg.poliza = '" + registro.poliza + "' and YEAR(r.fecha_apertura_reclamo) = YEAR(GETDATE())";
            lblTotalAnio.Text = conteo(Consulta);
        }

        if (tipo == 3)
        {
            PnAutos.Visible = false;
            PnDanios.Visible = false;
            PnAsegurados.Visible = true;
            var registro = DB.vistaReclamosMedicos.Find(id);
            lblAseguradoMedicos.Text = registro.asegurado;
            lblPolizaAsegurado.Text = registro.poliza;
            lblRamoAsegurado.Text = (registro.ramo == "123") ? "Colectivo Vida Y Gastos Médicos" : ((registro.ramo == "7") ? "Vida Individual" : "Gastos Médicos Individual");
            lblTipoAsegurado.Text = (registro.tipo == "I") ? "Individual" : "Colectivos";
            lblClaseAsegurado.Text = registro.clase;
            lblEjecutivoAsegurado.Text = registro.gst_nombre;
            lblAseguradoraAsegurado.Text = registro.nombre;
            lblContratanteAsegurado.Text = registro.contratante;
            lblEstadoAsegurado.Text = registro.status;
            lblVip.Text = registro.vip;
            lblVigiAsegurado.Text = registro.vigi.ToString();
            lblVigfAsegurado.Text = registro.vigf.ToString();

            lblVigenciaAsegurado.Text = vigencia(Convert.ToDateTime(registro.vigf)).ToString();
            lblVigenciaAsegurado.ForeColor = (vigencia(Convert.ToDateTime(registro.vigf)) > 0)
            ? System.Drawing.Color.Green
            : System.Drawing.Color.Red;

            if (registro.tipo == "C")
            {
                coberturas = "select descripcion,beneficio from beneficios_hospitalarios as b inner join  coberturas_hospitalarias " +
                    "ch on b.codcobertura = ch.codCobertura and b.grupo = ch.grupo where b.poliza = '" + registro.poliza + "' and b.secren = " + registro.secren + " and" +
                    " b.clase = 1 and b.beneficio not in('NO APLICA', '0', 'NO CUBIERTO', '0.00', '')";
            }
            else
            {
                coberturas = "SELECT descr as Descripcion, limite1, limite2, deducible,prima FROM cobeart INNER JOIN cobertura ON cobertura = cober" +
                    " WHERE poliza = '" + registro.poliza + "' AND secren = " + registro.secren + " AND cobertura.ramo = 9; ";
            }

            llenado.llenarGrid2(coberturas, GridCoberturas);
        }
    }

    private string conteo(string consulta)
    {
        SqlDataAdapter da = new SqlDataAdapter(consulta, objeto.ObtenerConexionReclamos());
        DataTable dt = new DataTable();
        da.Fill(dt);
        objeto.conexion.Close();
        return dt.Rows[0][0].ToString();
    }

    private void reclamosAutos(string placa)
    {
        Consulta = "select r.id as ID, r.estado_auto_unity as Estado from reclamo_auto as r " +
            "inner join auto_reclamo as a on a.id = r.id_auto_reclamo " +
            "where a.placa = '" + placa + "' and estado_unity = 'Seguimiento'";
        llenado.llenarGrid(Consulta, GridReclamos);
    }

    private void reclamosDanios(string poliza)
    {
        Consulta = "select r.id, r.estado_reclamo_unity  from reclamos_varios as r " +
            "inner join reg_reclamo_varios as reg on reg.id = r.id_reg_reclamos_varios " +
            "where reg.poliza = '" + poliza + "' and r.estado_unity = 'Seguimiento'";
        llenado.llenarGrid(Consulta, GridReclamos);
    }

    private int vigencia(DateTime vigf)
    {
        int total;
        DateTime final = vigf;
        DateTime hoy = DateTime.Now;
        total = (final - hoy).Days;

        return total;
    }

    //buscador inteligente que busca no importando el orden de los nombres
    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "SELECT id, tipo, asegurado as Asegurado, poliza as Poliza, ramo as Ramo,vigi as [Vigencia Inicial], vigf as [Vigencia Final] " +
                " from consultar_asegurados Where " + ddlTipo.SelectedValue + " like '%" + arreglo[0] + "%' ";

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

    private void vaciarGrid()
    {
        llenado.llenarGrid("select top(0) * from consultar_asegurados", GridCoberturas);
        llenado.llenarGrid("select top(0) * from consultar_asegurados", GridReclamos);
    }

    protected void GridReclamos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridReclamos.SelectedRow.Cells[1].Text);
        string reclamo = "window.open('/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), reclamo, true);
    }
}