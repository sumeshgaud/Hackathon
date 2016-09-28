using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFA.Hkt.UI.MVC.Models
{
    public class BudgetViewModel
    {
        public string CategoryName { get; set; }
        public double Amount { get; set; }

        public int UserId { get; set; }
        public string Type { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsRecuring { get; set; }
        public double RecievedAmmount { get; set; }
    }
}

 

