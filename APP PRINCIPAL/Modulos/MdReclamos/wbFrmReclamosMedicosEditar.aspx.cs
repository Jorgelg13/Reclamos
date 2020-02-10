using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmReclamosMedicosEditar : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name; //usuario que esta en sesion
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    Utils actualizar = new Utils();
    string metodo = "sistema";
    string idRecibido; //id de la ultima transaccion de la tabla reclamo_auto
    String comentarios, Documentos,pagos, datosReclamos;
    int id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Convert.ToString(Request.QueryString[0]).ToString();
        id = Int32.Parse(idRecibido);
        Documentos = "select descripcion as Descripcion, comentarios as Comentarios, cantidad as Cantidad from recibos_medicos where id_reclamo_medico =" + id + " ";
        lblId.Text = "<b>No.</b>"+id.ToString();
        labelID.Text = "<b>ID: </b>" + id.ToString();

        if (!IsPostBack)
        {
            DevolverDatos(id);
            llenado.llenarGrid(Documentos, GridRecibo);
        }
    }

    public void DevolverDatos(int identificador)
    {   
        try
        {
            datosReclamos = "SELECT " +
          "dbo.reclamos_medicos.id as ID," + //0
          "dbo.reg_reclamos_medicos.asegurado as Asegurado," +//1
          "dbo.reg_reclamos_medicos.poliza as Poliza," +//2
          "dbo.reg_reclamos_medicos.aseguradora as Aseguradora," +//3
          "dbo.reclamos_medicos.telefono as Telefono," +//4
          "dbo.reclamos_medicos.correo as Correo," +//5
          "dbo.reclamos_medicos.empresa as Empresa," +//6
          "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +//7
          "dbo.reg_reclamos_medicos.ramo as Ramo," +
          "dbo.reg_reclamos_medicos.tipo as Tipo," +//9
          "dbo.reg_reclamos_medicos.clase as Clase," +
          "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +//11
          "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
          "dbo.reg_reclamos_medicos.vip as VIP," +
          "dbo.reg_reclamos_medicos.moneda as Moneda," +//14
          "dbo.reg_reclamos_medicos.id," + //15
          "dbo.estado.id as Estado,"+ //16 
          "dbo.cabina.nombre as Cabina," +
          "dbo.sucursal.nombre as Sucursal," +
          "dbo.empresa.nombre as Empresa," +
          "dbo.pais.nombre as Pais " +
          "FROM " +
          " dbo.reg_reclamos_medicos " +
          "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
          "INNER JOIN dbo.cabina ON dbo.reclamos_medicos.id_cabina = dbo.cabina.id " +
          "INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id " +
          "INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id " +
          "INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id " +
          "INNER JOIN dbo.estado on dbo.reclamos_medicos.id_estado = dbo.estado.id "+
          "where reclamos_medicos.id = " + identificador + " ";

            SqlDataAdapter da = new SqlDataAdapter(datosReclamos, objeto.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
           // Response.Write(datosReclamos);

            txtAsegurado.Text = dt.Rows[0][1].ToString();
            txtAseguradora.Text = dt.Rows[0][3].ToString();
            txtPoliza.Text = dt.Rows[0][2].ToString(); 
            txtCorreo.Text = dt.Rows[0][5].ToString();
            txtTelefono.Text = dt.Rows[0][4].ToString();
            DDLTipo.Text = dt.Rows[0][7].ToString();
            ddlEstado.SelectedValue = dt.Rows[0][16].ToString(); 
            lblAsegurado2.Text = "<b>Asegurado:</b>        " + dt.Rows[0][1].ToString();
            lblPoliza2.Text = "<b>Poliza:</b>              " + dt.Rows[0][2].ToString();
            lblRamo.Text = "<b>Ramo:</b>                   " + dt.Rows[0][8].ToString();
            lblTipo.Text = "<b>Tipo:</b>                   " + dt.Rows[0][9].ToString();
            lblClase.Text= "<b>Clase:</b>                  " + dt.Rows[0][10].ToString();
            lblEjecutivo.Text= "<b>Ejecutivo:</b>          " + dt.Rows[0][11].ToString();
            lblAseguradora2.Text = "<b>Aseguradora:</b>    " + dt.Rows[0][3].ToString();
            lblContratante.Text = "<b>Contratante:</b>     " + dt.Rows[0][6].ToString();
            lblEstado.Text = "<b>Estado:</b>               " + dt.Rows[0][12].ToString();
            lblVip.Text = "<b>VIP:</b>                     " + dt.Rows[0][13].ToString();
            lblMoneda.Text = "<b>Moneda:</b>               " + dt.Rows[0][14].ToString();

            //datos imprimir
            lblAsegurado.Text = "<ins>" + dt.Rows[0][1].ToString() + "</ins>";
            lblAseguradora.Text = "<ins>" + dt.Rows[0][3].ToString() + "</ins>";
            lblpoliza.Text = "<ins>" + dt.Rows[0][2].ToString() + "</ins>";
            lblEmpresa.Text = "<ins>" + dt.Rows[0][6].ToString() + "</ins>";
            lblEjecutivoPoliza.Text = "<ins>" + dt.Rows[0][11].ToString() + "</ins>";
            objeto.conexion.Close();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al traer los datos", "Error..!", "error");
        }
        finally
        {
            objeto.DescargarConexion();
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        String query = "Update reclamos_medicos set asegurado = '" + txtAsegurado.Text + "', telefono = '"+ txtTelefono.Text+"', correo = '"+ txtCorreo.Text+"', tipo_reclamo = '"+ DDLTipo.SelectedItem +"', id_estado = "+Convert.ToInt32(ddlEstado.SelectedValue)+" from reclamos_medicos";
        if(actualizar.actualizarDatos(query, id))
        {
            if(ddlEstado.SelectedValue == "2" || ddlEstado.SelectedValue =="3")
            {
                Response.Redirect("/Modulos/Dashboard/DashboardCabina.aspx");
            }
            DevolverDatos(id);
            Utils.ShowMessage(this.Page, "Datos Actualizados con exito.", "Excelente..!", "success");
        }
        else
        {
            Utils.ShowMessage(this.Page, "No se pudo actualizar los datos", "Error..!", "error");
        }
    }
}

