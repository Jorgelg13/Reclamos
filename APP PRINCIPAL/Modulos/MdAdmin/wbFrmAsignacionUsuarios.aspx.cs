using System;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public partial class Modulos_MdReclamos_wbFrmAsignacionUsuarios : System.Web.UI.Page
{
   
    String userID;
    String cabina1;
    String userlogin = HttpContext.Current.User.Identity.Name;
    conexionBD obj = new conexionBD();
    ReclamosEntities DBReclamos = new ReclamosEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (checkUpdate.Checked)
        {
            btnActualizar.Enabled = true;
            btnGuardarAsignacion.Enabled = false;
        }
        else
        {
            btnActualizar.Enabled = false;
            btnGuardarAsignacion.Enabled = true;
        }
    }

    //metodo para obtener el identificador unico que hace referencia a cada usuario en la base de datos de usuario
    public void obtenerId()
    {
        try
        {
            string selectUser = "SELECT UserId FROM Users where UserName = '" + ddlUsuario.SelectedItem + "' ";
            SqlDataAdapter da = new SqlDataAdapter(selectUser, obj.ObtenerConexionSeg_Reclamos());
            DataTable dt = new DataTable();
            da.Fill(dt);
            int count = dt.Rows.Count;
            userID = dt.Rows[0][0].ToString();
        }
        catch (Exception)
        {
            Utils.ShowMessage(this.Page, "Error al realizar la busqueda", "Error..!", "errir"); 
        }
        finally
        {
            obj.DescargarConexion();
        }
    }

    //verificar si el usuario existe para no ser vuelto a asignar
    public bool verificarUsuario()
    {
        bool existe = false;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader sdr;
        cmd.Connection = obj.ObtenerConexionReclamos();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select nombre from usuario where nombre = '" + ddlUsuario.SelectedItem + "' ";
        try
        {
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                existe = true;
            }

            else
            {
                existe = false;
            }
        }

        catch (Exception)
        {
          
        }

        finally
        {
            obj.DescargarConexion();
        }

        return existe;
    }

    protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
    {
        //seleccionar id de usuario en base de datos de usuarios

        obtenerId();

        if (verificarUsuario() == true)
        {
            Utils.ShowMessage(this.Page, "Ese usuario ya fue asignado solo puedes actualizarlo", "Error..!", "error");
        }
        else
        { 
            try
            {
                usuario user = new usuario();
                gestores gestor = new gestores();

                user.nombre = ddlUsuario.SelectedItem.Text;
                user.id_usuario = Guid.NewGuid();
                user.id_cabina = Convert.ToInt32(ddlCabina.SelectedValue);
                user.nombre_completo = txtNombre.Text;
                user.fecha_nacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                user.correo = txtCorreo.Text;
                user.numero_gestor = Convert.ToInt16(txtGestor.Text);
                user.permiso_movil = checkMovil.Checked;
                user.pais = ddlPais.SelectedItem.Text;
                user.empresa = ddlEmpresa.SelectedItem.Text;
                user.sucursal = ddlSucursal.SelectedItem.Text;
                user.cabina = ddlCabina.SelectedItem.Text;
                user.codigo =Convert.ToInt16(ddlPais.SelectedValue);

                gestor.nombre = txtNombre.Text;
                gestor.usuario = ddlUsuario.SelectedItem.Text;
                gestor.correo = txtCorreo.Text;
                gestor.telefono = txtTelefono.Text;
                gestor.tipo = ddlArea.SelectedValue;
                gestor.estado = true;
                DBReclamos.usuario.Add(user);
                DBReclamos.gestores.Add(gestor);
                DBReclamos.SaveChanges();

                Utils.ShowMessage(this.Page, "Usuario Asignado..", "Excelente", "success");
            }
            catch (Exception)
            {
                Utils.ShowMessage(this.Page, "Hubo un error al asignar el usuario..", "Error", "error");
            }
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            var user = DBReclamos.usuario.Where(us => us.nombre == ddlUsuario.SelectedItem.Text).First();
            user.nombre = txtNombre.Text;
            user.id_cabina = Convert.ToInt16(ddlCabina.SelectedValue);
            user.nombre_completo = txtNombre.Text;
            user.fecha_nacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            user.correo = txtCorreo.Text;
            user.numero_gestor = Convert.ToInt16(txtGestor.Text);
            user.permiso_movil = checkMovil.Checked;
            user.pais = ddlPais.SelectedItem.Text;
            user.empresa = ddlEmpresa.SelectedItem.Text;
            user.sucursal = ddlSucursal.SelectedItem.Text;
            user.cabina = ddlCabina.SelectedItem.Text;
            user.codigo = Convert.ToInt16(ddlPais.SelectedValue);

            Utils.ShowMessage(this.Page, "Usuario Actualizado", "Excelente..!", "success");
        }
        catch (Exception )
        {
            Utils.ShowMessage(this.Page, "No se pudo actualizar", "Error..!", "error");
        }
    }
}