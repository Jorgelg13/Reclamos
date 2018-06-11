using System;
using System.Linq;
using System.Web;

public partial class Modulos_MdReclamosUnity_wbFrmAnalistas : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GridAnalistas.DataSource = DBReclamos.analistas.ToList();
            GridAnalistas.DataBind();
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

    protected void Actualizar_Click(object sender, EventArgs e)
    {
        try
        {
            int id2;
            id2 = Convert.ToInt32(GridAnalistas.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.analistas.Find(id2);
            actualizar.nombre = txtNombre.Text;
            actualizar.Empresa = txtEmpresa.Text;
            actualizar.correo = txtCorreo.Text;
            actualizar.telefono = txtTelefono.Text;
            actualizar.tipo = ddlTipo.SelectedItem.Text;
            actualizar.estado = Convert.ToBoolean(ddlestado.SelectedValue);
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtNombre.Text = "";
            txtEmpresa.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            ddlestado.SelectedItem.Text = "Activo";
            GridAnalistas.DataSource = DBReclamos.analistas.ToList();
            GridAnalistas.DataBind();
            Utils.ShowMessage(this.Page, "Usuario actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el analista "+ ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAnalistas.SelectedRow.Cells[1].Text);
        var analista = DBReclamos.analistas.Find(id);
        txtNombre.Text = analista.nombre;
        txtEmpresa.Text = analista.Empresa;
        txtTelefono.Text = analista.telefono;
        txtCorreo.Text = analista.correo;
        ddlTipo.SelectedValue = analista.tipo;
        ddlestado.SelectedValue = analista.estado.ToString();
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from analistas where nombre like '%" + txtbuscar.Text + "%'", GridAnalistas);
    }
}