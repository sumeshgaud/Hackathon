using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public class beRecurTransaction:beBaseEntity
    {
        public int TransactionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public string RecurType { get; set; }
        public int RecurDays { get; set; }
        public bool IsIndefinite { get; set; }
        public int NumberOfTimes { get; set; }
    }
}
