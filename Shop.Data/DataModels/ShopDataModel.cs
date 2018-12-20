namespace Shop.Data.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDataModel : DbContext
    {
        public ShopDataModel()
            : base("name=ShopDataModel1")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionView> TransactionView { get; set; }
        public virtual DbSet<CategoryClient> CategoryClient { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
