using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class BudgetDetailMap : EntityTypeConfiguration<BudgetDetail>
    {

        public BudgetDetailMap()
       {
           HasKey(t => new { t.Id });
           ToTable("BudgetDetail");
       }

    }
}
