using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmConsultasMedicasIndividualMovil : System.Web.UI.Page
{

    string poliza, chasis;
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();


    protected void Page_Load(object sender, EventArgs e)
    {
        poliza = (string)(Session["poliza"]);
        TextBox1.Text = poliza;
    }

    protected void linkSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Modulos/MdConsultaMovil/wbFrmConsultaMovilCliente.aspx");
    }
}