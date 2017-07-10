using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class GetDocumentsInDelay
    {
        public int totaldelay { get; set; }
        public string Entity { get; set; }
        public string RecordType { get; set; }
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

}
