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
        Guardar.Enabled = true;
        Actualizar.Enabled = false;

        if (!IsPostBack)
        {
            gridAutos.DataSource = DBReclamos.flotillas.OrderByDescending(es => es.id).Take(100).ToList();
            gridAutos.DataBind();
        }
    }

    protected void Guardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPlaca.Text == "")
            {
                Utils.ShowMessage(this.Page, "El campo placa es requerido", "Nota..!", "warning");
            }
            else
            {
                flotillas registro = new flotillas();
                registro.inciso = Convert.ToInt32(txtInciso.Text);
                registro.propietario = txtPropietario.Text;
                registro.marca = txtMarca.Text;
                registro.linea = txtLinea.Text;
                registro.chasis = txtChasis.Text;
                registro.motor = txtMotor.Text;
                registro.year = txtAnio.Text;
                registro.color = txtColor.Text;
                registro.placa = txtPlaca.Text;
                registro.aseguradora = txtAseguradora.Text;
                registro.asegurado = txtAsegurado.Text;
                registro.poliza = txtPoliza.Text;
                registro.vigencia = txtVigencia.Text;
                registro.ejecutivo = txtEjecutivo.Text;
                registro.codigo_interno = txtCodigoInterno.Text;
                registro.pagador = txtPagador.Text;
                DBReclamos.flotillas.Add(registro);
                DBReclamos.SaveChanges();
                Utils.ShowMessage(this.Page, "Registro guardado con exito", "Excelente..!", "success");
                gridAutos.DataSource = DBReclamos.flotillas.OrderByDescending(es => es.id).Take(100).ToList();
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
            var actualizar = DBReclamos.flotillas.Find(id2);
            actualizar.inciso = Convert.ToInt32(txtInciso.Text);
            actualizar.propietario = txtPropietario.Text;
            actualizar.marca = txtMarca.Text;
            actualizar.linea = txtLinea.Text;
            actualizar.chasis = txtChasis.Text;
            actualizar.motor = txtMotor.Text;
            actualizar.year = txtAnio.Text;
            actualizar.color = txtColor.Text;
            actualizar.placa = txtPlaca.Text;
            actualizar.aseguradora = txtAseguradora.Text;
            actualizar.asegurado = txtAsegurado.Text;
            actualizar.poliza = txtPoliza.Text;
            actualizar.vigencia = txtVigencia.Text;
            actualizar.ejecutivo = txtEjecutivo.Text;
            actualizar.codigo_interno = txtCodigoInterno.Text;
            actualizar.pagador = txtPagador.Text;
            DBReclamos.SaveChanges();
            Actualizar.Visible = false;
            Guardar.Visible = true;
            gridAutos.DataSource = DBReclamos.asegurados_caja_ahorro.OrderByDescending(es => es.id).Take(100).ToList();
            gridAutos.DataBind();
            limiparCampos();

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
        llenado.llenarGrid("select * from flotillas where placa like '%" + txtbuscar.Text + "%'", gridAutos);
    }

    protected void gridAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridAutos.SelectedRow.Cells[1].Text);
        var reg = DBReclamos.flotillas.Find(id);
        txtInciso.Text = reg.inciso.ToString();
        txtPropietario.Text = reg.propietario;
        txtMarca.Text = reg.marca;
        txtLinea.Text = reg.linea;
        txtChasis.Text = reg.chasis;
        txtMotor.Text = reg.motor;
        txtAnio.Text = reg.year;
        txtColor.Text = reg.color;
        txtPlaca.Text = reg.placa;
        txtAseguradora.Text = reg.aseguradora;
        txtAsegurado.Text = reg.asegurado;
        txtPoliza.Text = reg.poliza;
        txtVigencia.Text = reg.vigencia;
        txtEjecutivo.Text = reg.ejecutivo;
        txtCodigoInterno.Text = reg.codigo_interno;
        txtPagador.Text = reg.pagador;
        Guardar.Visible = false;
        Actualizar.Visible = true;
        Actualizar.Enabled = true;
        Borrar.Visible = true;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        id = Convert.ToInt32(gridAutos.SelectedRow.Cells[1].Text);
        var reg = DBReclamos.flotillas.Find(id);
        DBReclamos.flotillas.Remove(reg);
        DBReclamos.SaveChanges();
        gridAutos.DataSource = DBReclamos.flotillas.OrderByDescending(es => es.id).Take(100).ToList();
        gridAutos.DataBind();
    }

    private void limiparCampos()
    {
        txtInciso.Text ="";
        txtPropietario.Text = "";
        txtMarca.Text = "";
        txtLinea.Text = "";
        txtChasis.Text = "";
        txtMotor.Text = "";
        txtAnio.Text = "";
        txtColor.Text = "";
        txtPlaca.Text = "";
        txtAseguradora.Text = "";
        txtAsegurado.Text = "";
        txtPoliza.Text = "" ;
        txtVigencia.Text = "";
        txtEjecutivo.Text = "" ;
        txtCodigoInterno.Text = "";
        txtPagador.Text = "";
        Actualizar.Visible = false;
        Borrar.Visible = false;
    }
}