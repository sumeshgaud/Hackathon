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
    class CategoryMap : EntityTypeConfiguration<Category>
    {

        public CategoryMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.CategoryName);
           Property(t => t.Type);
           ToTable("Category");
       }
    }
}
