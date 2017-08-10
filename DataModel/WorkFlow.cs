using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CostSnap
    {
        // id	ProjectName	ProjectNumber	CommitmentCode	Description	CurrencyId	CurrencyCode	OriginalCommitment	
        //Invoiced	ApprovedChanges	RevisedContrcatSum	InvoicedPercentage	CommitmentType


        public long id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string CommitmentCode { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public float OriginalCommitment { get; set; }
        public float Invoiced { get; set; }

        public float ApprovedChanges { get; set; }
        public float RevisedContrcatSum { get; set; }

        public float InvoicedPercentage { get; set; }
        public string CommitmentType { get; set; }
    }
    public class exective_dashboard_cost_pic
    {
        public byte[] FileContent { get; set; }
        public string FileContentBase64 { get; set; }
   
    }
    public class ScheduleSnap
    {
        //Start Finish  BFinish Bstart  Cost ActualCost  
        //    StatusDate DurationPast    PastPercentage DurationRemaining   RemainingPercentage
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public DateTime StatusDate { get; set; }
        public long DurationPast { get; set; }
        public float PastPercentage { get; set; }
        public long DurationRemaining { get; set; }
        public float RemainingPercentage { get; set; }

    }
    public class exective_dashboard_cost
    {
        public double ActualCost { get; set; }
        public double AnticipatedBudget { get; set; }
        public double AnticipatedCost { get; set; }
        public double Forecast { get; set; }
        public double Variance { get; set; }
        public double ForeCastVariance { get; set; }
    }


    public class StageGatesSnap
    {
        // GateId GateDescrption  CountActivitiesDone TotalActivities Percentage

        public long GateId { get; set; }
        public string GateDescrption { get; set; }
        public long CountActivitiesDone { get; set; }
        public long TotalActivities { get; set; }
        public float Percentage { get; set; }
    }

    public class DocManagerRFIs
    {
        public string StatusName { get; set; }
        public long CountVal { get; set; }
    }
    public class DocManagerCOs
    {
        public string StatusName { get; set; }
        public long CountVal { get; set; }
    }
    public class ActiveDocumentPerProjectChart
    {
        public string RecordName { get; set; }
        public long CountVal { get; set; }
    }
    public class DelayedDocumentPerProjectChart
    {
        public string RecordName { get; set; }
        public long CountVal { get; set; }
    }
    public class PunchListChart
    {
        public string ToCoName { get; set; }
        public long? Draft { get; set; }
        public long? Submitted { get; set; }
        public long? Returned { get; set; }
        public long? Resubmitted { get; set; }
        public long? Approved { get; set; }
        public long? Rejected { get; set; }
        public long? Withdrawn { get; set; }
        public long? TotalOutStanding { get; set; }
        public long? TotalOverDue { get; set; }
    }


    public class GoogleMapAddress
    {
        public long projectid { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string GoogleAddress { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public long? OUTSTANDING_DOCUMENT { get; set; }
        public long? OVERDUE_DOCUMENT { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? BaselineFinishDate { get; set; }
        public decimal ForecastsVariance { get; set; }
    }
    public class PortifolioSummryOne
    {
        public long ProjectId { get; set; }
        public long ProjCurrency { get; set; }
        public string GoogleAddress { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectExecutive { get; set; }
        public string Superintendent { get; set; }
        public string ProjectType { get; set; }
        public string Program { get; set; }
        public string ProgramName { get; set; }
        public string Property { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StateKey { get; set; }
        public string StatusKey { get; set; }
        public string Status { get; set; }
        public decimal OriginalBudget { get; set; }
        public decimal BudgetChanges { get; set; }
        public decimal AnticipatedBudget { get; set; }
        public decimal OriginalCommitments { get; set; }
        public decimal CommitmentsRevisions { get; set; }
        public decimal AnticipatedCost { get; set; }
        public decimal Forecasts { get; set; }
        public decimal ForecastsVariance { get; set; }
        public decimal ActualCosts { get; set; }
        public decimal CostPctComplete { get; set; }
        public decimal PhysicalPctComplete { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public long? Duration { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineFinishDate { get; set; }
        public long? Days { get; set; }
        public long? OUTSTANDING_DOCUMENT { get; set; }
        public long? OVERDUE_DOCUMENT { get; set; }


    }

    public class PortifolioSummryTwo
    {
        public decimal WorkUnderContract { get; set; }
        public decimal WorkinProgress { get; set; }
        public decimal UnstartedContracts { get; set; }
        public decimal ContractChanges { get; set; }
        public decimal ProjectedCost { get; set; }

    }
        public class ProgramsList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<PortifolioSummryOne> ProjectList { get; set; }
    }


    public class GetDocumentsInDelay
    {
        public int totaldelay { get; set; }
        public string Entity { get; set; }
        public string RecordType { get; set; }
    }
    public class ProjectList
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
    }
    public class Workflow_GetInboxByUser
    {
        public long DocumentId { get; set; }
        public long ObjectTypeId { get; set; }
        public long RecordId { get; set; }
        public long RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public long EntityId { get; set; }
        public string Project { get; set; }
        public string PropertyName { get; set; }
        public string Entity { get; set; }
        public string Description { get; set; }
        public long StatusId { get; set; }
        public long StepNumber { get; set; }
        public long NumberOfSteps { get; set; }
        public string MainPage { get; set; }
        public long ModuleId { get; set; }
        public long PageId { get; set; }
        public long CurrentStepNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public string correspondencedetails { get; set; }
        public string ProjectNumber { get; set; }
        public string RecordNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string FromContact { get; set; }
        public string ToContact { get; set; }
        public string FromCompany { get; set; }
        public string ToCompany { get; set; }
        public long TotalPendingWorkFlow { get; set; }
       
    }

    public class WorkflowMenu
    {
        //RecordTypeId	RecordType	TotalPendingItems

        public Int64 RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public int TotalPendingItems { get; set; }
    }
    public class WorkflowDetailsByModule
    {
        // RowID DocumentId  ObjectTypeId RecordId    RecordTypeId RecordType  EntityId Project PropertyName Entity
        //Description StatusId StepNumber NumberOfSteps MainPage CurrentStepNumber DueDate RecordNumber projectId


        public long RowID { get; set; }
        public long DocumentId { get; set; }
        public long ObjectTypeId { get; set; }
        public long RecordId { get; set; }
        public long RecordTypeId { get; set; }
        public string RecordType { get; set; }

        public long EntityId { get; set; }
        public string Project { get; set; }
        public string PropertyName { get; set; }
        public string Entity { get; set; }
        public string Description { get; set; }
        public long StatusId { get; set; }

        public long StepNumber { get; set; }
        public long NumberOfSteps { get; set; }
        public string MainPage { get; set; }
        public long CurrentStepNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public string RecordNumber { get; set; }
        public long projectId { get; set; }

        public IList<DocumentStepsRoles> VisualWorkFlow { get; set; }
        public IList<WorkflowAttachments> WorkFlowAttachments { get; set; }
    }

    public class WorkflowAttachments
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public long FileId { get; set; }
        public string URL { get; set; }
        public string FileOption { get; set; }
        public string FullFileName { get; set; }
        public string FileGUID { get; set; }
        public string Description { get; set; }
        public byte[] FileContent { get; set; }
        public string FileContentBase64 { get; set; }
    }

    public class WorkflowDetailByModel
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public Int64 RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public int TotalPendingItems { get; set; }
    }

    public class DocumentStepsRoles
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public double Id { get; set; }
        public long DocumentStepId { get; set; }
        public long RoleId { get; set; }
        public long SavedUserId { get; set; }
        public string RoleName { get; set; }
        public long SpecialRoleId { get; set; }
        public string FullName { get; set; }
        public string Delegates { get; set; }
        public string TeamInput { get; set; }
        public long SpecialRoleUserId { get; set; }
        public string SpecialRoleUserName { get; set; }
        public bool IsCurrentStep { get; set; }
        public long CurrentStepNumber { get; set; }
        public long TotalItems { get; set; }

    }

    public class CurrentStep
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public double StepId { get; set; }

    }

    
    public class DocumentActionLogs
    {
        public long ActionId { get; set; }
        public long StepId { get; set; }
        public long ParentId { get; set; }
        public long StepNumber { get; set; }
        public long StepSort { get; set; }
        public long StepRoleId { get; set; }
        public long RoleId { get; set; }
        public long SpecialRoleId { get; set; }
        public string RoleName { get; set; }
        public long ActionTypeId { get; set; }
        public long ActionBy { get; set; }
        public string FullName { get; set; }
        public DateTime? ActionDate { get; set; }
        public DateTime? ActionDueDate { get; set; }
        public string Comments { get; set; }
        public string DocValue { get; set; }
        public string IsBranch { get; set; }
        public long BranchActionTypeId { get; set; }
        public string BranchName { get; set; }
        public string SignatureFileName { get; set; }
        public string SignatureExtension { get; set; }
        public Guid SignatureFileGuid { get; set; }
        public Guid thumbnailGuid { get; set; }
        public string FullFileName { get; set; }
        public string ActionType { get; set; }
        public string DelegateName { get; set; }
        public string TeamInputNames { get; set; }
        public long DeliveredToStepId { get; set; }
        public string HasEmail { get; set; }
        public string Generated { get; set; }
        public string Instructions { get; set; }

    }


    public class HelpDTO
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public long UserID { get; set; }
        public string Module { get; set; }
        public string TypeOfIssue { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

    }

}
