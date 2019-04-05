using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Estados_Invalidas : System.Web.UI.Page
{
    Utils llenar = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Renovaciones.RenovacionesEntities DB = new Renovaciones.RenovacionesEntities();
    String Cargadas;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string usuarioLogin = HttpContext.Current.User.Identity.Name;
            var user = DBReclamos.usuario.Where(U => U.nombre == usuarioLogin).First();

            if (user.rol == "F")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Estados/Renovadas.aspx");
            }
        }
        catch { }

     
        if (!IsPostBack)
        {
            llenarGrid();
        }
    }

    private void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 8, "", ""), GridInvalidas);
    }

    protected void GridInvalidas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int identificador = Convert.ToInt32(GridInvalidas.SelectedRow.Cells[3].Text);
        var registro = DB.renovaciones_polizas.Find(identificador);
        registro.estado = 2;
        DB.SaveChanges();

        llenarGrid();
    }
}