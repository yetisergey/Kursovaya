using System.Data.Entity;

namespace Data
{
    public class BaseContext : DbContext
    {

        //static BaseContext()
        //{
        //    Database.SetInitializer<BaseContext>(new DbInit());
        //}
        public BaseContext()
            : base("DbConnection")
        {          
        }
        public DbSet<User> UsersAdmin { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        
    }
}
