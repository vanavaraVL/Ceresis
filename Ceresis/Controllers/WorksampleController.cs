using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core;
using Ceresis.Service.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ceresis.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WorksampleController : Controller
    {
        private readonly AdminManager aManager;

        public WorksampleController(AdminManager aManager)
        {
            this.aManager = aManager;
        }

        [HttpGet]
        [Route("", Name = "GetWorkAllWorkSamples")]
        public ResponseGetAllWorkSamples GetWorkSamples()
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetWorkSamples(); });
        }
    }
}