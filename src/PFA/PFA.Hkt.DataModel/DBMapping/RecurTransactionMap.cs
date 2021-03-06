﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    class RecurTransactionMap:EntityTypeConfiguration<RecurTransaction>
    {

        public RecurTransactionMap()
       {
           HasKey(t => t.Id);
           Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.RecurType).IsRequired();
           Property(t => t.RecurDays).IsRequired();
           Property(t => t.NumberOfTimes).IsRequired();
           ToTable("RecurTransaction");
       }
    }
}
