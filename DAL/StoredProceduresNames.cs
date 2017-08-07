using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class StoredProceduresNames
    {
        public static string Pending_WorkFlow_ByUserID = "[dbo].uspmc_Workflow_GetInboxByUser";
        public static string WorkFlow_GetAll = "[db_owner].CmnEntity_GetAll";
        public static string UserManagement_LoginUserValidation = "[dbo].UserManagement_LoginUserValidation";
        public static string rpt_Workflow_GetInboxByUser = "[dbo].uspmc_Workflow_GetInboxByUser";
        public static string GetDocumentsInDelay = "[dbo].FG_Workflow_GetDocumentsInDelay";
        public static string GetPendingDocuments = "[dbo].FG_Workflow_ActiveDocumnets";
        public static string GetWorkflowMenu = "[dbo].USPMC_Menu_Workflow_GetInboxByUser";
        public static string GetActiveWorkflowdocuments = "[dbo].FG_Workflow_ActiveDocumnets";
        //@User AS NVARCHAR(50),@RecTypeID bigint
        public static string GetWorkflowDetailByModule = "[dbo].uspmc_rpt_Workflow_Getworkflow_detail_by_module";
        //@Project  AS NVARCHAR(50) FG_Workflow_GetDocumentsInDelay
        public static string GetDelayedWorkflowdocuments = "[dbo].FG_Workflow_GetDocumentsInDelay";
        //@User bigint,@DocId bigint, @EntId bigint,@RecId bigint, @RecTypeId bigint,@ObjTypeId bigint, @ProjectId bigint,
        //@Comment nvarchar(max)
        public static string finalApproveForWorkflow = "[dbo].USPMC_FinalApproveWorkflowDocument";
        public static string GetALLUserProjects = "[dbo].GetALLUserProjects";
        public static string uspmc_rpt_GetPunchLists = "[dbo].uspmc_rpt_GetPunchLists";
        public static string GetProgramsList = "[dbo].GetProgramsList";
        public static string uspmc_portifolio_summry_dashbaord_level_two = "[dbo].uspmc_portifolio_summry_dashbaord_level_two";
        public static string uspmc_document_management_dashboard_punchlist_OVER = "[dbo].uspmc_document_management_dashboard_punchlist_OVER";
        public static string getDocManagementRFIs = "[dbo].USPMC_DocManager_RFIs";
        public static string gettestcharts = "[dbo].[uspmc_test_charts]";
        public static string getActiveDocumentsChart = "[dbo].[USPMC_APIWorkflow_ActiveDocumnets]";
        public static string getDelayedDocumentsChart = "[dbo].[USPMC_APIWorkflow_DelayedDocumnets]";
        public static string getDocManager_RFIAPI = "[dbo].[uspmc_DocManager_RFIAPI]";
        public static string getDocManager_COChart = "[dbo].[uspmc_document_management_dashboard_changeeventCharts]";
        public static string getStageGatesSnap = "[dbo].[uspmc_stageGatesSnap]";
        public static string getCostSnap = "[dbo].[uspmc_CostSnap]";
        public static string uspmc_exective_dashboard_cost = "[dbo].[uspmc_exective_dashboard_cost]";
        public static string uspmc_exective_dashboard_cost_pic = "[dbo].[uspmc_getProjectImagesById]";
        public static string getScheduleSnap = "[dbo].[uspmc_ScheduleSnap]";
        public static string Workflow_GetDocumentActionLogs = "[dbo].[Workflow_GetDocumentActionLogs]";
        public static string uspmc_Workflow_GetDocumentStepsRoles = "[dbo].[uspmc_Workflow_GetDocumentStepsRoles]";
        public static string Workflow_CalculateCurrentPendingStepId = "[dbo].[uspmc_Workflow_CalculateCurrentPendingStepId]";
        public static string uspmc_Insert_HelpDesk = "[dbo].[uspmc_Insert_HelpDesk]";

    }







}

