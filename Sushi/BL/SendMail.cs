using Sushi.BL.Logger;
using System;
using System.Net;
using System.Net.Mail;

namespace Sushi.BL
{
    class SendMail
    {
        public void SendEmailDefault(string email)
        {
            try
            {
                Program program = new Program();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("SushiBot", "Cуши бот");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Сообщение от суши бота";
                mailMessage.Attachments.Add(new Attachment(@"Sushi\BL\Sushi\Repository\Order.txt"));
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("zaglyshka@gmail.com", "pass");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Send(mailMessage);
                    Console.WriteLine(@$"на ваш email {email} выслано письмо с вашим заказом");

                }
            }
            catch (Exception ex)
            {
                MyLogger log = new MyLogger();
                SendMail sM = new SendMail();
                Console.WriteLine($"Возникла небольшая ошибка: {ex.Message}");
                log.Error("User choise more quantity sushi", sM.GetType().ToString());
            }
            
        }
    }
}
