using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
     class TransactionMap : EntityTypeConfiguration<Transaction>
    {
       public TransactionMap()
       {
           HasKey(t => new { t.Id });
           Property(t => t.Date);
           Property(t => t.Description);
           Property(t => t.Type);
           Property(t => t.Amount);
           Property(t => t.Payee);
           Property(t => t.Note);
           ToTable("Transaction");
       }
    }
}
