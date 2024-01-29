using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_vifrio_Default : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();

    String consulta, sucursal;

    protected void Page_Load(object sender, EventArgs e)
    {
        consulta = "select servicio as Servicio, descuento as Descuento from descuentos_vifrio where empresa = 'grupo_q' ";
        llenado.llenarGrid(consulta, GridDescuentos);
    }
}