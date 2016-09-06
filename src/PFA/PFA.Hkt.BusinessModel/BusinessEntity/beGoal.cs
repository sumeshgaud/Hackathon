using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public class beGoal:beBaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime TargetDate { get; set; }
        public double AmountRequired { get; set; }
        public double MonthlyContribution { get; set; }
        public DateTime RecurDate { get; set; }
        public Guid FoundingSource { get; set; }
        public string Note { get; set; }
    }
}
