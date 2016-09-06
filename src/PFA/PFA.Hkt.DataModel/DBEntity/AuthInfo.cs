using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AuthInfo:BaseEntity
    {
        public Guid AccountId { get; set; }
        public string Token { get; set; }
        public Guid MerchantId { get; set; }
        public Guid UserId { get; set; }
  
    }
}
