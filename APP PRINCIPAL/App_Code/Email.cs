using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    public bool enviarcorreo(string from, string password, string to, string mensaje, string asunto)
    {
        try
        {
            m.To.Clear();
            m.From = new MailAddress(from);
            m.To.Add(new MailAddress(to));
            m.Body = mensaje;
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
            Console.WriteLine( "Bitaocora de error" + ex);
            throw ex;
        }

    }

    public bool enviarcorreo2(string from, string password, string to, string mensaje, string asunto, string copia)
    {

        try
        {
            m.To.Clear();
            m.From = new MailAddress(from);
            m.To.Add(new MailAddress(to));
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