using System;
using System.Net;
using System.Net.Mail;


public class Email
{
    //variables utilizadas para el manejo del envio de correo electronico
    MailMessage m = new MailMessage();
    SmtpClient smtp = new SmtpClient();

    public Email()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public bool CorreoReclamos( string para, string cuerpo, string asunto)
    {
        try
        {
            string from = "reclamosgt@unitypromotores.com";
            string password = "123$456R";
            m.To.Clear();
            m.From = new MailAddress(from);
            m.To.Add(new MailAddress(para));
            m.Body = cuerpo;
            m.Subject = asunto;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(m);

            return true;
        }

        catch (SmtpException ex)
        {
            throw ex;
        }
    }

    public static bool EnviarERROR(string asunto, string cuerpo)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            string from = "reclamosgt@unitypromotores.com";
            string password = "123$456R";
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


    public bool enviarcorreo2( string para, string mensaje, string asunto, string copia)
    {
        try
        {
            string from = "reclamosgt@unitypromotores.com";
            string password = "123$456R";
            m.To.Clear();
            m.From = new MailAddress(from);
            m.To.Add(new MailAddress(para));
            m.Bcc.Add(copia);
            m.Body = mensaje;
            m.Subject = asunto;
            m.IsBodyHtml = true;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(m);

            return true;
        }

        catch (SmtpException ex)
        {
            Console.WriteLine("Bitaocora de error" + ex);
            throw ex;
        }
    }
}