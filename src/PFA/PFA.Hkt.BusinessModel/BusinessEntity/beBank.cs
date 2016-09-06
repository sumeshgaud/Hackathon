using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
  public  class beBank:beBaseEntity
    {
        public string Name { get; set; }
        public string IfscCode { get; set; }
        public string Token { get; set; }
        public string Address { get; set; }
    }
}
