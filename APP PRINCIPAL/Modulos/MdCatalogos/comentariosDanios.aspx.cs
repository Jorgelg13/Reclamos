using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_comentariosDanios : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenado = new Utils();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "mbarrios" || userlogin == "jlaj")
        {
            PnPrincipal.Visible = true;
        }
    }

    private void consulta()
    {
        llenado.llenarGrid("select id, descripcion as Descripcion,usuario as Usuario,fecha as Fecha from comentarios_reclamos_varios where id_reclamos_varios= " + txtbuscar.Text + " order by id desc", gridComentarios);
        gridComentarios.DataBind();
    }

    protected void busca_Click(object sender, EventArgs e)
    {
        consulta();
    }

    protected void gridComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Replace("\n", "<br/>");
            }
        }
        catch (Exception)
        {

        }
    }

    //editar comentario
    protected void gridComentarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtComentario.Text = HttpUtility.HtmlDecode(gridComentarios.SelectedRow.Cells[2].Text).Replace("<br/>", "\n");
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalComentario').modal('show');", addScriptTags: true);
    }

    //actualizar comentario
    protected void btnGuardarComentario_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridComentarios.SelectedRow.Cells[1].Text);
        var reclamo = DBReclamos.comentarios_reclamos_varios.Find(id);
        reclamo.descripcion = txtComentario.Text;
        DBReclamos.SaveChanges();
        consulta();
        Utils.ShowMessage(this.Page, "Comentario actualizado con exito", "Excelente..!", "success");
    }

    //eliminar comentario
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridComentarios.SelectedRow.Cells[1].Text);
        var reclamo = DBReclamos.comentarios_reclamos_varios.Find(id);
        DBReclamos.comentarios_reclamos_varios.Remove(reclamo);
        DBReclamos.SaveChanges();
        consulta();
        Utils.ShowMessage(this.Page, "Comentario eliminado con exito", "Excelente..!", "info");
    }
}