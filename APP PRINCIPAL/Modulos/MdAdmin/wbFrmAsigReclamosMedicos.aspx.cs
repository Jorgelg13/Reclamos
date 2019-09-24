using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class Modulos_MdAdmin_wbFrmAsigReclamosMedicos : System.Web.UI.Page
{
    String userlogin = HttpContext.Current.User.Identity.Name;
    Email notificacion = new Email();
    ReclamosEntities DBReclamos = new ReclamosEntities();
    private static readonly /*HttpClient client = new HttpClient();*/
    Utils comprobar = new Utils();
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!comprobar.verificarUsuario(userlogin))
        {
            Response.Redirect("/Asignacion.aspx");
        }
    }

    private void asignar_reclamos()
    {
        foreach (GridViewRow row in GridAsigMedicos.Rows)
        {
            CheckBox checkAsig = (CheckBox)row.FindControl("checkAsignar");
            String reclamo = Convert.ToString(row.Cells[1].Text);
            int id = Convert.ToInt32(reclamo);
            if (checkAsig.Checked)
            {
                try
                {
                    var asignar = DBReclamos.reclamos_medicos.Find(id);
                    var telefonoGestor = DBReclamos.gestores.Select(g => new { g.telefono, g.usuario, g.tipo }).Where(ges => ges.usuario == DDLusuario.SelectedValue && ges.tipo == "Medicos").First();
                    asignar.usuario_unity = DDLusuario.SelectedValue;
                    asignar.id_estado = 6;
                    asignar.estado_unity = "Asignado";
                    asignar.fecha_asignacion = DateTime.Now;
                    DBReclamos.SaveChanges();
                    GridAsigMedicos.DataBind();
                    Utils.insertarComentario(id, "Su reclamo ha sido asignado a un ejecutivo para su revisión, fecha: " + DateTime.Now, "Asignado");
                    string mensaje = "UNITY: Estimad@ cliente su reclamo ha sido asignado a  "+DDLusuario.SelectedItem.Text+", Telefono: "+telefonoGestor.telefono+".";
                    Utils.SMS_gastos_medicos(asignar.telefono,mensaje,userlogin,"Asignado",id, asignar.reg_reclamos_medicos.tipo);
            
                    Utils.ShowMessage(this.Page, "Reclamos asignados con exito", "Excelente", "success");
                }
                catch (Exception)
                {
                    Utils.ShowMessage(this.Page, "No se pudieron asignar los reclamos", "Error..!", "error");
                }
            }
        }
    }

    protected void bntAsignar_Click(object sender, EventArgs e)
    {
        asignar_reclamos();
        Utils.actividades(0, Constantes.GASTOS_MEDICOS(), 41, Constantes.USER());
    }
}