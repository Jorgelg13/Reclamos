using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdCatalogos_wbAseguradoras : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "jlaj") PnPrincipal.Visible = true;
        if (!IsPostBack)
        {
            GridAseguradoras.DataSource = DBReclamos.aseguradoras.ToList();
            GridAseguradoras.DataBind();
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
                aseguradoras aseguradora = new aseguradoras();
                aseguradora.aseguradora = txtDescripcion.Text;
                aseguradora.total_dias_rc_medicos = Convert.ToInt16(txtDias.Text);
                DBReclamos.aseguradoras.Add(aseguradora);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                GridAseguradoras.DataBind();
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
            id2 = Convert.ToInt32(GridAseguradoras.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.aseguradoras.Find(id2);
            actualizar.aseguradora = txtDescripcion.Text;
            actualizar.total_dias_rc_medicos = Convert.ToInt16(txtDias.Text);
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            txtDescripcion.Text = "";
            txtDias.Text = "";
            GridAseguradoras.DataSource = DBReclamos.aseguradoras.ToList();
            GridAseguradoras.DataBind();
            Utils.ShowMessage(this.Page, "aseguradora actualizada con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar los tiempos " + ex.Message, "Excelente", "error");
        }
    }

    protected void GridGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(GridAseguradoras.SelectedRow.Cells[1].Text);
        var aseguradora = DBReclamos.aseguradoras.Find(id);
        txtDescripcion.Text = aseguradora.aseguradora;
        txtDias.Text = aseguradora.total_dias_rc_medicos.ToString();
        Actualizar.Visible = true;
        Guardar.Visible = false;
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from aseguradoras where aseguradora like '%" + txtbuscar.Text + "%'", GridAseguradoras);
    }
}