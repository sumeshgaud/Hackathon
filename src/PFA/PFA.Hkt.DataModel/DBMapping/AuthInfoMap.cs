using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class AuthInfoMap : EntityTypeConfiguration<AuthInfo>
    {
        public AuthInfoMap()
        {
            HasKey(t => new { t.Id });
           
            Property(t => t.Token).IsRequired();
           

            ToTable("AuthInfo");
        }
    }
}
