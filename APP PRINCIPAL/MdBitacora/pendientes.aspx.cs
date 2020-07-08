using System;
using System.Data;
using System.Data.SqlClient;

public partial class MdBitacora_pendientes : System.Web.UI.Page
{
    Utils llenado = new Utils();

    //public static string servidor = "192.168.81.41";
    //public static string pw = "Reclamos=/2017";
    public static string servidor = "DESKTOP-5BEDPMS";
    public static string pw = "sistemasj13";
    public static string bd = "reclamos";
    public static string user = "sa";
    public static string mensaje;
    public static string consulta = "";
    public static string maternidad, contenido;
    string correo_gestor;

    protected void Page_Load(object sender, EventArgs e)
    {
        string codigo = Convert.ToString(Request.QueryString[0]).ToString();

        string consulta = "select " +
            "r.id as ID, " +
            "reg.poliza as Poliza," +
            "reg.asegurado as Asegurado," +
            "r.fecha as Fecha," +
            "r.reserva as Reserva," +
            "reg.ejecutivo as Ejecutivo " +
            "from reclamos_varios as r " +
            "inner join reg_reclamo_varios as reg on r.id_reg_reclamos_varios = reg.id " +
            "where r.estado_unity = 'Seguimiento' " +
            "and reg.gestor = " + codigo + " ";

        llenado.llenarGrid(consulta, GridPendientes);

       // PENDIENTES();
    }

    protected void GridPendientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id = GridPendientes.SelectedRow.Cells[1].Text;
        Response.Redirect("/MdBitacora/wbFrmConsultaSeguimientoDaños.aspx?ID_reclamo=" + id , false);
    }

    //private void PENDIENTES()
    //{
    //    DateTime hoy = DateTime.Now;

    //    consulta = "select top 2 reg.gestor from reclamos_varios as r " +
    //        "inner join reg_reclamo_varios as reg on r.id_reg_reclamos_varios = reg.id " +
    //        "where r.estado_unity = 'Seguimiento' and reg.gestor is not null group by reg.gestor";

    //    try
    //    {
    //        if(hoy.Day == 15 || hoy.Day == 30)
    //        {
    //            SqlConnection conexion = new SqlConnection("Data Source=" + servidor + ";Initial Catalog=" + bd + ";User ID=" + user + ";Password=" + pw + "");
    //            SqlDataAdapter data = new SqlDataAdapter(consulta, conexion);
    //            DataTable dtl = new DataTable();
    //            data.Fill(dtl);
    //            int codigo;

    //            foreach (DataRow row in dtl.Rows)
    //            {
    //                codigo = Convert.ToInt32(row[0].ToString());

    //                correo_gestor = Utils.seleccionarCorreo(codigo);
    //                contenido = "Hola recuerde que existen reclamos pendientes de cierre puede consultarlos aqui <a href=\"/MdBitacora/pendientes.aspx?codigo=" + codigo + " \">VER RECLAMOS</a>";

    //                //utils.email.NOTIFICACION("jorge.laj.guerra@gmail.com", contenido, "Reclamos pendientes de cierre");
    //            }
    //        }
          
    //    }

    //    catch(Exception ex)
    //    {
    //       // utils.email.NOTIFICACION("jorge.laj@unitypromotores.com", "A ocurrido un error al notificar a los ejecutivos " + ex, "ERROR DE INFORME A EJECUTIVOS");
    //    }
    //}
}