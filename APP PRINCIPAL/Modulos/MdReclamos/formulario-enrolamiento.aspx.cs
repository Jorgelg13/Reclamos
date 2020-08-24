using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamos_formulario_enrolamiento : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String consulta,carpetas, url;
    String guardarArchivo = @"C:\Proyectos\Formularios\";
    //String guardarArchivo = @"D:\Reclamos\pdf\formularios-enrolamiento\";
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        GuardarArchivo.Visible = false;
        carpetas = "select a.id, ca.id as id_ca, a.aseguradora as Aseguradora from carpetas_aseguradoras as ca inner join aseguradoras as a on ca.id_aseguradora = a.id";

        if (!IsPostBack)
        {
            llenado.llenarGrid(carpetas, GridCarpetas);

            ddlAseguradoras.DataSource = DBReclamos.aseguradoras.ToList();
            ddlAseguradoras.DataValueField = "id";
            ddlAseguradoras.DataTextField = "aseguradora";
            ddlAseguradoras.DataBind();
        }

        coloresGrid();
    }

    public void coloresGrid()
    {
        foreach (GridViewRow row in GridArchivos.Rows)
        {
            string valor = row.Cells[3].Text;
            string extension = valor.Substring(valor.Length - 1, 1);
            if (extension == "f")
            {
                row.CssClass = "danger";
            }
            else
            {
                row.CssClass = "info";
            }
        }
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        int id_aseguradora = Convert.ToInt32(GridCarpetas.SelectedRow.Cells[1].Text);
        var aseguradora = DBReclamos.carpetas_aseguradoras.Where(a => a.id_aseguradora == id_aseguradora).First();

        String archivo = SubirArchivo.FileName;
        url = "pdf\\formularios-enrolamiento\\" + aseguradora.nombre_carpeta + "\\"+ archivo;

        if (SubirArchivo.HasFile == false)
        {
            Utils.ShowMessage(this.Page, "Debe agregar un nombre y un archivo al registro", "Nota..", "info");
        }

        else
        {
            if (SubirArchivo.HasFile)
            {
                if (Directory.Exists(guardarArchivo + aseguradora.nombre_carpeta))
                {
                    try
                    {
                        id = Convert.ToInt32(GridCarpetas.SelectedRow.Cells[2].Text);
                        SubirArchivo.SaveAs(guardarArchivo + aseguradora.nombre_carpeta + "\\" + archivo);
                        formularios_aseguradoras nuevo = new formularios_aseguradoras();
                        nuevo.id_carpeta = aseguradora.id;
                        nuevo.usuario = userlogin;
                        nuevo.ruta = url;
                        nuevo.fecha_registro = DateTime.Now;
                        DBReclamos.formularios_aseguradoras.Add(nuevo);
                        DBReclamos.SaveChanges();

                        Utils.ShowMessage(this.Page, "Archivo subido con exito.", "Excelente..", "success");
                        consulta = "select id, ruta as Ruta, fecha_registro as Fecha from formularios_aseguradoras where id_carpeta = " + id + " ";
                        llenado.llenarGrid(consulta, GridArchivos);

                        coloresGrid();
                    }

                    catch (Exception ex)
                    {
                        Utils.ShowMessage(this.Page, "No se a podido subir el archivo " + ex, "Error..", "error");
                    }
                }

                else
                {

                }
            }
        }
    }

    protected void GridCopagos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridArchivos.SelectedRow.Cells[2].Text);
        var registro = DBReclamos.formularios_aseguradoras.Find(id);
        lblRegistro.Text = registro.ruta;
        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#validacion').modal('show');", addScriptTags: true);
    }

    protected void GridCopagos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridArchivos.Rows[e.RowIndex];
        id = Convert.ToInt32(row.Cells[2].Text);

        var registro = DBReclamos.formularios_aseguradoras.Find(id);
        url = "https://reclamosgt.unitypromotores.com/" + registro.ruta.Replace("\\", "/");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Prueba", "window.open('" + url + "', '_blank');", true);
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridArchivos.SelectedRow.Cells[2].Text);
        var registro = DBReclamos.formularios_aseguradoras.Find(id);
        string ruta = guardarArchivo + registro.ruta;

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

        id = Convert.ToInt32(GridArchivos.SelectedRow.Cells[2].Text);
        consulta = "select id, ruta as Ruta, fecha_registro as Fecha from formularios_aseguradoras where id_carpeta = " + id + " ";
        llenado.llenarGrid(consulta, GridArchivos);

        DBReclamos.formularios_aseguradoras.Remove(registro);
        DBReclamos.SaveChanges();
        llenado.llenarGrid(consulta, GridArchivos);
        coloresGrid();
        Utils.ShowMessage(this.Page, "El registro y archivo se a eliminado correctamente ", "Excelente..", "success");
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        carpetas_aseguradoras nueva = new carpetas_aseguradoras();
        nueva.id_aseguradora = Convert.ToInt32(ddlAseguradoras.SelectedValue);
        nueva.nombre_carpeta = "Codigo-Aseguradora-" + ddlAseguradoras.SelectedValue;
        DBReclamos.carpetas_aseguradoras.Add(nueva);

        if (!Directory.Exists(guardarArchivo + nueva.nombre_carpeta))
        {
            try
            {
                DirectoryInfo nueva_carepta = Directory.CreateDirectory(guardarArchivo + nueva.nombre_carpeta);
                DBReclamos.SaveChanges();

                llenado.llenarGrid(carpetas, GridCarpetas);
                Utils.ShowMessage(this.Page, "Registro agregado con exito", "Excelente..", "success");
            }

            catch (Exception ex)
            {
                Utils.ShowMessage(this.Page, "No se a crear la nueva carpeta " + ex, "Error..", "error");
            }
        }
        else
        {
            Utils.ShowMessage(this.Page, "Ya existe una carpeta creada con esa aseguradora", "Precaucion..", "warning");
        }
    }

    protected void GridCarpetas_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridCarpetas.SelectedRow.Cells[2].Text);
        consulta = "select id, ruta as Ruta, fecha_registro as Fecha from formularios_aseguradoras where id_carpeta = "+id+" ";

        GuardarArchivo.Visible = true;
        llenado.llenarGrid(consulta, GridArchivos);
        coloresGrid();
    }
}