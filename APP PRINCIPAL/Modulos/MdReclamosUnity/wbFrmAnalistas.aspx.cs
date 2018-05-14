using System;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmAnalistas : System.Web.UI.Page
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
                analistas analista = new analistas();
                analista.nombre = txtNombre.Text;
                analista.Empresa = txtEmpresa.Text;
                analista.telefono = txtTelefono.Text;
                analista.correo = txtCorreo.Text;
                analista.estado = true;
                analista.tipo = ddlTipo.SelectedItem.Text;
                DBReclamos.analistas.Add(analista);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                GridAnalistas.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
            }
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se a podido guardar el registro", "Error..!", "error");
        }
    }

    public void buscar()
    {

    }
}