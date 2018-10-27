using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_wbEstados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {
        idRecibido = Request.QueryString[0].ToString();

        if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "jlaj")
        {
            Guardar.Enabled = true;
            Actualizar.Enabled = false;
        }

        if (!IsPostBack)
        {
            if(idRecibido == "1")
            {
                gridEstados.DataSource = DBReclamos.estados_reclamos_unity.Where(estados => estados.tipo == "auto").OrderBy(es => es.tipo).ToList();
                gridEstados.DataBind();
            }
            else
            {
                gridEstados.DataSource = DBReclamos.estados_reclamos_unity.Where(estados => estados.tipo == "daños").OrderBy(es => es.tipo).ToList();
                gridEstados.DataBind();
            }
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
                estados_reclamos_unity estado = new estados_reclamos_unity();
                estado.descripcion = txtDescripcion.Text;
                estado.dias_revision = Convert.ToInt16(txtDias.Text);
                estado.tipo = ddlTipo.SelectedValue;
                DBReclamos.estados_reclamos_unity.Add(estado);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                gridEstados.DataBind();
                txtDescripcion.Text = "";
                txtDias.Text = "";
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
            id2 = Convert.ToInt32(gridEstados.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.estados_reclamos_unity.Find(id2);
            actualizar.descripcion = txtDescripcion.Text;
            actualizar.dias_revision = Convert.ToInt16(txtDias.Text);
            actualizar.tipo = ddlTipo.SelectedValue;
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtDescripcion.Text = "";
            txtDias.Text = "";
            if (idRecibido == "1")
            {
                gridEstados.DataSource = DBReclamos.estados_reclamos_unity.Where(estados => estados.tipo == "auto").OrderBy(es => es.tipo).ToList();
                gridEstados.DataBind();
            }
            else
            {
                gridEstados.DataSource = DBReclamos.estados_reclamos_unity.Where(estados => estados.tipo == "daños").OrderBy(es => es.tipo).ToList();
                gridEstados.DataBind();
            }
            gridEstados.DataBind();
            Utils.ShowMessage(this.Page, "estado actualizado con exito", "Excelente", "success");
            txtDescripcion.Enabled = true;
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el estado " + ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "jlaj")
        {

            txtDescripcion.Enabled = false;
            id = Convert.ToInt32(gridEstados.SelectedRow.Cells[1].Text);
            var estados = DBReclamos.estados_reclamos_unity.Find(id);
            txtDescripcion.Text = estados.descripcion;
            txtDias.Text = estados.dias_revision.ToString();
            ddlTipo.SelectedValue = estados.tipo;
            Guardar.Visible = false;
            Actualizar.Visible = true;
            Actualizar.Enabled = true;
        }
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from estados_reclamos_unity where descripcion like '%" + txtbuscar.Text + "%'", gridEstados);
    }
}