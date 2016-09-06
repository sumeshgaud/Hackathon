using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
  public  class beBudgetDetail:beBaseEntity
    {
        public Guid BudgetId { get; set; }
        public Guid CategoryId { get; set; }

    }
}
