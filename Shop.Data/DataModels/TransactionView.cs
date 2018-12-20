namespace Shop.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionView")]
    public partial class TransactionView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public double? Amount { get; set; }

        public int? ClientId { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
