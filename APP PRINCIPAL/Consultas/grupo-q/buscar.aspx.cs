using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Consultas_vifrio_Default : System.Web.UI.Page
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Utils llenado = new Utils();
    String consulta, sucursal;

    protected void Page_Load(object sender, EventArgs e)
    {
        sucursal = Convert.ToString(Request.QueryString[0]).ToString();
        consulta = "select poliza as Poliza, estado as Estado, " +
            "placa as Placa from asegurados_consultas where poliza like '%" + txtBusqueda.Text + "%' or placa like '%"+txtBusqueda.Text+ "%'  or chasis like '%"+txtBusqueda.Text+"%'  ";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if(txtBusqueda.Text == "")
        {
            lblError.Text = "Debe igresar un codigo";
            panelError.Visible = true;
            GridBuscar.Visible = false;
            panelSuccess.Visible = false;
        } 

        else
        {
            GridBuscar.Visible = true;
            llenado.llenarGrid(consulta, GridBuscar);
            if (GridBuscar.Rows.Count > 0)
            {
                panelError.Visible = false;
            }
            else
            {
                lblError.Text = "No se encontro ningun asegurado";
                ddlServicio.Visible = false;
                btnGuardar.Visible = false;
                panelSuccess.Visible = false;
                panelError.Visible = true;
            }
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if(ddlServicio.SelectedItem.Text =="Seleccionar servicio")
            {
                lblError.Text = "debe seleccionar un tipo de servicio";
                panelError.Visible = true;
            } 
            
            else
            {
                registros_consultas registro = new registros_consultas();
                registro.poliza = GridBuscar.SelectedRow.Cells[1].Text;
                registro.asegurado = "";
                registro.placa = GridBuscar.SelectedRow.Cells[3].Text;
                registro.fecha = DateTime.Now;
                registro.servicio = ddlServicio.SelectedItem.Text;
                registro.sucursal = sucursal;
                DBReclamos.registros_consultas.Add(registro);
                DBReclamos.SaveChanges();
                lblSuccess.Text = "Registro guardado exitosamente";
                panelError.Visible = false;
                panelSuccess.Visible = true;
                ddlServicio.Visible = false;
                btnGuardar.Visible = false;
            }
        }
        catch(Exception ex)
        {
            lblError.Text = "No se pudo guardar el registro, " + ex.Message;
            panelSuccess.Visible = false;
            panelError.Visible = true;
        }
        
    }

    protected void GridBuscar_SelectedIndexChanged(object sender, EventArgs e)
    {
        panelSuccess.Visible = false;
        ddlServicio.Visible = true;
        btnGuardar.Visible = true;
    }
}