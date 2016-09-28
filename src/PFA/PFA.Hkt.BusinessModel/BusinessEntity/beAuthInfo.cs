using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
   public class beAuthInfo:beBaseEntity
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
    }
}
