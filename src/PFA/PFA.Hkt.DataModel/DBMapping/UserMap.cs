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
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.UserName).IsRequired();
            Property(t => t.Email).IsRequired();
            Property(t => t.PrimaryNumber).IsRequired();
            Property(t => t.Password).IsRequired();
            ToTable("User");
        }
    }
}
