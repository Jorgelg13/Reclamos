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
        //String path = @"C:\Reclamos";
        String path = @"E:\ReclamosScanner\files\GastosMedicos";
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        DateTime fecha = DateTime.Now;
        String nombre, RM;
        String mes = formatoFecha.GetMonthName(fecha.Month);
        String anio = fecha.Year.ToString();
        string id = (string)(Session["id_RM"]);
        var reclamo = DBReclamos.reclamos_medicos.Find(Convert.ToInt64(id));

        if(String.IsNullOrEmpty(reclamo.documento))
        {
            RM = anio+"\\"+mes+"\\"+"RM"+id;
        }

        else
        {
            RM = reclamo.documento;
        }

        if (Directory.Exists(path+"\\"+RM))
        {
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\"+ RM +"\\"+ nombre);
            reclamo.documento = RM;
            DBReclamos.SaveChanges();
        }

        else
        {
            DirectoryInfo di = Directory.CreateDirectory(path+"\\"+RM);
            nombre = archivo.FileName;
            archivo.SaveAs(path + "\\" + RM +"\\"+ nombre);
            reclamo.documento = RM;
            DBReclamos.SaveChanges();
        }
    }

    catch (Exception ex)
    {
        Response.Write(ex);
    }
%>