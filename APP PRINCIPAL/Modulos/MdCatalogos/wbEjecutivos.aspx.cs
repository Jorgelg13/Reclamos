using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_wbEjecutivos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "jlaj") PnPrincipal.Visible = true;
        if (!IsPostBack)
        {
            GridEjecutivos.DataSource = DBReclamos.ejecutivos.ToList();
            GridEjecutivos.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtGestor.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo nombre es requerido", "Nota..!", "warning");
            }
            else
            {
                ejecutivos ejecutivo = new ejecutivos();
                ejecutivo.gestor = txtGestor.Text;
                ejecutivo.codigo = Convert.ToInt16(txtCodigo.Text);
                ejecutivo.correo = txtCorreo.Text;
                ejecutivo.telefono = txtTelefono.Text;
                DBReclamos.ejecutivos.Add(ejecutivo);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                GridEjecutivos.DataSource = DBReclamos.ejecutivos.ToList();
                GridEjecutivos.DataBind();
                txtGestor.Text = "";
                txtCodigo.Text = "";
                txtCorreo.Text = "";
                txtTelefono.Text = "";
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
            id2 = Convert.ToInt32(GridEjecutivos.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.ejecutivos.Find(id2);
            actualizar.gestor = txtGestor.Text;
            actualizar.codigo = Convert.ToInt16(txtCodigo.Text);
            actualizar.correo = txtCorreo.Text;
            actualizar.telefono = txtTelefono.Text;
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtGestor.Text = "";
            txtCodigo.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            GridEjecutivos.DataSource = DBReclamos.ejecutivos.ToList();
            GridEjecutivos.DataBind();
            Utils.ShowMessage(this.Page, "ejecutivo actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al actualizar el registro " + ex.Message, "Error", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridEjecutivos.SelectedRow.Cells[1].Text);
        var ejecutivo = DBReclamos.ejecutivos.Find(id);
        txtGestor.Text = ejecutivo.gestor;
        txtCodigo.Text = ejecutivo.codigo.ToString();
        txtCorreo.Text = ejecutivo.correo;
        txtTelefono.Text = ejecutivo.telefono;
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from ejecutivos where gestor like '%" + txtbuscar.Text + "%'", GridEjecutivos);
    }
}