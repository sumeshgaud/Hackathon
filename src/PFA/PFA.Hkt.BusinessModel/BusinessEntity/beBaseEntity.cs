using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public abstract class beBaseEntity
    {
        public Guid Id;
        public string CreatedBy;
        public DateTime CreatedOn;
        public string ModifiedBy;
        public DateTime ModifiedOn;
    }
}
