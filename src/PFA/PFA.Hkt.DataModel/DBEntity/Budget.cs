using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Budget:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsRecuring { get; set; }
    }
}
