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
     class TransactionMap : EntityTypeConfiguration<BankTransaction>
    {
       public TransactionMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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
