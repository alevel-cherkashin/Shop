using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Shop.BusinnesLogic.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Should")]
        [MaxLength(20,ErrorMessage ="To long")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
