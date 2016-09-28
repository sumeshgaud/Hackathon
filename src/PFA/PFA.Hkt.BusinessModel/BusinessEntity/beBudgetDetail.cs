using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
  public  class beBudgetDetail:beBaseEntity
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
    }
}
