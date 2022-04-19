using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdFlotillas_cargar_autos : System.Web.UI.Page
{
    ReclamosEntities DB = new ReclamosEntities();
    Utils cargarDatos = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {

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

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        RecorrerCarga();
    }

    private void RecorrerCarga()
    {
        flotillas insertar = new flotillas();

        foreach (GridViewRow row in GridCargas.Rows)
        {
            //string placa = row.Cells[5].Text;
            //var registro = DB.flotillas.Where(reg => reg.placa == placa).ToList();

            try
            {
                /*if (registro.Count >= 1)
                {
                    row.CssClass = "danger";
                    lblMensaje.Text = "Los registros que aparecen en rojo estan duplicados";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }*/


                insertar.inciso = Convert.ToInt32(row.Cells[0].Text);
                insertar.propietario = row.Cells[1].Text;
                insertar.marca = row.Cells[2].Text;
                insertar.linea = row.Cells[3].Text;
                insertar.chasis = row.Cells[4].Text;
                insertar.motor = row.Cells[5].Text;
                insertar.year = row.Cells[6].Text;
                insertar.color = row.Cells[7].Text;
                insertar.placa = row.Cells[8].Text;
                DB.flotillas.Add(insertar);
                DB.SaveChanges();
                row.CssClass = "success";
                Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");

            }

            catch (Exception ex)
            {
                row.CssClass = "danger";
                Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString(), "ERROR", "error");
            }
        }
    }
}