using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GoogleMapAddress
    {
        public long projectid { get; set; }
        public string GoogleAddress { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
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
    }

    public class WorkflowDetailByModel
    {
        //RecordTypeId	RecordType	TotalPendingItems
        public Int64 RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public int TotalPendingItems { get; set; }
    }



}
