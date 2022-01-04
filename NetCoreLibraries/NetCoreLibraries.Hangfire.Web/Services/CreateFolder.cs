using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Hangfire.Web.Services
{
    public class CreateFolder : ICreateFolder
    {
        private readonly IConfiguration _configuration;
        public CreateFolder(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void CreateFile(string message) // Job içerisinde çalışacak metod public olmalıdır
        {
            // bu userId ye sahip kullanıcıyı bul ve email 

            //var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("emreakturk25@gmail.com", "Example User");
            //var subject = "Bilgilendirme";
            //var to = new EmailAddress("akturk_emre@hotmail.com", "Example User"); 
            //var htmlContent = $"<strong>{message}</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            // await client.SendEmailAsync(msg);

            // Mail atıldıktan sonra klasör oluştur
              
            File.WriteAllText(Path.Combine(@"C:\Users\emre.akturk\Desktop\Deneme_Hangfire", $"log_{Guid.NewGuid().ToString().Substring(0,10)}.txt"), message + Guid.NewGuid());


        }

      

    }
}
