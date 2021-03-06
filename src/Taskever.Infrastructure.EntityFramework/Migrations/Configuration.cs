using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using EntityFramework.DynamicFilters;

using Taskever.Infrastructure.EntityFramework.Data;
using Taskever.Infrastructure.EntityFramework.Migrations.SeedData;


namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TaskeverDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskeverDbContext context)
        {
            context.DisableAllFilters();

            new InitialDataBuilder(context).Build();

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
        }
    }
}
