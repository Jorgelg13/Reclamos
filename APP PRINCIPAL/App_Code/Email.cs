using System;
using System.Net;
using System.Net.Mail;


public class Email
{
    //variables utilizadas para el manejo del envio de correo electronico
    MailMessage mail = new MailMessage();
    SmtpClient smtp = new SmtpClient();
    string from = "reclamosgt@unitypromotores.com";
    string password = "ymqrmndyzqbrwshw";

    public Email()
    {

    }

    public bool NOTIFICACION( string para, string cuerpo, string asunto)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            string from = "reclamosgt@unitypromotores.com";
            string password = "ymqrmndyzqbrwshw";
            //string para = "jorge.laj@unitypromotores.com";
            mail.To.Clear();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(para));
            mail.Body = cuerpo;
            mail.Subject = asunto;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);


            //mail.To.Clear();
            //mail.From = new MailAddress(from);
            //mail.To.Add(new MailAddress(para));
            //mail.Body = cuerpo;
            //mail.Subject = asunto;
            //smtp.Host = "smtp.office365.com";
            //smtp.Port = 587;
            //smtp.Credentials = new NetworkCredential(from, password);
            //smtp.EnableSsl = true;
            //smtp.Send(mail);

            return true;
        }

        catch (SmtpException ex)
        {
            throw ex;
        }
    }

    public static bool ENVIAR_ERROR(string asunto, string cuerpo)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            string from = "reclamosgt@unitypromotores.com";
            string password = "ymqrmndyzqbrwshw";
            string para = "jorge.laj@unitypromotores.com";
            mail.To.Clear();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(para));
            mail.Body = cuerpo;
            mail.Subject = asunto;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true;
        }

        catch (SmtpException ex)
        {
            throw ex;
        }
    }


    public bool NOTIFICACION_EJECUTIVO( string para, string mensaje, string asunto, string copia)
    {
        try
        {
            mail.To.Clear();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(para));
            mail.Bcc.Add(copia);
            mail.Body = mensaje;
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true;
        }

        catch (SmtpException ex)
        {
            Console.WriteLine("Bitaocora de error" + ex);
            throw ex;
        }
    }
}