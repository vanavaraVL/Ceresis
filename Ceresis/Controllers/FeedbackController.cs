using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ceresis.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FeedbackController : Controller
    {
        private readonly EmailServices emailService;

        public FeedbackController(EmailServices emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        [Route("send", Name = "Send")]
        public ResponseFeedback SendQuestion([FromBody] RequestFeedback request)
        {
            emailService.SendFeedBack(request.Phone, request.Email, request.Name, request.Message);

            return new ResponseFeedback();
        }
    }
}