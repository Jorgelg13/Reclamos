using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_wbAsegurados : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Guardar.Enabled = true;
        Actualizar.Enabled = false;
        
        if (!IsPostBack)
        {
           gridAsegurados.DataSource = DBReclamos.info_asegurado.Take(20).Where(a => a.estado ==true).ToList();
           gridAsegurados.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPoliza.Text == "" || txtAsegurado.Text == "" || txtCarne.Text == "" || txtEjecutivo.Text == "")
            {
                Utils.ShowMessage(this.Page, "Todos los campos son requeridos", "Nota..!", "warning");
            }

            else
            {
                info_asegurado asegurado = new info_asegurado();
                asegurado.poliza = txtPoliza.Text;
                asegurado.asegurado = txtAsegurado.Text;
                asegurado.carne = txtCarne.Text;
                asegurado.ejecutivo = txtEjecutivo.Text;
                asegurado.parentesco = ddlParentesco.SelectedValue;
                asegurado.estado = true;
                DBReclamos.info_asegurado.Add(asegurado);
                DBReclamos.SaveChanges();

                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                gridAsegurados.DataSource = DBReclamos.info_asegurado.Take(20).Where(a => a.id == asegurado.id).ToList();
                gridAsegurados.DataBind();
                txtPoliza.Text = "";
                txtEjecutivo.Text = "";
                txtCarne.Text = "";
                txtAsegurado.Text = "";
            }
        }

        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido guardar el registro", "Error..!", "error");
        }
    }

    protected void Actualizar_Click(object sender, EventArgs e)
    {
        try
        {
            int id2;
            id2 = Convert.ToInt32(gridAsegurados.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.info_asegurado.Find(id2);
            actualizar.poliza = txtPoliza.Text;
            actualizar.ejecutivo = txtEjecutivo.Text;
            actualizar.carne = txtCarne.Text;
            actualizar.asegurado = txtAsegurado.Text;
            actualizar.parentesco = ddlParentesco.SelectedItem.Text;
            actualizar.estado = Convert.ToBoolean(ddlEstado.SelectedValue);
            DBReclamos.SaveChanges();
            txtPoliza.Text = "";
            txtEjecutivo.Text = "";
            txtCarne.Text = "";
            txtAsegurado.Text = "";

            Actualizar.Visible = false;
            Guardar.Visible = true;

            gridAsegurados.DataSource = DBReclamos.info_asegurado.Take(20).Where(a => a.estado == true).ToList();
            gridAsegurados.DataBind();
          
            Utils.ShowMessage(this.Page, "registro actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el estado " + ex.Message, "Excelente", "error");
        }
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select * from info_asegurado where poliza like '%"+txtbuscar.Text+"%' or asegurado like '%"+txtbuscar.Text+"%' and estado = 1", gridAsegurados);
    }

    protected void gridAsegurados_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridAsegurados.SelectedRow.Cells[1].Text);
        var asegurado = DBReclamos.info_asegurado.Find(id);
        txtPoliza.Text = asegurado.poliza;
        txtEjecutivo.Text = asegurado.ejecutivo;
        txtCarne.Text = asegurado.carne;
        txtAsegurado.Text = asegurado.asegurado;
        ddlParentesco.SelectedItem.Text = asegurado.parentesco;
        ddlEstado.SelectedValue = asegurado.estado.Value.ToString();
        Guardar.Visible = false;
        Actualizar.Visible = true;
        Actualizar.Enabled = true;

    }
}