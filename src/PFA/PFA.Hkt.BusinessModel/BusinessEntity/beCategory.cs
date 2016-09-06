using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class beCategory:beBaseEntity
    {
        public Guid UserId { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public Guid ParentCategoryId { get; set; }
    }
}
