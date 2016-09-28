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
    class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
       {
           HasKey(t =>t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.Name);
           Property(t => t.Type);
           Property(t => t.Balance);
        
           ToTable("Account");
       }
    }
}
