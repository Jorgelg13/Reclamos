using EmailValidation;
using System;
using System.Web;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Modulos_MdRenovaciones_Dashboard : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Utils llenar = new Utils();
    Renovaciones.RenovacionesEntities DBRenovaciones = new Renovaciones.RenovacionesEntities();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    String cuerpo;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CodigoGestor"] = Utils.CODIGO_GESTOR(userlogin);

        try
        {
            var user = DBReclamos.usuario.Where(U => U.nombre == userlogin).First();

            if (user.rol == "F")
            {
                Response.Redirect("/Modulos/MdRenovaciones/Estados/Renovadas.aspx",false);
            }
        }
        catch { }

        if (!IsPostBack)
        {
            PolizasRoble();
        }
    }


    public void PolizasRoble()
    {
        llenarGrid();
    }

    public void llenarGrid()
    {
        llenar.llenarGridRenovaciones(Consultas.POLIZAS_RENOVADAS(Convert.ToInt32(Session["CodigoGestor"]), 2, "", ""), GridElRoble);
    }

    public void ValidarCorreo(String correo, int id)
    {
        EmailValidator emailValidator = new EmailValidator();
        EmailValidationResult resultado;
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);
        var gestor = DBReclamos.usuario.Find(Convert.ToInt32(Session["CodigoGestor"]));
        if(registro.correo_cliente != "")
        {
            envio(id,correo);
            /*if (!emailValidator.Validate(correo.Trim(), out resultado))
            {
                Console.WriteLine("Unable to check email"); // no internet connection or mailserver is down / busy
                registro.estado = 6;
                DBRenovaciones.SaveChanges();
                llenarGrid();
            }

            switch (resultado)
            {
                case EmailValidationResult.OK:
                    Utils.EmailRenovacion("pa_envio_renovaciones", correo.Trim(), txtCuerpo.Text, registro.correo_gestor.Trim());
                    Utils.EmailRenovacion("pa_envio_renovaciones", registro.correo_gestor.Trim(), txtCuerpo.Text, registro.correo_gestor.Trim());
                    registro.estado = 3;
                    DBRenovaciones.SaveChanges();
                    String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
                    Utils.MoverArchivos(Poliza, "Enviadas");
                    //EnvioSms();
                    llenarGrid();
                    break;

                case EmailValidationResult.MailboxUnavailable:
                    //Console.WriteLine("Email server replied there is no such mailbox");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;

                case EmailValidationResult.MailboxStorageExceeded:
                    //Console.WriteLine("Mailbox overflow");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;

                case EmailValidationResult.NoMailForDomain:
                    //Console.WriteLine("Emails are not configured for domain (no MX records)");
                    registro.estado = 6;
                    DBRenovaciones.SaveChanges();
                    llenarGrid();
                    break;
            } */
        } 

        else
        {
            registro.estado = 6;
            DBRenovaciones.SaveChanges();
            llenarGrid();
        }
    }
    
    private void envio(int id,string correo)
    {
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);

        try
        {
            Utils.EmailRenovacion("pa_envio_renovaciones", correo, txtCuerpo.Text, registro.correo_gestor.Trim());
            Utils.EmailRenovacion("pa_envio_renovaciones", registro.correo_gestor, txtCuerpo.Text, Utils.seleccionarCorreoGestor(userlogin));
            registro.estado = 3;
            DBRenovaciones.SaveChanges();
            String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
            Utils.MoverArchivos(Poliza, "Enviadas","Polizas");
            EnvioSms();
            llenarGrid();
        }

        catch (Exception)
        {
            registro.estado = 6;
            DBRenovaciones.SaveChanges();
            llenarGrid();
        }
    }

    protected void GridElRoble_SelectedIndexChanged(object sender, EventArgs e)
    {
        int identificador = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(identificador);
        txtTelefono.Text = registro.telefono_cliente;
        cuerpo = Cartas.RENOVACIONES(identificador);
        txtCuerpo.Text = cuerpo;
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "show_modal", "$('#ModalCorreo').modal('show');", addScriptTags: true);
    }

    //enviar correo electronico
    protected void lnkGuardar_Click(object sender, EventArgs e)
    {
        string correo = Convert.ToString(GridElRoble.SelectedRow.Cells[12].Text);
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);

        try
        {
            this.ValidarCorreo(correo, id);
        }
        catch (Exception ex)
        {
            Utils.ShowMessage(this.Page, "No se a podido renovar " + ex.Message, "Excelente", "success");
        }
    }

  
    //mover registros a invalidos
    protected void GridElRoble_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridElRoble.Rows[e.RowIndex];
        int ID = Convert.ToInt32(row.Cells[3].Text);

        var registro = DBRenovaciones.renovaciones_polizas.Find(ID);
        registro.estado = 8;

        String Poliza = (registro.ramo + registro.poliza + registro.endoso_renov + ".pdf");
        Utils.MoverArchivos(Poliza, "Invalidas", "Polizas");

        DBRenovaciones.SaveChanges();
        llenarGrid();
    }

    private void EnvioSms()
    {
        int id = Convert.ToInt32(GridElRoble.SelectedRow.Cells[3].Text);
        var registro = DBRenovaciones.renovaciones_polizas.Find(id);

        String mensaje = "Hemos enviado a su email registrado la renovacion " +  Convert.ToDateTime(registro.vigf).Year + "/" +  Convert.ToDateTime(registro.vigf).AddYears(1).Year + " " +
            "de su poliza " + registro.poliza_unity + " del " + registro.marca + " / " + registro.modelo +", favor revisar y cualquier duda contacte a " +
            "" + registro.nombre_gestor + " al " + Utils.TelefonoEjecutivo(Convert.ToInt32(registro.codigo_gestor));

        Utils.ENVIOSMS(txtTelefono.Text,mensaje);
    }
}