using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_wbTipoDocumentos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();

        if (!IsPostBack)
        {
            if(idRecibido == "1")
            {
                GridDocumentos.DataSource = DBReclamos.tipo_documentos.Select(d => new { d.id, d.descripcion,d.tipo, d.estado}).Where(doc => doc.tipo == "Autos").ToList();
            }
            else if(idRecibido == "2")
            {
                GridDocumentos.DataSource = DBReclamos.tipo_documentos.Select(d => new { d.id, d.descripcion, d.tipo, d.estado }).Where(doc => doc.tipo == "Daños").ToList();
            }
            GridDocumentos.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDescripcion.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo nombre es requerido", "Nota..!", "warning");
            }

            else
            {
                tipo_documentos documento = new tipo_documentos();
                var sec_registro = DBReclamos.pa_sec_tipo_documentos();
                int? id_registro = sec_registro.Single();
                documento.id = Convert.ToInt32(id_registro);
                documento.descripcion = txtDescripcion.Text;
                documento.estado = true;
                documento.tipo = ddlTipo.SelectedValue;
                documento.usuario = userlogin;
                documento.fecha = DateTime.Now;
                DBReclamos.tipo_documentos.Add(documento);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");

                if (idRecibido == "1")
                {
                    GridDocumentos.DataSource = DBReclamos.tipo_documentos.Where(doc => doc.tipo == "Autos").ToList();
                }
                else if (idRecibido == "2")
                {
                    GridDocumentos.DataSource = DBReclamos.tipo_documentos.Where(doc => doc.tipo == "Daños").ToList();
                }
                GridDocumentos.DataBind();
                txtDescripcion.Text = "";
            }
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido guardar el registro", "Error..!", "error");
        }
    }

    protected void Actualizar_Click(object sender, EventArgs e)
    {
        try
        {
            int id2;
            id2 = Convert.ToInt32(GridDocumentos.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.tipo_documentos.Find(id2);
            actualizar.descripcion = txtDescripcion.Text;
            actualizar.tipo = ddlTipo.SelectedValue;
            actualizar.estado = Convert.ToBoolean(ddlestado.SelectedValue);
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtDescripcion.Text = "";
            if (idRecibido == "1")
            {
                GridDocumentos.DataSource = DBReclamos.tipo_documentos.Select(d => new { d.id, d.descripcion, d.tipo, d.estado }).Where(doc => doc.tipo == "Autos").ToList();
            }
            else if (idRecibido == "2")
            {
                GridDocumentos.DataSource = DBReclamos.tipo_documentos.Select(d => new { d.id, d.descripcion, d.tipo, d.estado }).Where(doc => doc.tipo == "Daños").ToList();
            }
            GridDocumentos.DataBind();
            Utils.ShowMessage(this.Page, "Documento actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el tipo de documento " + ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridDocumentos.SelectedRow.Cells[1].Text);
        var doc = DBReclamos.tipo_documentos.Find(id);
        txtDescripcion.Text = doc.descripcion;
        ddlTipo.SelectedValue = doc.tipo;
        ddlestado.SelectedValue = doc.estado.ToString();
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        if (idRecibido == "1")
        {
            llenado.llenarGrid("select id, descripcion, tipo, estado  from tipo_documentos where descripcion like '%" + txtbuscar.Text + "%' and tipo = 'Autos'", GridDocumentos);
        }
        else if (idRecibido == "2")
        {
            llenado.llenarGrid("select id, descripciom, tipo, estado from tipo_documentos where descripcion like '%" + txtbuscar.Text + "%' and tipo = 'Daños'", GridDocumentos);
        }
    }
}