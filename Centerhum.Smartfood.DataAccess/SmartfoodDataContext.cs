using Centerhum.SmartFood.DataAccess.Map;
using Centerhum.SmartFood.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centerhum.SmartFood.DataAccess
{
    public class SmartFoodDataContext : DbContext
    {

        // How to Use Migration, use this commands in Tools --> Library Package Manager --> Package Manager Console
        // Install
        //Enable-Migrations -ProjectName Centerhum.SmartFood.DataAccess -StartUpProjectName Centerhum.SmartFood.Web -Verbose

        // Update
        //Update-Database -Force -Verbose -ProjectName Centerhum.SmartFood.DataAccess
        public SmartFoodDataContext()
            : base("SmartFoodConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new BoardMap());
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ApiAccess> ApiAccess { get; set; }
        public DbSet<Board> Board { get; set; }
    }
}
