<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Globalization" %>

<%
    try
    {
        DateTime fecha = DateTime.Now;
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        string mes = formatoFecha.GetMonthName(fecha.Month);
        string anio = fecha.Year.ToString();
        string path = @"E:\ReclamosScanner\files\GastosMedicos";
        //string path = @"C:\Reclamos";
        string RM = path + "\\"+anio+"\\"+ mes;

        if (Directory.Exists(RM))
        {

        }

        DirectoryInfo di = Directory.CreateDirectory(RM);

        String strImageName;
        HttpFileCollection files = HttpContext.Current.Request.Files;
        HttpPostedFile uploadfile = files["RemoteFile"];
        strImageName = uploadfile.FileName;
        uploadfile.SaveAs(RM +"\\"+ strImageName);
    }

    catch
    {

    }
%>
