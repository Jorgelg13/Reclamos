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
        HttpFileCollection files = HttpContext.Current.Request.Files;
        HttpPostedFile archivo = files["RemoteFile"];
        String path = @"E:\ReclamosScanner\files\Cabina";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String nombre, CA;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String id = Convert.ToString(Request.QueryString[0]);

        CA = anio+"\\"+mes+"\\"+archivo.FileName.Replace(".pdf","");

        if (Directory.Exists(path+"\\"+CA))
        {
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\"+ CA +"\\"+ nombre);
        }

        else
        {
            DirectoryInfo di = Directory.CreateDirectory(path+"\\"+CA);
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\" + CA +"\\"+ nombre);
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message + " A ocurrido un error");
    }
%>