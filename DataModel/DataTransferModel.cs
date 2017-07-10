using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataTransferModel
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public dynamic DataValue { get; set; }
    }
}
