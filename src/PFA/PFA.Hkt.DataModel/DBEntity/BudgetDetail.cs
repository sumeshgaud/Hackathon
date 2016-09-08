using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
   public class BudgetDetail:BaseEntity
    {
       public Guid BudgetId { get; set; }
       public Guid CategoryId { get; set; }
       public double Amount { get; set; }
    }
}
