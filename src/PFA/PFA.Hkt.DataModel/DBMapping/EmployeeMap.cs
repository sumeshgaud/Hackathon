using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    class EmployeeMap:EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(t => new { t.Id});
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();
            ToTable("Employee");
        }
    }
}
