using System;

public partial class ReclamosUnity : System.Web.UI.MasterPage
{
    private void Page_Error(object sender, EventArgs e)
    {
        Response.Redirect("/Error.aspx");
        Server.ClearError();
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscarId_Click(object sender, EventArgs e)
    {
        if (txtBusquedaId.Text == "")
        {
            Response.Write("<Script>setTimeout(function () { toastr.error('Debe de ingresar un Id', 'Error!');  }, 200);</script>");
        }
        else
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + txtBusquedaId.Text, false);
        }
    }

    protected void btnBuscarReclamosVarios_Click(object sender, EventArgs e)
    {
        if (txtReclamosVarios.Text == "")
        {
            Response.Write("<Script>setTimeout(function () { toastr.error('Debe de ingresar un Id', 'Error!');  }, 200);</script>");
        }
        else
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + txtReclamosVarios.Text, false);
        }
    }

    protected void btnReclamoMedico_Click(object sender, EventArgs e)
    {
        if (txtBuscarReclamoMedico.Text == "")
        {
            Response.Write("<Script>setTimeout(function () { toastr.error('Debe de ingresar un ID', 'Error!');  }, 200);</script>");
        }
        else
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?Id_reclamo=" + txtBuscarReclamoMedico.Text, false);
        }
    }
}
