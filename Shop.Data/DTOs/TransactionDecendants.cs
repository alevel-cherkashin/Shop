using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.DTOs
{
    public class OrdinaryTransaction : Transaction
    {
            public string PaymentSystemId { get; set; }
    }

    public class CraditTransaction : Transaction
    {

        public string BillNumber { get; set; }

        public double Overdraft { get; set; }

        public string ManagerName { get; set; }

        public DateTime CommitmenData { get; set; }

    }
}
