using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Services
{
    public class EmailServices
    {
        private readonly SmtpClient mailClient;
        private readonly LoggerManager logger;

        public EmailServices(LoggerManager logger)
        {
            this.logger = logger;

            mailClient = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["SMTPHost"],
                Port = Convert.ToInt16(ConfigurationManager.AppSettings["SMTPPort"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["NoReplayMail"], ConfigurationManager.AppSettings["NoReplayPassword"]),
                Timeout = 10000,
            };
        }

        private void SendFeedBack(string contacts, string message)
        {
            var messageForm = GetFeedbackMessage();
            var path = HostingEnvironment.MapPath(@"~/bin/References/images/logo.png") ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"References\images\logo.png");

            try
            {
                MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["NoReplayMail"], accountEmail);
                mm.IsBodyHtml = true;
                mm.Subject = "Ошибка при осуществлении подтверждений";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, null, MediaTypeNames.Text.Html);
                htmlView.LinkedResources.Add(GetEmbeddedImage(path));

                mm.AlternateViews.Add(htmlView);

                mailClient.Send(mm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SendFeedBack));
            }
        }

        private string GetFeedbackMessage()
        {
            var htmlTemplateStream = GetResourseStream("Feedback.html");

            using (var reader = new StreamReader(htmlTemplateStream))
            {
                var html = reader.ReadToEnd();
                return html;
            }
        }

        private Stream GetResourseStream(string resName)
        {
            Assembly currAssembly = Assembly.GetExecutingAssembly();
            string path = currAssembly.GetManifestResourceNames().FirstOrDefault(f => f.EndsWith(resName, StringComparison.OrdinalIgnoreCase));
            return path == null ? null : currAssembly.GetManifestResourceStream(path);
        }
    }
}
