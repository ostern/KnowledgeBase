using System.Security.Cryptography.X509Certificates;
using KnowledgeBase.Models;

namespace KnowledgeBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KnowledgeBase.DAL.BaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KnowledgeBase.DAL.BaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Products.AddOrUpdate(
                p => p.ProductName,
                new Product { ProductName = "Creditbility"},
                new Product { ProductName = "CreditFlow" },
                new Product { ProductName = "CreditBerueu" },
                new Product { ProductName = "StrategyOne" },
                new Product { ProductName = "Rapid" }
                );

        }
    }
}
