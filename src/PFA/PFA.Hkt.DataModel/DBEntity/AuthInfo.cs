using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AuthInfo:BaseEntity
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
  
    }
}
