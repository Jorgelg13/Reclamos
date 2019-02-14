using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    ReclamosEntities DBReclamos = new ReclamosEntities();
    Email Util = new Email();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}