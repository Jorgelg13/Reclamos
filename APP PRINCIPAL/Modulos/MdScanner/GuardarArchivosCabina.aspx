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
        ReclamosEntities DBReclamos = new ReclamosEntities();
        HttpFileCollection files = HttpContext.Current.Request.Files;
        HttpPostedFile archivo = files["RemoteFile"];
        //String path = @"C:\Reclamos\ReclamosAutos";
        String path = @"E:\ReclamosScanner\files\Cabina";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String nombre, CA;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String id = Convert.ToString(Request.QueryString[0]).ToString();

       // var reclamo = DBReclamos.reclamo_auto.Find(Convert.ToInt64(id));

        CA = anio+"\\"+mes+"\\"+id;

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
        Response.Write(ex);
    }
%>