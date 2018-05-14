using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_Dashboard_DashboardNoConforme : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        totales();
    }

    public void totales()
    {
        var autos = DBReclamos.v_producto_no_conforme.ToList().Where(a => a.Tipo == "A" && a.estado == "Abierto").Count();
        lblautos.Text = autos.ToString();

        var danios = DBReclamos.v_producto_no_conforme.ToList().Where(d => d.Tipo == "D" && d.estado == "Abierto" ).Count();
        lbldanios.Text = danios.ToString();

        var individuales = DBReclamos.v_producto_no_conforme.ToList().Where(i => i.Tipo == "I" && i.estado == "Abierto").Count();
        lblindividuales.Text = individuales.ToString();

        var colectivos = DBReclamos.v_producto_no_conforme.ToList().Where(c => c.Tipo == "C" && c.estado == "Abierto").Count();
        lblcolectivos.Text = colectivos.ToString();
    }

    protected void autos_Click(object sender, EventArgs e)
    {
        principal.Visible = false;
        PanelGrid.Visible = true;
        GridNoConforme.DataSource = DBReclamos.v_producto_no_conforme.Where(a => a.Tipo == "A" && a.estado == "Abierto").ToList();
        GridNoConforme.DataBind();
    }

    protected void danios_Click(object sender, EventArgs e)
    {
        principal.Visible = false;
        PanelGrid.Visible = true;
        GridNoConforme.DataSource = DBReclamos.v_producto_no_conforme.Where(a => a.Tipo == "D" && a.estado == "Abierto").ToList();
        GridNoConforme.DataBind();
    }

    protected void individuales_Click(object sender, EventArgs e)
    {
        principal.Visible = false;
        PanelGrid.Visible = true;
        GridNoConforme.DataSource = DBReclamos.v_producto_no_conforme.Where(a => a.Tipo == "I" && a.estado == "Abierto").ToList();
        GridNoConforme.DataBind();
    }

    protected void colectivos_Click(object sender, EventArgs e)
    {
        principal.Visible = false;
        PanelGrid.Visible = true;
        GridNoConforme.DataSource = DBReclamos.v_producto_no_conforme.Where(a => a.Tipo == "C" && a.estado == "Abierto").ToList();
        GridNoConforme.DataBind();
    }

    protected void GridNoConforme_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        string tipo;
        id = Convert.ToInt32(GridNoConforme.SelectedRow.Cells[1].Text);
        tipo = GridNoConforme.SelectedRow.Cells[11].Text;

        if (tipo == "A")
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosAutosSeguimiento.aspx?ID_reclamo=" + id);
        }

        if (tipo == "D")
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosDañosSeguimiento.aspx?ID_reclamo=" + id);
        }

        if (tipo == "I" || tipo =="C")
        {
            Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id);
        }
    }
    protected void linkDescargar_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Producto No Conforme.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridNoConforme.AllowPaging = false;
            GridNoConforme.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void Regresar_Click(object sender, EventArgs e)
    {
        principal.Visible = true;
        PanelGrid.Visible = false;
    }
}