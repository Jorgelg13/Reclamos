using System;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_aperturar_reclamos : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    string consulta;
    Utils llenar = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenar.llenarGrid(buscador(txtBusqueda.Text), GridReclamos);
    }

    protected void btnAperturar_Click(object sender, EventArgs e)
    {
        reaperturar();
    }

    private void reaperturar()
    {
        foreach (GridViewRow row in GridReclamos.Rows)
        {
            CheckBox checkAperturar = (CheckBox)row.FindControl("checkReaperturar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAperturar.Checked)
            {
                try
                {
                    var aperturar = DBReclamos.reclamos_varios.Find(id);
                    aperturar.estado_unity = "Seguimiento";
                    DBReclamos.SaveChanges();
                    llenar.llenarGrid(buscador(txtBusqueda.Text), GridReclamos);
                    GridReclamos.DataBind();
                    Utils.ShowMessage(this.Page, "Reclamos reaperturados con exito", "Excelente", "success");
                }
                catch (Exception)
                {
                    Utils.ShowMessage(this.Page, "No se pudieron reaperturar los reclamos", "Error..!", "error");
                }
            }
        }
    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
            sql = "select " +
                "r.id as ID, " +
                "reg.poliza as Poliza, " +
                "reg.asegurado as Asegurado, " +
                "r.estado_unity as Estado "+
                "FROM reclamos_varios as r " +
                "INNER JOIN reg_reclamo_varios as reg ON r.id_reg_reclamos_varios = reg.id " +
                "where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' and r.estado_unity = 'Cerrado' ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        sql += " and " + DDLTipo.SelectedValue + " like '%" + arreglo[i] + "%' ";
                    }
                }
            }
        }

        return sql;
    }
}