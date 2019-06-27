using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CatalogController : Controller
    {
        private readonly CatalogManager catalogManager;

        public CatalogController(CatalogManager catalogManager)
        {
            this.catalogManager = catalogManager;
        }

        [HttpGet]
        [Route("windows/all", Name = "GetAllWindowCatalog")]
        public ResponseGetWindowPlastics GetWindowsCatalog()
        {
            return ExecuteWrapper.Execute(() => { return catalogManager.GetWindows(); });
        }

        [HttpGet]
        [Route("splithouse/all", Name = "GetSplitHouseCatalog")]
        public ResponseGetSplitHouseCatalog GetSplitHouseCatalog()
        {
            return ExecuteWrapper.Execute(() => { return catalogManager.GetSplitHouse(); });
        }

        [HttpGet]
        [Route("workprice/all", Name = "GetWorkpriceCatalog")]
        public ResponseGetWorkpriceCatalog GetWorkpriceCatalog()
        {
            return ExecuteWrapper.Execute(() => { return catalogManager.GetWorkpriceCatalog(); });
        }


        [HttpGet]
        [Route("logos/all", Name = "GetLogosCatalog")]
        public ResponseGetLogos GetLogos()
        {
            return ExecuteWrapper.Execute(() => { return catalogManager.GetLogos(); });
        }
    }
}