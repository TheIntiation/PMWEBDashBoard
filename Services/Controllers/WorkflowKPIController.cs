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

        [HttpGet]
        [Route("api/WorkFlowKPI/gettestchart")]
        public HttpResponseMessage gettestchart()
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.gettestcharts();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlowKPI/getactivedocumentsperproject")]
        public HttpResponseMessage getactivedocumentsperproject(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getActiveDocumentsChart(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlowKPI/getdelayeddocumentsperproject")]
        public HttpResponseMessage getdelayeddocumentsperproject(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getDelayedDocumentsChart(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


        [HttpGet]
        [Route("api/WorkFlowKPI/getDocManagerRFI")]
        public HttpResponseMessage getDocManagerRFI(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getDocManagerRFI(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlowKPI/getDocManagerCOs")]
        public HttpResponseMessage getDocManagerCOs(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getDocManagerCOs(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }
    }
}

