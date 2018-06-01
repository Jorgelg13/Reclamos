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
        String path = @"E:\ReclamosScanner\files\ReclamosAutos";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String nombre, RA;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String id = (string)(Session["id_RA"]);
        var reclamo = DBReclamos.reclamo_auto.Find(Convert.ToInt64(id));

        if(String.IsNullOrEmpty(reclamo.documentos))
        {
            RA = anio+"\\"+mes+"\\"+"RA"+id;
        }

        else
        {
            RA = reclamo.documentos;
        }

        if (Directory.Exists(path+"\\"+RA))
        {
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\"+ RA +"\\"+ nombre);
            reclamo.documentos = RA;
            DBReclamos.SaveChanges();
        }

        else
        {
            DirectoryInfo di = Directory.CreateDirectory(path+"\\"+RA);
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\" + RA +"\\"+ nombre);
            reclamo.documentos = RA;
            DBReclamos.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex);
    }
%>