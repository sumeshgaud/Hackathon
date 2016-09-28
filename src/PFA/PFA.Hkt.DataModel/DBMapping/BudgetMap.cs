using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    class BudgetMap : EntityTypeConfiguration<Budget>
    {

        public BudgetMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.Type).IsRequired();
           Property(t => t.Month).IsRequired();
           Property(t => t.Year).IsRequired();
           ToTable("Budget");
       }
    }
}
