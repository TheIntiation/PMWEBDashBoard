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
        //@User  AS NVARCHAR(50) USPMC_Menu_Workflow_GetInboxByUser
        public static string GetWorkflowMenu = "[dbo].USPMC_Menu_Workflow_GetInboxByUser";
        //@Project  AS NVARCHAR(50) FG_Workflow_ActiveDocumnets
        public static string GetActiveWorkflowdocuments = "[dbo].FG_Workflow_ActiveDocumnets";

    }







}

