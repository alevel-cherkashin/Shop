using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.DTOs
{
    public  class TransactionDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public ClientDto Client { get; set; } 

        public int ClientId { get; set; }
    }
}
