using System;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmGestores : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnguardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombre.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo nombre es requerido", "Nota..!", "warning");
            }
            else
            {
                gestores gestor = new gestores();
                gestor.nombre = txtNombre.Text;
                gestor.correo = txtCorreo.Text;
                gestor.telefono = txtTelefono.Text;
                gestor.estado = true;
                gestor.tipo = ddlTipo.SelectedItem.Text;
                DBReclamos.gestores.Add(gestor);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Gestor ingresado con exito", "Excelente..!", "success");
                GridGestores.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
            }
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido guardar el gestor", "Error..!", "error");
        }
    }
}