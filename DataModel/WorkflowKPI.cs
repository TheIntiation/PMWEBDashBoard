using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{


    public class ActiveWorkflowDocumentsByProject
    {
        //tableID DocumentId  RecordId RecordTypeId    RecordType ObjectId    ObjectTypeId EntityId    Entity
        //DocumentDescription StatustID CurrentPendingStepId    StepNumber NumberOfSteps   DueDateOfCurrentPendingStep ActionId

        public long tableID { get; set; }
        public long DocumentId { get; set; }
        public long RecordId { get; set; }
        public long RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public long ObjectId { get; set; }

        public long EntityId { get; set; }
        public string Entity { get; set; }
        public string DocumentDescription { get; set; }
        public long StatustID { get; set; }
        public long CurrentPendingStepId { get; set; }
        public long StepNumber { get; set; }
        public long NumberOfSteps { get; set; }
        public DateTime? DueDateOfCurrentPendingStep { get; set; }
        public long ActionId { get; set; }

    }


    public class DelayedWorkflowDocumentsByProject
    {
        //tableID DocumentId  RecordId RecordTypeId    RecordType ObjectId    ObjectTypeId EntityId    Entity
        //DocumentDescription StatustID CurrentPendingStepId    StepNumber NumberOfSteps   DueDateOfCurrentPendingStep ActionId

        public long tableID { get; set; }
        public long DocumentId { get; set; }
        public long RecordId { get; set; }
        public long RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public long ObjectId { get; set; }

        public long EntityId { get; set; }
        public string Entity { get; set; }
        public string DocumentDescription { get; set; }
        public long StatustID { get; set; }
        public long CurrentPendingStepId { get; set; }
        public long StepNumber { get; set; }
        public long NumberOfSteps { get; set; }
        public DateTime? DueDateOfCurrentPendingStep { get; set; }
        public long ActionId { get; set; }

    }

    public class ChartDetail
    {
        public string RecordName { get; set; }
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

    public class StageGatesSnap
    {
       // GateId GateDescrption  CountActivitiesDone TotalActivities Percentage

        public long GateId { get; set; }
         public string GateDescrption { get; set; }
        public long CountActivitiesDone { get; set; }
        public long TotalActivities { get; set; }
        public float Percentage { get; set; }
    }

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
}
