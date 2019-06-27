using Ceresis.Service.Core;
using Ceresis.Service.Core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Ceresis.Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void SendFeedback()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();

            mockEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            mockEnvironment.Setup(m => m.ContentRootPath).Returns(AppDomain.CurrentDomain.BaseDirectory);
            mockEnvironment.Setup(m => m.WebRootPath).Returns(AppDomain.CurrentDomain.BaseDirectory);

            var pathProvider = new PathProvider(mockEnvironment.Object);

            var emailService = new EmailServices(
                new LoggerManager(mockEnvironment.Object),
                new PathProvider(mockEnvironment.Object),
                Options.Create(new AppSettings()
                {
                    NoReplayMail = "kit-service-mail@yandex.ru",
                    NoReplayPassword = "Qwerty103!",
                    SMTPHost = "smtp.yandex.ru",
                    SMTPPort = 25
                }));

            emailService.SendFeedBack("9061010909", "test@mail.ru", "Mr. Anderson", "Test message");

            Assert.IsTrue(true);
        }
    }
}
