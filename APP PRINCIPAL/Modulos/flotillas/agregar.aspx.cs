using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modulos_flotillas_agregar : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    ReclamosEntities DBReclamos = new ReclamosEntities();
    int id;
    string idRecibido;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (userlogin == "nsierra" || userlogin == "cmejia" || userlogin == "jlaj")
        {
            Guardar.Enabled = true;
            Actualizar.Enabled = false;
        }

        if (!IsPostBack)
        {
            gridAutos.DataSource = DBReclamos.asegurados_caja_ahorro.OrderByDescending(es => es.id).Take(100).ToList();
            gridAutos.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNombreAsegurado.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo nombre es requerido", "Nota..!", "warning");
            }
            else
            {
                asegurados_caja_ahorro registro = new asegurados_caja_ahorro();
                registro.nombre = txtNombreAsegurado.Text;
                registro.poliza = txtPoliza.Text;
                registro.modelo = txtModelo.Text;
                registro.marca = txtMarca.Text;
                registro.linea = txtLinea.Text;
                registro.placa = txtPlaca.Text;
                registro.empresa = ddlEmpresa.SelectedItem.Text;
                DBReclamos.asegurados_caja_ahorro.Add(registro);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                gridAutos.DataSource = DBReclamos.asegurados_caja_ahorro.OrderByDescending(es => es.id).Take(100).ToList();
                gridAutos.DataBind();
                limiparCampos();
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
            id2 = Convert.ToInt32(gridAutos.SelectedRow.Cells[1].Text);
            var actualizar = DBReclamos.asegurados_caja_ahorro.Find(id2);
            actualizar.nombre = txtNombreAsegurado.Text;
            actualizar.poliza = txtPoliza.Text;
            actualizar.modelo = txtModelo.Text;
            actualizar.marca = txtMarca.Text;
            actualizar.linea = txtLinea.Text;
            actualizar.placa = txtPlaca.Text;
            actualizar.empresa = ddlEmpresa.SelectedItem.Text;
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            gridAutos.DataSource = DBReclamos.asegurados_caja_ahorro.OrderByDescending(es => es.id).Take(100).ToList();
            gridAutos.DataBind();
            limiparCampos();

            Utils.ShowMessage(this.Page, "estado actualizado con exito", "Excelente", "success");
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "Hubo un error al Actualizar el estado " + ex.Message, "Excelente", "error");
        }
    }


    protected void buscar_Click(object sender, EventArgs e)
    {
        Utils llenado = new Utils();
        llenado.llenarGrid("select *from asegurados_caja_ahorro where placa like '%" + txtbuscar.Text + "%'", gridAutos);
    }

    protected void gridAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridAutos.SelectedRow.Cells[1].Text);
        var reg = DBReclamos.asegurados_caja_ahorro.Find(id);
        txtNombreAsegurado.Text = reg.nombre;
        txtPoliza.Text = reg.poliza;
        txtMarca.Text = reg.marca;
        txtLinea.Text = reg.linea;
        txtModelo.Text = reg.modelo;
        txtPlaca.Text = reg.placa;
        ddlEmpresa.SelectedValue = reg.empresa;
        Guardar.Visible = false;
        Actualizar.Visible = true;
        Actualizar.Enabled = true;
        Borrar.Visible = true;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridAutos.SelectedRow.Cells[1].Text);
        var reg = DBReclamos.asegurados_caja_ahorro.Find(id);
        DBReclamos.asegurados_caja_ahorro.Remove(reg);
        DBReclamos.SaveChanges();
        gridAutos.DataSource = DBReclamos.asegurados_caja_ahorro.OrderByDescending(es => es.id).Take(100).ToList();
        gridAutos.DataBind();
    }

    private void limiparCampos()
    {
        txtNombreAsegurado.Text = "";
        txtPoliza.Text = "";
        txtPlaca.Text = "";
        txtLinea.Text = "";
        txtMarca.Text = "";
        txtModelo.Text = "";
        Actualizar.Visible = false;
        Borrar.Visible = false;
    }
}