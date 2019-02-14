using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_Cabina_ClientesPendientes : System.Web.UI.Page
{
    ReclamosEntities DB = new ReclamosEntities();
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientesPendientes();
    }

    public void ClientesPendientes()
    {
        String Consulta = "Select * from clientes where estado = 'p' ";
        llenado.llenarGrid(Consulta,GridPendientes);
    }

    private void atendidos()
    {
        foreach (GridViewRow row in GridPendientes.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAsig.Checked)
            {
                try
                {
                    var cliente = DB.clientes.Find(id);
                   // cliente.estado = "a";
                    DB.SaveChanges();
                    Utils.ShowMessage(this.Page, "Reclamos asignados exitosamente", "Excelente", "success");
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this.Page, "No se a podido asigar el reclamo" + ex.Message, "Excelente", "success");
                }
            }
        }
    }

    protected void btnAtendidos_Click(object sender, EventArgs e)
    {
        atendidos();
        ClientesPendientes();
    }
}