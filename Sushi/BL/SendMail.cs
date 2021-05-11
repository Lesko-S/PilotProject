using Sushi.BL.Logger;
using Sushi.BL.Sushi;
using System;
using System.Net;
using System.Net.Mail;

namespace Sushi.BL
{
    class SendMail
    {
        public async void SendEmailDefault(string messege)
        {
            try
            {
                Byer_sRights byer_S = new Byer_sRights();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("SushiBot", "Рассылка");
                mailMessage.To.Add(byer_S.EMail);
                mailMessage.Subject = "Сообщение от суши бота";
                //mailMessage.Attachments.Add(new Attachment(@"D:\C#\Project\Sushi\BL\Sushi\Repository\Order.txt"));
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("zaglyshka@gmail.com", "pass");
                    client.Port = 587;
                    client.EnableSsl = true;
                    await client.SendMailAsync(mailMessage);
                    Console.WriteLine(@$"на ваш email {byer_S.EMail} выслано письмо с вашим заказом");

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
