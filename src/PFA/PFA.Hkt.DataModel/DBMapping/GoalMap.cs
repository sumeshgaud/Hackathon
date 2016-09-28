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
    class GoalMap : EntityTypeConfiguration<Goal>
    {
        public GoalMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.TargetDate).IsRequired();
           Property(t => t.AmountRequired).IsRequired();
           Property(t => t.MonthlyContribution).IsRequired();
           Property(t => t.RecurDate).IsRequired();
           Property(t => t.Note);
           ToTable("Goal");
       }
    }
}
