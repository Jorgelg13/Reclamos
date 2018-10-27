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

        Utils.actividades(Convert.ToInt32(txtBusquedaId.Text), Constantes.AUTOS(), 25, Constantes.USER());
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

        Utils.actividades(Convert.ToInt32(txtReclamosVarios.Text), Constantes.DANIOS(), 25, Constantes.USER());
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

        Utils.actividades(Convert.ToInt32(txtBuscarReclamoMedico.Text), Constantes.GASTOS_MEDICOS(), 25, Constantes.USER());
    }
}
