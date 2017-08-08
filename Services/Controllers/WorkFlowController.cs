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
        [Route("api/WorkFlow/ScheduleSnap")]
        public HttpResponseMessage ScheduleSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getScheduleSnap(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }



        [HttpGet]
        [Route("api/WorkFlow/GetExeDashBoardPic")]
        public HttpResponseMessage GetExeDashBoardPic(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetExeDashBoardPic(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


        [HttpGet]
        [Route("api/WorkFlow/GetExeDashBoard")]
        public HttpResponseMessage GetExeDashBoard(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetExeDashBoard(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


        [HttpGet]
        [Route("api/WorkFlow/getStageGatesSnap")]
        public HttpResponseMessage getStageGatesSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getStageGatesSnap(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/getCostSnap")]
        public HttpResponseMessage getCostSnap(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getCostSnap(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


        [HttpGet]
        [Route("api/WorkFlow/getDocManagerCOs")]
        public HttpResponseMessage getDocManagerCOs(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getDocManagerCOs(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


        [HttpGet]
        [Route("api/WorkFlow/getDocManagerRFI")]
        public HttpResponseMessage getDocManagerRFI(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getDocManagerRFI(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }



        [HttpGet]
        [Route("api/WorkFlow/getdelayeddocumentsperproject")]
        public HttpResponseMessage getdelayeddocumentsperproject(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getDelayedDocumentsChart(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/getactiveworkflowdocuments")]
        public HttpResponseMessage getactiveworkflowdocuments(string projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkflowKPI.getActiveWorkflowDocuments(projectid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/getactivedocumentsperproject")]
        public HttpResponseMessage getactivedocumentsperproject(string projectId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getActiveDocumentsChart(projectId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }



        [HttpGet]
        [Route("api/WorkFlow/GetPunchListChart")]
        public HttpResponseMessage GetPunchListChart(long projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetPunchListChart(projectid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }



        [HttpGet]
        [Route("api/WorkFlow/GetPortifolioSummryDashbaord")]
        public HttpResponseMessage GetPortifolioSummryDashbaord(int programid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetPortifolioSummryDashbaord(programid);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetProgramsList")]
        public HttpResponseMessage GetProgramsList(int UserId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetProgramsList(UserId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

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
        [Route("api/WorkFlow/GetDocumentPunchList")]
        public HttpResponseMessage GetDocumentPunchList(int projectid)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetDocumentPunchList(projectid);
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
        [Route("api/WorkFlow/getWorkflowmenu")]
        public HttpResponseMessage getWorkflowMenu(string userId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetWorkflowMenu(userId);
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
        public class obj
        {
            public Int64 User {get ; set ;}
            public Int64 DocId { get; set; }
            public Int64 EntId { get; set; }
            public Int64 RecId { get; set; }
            public Int64 RecTypeId { get; set; }
            public Int64 ObjTypeId { get; set; }
            public Int64 ProjectId { get; set; }
            public string Comment { get; set; }

        }
        


        [HttpPost]
        [Route("api/WorkFlow/finalapproveforworkflow")]
        public HttpResponseMessage finalapproveforworkflow(obj obj)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.finalApproveForWorkflow(obj.User,obj.DocId,obj.EntId,
                obj.RecId, obj.RecTypeId, obj.ObjTypeId, obj.ProjectId, obj.Comment);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }
        [HttpGet]
        [Route("api/WorkFlow/getworkflowdetailsbymodule")]
        public HttpResponseMessage GetWorkflowDetailByModuleAndUser(string username, int moduleId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.getWorkflowDetailByModule(username, moduleId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetALLUserProjects")]
        public HttpResponseMessage GetALLUserProjects(long UserId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetALLUserProjects(UserId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetDocumentActionLogs")]
        public HttpResponseMessage GetDocumentActionLogs(string DocumentId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetDocumentActionLogs(DocumentId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetDocumentStepsRoles")]
        public HttpResponseMessage GetDocumentStepsRoles(string DocumentId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetDocumentStepsRoles(DocumentId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpGet]
        [Route("api/WorkFlow/GetCurrentStep")]
        public HttpResponseMessage GetCurrentStep(string DocumentId)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.GetCurrentStep(DocumentId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }

        [HttpPost]
        [Route("api/WorkFlow/InsertHelpDesk")]
        public HttpResponseMessage InsertHelpDesk(HelpDTO HelpDTO)
        {
            DataTransferModel returnValue = new DataTransferModel();
            returnValue = DAL.WorkFlow.InsertHelpDesk(HelpDTO);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, returnValue);
            return response;
        }


    }
}
