using System;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmTalleres : System.Web.UI.Page
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
                talleres taller = new talleres();
                taller.nombre = txtNombre.Text;
                taller.direccion = txtDireccion.Text;
                taller.telefono = txtTelefono.Text;
                taller.correo = txtCorreo.Text;
                taller.estado = true;
                DBReclamos.talleres.Add(taller);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Taller ingresado con exito", "Excelente..!", "success");
                GridTalleres.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
            }
        }

        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "No se pudo ingresar el taller", "Error..!", "error");
        }
    }
}