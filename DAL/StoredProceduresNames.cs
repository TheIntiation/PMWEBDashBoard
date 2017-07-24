﻿using System;
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


    }







}

