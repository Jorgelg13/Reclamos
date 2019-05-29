using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_Copagos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String consulta, url;
    //String guardarArchivo = @"C:\Proyectos\Reclamos\pdf\Copagos\";
    String guardarArchivo = @"D:\Reclamos\pdf\Copagos\";
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        consulta = "select id, nombre as Nombre, nombre_archivo as Archivo, fechareg as Fecha from archivos_copagos order by nombre";

        if (!IsPostBack)
        {
            llenado.llenarGrid(consulta, GridCopagos);
        }

        coloresGrid();
    }

    public void coloresGrid()
    {
        foreach (GridViewRow row in GridCopagos.Rows)
        {
            string valor = row.Cells[4].Text;
            string extension = valor.Substring(valor.Length - 1, 1);
            if (extension == "f")
            {
                row.CssClass = "danger";
            }
            else
            {
                row.CssClass = "success";
            }
        }
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        String archivo = SubirArchivo.FileName;
        url = "pdf" + "\\" + "Copagos" + "\\" + archivo;
        var reclamo = DBReclamos.reclamo_auto.Find(id);

        if (txtNombre.Text == "" || SubirArchivo.HasFile == false)
        {
            Utils.ShowMessage(this.Page, "Debe agregar un nombre y un archivo al registro", "Nota..", "info");
        }

        else
        {
            if (SubirArchivo.HasFile)
            {
                if (Directory.Exists(guardarArchivo))
                {
                    try
                    {
                        SubirArchivo.SaveAs(guardarArchivo + archivo);
                        archivos_copagos nuevo = new archivos_copagos();
                        nuevo.fechareg = DateTime.Now;
                        nuevo.usuario = userlogin;
                        nuevo.nombre = txtNombre.Text;
                        nuevo.nombre_archivo = archivo;
                        nuevo.path = url;
                        DBReclamos.archivos_copagos.Add(nuevo);
                        DBReclamos.SaveChanges();
                        Utils.ShowMessage(this.Page, "Archivo subido con exito.", "Excelente..", "success");
                        llenado.llenarGrid(consulta, GridCopagos);
                        coloresGrid();
                        txtNombre.Text = "";
                    }

                    catch (Exception ex)
                    {
                        Utils.ShowMessage(this.Page, "No se a podido subir el archivo " + ex, "Error..", "error");
                    }
                }
            }
        }
    }

    protected void GridCopagos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridCopagos.SelectedRow.Cells[2].Text);
        var registro = DBReclamos.archivos_copagos.Find(id);
        lblRegistro.Text = registro.nombre;
        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#validacion').modal('show');", addScriptTags: true);
    }

    protected void GridCopagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridCopagos.Rows[e.RowIndex];
        id = Convert.ToInt32(row.Cells[2].Text);

        var registro = DBReclamos.archivos_copagos.Find(id);
        url = "https://reclamosgt.unitypromotores.com/" + registro.path.Replace("\\", "/");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Prueba", "window.open('" + url + "', '_blank');", true);
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        string filtro = "select id, usuario as Usuario, nombre as Nombre, nombre_archivo as Archivo, fechareg as Fecha from archivos_copagos where nombre like '%"+txtbuscar.Text+"%' order by nombre";
        llenado.llenarGrid(filtro, GridCopagos);
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridCopagos.SelectedRow.Cells[2].Text);
        var registro = DBReclamos.archivos_copagos.Find(id);
        string ruta = guardarArchivo + registro.nombre_archivo;

        if (File.Exists(ruta))
        {
            try
            {
                File.Delete(ruta);
            }
            catch (IOException)
            {

            }
        }

        DBReclamos.archivos_copagos.Remove(registro);
        DBReclamos.SaveChanges();
        llenado.llenarGrid(consulta, GridCopagos);
        coloresGrid();
        Utils.ShowMessage(this.Page, "El registro y archivo se a eliminado correctamente ", "Excelente..", "success");
    }
}