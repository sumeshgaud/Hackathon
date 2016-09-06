using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {

        public CategoryMap()
       {
           HasKey(t => new { t.Id });
           Property(t => t.CategoryName);
           Property(t => t.Type);
           ToTable("Category");
       }
    }
}
