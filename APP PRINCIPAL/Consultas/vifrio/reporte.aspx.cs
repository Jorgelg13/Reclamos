using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_vifrio_Default : System.Web.UI.Page
{
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        string registros = "SELECT asegurado as Asegurado, sucursal as Sucursal, codigo as Codigo," +
            " servicio as Servicio, placa as Placa, fecha as Fecha from registros_vifrio";
        llenado.llenarGrid(registros, GridGeneral);
    }

    //funcion para exportar a un archivo de excel lo que aparece en el gridview
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Utils.ExportarExcel(GridGeneral, Response, "Registros");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}