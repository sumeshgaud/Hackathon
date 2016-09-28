using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public class beAccount:beBaseEntity
    {
        public int UserId { get; set; }
        public int BankId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }

    }
}
