using Shop.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BusinnesLogic.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public ClientViewModel Client { get; set; }

        public int ClientId { get; set; }
    }
}
