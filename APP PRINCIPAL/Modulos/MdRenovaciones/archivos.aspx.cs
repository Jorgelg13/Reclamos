using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_archivos : System.Web.UI.Page
{
    Utils llenado = new Utils();
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        llenado.llenarGridRenovaciones("select * from archivos ", GridArchivos);
    }

    protected void GridArchivos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridArchivos.Rows)
        {
            int id = Convert.ToInt32(Convert.ToString(row.Cells[0].Text));

            try
            {
                var poliza = DBRenovaciones.archivos.Find(id);
                String Poliza = poliza.poliza;
                Utils.MoverArchivos(Poliza, "Archivo", "Enviadas");
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
            }
            
        }
    }
}