using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace Services.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DocManagementController : ApiController
    {
        [HttpGet]
        [Route("api/DocManagementKPI/getDocManagementRFIs")]
        public HttpResponseMessage getDocManagementRFIs(long projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.DocManagementKPI.getDocManagementRFIs(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }
    }
}
