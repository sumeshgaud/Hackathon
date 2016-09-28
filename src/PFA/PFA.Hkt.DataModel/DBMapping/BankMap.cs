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
    class BankMap : EntityTypeConfiguration<Bank>
    {
        public BankMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.Name).IsRequired();
           Property(t => t.Token).IsRequired();
           Property(t => t.IfscCode).IsRequired();
         
           ToTable("Bank");
       }
    }
}
