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
    public class WorkflowKPIController : ApiController
    {
        [HttpGet]
        [Route("api/WorkFlowKPI/getactiveworkflowdocuments")]
        public HttpResponseMessage getactiveworkflowdocuments(string projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getActiveWorkflowDocuments(projectid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlowKPI/getdelayedworkflowdocuments")]
        public HttpResponseMessage getdelayedworkflowdocuments(string projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getDelayedWorkflowDocuments(projectid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


    }
}
