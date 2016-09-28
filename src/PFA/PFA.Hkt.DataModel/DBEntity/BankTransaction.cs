using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
   public class BankTransaction :BaseEntity
    {
       public DateTime Date { get; set; }
       public int ReferenceId { get; set; }
       public int CategoryId { get; set; }
       public string Description { get; set; }
       public int AccountId { get; set; }
       public int UserId { get; set; }
       public string Type { get; set; }
       public double Amount { get; set; }
       public string Payee { get; set; }
       public string Note { get; set; }
       public int ParentId { get; set; }
       public bool IsSplitTransaction { get; set; }
       public string TxSource { get; set; }
    }
}
