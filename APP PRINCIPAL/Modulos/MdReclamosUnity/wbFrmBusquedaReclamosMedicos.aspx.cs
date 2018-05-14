using System;
using System.Data.SqlClient;

public partial class Modulos_MdReclamosUnity_wbFrmBusquedaReclamosMedicos : System.Web.UI.Page
{
    conexionBD objeto = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Utils llenado = new Utils();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string buscador(String dato)
    {
        string[] arreglo = dato.Split(" ".ToCharArray());
        string sql = "";
        if (arreglo.Length > 0)
        {
           sql = "SELECT distinct " +
           "dbo.reclamos_medicos.id as ID," + //1
           "dbo.reclamos_medicos.asegurado as Asegurado," +
           "dbo.reclamos_medicos.estado_unity as [Estado Reclamo]," +
           "p.total_reclamado as [Monto Reclamado], "+
           "p.total_aprobado as [Total Aprobado],"+
           "p.deducible as Deducible, "+
           "dbo.reclamos_medicos.empresa as Empresa," +
           "dbo.reclamos_medicos.tipo_reclamo as [Tipo Reclamo]," +
           "dbo.reg_reclamos_medicos.poliza as Poliza,"+
           "dbo.reg_reclamos_medicos.ramo as Ramo," +
           "dbo.reg_reclamos_medicos.tipo as Tipo," +
           "dbo.reg_reclamos_medicos.clase as Clase," +
           "dbo.reg_reclamos_medicos.ejecutivo as Ejecutivo," +
           "dbo.reg_reclamos_medicos.estado_poliza as [Estado Poliza]," +
           "dbo.reg_reclamos_medicos.vip as VIP," +
           "dbo.reg_reclamos_medicos.moneda as Moneda," +
           "dbo.reg_reclamos_medicos.id " + //16
           " FROM " +
           " dbo.reg_reclamos_medicos " +
           "INNER JOIN dbo.reclamos_medicos ON dbo.reclamos_medicos.id_reg_reclamos_medicos = dbo.reg_reclamos_medicos.id " +
           "LEFT JOIN dbo.detalle_pagos_reclamos_medicos as p on p.id_reclamo_medico = reclamos_medicos.id "+
           "where " + DDLTipo.SelectedValue + " like '%" + arreglo[0] + "%' ";

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


    protected void GridBusquedaGeneral_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        id = Convert.ToInt32(GridBusquedaGeneral.SelectedRow.Cells[1].Text);
        Response.Redirect("/Modulos/MdReclamosUnity/wbFrmReclamosMedicosSeguimiento.aspx?ID_reclamo=" + id);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        llenado.llenarGrid(buscador(txtBusqueda.Text.ToString()), GridBusquedaGeneral);
    }
}