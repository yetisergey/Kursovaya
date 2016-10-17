using System.Data.Entity;

namespace Data
{
    public class PurchaseContext:DbContext
    {
        public PurchaseContext()
            :base("DbConnection")
        { }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
