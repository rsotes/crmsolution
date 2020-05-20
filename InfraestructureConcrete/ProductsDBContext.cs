using InfraestructureConcrete.Configurations;
using Infrastructure;
using ProductsDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureConcrete
{
    public class ProductsDBContext : DbContext, IDBContext
    {
        public ProductsDBContext() : base("ProductsDB")
        {
            Database.SetInitializer<ProductsDBContext>(new CreateDatabaseIfNotExists<ProductsDBContext>());              
        }

        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }

        void IDBContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
