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
    public class WorkFlowController : ApiController
    {
        
        [HttpGet]
        [Route("api/WorkFlow/GetAll")]
        public HttpResponseMessage GetAll()
        {
            DataTransferModel returnValue = new DataTransferModel();
            //returnValue = DAL.WorkFlow.GetAll();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetPendingWorkFlowByUserID")]
        public HttpResponseMessage GetPendingWorkFlowByUserID(string UserID)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetPendingWorkFlowByUserID(UserID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetDocumentsInDelay")]
        public HttpResponseMessage GetDocumentsInDelay(string Project)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetDocumentsInDelay(Project);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetPendingDocuments")]
        public HttpResponseMessage GetPendingDocuments(string Project)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetPendingDocuments(Project);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


    }
}
