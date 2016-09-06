using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    class TravelMap : EntityTypeConfiguration<TravelPlan>
    {
        public TravelMap()
        {
            HasKey(x => x.Id);
            Property(x => x.FromLocation).IsRequired();
            Property(x => x.ToLocation).IsRequired();
            ToTable("TravelPlan");
        }
    }
}
