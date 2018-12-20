using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Models
{
    public class CategoryClientViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
