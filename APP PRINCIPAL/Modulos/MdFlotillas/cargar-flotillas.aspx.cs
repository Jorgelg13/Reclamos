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
    String userlogin = HttpContext.Current.User.Identity.Name;

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
            string placa = row.Cells[8].Text.Trim();
            var auto = DB.flotillas.Where(reg => reg.placa == placa).ToList();

            try
            {
                if (auto.Count >= 1)
                {
                    var registro = DB.flotillas.Where(reg => reg.placa == placa).First();
                    //row.CssClass = "danger";
                    //lblMensaje.Text = "Los registros que aparecen en rojo estan duplicados";
                    //lblMensaje.ForeColor = System.Drawing.Color.Red;

                    registro.inciso = Convert.ToInt32(row.Cells[0].Text);
                    registro.propietario = row.Cells[1].Text;
                    registro.marca = row.Cells[2].Text;
                    registro.linea = row.Cells[3].Text;
                    registro.chasis = row.Cells[4].Text;
                    registro.motor = row.Cells[5].Text;
                    registro.year = row.Cells[6].Text;
                    registro.color = row.Cells[7].Text;
                    registro.placa = row.Cells[8].Text;
                    registro.usuario = userlogin;
                    registro.asegurado = row.Cells[9].Text;
                    registro.poliza = row.Cells[10].Text;
                    registro.aseguradora = row.Cells[11].Text;
                    registro.vigencia = row.Cells[12].Text;
                    registro.ejecutivo = row.Cells[13].Text;
                    registro.codigo_interno = row.Cells[14].Text;
                    registro.pagador = row.Cells[15].Text;
                    registro.fecha = DateTime.Now;
                    registro.estado = "Activo";
                    DB.SaveChanges();
                    row.CssClass = "success";
                    Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");
                } 
                else
                {
                    insertar.inciso = Convert.ToInt32(row.Cells[0].Text);
                    insertar.propietario = row.Cells[1].Text;
                    insertar.marca = row.Cells[2].Text;
                    insertar.linea = row.Cells[3].Text;
                    insertar.chasis = row.Cells[4].Text;
                    insertar.motor = row.Cells[5].Text;
                    insertar.year = row.Cells[6].Text;
                    insertar.color = row.Cells[7].Text;
                    insertar.placa = row.Cells[8].Text;
                    insertar.usuario = userlogin;
                    insertar.asegurado = row.Cells[9].Text;
                    insertar.poliza = row.Cells[10].Text;
                    insertar.aseguradora = row.Cells[11].Text;
                    insertar.vigencia = row.Cells[12].Text;
                    insertar.ejecutivo = row.Cells[13].Text;
                    insertar.codigo_interno = row.Cells[14].Text;
                    insertar.pagador = row.Cells[15].Text;
                    insertar.fecha = DateTime.Now;
                    insertar.estado = "Activo";
                    DB.flotillas.Add(insertar);
                    DB.SaveChanges();
                    row.CssClass = "success";
                    Utils.ShowMessage(this.Page, "Datos Cargados con exito", "Excelente", "success");
                }
            }

            catch (Exception ex)
            {
                row.CssClass = "danger";
                Utils.ShowMessage(this.Page, "No se pudieron insertar los datos " + ex.Message.ToString(), "ERROR", "error");
            }
        }
    }
}