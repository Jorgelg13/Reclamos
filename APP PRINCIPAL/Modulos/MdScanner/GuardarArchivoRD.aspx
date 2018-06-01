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
        //String path = @"C:\Reclamos\ReclamosVarios";
        String path = @"E:\ReclamosScanner\files\ReclamosVarios";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String nombre, RD;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        String id = (string)(Session["id_RD"]);
        var reclamo = DBReclamos.reclamos_varios.Find(Convert.ToInt64(id));

        if(String.IsNullOrEmpty(reclamo.documentos))
        {
            RD = anio+"\\"+mes+"\\"+"RD"+id;
        }

        else
        {
            RD = reclamo.documentos;
        }

        if (Directory.Exists(path+"\\"+RD))
        {
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\"+ RD +"\\"+ nombre);
            reclamo.documentos = RD;
            DBReclamos.SaveChanges();
        }

        else
        {
            DirectoryInfo di = Directory.CreateDirectory(path+"\\"+RD);
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\" + RD +"\\"+ nombre);
            reclamo.documentos = RD;
            DBReclamos.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex);
    }
%>