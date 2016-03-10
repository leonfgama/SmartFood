namespace Centerhum.SmartFood.DataAccess.Migrations
{
    using Centerhum.SmartFood.Model;
    using Centerhum.SmartFood.Model.Enum;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Centerhum.SmartFood.DataAccess.SmartFoodDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Centerhum.SmartFood.DataAccess.SmartFoodDataContext context)
        {
            var products1 = new Product[2] { 
                        new Product() { Id = 1, Name = "Temaki", Price = 15.00 },
                        new Product() { Id = 2, Name = "Hot Roll", Price = 10.00 },
                    };
            var products2 = new Product[2] { 
                        new Product() { Id = 3, Name = "Yaksoba", Price = 22.00 },
                        new Product() { Id = 4, Name = "Coca-Cola", Price = 4.50 },
                    };

            var products3 = new Product[2] { 
                        new Product() { Id = 1, Name = "Temaki", Price = 15.00 },
                        new Product() { Id = 4, Name = "Coca-Cola", Price = 4.50 },
                    };

            context.ApiAccess.AddOrUpdate(new ApiAccess() {
                Id = 1,
                Token = "80079F80-F203-4E0E-954E-48326DDD6979",
                Description = "Maquina Local"
            });

            context.Product.AddOrUpdate(products1);
            context.Product.AddOrUpdate(products2);

            context.Board.AddOrUpdate(
                    new Board() { 
                        Id = 1,
                        Name = "Mesa do Leon",
                        Status = BoardStatusType.Open
                    }
                );

            context.Order.AddOrUpdate(
                    new Order()
                    {
                        Id = 1,
                        BoardId = 1
                    },
                    new Order()
                    {
                        Id = 2,
                        BoardId = 1
                    },
                    new Order()
                    {
                        Id = 3,
                        BoardId = 1
                    }
                );

            context.ProductOrder.AddOrUpdate(
                    new ProductOrder() { OrderId = 1, ProductId = 1 },
                    new ProductOrder() { OrderId = 1, ProductId = 2 },
                    new ProductOrder() { OrderId = 2, ProductId = 1 },
                    new ProductOrder() { OrderId = 2, ProductId = 3 },
                    new ProductOrder() { OrderId = 3, ProductId = 4 },
                    new ProductOrder() { OrderId = 3, ProductId = 3 },
                    new ProductOrder() { OrderId = 3, ProductId = 3 },
                    new ProductOrder() { OrderId = 3, ProductId = 1 }
                );
        }
    }
}



