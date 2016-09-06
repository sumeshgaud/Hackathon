using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
       {
           HasKey(t => new { t.Id });
           Property(t => t.Name);
           Property(t => t.Type);
           Property(t => t.Balance);
        
           ToTable("Account");
       }
    }
}
