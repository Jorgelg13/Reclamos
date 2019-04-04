using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_MdReclamosUnity_wbFrmBusquedaReclamosMedicos : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();
    String where = "";
    String sql = "";
    Double montoReclamado, totalAprobado, deducible;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string buscador(String poliza, String asegurado)
    {
        string[] arreglo = asegurado.Split(" ".ToCharArray());
        
        if(poliza != "" && asegurado == "")
        {
            where = "Where reg_reclamos_medicos.poliza = '"+poliza+"' ";
        }

        else if(asegurado != "" && poliza =="")
        {
            where = "where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%'  ";
        }

        else if (poliza != "" && asegurado != "")
        {
            where = "where reclamos_medicos.asegurado like '%" + arreglo[0] + "%' and  reg_reclamos_medicos.poliza = '" + poliza + "' ";
        }

        if (arreglo.Length > 0)
        {
            sql = "SELECT distinct " +
            "dbo.reclamos_medicos.id as ID," + //1
            "dbo.reclamos_medicos.asegurado as Asegurado," +
            "dbo.reclamos_medicos.estado_unity as [Estado Reclamo]," +
            "p.total_reclamado as [Monto Reclamado], " +
            "p.total_aprobado as [Total Aprobado]," +
            "p.deducible as Deducible, " +
            "dbo.reclamos_medicos.empresa as Contratante," +
            "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
            "dbo.reg_reclamos_medicos.poliza as Poliza," +
            "dbo.reg_reclamos_medicos.tipo as Tipo," +
            "dbo.reg_reclamos_medicos.clase as Clase" +
            " FROM " +
            " dbo.reg_reclamos_medicos " +
            "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
            "LEFT JOIN dbo.detalle_pagos_reclamos_medicos as p on p.id_reclamo_medico = reclamos_medicos.id " + where; 
          
           //"where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%'  ";

            if (arreglo.Length > 1)
            {
                for (int i = 1; i < arreglo.Length; i++)
                {
                    if (!String.IsNullOrEmpty(arreglo[i].Trim()))
                    {
                        if(DDLTipo.SelectedValue == "ambos")
                        {
                            sql += " and reclamos_medicos.asegurado like '%" + arreglo[i] + "%' ";
                        }
                        else
                        {
                            sql += " and " + DDLTipo.SelectedValue + " like '%" + arreglo[i] + "%' ";
                        }
                    }
                }
            }
        }

        return sql;
    }


    protected void GridBusquedaGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        id = Convert.ToInt32(GridBusquedaGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id, false);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (DDLTipo.SelectedItem.Text == "Poliza")
        {
            llenado.llenarGrid(buscador(txtBusqueda.Text, txtAsegurado.Text), GridBusquedaGeneral);
        }

        else if (DDLTipo.SelectedItem.Text == "Asegurado")
        {
            llenado.llenarGrid(buscador(txtBusqueda.Text, txtAsegurado.Text), GridBusquedaGeneral);
        }

        else if (DDLTipo.SelectedItem.Text == "Ambos")
        {
            llenado.llenarGrid(buscador(txtBusqueda.Text, txtAsegurado.Text), GridBusquedaGeneral);
        }
    }

    protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DDLTipo.SelectedItem.Text == "Poliza")
        {
            txtAsegurado.Enabled = false;
            txtAsegurado.Text = "";
            txtBusqueda.Enabled = true;
        }

        else if(DDLTipo.SelectedItem.Text == "Asegurado")
        {
            txtAsegurado.Enabled = true;
            txtBusqueda.Enabled = false;
            txtBusqueda.Text = "";
        }

        else if(DDLTipo.SelectedItem.Text == "Ambos")
        {
            txtAsegurado.Enabled = true;
            txtBusqueda.Enabled = true;
        }
    }

    protected void GridBusquedaGeneral_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                montoReclamado += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Monto Reclamado]"));
                totalAprobado += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Total Aprobado]"));
                deducible += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "[Deducible]"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "TOTALES:";
                e.Row.Cells[4].Text = montoReclamado.ToString("N");
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
                lblMontoReclamado.Text = "Monto Reclamado: "+ montoReclamado.ToString("N");

                e.Row.Cells[5].Text = totalAprobado.ToString("N");
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Font.Bold = true;
                lblTotalAprobado.Text ="Total Aprobado: "+ totalAprobado.ToString("N");

                e.Row.Cells[6].Text = deducible.ToString("N");
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                lblDeducible.Text = "Deducible: " + deducible.ToString("N");

                e.Row.Font.Bold = true;
            }
        }
        catch (Exception)
        {
            // Response.Write(err);
        }
    }
}