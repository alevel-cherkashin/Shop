namespace Shop.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }

        public DateTime? Date { get; set; }

        public double? Amount { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Client Client { get; set; }
    }
}
