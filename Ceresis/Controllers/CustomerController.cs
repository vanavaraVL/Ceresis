using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core;
using Ceresis.Service.Core.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ceresis.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CustomerController : Controller
    {
        private readonly EmailServices emailService;
        private readonly AccountManager accountManager;

        public CustomerController(AccountManager accountManager, EmailServices emailService)
        {
            this.accountManager = accountManager;
            this.emailService = emailService;
        }


        [HttpPost]
        [Route("login", Name = "Login")]
        public async Task<ResponseLogin> Login([FromBody] RequestLogin request)
        {
            return await accountManager.CreateToken(request);
        }

        [HttpPost]
        [Route("create", Name = "CreateOrder")]
        public ResponseCreateCart Create([FromBody] RequestCreateCart request)
        {
            var response = new ResponseCreateCart();

            emailService.SendOrderToCustomer(request.Data, request.Email, request.Phone, request.Name, request.Description);
            emailService.SendOrderToService(request.Data, request.Email, request.Phone, request.Name, request.Description);

            return response;
        }
    }
}