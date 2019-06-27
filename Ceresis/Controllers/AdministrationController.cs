using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using Ceresis.Data.Core.Model.Sorting;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core;
using Ceresis.Service.Core.Managers;
using Ceresis.Service.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ceresis.Controllers
{
    [Authorize(Roles = "admin")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AdministrationController : Controller
    {
        private readonly AdminManager aManager;

        public AdministrationController(AdminManager aManager)
        {
            this.aManager = aManager;
        }

        [HttpGet]
        [Route("worksamples", Name = "GetWorkSamples")]
        public ResponseGetAllWorkSamples GetWorkSamples([FromQuery] RequestGetWorkSamples request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetWorkSamples(request); });
        }

        [HttpDelete]
        [Route("worksamples/{id:int:required}", Name = "DeleteWorkSample")]
        public ResponseDeleteWorkSample DeleteWorkSample(int id)
        {
            return ExecuteWrapper.Execute(() => { return aManager.DeleteWorkSample(id); });
        }


        [HttpPost]
        [Route("worksamples/new", Name = "AddNewWorksample")]
        public ResponseAddNewWorksample AddNewWorksample([FromBody] RequestAddNewWorksample request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.AddWorksample(request); });
        }

        [HttpGet]
        [Route("windows", Name = "GetWindowPlastics")]
        public ResponseGetWindowPlastics GetWindowPlastics([FromQuery] RequestGetWindowPlastics request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetWindowPlastics(request); });
        }

        [HttpDelete]
        [Route("windows/{id:int:required}", Name = "DeleteWindow")]
        public ResponseDeleteWindow DeleteWindow(int id)
        {
            return ExecuteWrapper.Execute(() => { return aManager.DeleteWindow(id); });
        }

        [HttpPost]
        [Route("windows/new", Name = "AddNewWindow")]
        public ResponseAddWindow AddNewWindow([FromBody] RequestAddWindow request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.AddWindow(request); });
        }

        [HttpPost]
        [Route("windows/update/{id:int:required}", Name = "UpdateWindow")]
        public ResponseUpdateWindow UpdateWindow(int id, [FromBody] RequestUpdateWindow request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.UpdateWindow(id, request); });
        }


        [HttpGet]
        [Route("splithouse", Name = "GetSplitHouses")]
        public ResponseGetSplitHouseCatalog GetSplitHouses([FromQuery] RequestGetSplitHouseCatalog request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetSplitHouses(request); });
        }

        [HttpDelete]
        [Route("splithouse/{id:int:required}", Name = "DeleteSplitHouse")]
        public ResponseDeleteSplitHouse DeleteSplitHouse(int id)
        {
            return ExecuteWrapper.Execute(() => { return aManager.DeleteSplitHouse(id); });
        }

        [HttpPost]
        [Route("splithouse/new", Name = "AddSplitHouse")]
        public ResponseAddSplitHouse AddSplitHouse([FromBody] RequestAddSplitHouse request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.AddSplitHouse(request); });
        }

        [HttpPost]
        [Route("splithouse/update/{id:int:required}", Name = "UpdateSplitHouse")]
        public ResponseUpdateSplitHouse UpdateSplitHouse(int id, [FromBody] RequestUpdateSplitHouse request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.UpdateSplitHouse(id, request); });
        }

        [HttpGet]
        [Route("workprice", Name = "GetWorkPrice")]
        public ResponseGetWorkpriceCatalog GetWorkPrice([FromQuery] RequestGetWorkprice request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetWorkprices(request); });
        }

        [HttpDelete]
        [Route("workprice/{id:int:required}", Name = "DeleteWorkprice")]
        public ResponseDeleteWorkprice DeleteWorkprice(int id)
        {
            return ExecuteWrapper.Execute(() => { return aManager.DeleteWorkprice(id); });
        }

        [HttpPost]
        [Route("workprice/new", Name = "AddWorkprice")]
        public ResponseAddWorkprice AddWorkprice([FromBody] RequestAddWorkprice request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.AddWorkprice(request); });
        }

        [HttpPost]
        [Route("workprice/update/{id:int:required}", Name = "UpdateWorkprice")]
        public ResponseUpdateWorkprice UpdateWorkprice(int id, [FromBody] RequestUpdateWorkprice request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.UpdateWorkprice(id, request); });
        }

        [HttpGet]
        [Route("logos", Name = "GetLogos")]
        public ResponseGetLogos GetLogos([FromQuery] RequestGetLogos request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.GetLogos(request); });
        }

        [HttpDelete]
        [Route("logos/{id:int:required}", Name = "DeleteLogo")]
        public ResponseDeleteLogo DeleteLogo(int id)
        {
            return ExecuteWrapper.Execute(() => { return aManager.DeleteLogo(id); });
        }


        [HttpPost]
        [Route("logos/new", Name = "AddLogo")]
        public ResponseAddLogo AddLogo([FromBody] RequestAddLogo request)
        {
            return ExecuteWrapper.Execute(() => { return aManager.AddLogo(request); });
        }
    }
}