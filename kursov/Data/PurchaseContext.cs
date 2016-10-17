using System.Data.Entity;

namespace Data
{
    class PurchaseContext:DbContext
    {
        public PurchaseContext()
            :base("DbConnection")
        { }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
