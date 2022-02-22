using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void enviarContatoPorEmail(Contato contato)
        {
            // Smtp-> Servidor q vai enviar a mensagem
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("viits012@gmail.com", "");
            smtp.EnableSsl = true;


            string bodyAux = string.Format("Contato - Bercinho de ouro");

            // MailMessage -> Construir a mensagem
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("artonifilipe.01@gmail.com");
            mensagem.To.Add("viits012@gmail.com");
            mensagem.Subject = "Contato - Bercinho de Ouro- E-mail: " + contato.Email;
            mensagem.Body = bodyAux;
            mensagem.IsBodyHtml = true;
            // Enviar o email
            smtp.Send(mensagem);



        }
    }
}