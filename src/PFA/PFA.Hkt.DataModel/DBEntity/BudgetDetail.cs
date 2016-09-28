using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
   public class BudgetDetail:BaseEntity
    {
       public int BudgetId { get; set; }
       public int CategoryId { get; set; }
       public double Amount { get; set; }
    }
}
