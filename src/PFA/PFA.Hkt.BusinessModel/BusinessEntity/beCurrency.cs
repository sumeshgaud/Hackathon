using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
  public  class beCurrency:beBaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
    }
}
