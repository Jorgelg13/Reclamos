using System;

public partial class ViewSwitcher : System.Web.UI.UserControl
{
    protected string CurrentView { get; private set; }

    protected string AlternateView { get; private set; }

    protected string SwitchUrl { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}