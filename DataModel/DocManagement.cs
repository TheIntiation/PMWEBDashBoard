using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
 
        public class DocManagementRFIs
        {
        // ProjID ProjectName ProjectNumber DocNumber   DocumentDate Revision    DocStatusId DocStatusName  
        //RequiredDate AnsweredDate

            public long ProjID { get; set; }
            public string ProjectName { get; set; }
            public string ProjectNumber { get; set; }
            public string DocNumber { get; set; }
            public DateTime? DocumentDate { get; set; }
            public long DocStatusId { get; set; }
            public string DocStatusName { get; set; }
            public DateTime? RequiredDate { get; set; }
            public DateTime? AnsweredDate { get; set; }
           

        }

}
