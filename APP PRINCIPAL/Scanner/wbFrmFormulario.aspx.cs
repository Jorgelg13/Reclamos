using System;
using System.Data;
using System.Data.SqlClient;

public partial class formulario_wbFrmFormulario : System.Web.UI.Page
{
    conexionBD obj = new conexionBD();
    SqlCommand cmd = new SqlCommand();
    Int16 enfermedaded ;
    Int16 impedimentos ;
    Int16 actividadFisica ;
    String ultimoId;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void insertarRegistro()
    {
        if( validarCheck() == true)
        {
            try
            {
                opcionesCheck();

                if (txtNombre.Text == "")
                {
                    Response.Write("<Script>setTimeout(function () { toastr.warning('Debe de ingresar todos los datos requeridos', 'Revisar!');  }, 200);</script>");
                }

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into formulario_colectivo(poliza, " +
                    "certificado,vigencia," +
                    "contratante, nombre_titular," +
                    "dpi," +
                    "nit," +
                    "direccion," +
                    "telefono," +
                    "email, " +
                    "nombre_asegurado_titular," +
                    "ocupacion_titular, " +
                    "peso_titular, " +
                    "estatura_titular, " +
                    "fecha_nacimiento_titular, " +
                    "nombre_beneficiario1, parentesco_ben1, " +
                    "porcentaje_ben1," +
                    "nombre_beneficiario2, " +
                    "parentesco_ben2, " +
                    "porcentaje_ben2, " +
                    "enfermedades, " +
                    "detalle_enfermedades, " +
                    "impedimentos," +
                    "detalle_impedimentos," +
                    "enfermedades_recientes," +
                    "actividad_peligrosa, " +
                    "detalle_actividad_peligrosa, " +
                    "lugar_fecha, solicitante) " +
                    "values('" + txtPoliza.Text + "','" + txtCertificado.Text + "','" + txtVigencia.Text + "','" + txtContratante.Text + "','" + txtNombre.Text + "', '" + txtDpi.Text + "','" + txtNit.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "','" + txtEmail.Text + "','" + txtNombreCompletoTitular.Text + "','" + txtocupacionTitular.Text + "','" + txtpesoTitular.Text + "','" + txtEstaturaTitular.Text + "','" + txtFechaNacimientoTitular.Text + "','" + txtNombreBeneficiario1.Text + "','" + txtParentesco1.Text + "','" + txtPorcentaje1.Text + "', '" + txtNombreBeneficiaro2.Text + "','" + txtParentesco2.Text + "','" + txtPorcentaje2.Text + "'," + enfermedaded + ",'" + txtDetalleEnfermedad.Text + "', " + impedimentos + ",'" + txtDetallesImpedimemtos.Text + "','" + txtEnfermedadesRecientes.Text + "'," + actividadFisica + ", '" + txtAcitividadFisica.Text + "','" + txtLugar.Text + "','" + txtSolicitante.Text + "')";
                cmd.Connection = obj.ObtenerConexionReclamos();
                cmd.ExecuteNonQuery();
                obj.conexion.Close();
                Response.Write("<Script>setTimeout(function () { toastr.success('Registro ingresado con exito', 'Excelente!');  }, 200);</script>");
                //limpiar();
                obtenerId();
            }

            catch (Exception ex)
            {
                Response.Write(ex);
                Response.Write("<Script>setTimeout(function () { toastr.error('Error de insercion revise los campos digitados', 'Error!');  }, 200);</script>");
            }

            finally
            {
                obj.DescargarConexion();
            }
        }  
    }

    protected void btngGuardar_Click(object sender, EventArgs e)
    {
        insertarRegistro();
        //imprimir();
    }

    public void limpiar()
    {
        txtCertificado.Text = "";
        txtVigencia.Text = "";
        txtNombre.Text = "";
        txtNit.Text = "";
        txtDpi.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtEmail.Text = "";
        txtNombreCompletoTitular.Text = "";
        txtocupacionTitular.Text = "";
        txtpesoTitular.Text = "";
        txtEstaturaTitular.Text = "";
        txtFechaNacimientoTitular.Text = "";
        txtNombreBeneficiario1.Text = "";
        txtParentesco1.Text = "";
        txtPorcentaje1.Text = "";
        txtNombreBeneficiaro2.Text = "";
        txtParentesco2.Text = "";
        txtPorcentaje2.Text = "";
        txtDetalleEnfermedad.Text = "";
        txtDetallesImpedimemtos.Text = "";
        txtAcitividadFisica.Text = "";
        txtLugar.Text = "";
        txtSolicitante.Text = "";
    }

    public void obtenerId()
    {
        try
        {
            string selecid = "SELECT IDENT_CURRENT('formulario_colectivo')";
            SqlDataAdapter da = new SqlDataAdapter(selecid, obj.ObtenerConexionReclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblId.Text = dt.Rows[0][0].ToString();
            obj.conexion.Close();
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
    }


    public bool validarCheck()
    {
        bool validado = false;

        if((checkSi.Checked == true && checkNo.Checked == true) || (chekActividadFisicaSi.Checked == true && checkActividadFisicaNo.Checked == true) || (checkImpedimientoFisicoSi.Checked == true && checkImpedimentoFisicoNo.Checked))
        {
            Response.Write("<Script>setTimeout(function () { toastr.warning('No Puede tener dos opciones chequeadas, deseleccione una', 'Revisar!');  }, 200);</script>");
            validado = false;
        }

        else
        {
            validado = true;
        }

        return validado;
    }

    public void opcionesCheck()
    {
        if (checkSi.Checked)
        {
            enfermedaded = 1;
        }
        if (checkNo.Checked)
        {
            enfermedaded = 0;
        }
        if (checkImpedimientoFisicoSi.Checked)
        {
            impedimentos = 1;
        }
        if (checkImpedimentoFisicoNo.Checked)
        {
            impedimentos = 0;
        }
        if (chekActividadFisicaSi.Checked)
        {
            actividadFisica = 1;
        }
        if (checkActividadFisicaNo.Checked)
        {
            actividadFisica = 0;
        }
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        limpiar();
    }
}