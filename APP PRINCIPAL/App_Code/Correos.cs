using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EASendMail;

/// <summary>
/// Descripción breve de Correos
/// </summary>
public class Correos
{
    public Correos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public static void Notificacion(String para, String asunto, String cuerpo)
    {
        try
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();
            oMail.From = new MailAddress("reclamosgt@unitypromotores.com");
            oMail.To = new AddressCollection(para);
            oMail.Subject = asunto;
            oMail.HtmlBody = cuerpo;

            SmtpServer oServer = new SmtpServer("smtp.office365.com");
            oServer.User = "reclamosgt@unitypromotores.com";
            oServer.Password = "123$456R";
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            oSmtp.SendMailToQueue(oServer, oMail);
        }
        catch (Exception)
        {

        }
    }
}