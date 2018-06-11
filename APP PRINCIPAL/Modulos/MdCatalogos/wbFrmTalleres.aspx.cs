using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmTalleres : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridTalleres.DataSource = DBReclamos.talleres.ToList();
            GridTalleres.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
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
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                GridTalleres.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
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
            id2 = Convert.ToInt32(GridTalleres.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.talleres.Find(id2);
            actualizar.nombre = txtNombre.Text;
            actualizar.correo = txtCorreo.Text;
            actualizar.telefono = txtTelefono.Text;
            actualizar.direccion = txtDireccion.Text;
            actualizar.estado = Convert.ToBoolean(ddlestado.SelectedValue);
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            GridTalleres.DataSource = DBReclamos.talleres.ToList();
            GridTalleres.DataBind();
            Utils.ShowMessage(this.Page, "Taller actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el taller " + ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridTalleres.SelectedRow.Cells[1].Text);
        var taller = DBReclamos.talleres.Find(id);
        txtNombre.Text = taller.nombre;
        txtDireccion.Text = taller.direccion;
        txtTelefono.Text = taller.telefono;
        txtCorreo.Text = taller.correo;
        ddlestado.SelectedValue = taller.estado.ToString();
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from talleres where nombre like '%" + txtbuscar.Text + "%'", GridTalleres);
    }
}