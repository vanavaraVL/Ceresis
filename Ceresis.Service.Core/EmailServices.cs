using Ceresis.Data.Core.Model;
using Ceresis.Service.Core.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace Ceresis.Service.Core
{
    public class EmailServices
    {
        private readonly SmtpClient mailClient;
        private readonly LoggerManager logger;
        private IPathProvider pathProvider;

        private readonly string serviceMail;

        public EmailServices(LoggerManager logger, IPathProvider pathProvider, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.pathProvider = pathProvider;

            mailClient = new SmtpClient
            {
                Host = settings.Value.SMTPHost,
                Port = settings.Value.SMTPPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(settings.Value.NoReplayMail, settings.Value.NoReplayPassword),
                Timeout = 10000,
            };

            serviceMail = settings.Value.NoReplayMail;
        }

        public void SendFeedBack(string contacts, string email, string customer, string message)
        {
            var messageForm = GetFeedbackMessage(contacts, email, customer, message);
            var path = pathProvider.MapPathContent(Path.Combine("images", "logoPath.png"));

            try
            {
                MailMessage mm = new MailMessage(serviceMail, serviceMail);
                mm.IsBodyHtml = true;
                mm.Subject = "Поступил новый запрос";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageForm, null, MediaTypeNames.Text.Html);
                htmlView.LinkedResources.Add(GetEmbeddedImage(path, "logoPath", MediaTypeNames.Image.Jpeg));

                mm.AlternateViews.Add(htmlView);

                mailClient.Send(mm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SendFeedBack));
            }
        }

        public void SendOrderToCustomer(Cart cart, string email, string phone, string name, string description)
        {
            var messageForm = GetOrderMessage(cart, email, phone, name, description);

            var path_logo = pathProvider.MapPath(Path.Combine("images", "logoPath.png"));
            var path_cartItem = pathProvider.MapPath(Path.Combine("images", "cartItemPath.jpg"));

            try
            {
                MailMessage mm = new MailMessage(serviceMail, email);
                mm.IsBodyHtml = true;
                mm.Subject = "Заказ на сайте Кит-Сервис";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageForm, null, MediaTypeNames.Text.Html);
                htmlView.LinkedResources.Add(GetEmbeddedImage(path_logo, "logoPath", MediaTypeNames.Image.Jpeg));
                htmlView.LinkedResources.Add(GetEmbeddedImage(path_cartItem, "cartItemPath", MediaTypeNames.Image.Jpeg));

                mm.AlternateViews.Add(htmlView);

                mailClient.Send(mm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SendFeedBack));
            }
        }

        public void SendOrderToService(Cart cart, string email, string phone, string name, string description)
        {
            var messageForm = GetOrderServiceMessage(cart, email, phone, name, description);
            var path = pathProvider.MapPath(Path.Combine("images", "logo_2.png"));

            try
            {
                MailMessage mm = new MailMessage(serviceMail, serviceMail);
                mm.IsBodyHtml = true;
                mm.Subject = "Новый заказ на сайте Кит-Сервис";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageForm, null, MediaTypeNames.Text.Html);
                htmlView.LinkedResources.Add(GetEmbeddedImage(path, "logoPath", MediaTypeNames.Image.Jpeg));

                mm.AlternateViews.Add(htmlView);

                mailClient.Send(mm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(SendFeedBack));
            }
        }

        private string GetFeedbackMessage(string contacts, string email, string customer, string message)
        {
            var htmlTemplateStream = GetResourseStream("Feedback.html");
            var htmlHeaderStream = GetResourseStream("FeedbackHead.html");

            using (var reader = new StreamReader(htmlTemplateStream))
            {
                using (var readHead = new StreamReader(htmlHeaderStream))
                {
                    var htmlHeader = readHead.ReadToEnd();

                    var html = reader.ReadToEnd();
                    var htmlParams = string.Format(html, customer, DateTime.Now.ToString(), $"+7{contacts}", email, message);

                    return $"{htmlHeader}{htmlParams}";
                }
            }
        }

        private string GetOrderServiceMessage(Cart cart, string email, string phone, string name, string description)
        {
            var htmlTemplateStream = GetResourseStream("OrderService.html");
            var htmlHeader = GetResourseStream("OrderHeadService.html");

            using (var reader = new StreamReader(htmlTemplateStream))
            {
                using (var readerHead = new StreamReader(htmlHeader))
                {
                    var tableItems = new StringBuilder();

                    var even = @"<tr style=""border-collapse:collapse;""> " +
                                    @"<td style=""padding:5px 10px 5px 0;Margin:0;"" width=""80%"" align=""left""> <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-size:16px;font-family:'open sans', 'helvetica neue', helvetica, arial, sans-serif;line-height:24px;color:#333333;"">{0}</p> </td>" +
                                    @"<td style=""padding:5px 0;Margin:0;"" width=""20%"" align=""left""> <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-size:16px;font-family:'open sans', 'helvetica neue', helvetica, arial, sans-serif;line-height:24px;color:#333333;"">₽ {1}</p> </td>" +
                                @"</tr>";


                    var data = cart.Items.ToList();
                    for (var i = 0; i < data.Count; i++)
                    {
                        var totalItem = (data[i].Price ?? 0) * (data[i].Count ?? 1);

                        tableItems.AppendLine(string.Format(even, $"{data[i].Name} ({data[i].Description})x{data[i].Count ?? 1}", totalItem > 0 ? string.Format("{0:0.00}", totalItem) : "(дог)"));
                    }

                    var total = "";
                    var totalCost = data.Sum(d => (d.Price ?? 0) * (d.Count ?? 1));

                    if (totalCost == 0)
                        total = "(дог)";
                    else
                    {
                        total = string.Format("{0:0.00}", totalCost) + (data.Any(d => d.Price == null) ? " (дог)" : "");
                    }

                    var html = reader.ReadToEnd();
                    var htmlHead = readerHead.ReadToEnd();

                    var htmlParams = string.Format(html, name, DateTime.Now.ToString(), $"+7{phone}", email, description, tableItems.ToString(), total);

                    return $"{htmlHead}{htmlParams}";
                }
            }
        }

        private string GetOrderMessage(Cart cart, string email, string phone, string name, string description)
        {
            var htmlTemplateStream = GetResourseStream("Order.html");
            var htmlHeader = GetResourseStream("OrderHead.html");

            using (var reader = new StreamReader(htmlTemplateStream))
            {
                using (var readerHead = new StreamReader(htmlHeader))
                {
                    var tableItems = new StringBuilder();

                    var even = @"<tr style=""border-collapse:collapse;"">" +
                                        @"<td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px;"">" +
                                            @"<table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                @"<tr style=""border-collapse:collapse;"">" +
                                                    @"<td width=""560"" valign=""top"" align=""center"" style=""padding:0;Margin:0;"">" +
                                                        @"<table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                            @"<tr style=""border-collapse:collapse;"">" +
                                                                @"<td align=""center"" style=""padding:0;Margin:0;padding-bottom:10px;"">" +
                                                                    @"<table width=""100%"" height=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                                        @"<tr style=""border-collapse:collapse;"">" +
                                                                            @"<td style=""padding:0;Margin:0px;border-bottom:1px solid #EFEFEF;background:rgba(0, 0, 0, 0) none repeat scroll 0% 0%;height:1px;width:100%;margin:0px;""></td>" +
                                                                        @"</tr>" +
                                                                    "</table>" +
                                                                "</td>" +
                                                            "</tr>" +
                                                        "</table>" +
                                                    "</td>" +
                                                "</tr>" +
                                            "</table>" +
                                        "</td>" +
                                    "</tr>" +
                                    @"<tr style=""border-collapse:collapse;"">" +
                                        @"<td align=""left"" style=""Margin:0;padding-top:5px;padding-bottom:10px;padding-left:20px;padding-right:20px;"">" +
                                            @"<!--[if mso]><table width=""560"" cellpadding=""0"" cellspacing=""0""><tr><td width=""178"" valign=""top""><![endif]-->" +
                                            @"<table class=""es-left"" cellspacing=""0"" cellpadding=""0"" align=""left"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left;"">" +
                                                @"<tr style=""border-collapse:collapse;"">" +
                                                    @"<td class=""es-m-p0r es-m-p20b"" width=""178"" valign=""top"" align=""center"" style=""padding:0;Margin:0;"">" +
                                                        @"<table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                            @"<tr style=""border-collapse:collapse;"">" +
                                                                @"<td align=""center"" style=""padding:0;Margin:0;""> <img src=""cid:cartItemPath"" alt=""{0}"" class=""adapt-img"" title=""{0}"" width=""95"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic;""></td>" +
                                                            @"</tr>" +
                                                        @"</table>" +
                                                    @"</td>" +
                                                @"</tr>" +
                                            @"</table>" +
                                            @"<!--[if mso]></td><td width=""20""></td><td width=""362"" valign=""top""><![endif]-->" +
                                            @"<table cellspacing=""0"" cellpadding=""0"" align=""right"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                @"<tr style=""border-collapse:collapse;"">" +
                                                    @"<td width=""362"" align=""left"" style=""padding:0;Margin:0;"">" +
                                                        @"<table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;"">" +
                                                            @"<tr style=""border-collapse:collapse;"">" +
                                                                @"<td align=""left"" style=""padding:0;Margin:0;"">" +
                                                                    @"<p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-size:14px;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;""><br></p>" +
                                                                    @"<table style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;"" class=""cke_show_border"" cellspacing=""1"" cellpadding=""1"" border=""0"">" +
                                                                        @"<tr style=""border-collapse:collapse;"">" +
                                                                            @"<td style=""padding:0;Margin:0;"">{0}</br>{1}</td>" +
                                                                            @"<td style=""padding:0;Margin:0;text-align:center;"" width=""60"">{2}</td>" +
                                                                            @"<td style=""padding:0;Margin:0;text-align:center;"" width=""100"">₽ {3}</td>" +
                                                                        @"</tr>" +
                                                                    @"</table> <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-size:14px;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#333333;""><br></p> " +
                                                                @"</td> " +
                                                            @"</tr> " +
                                                        @"</table> " +
                                                    @"</td> " +
                                                @"</tr> " +
                                            @"</table>" +
                                            @"<!--[if mso]></td></tr></table><![endif]--> " +
                                        @"</td> " +
                                    @"</tr>";

                    var data = cart.Items.ToList();
                    for (var i = 0; i < data.Count; i++)
                    {
                        tableItems.AppendLine(string.Format(even, data[i].Name, data[i].Description, data[i].Count, data[i].Price.HasValue ? string.Format("{0:0.00}", data[i].Price.Value) : "(дог)"));
                    }

                    var total = "";
                    var totalCost = data.Sum(d => (d.Price ?? 0) * (d.Count ?? 1));

                    if (totalCost == 0)
                        total = "(дог)";
                    else
                    {
                        total = string.Format("{0:0.00}", totalCost) + (data.Any(d => d.Price == null) ? " (дог)" : "");
                    }

                    var html = reader.ReadToEnd();
                    var htmlHead = readerHead.ReadToEnd();

                    var htmlParams = string.Format(html, name, DateTime.Now.ToString(), $"+7{phone}", email, total, description, tableItems.ToString(), data.Count, total, total);

                    return $"{htmlHead}{htmlParams}";
                }
            }
        }

        private LinkedResource GetEmbeddedImage(string filePath, string contentId, string contentType)
        {
            LinkedResource inline = new LinkedResource(filePath);
            inline.ContentId = contentId;
            inline.ContentType = new ContentType(contentType);

            return inline;
        }

        private Stream GetResourseStream(string resName)
        {
            Assembly currAssembly = Assembly.GetExecutingAssembly();
            string path = currAssembly.GetManifestResourceNames().FirstOrDefault(f => f.EndsWith(resName, StringComparison.OrdinalIgnoreCase));
            return path == null ? null : currAssembly.GetManifestResourceStream(path);
        }
    }
}
