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
}
