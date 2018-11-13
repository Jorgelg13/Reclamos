using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_CargarPolizas : System.Web.UI.Page
{
    Utils cargarDatos = new Utils();
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (Archivo.HasFile)
        {
            string FileName = Path.GetFileName(Archivo.PostedFile.FileName);
            string Extension = Path.GetExtension(Archivo.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string FilePath = Server.MapPath(FolderPath + FileName);
            Archivo.SaveAs(FilePath);
            cargarDatos.importar(FilePath, Extension, rbHDR.SelectedItem.Text, GridCargas);
        }
    }

    private void RecorrerCarga()
    {
        foreach (GridViewRow row in GridCargas.Rows)
        {
            String cliente = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[0].Text));
            String nombre = HttpUtility.HtmlDecode(Convert.ToString(row.Cells[1].Text));
        }
    }
}