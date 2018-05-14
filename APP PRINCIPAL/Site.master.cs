using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Email Util = new Email();
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // El código siguiente ayuda a proteger frente a ataques XSRF
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Utilizar el token Anti-XSRF de la cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Establecer token Anti-XSRF
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validar el token Anti-XSRF
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        string user = HttpContext.Current.User.Identity.Name;
        //consulta la base de datos;
        Conteo();

    }

    public void Conteo()
    {
        try
        {
            var autos = DBReclamos.reclamo_auto.ToList().Where(a => a.id_estado == 1).Count();
            totalReclamosAutos.Text = autos.ToString();

            var danios = DBReclamos.reclamos_varios.ToList().Where(d => d.id_estado == 1).Count();
            totalReclamosDaños.Text = danios.ToString();

            var medicos = DBReclamos.reclamos_medicos.ToList().Where(m => m.estado_unity == "Sin Asignar").Count();
            totalReclamosMedicos.Text = medicos.ToString();

            var autorizaciones = DBReclamos.autorizaciones.ToList().Where(a => a.tipo_estado != "Cerrado").Count();
            totalAutorizaciones.Text = autorizaciones.ToString();
        }

        catch (Exception ex)
        {
            Util.enviarcorreo("reclamosgt@unitypromotores.com", "123$456R", "jorge.laj@unitypromotores.com", "Descripcion del error: " + ex, "Error en conteo de reclamos en cabina");
        }
    }
}