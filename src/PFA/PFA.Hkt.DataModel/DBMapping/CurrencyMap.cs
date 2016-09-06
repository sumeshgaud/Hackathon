using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
       {
           HasKey(t => new { t.Id });
           Property(t => t.Name);
           Property(t => t.Country);
           ToTable("Currency");
       }
    }
}
