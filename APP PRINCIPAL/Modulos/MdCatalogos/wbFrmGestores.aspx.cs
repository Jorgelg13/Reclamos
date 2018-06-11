using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmGestores : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridGestores.DataSource = DBReclamos.gestores.ToList();
            GridGestores.DataBind();
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
                gestores gestor = new gestores();
                gestor.nombre = txtNombre.Text;
                gestor.usuario = txtusuario.Text;
                gestor.telefono = txtTelefono.Text;
                gestor.correo = txtCorreo.Text;
                gestor.estado = true;
                gestor.tipo = ddlTipo.SelectedItem.Text;
                DBReclamos.gestores.Add(gestor);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                GridGestores.DataBind();
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
                txtusuario.Text = "";
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
            id2 = Convert.ToInt32(GridGestores.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.gestores.Find(id2);
            actualizar.nombre = txtNombre.Text;
            actualizar.usuario = txtusuario.Text;
            actualizar.correo = txtCorreo.Text;
            actualizar.telefono = txtTelefono.Text;
            actualizar.tipo = ddlTipo.SelectedItem.Text;
            actualizar.estado = Convert.ToBoolean(ddlestado.SelectedValue);
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtusuario.Text = "";
            GridGestores.DataSource = DBReclamos.gestores.ToList();
            GridGestores.DataBind();
            Utils.ShowMessage(this.Page, "Usuario actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el gestor " + ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridGestores.SelectedRow.Cells[1].Text);
        var gestor = DBReclamos.gestores.Find(id);
        txtNombre.Text = gestor.nombre;
        txtusuario.Text = gestor.usuario;
        txtTelefono.Text = gestor.telefono;
        txtCorreo.Text = gestor.correo;
        ddlTipo.SelectedValue = gestor.tipo;
        ddlestado.SelectedValue = gestor.estado.ToString();
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from gestores where nombre like '%" + txtbuscar.Text + "%'", GridGestores);
    }
}