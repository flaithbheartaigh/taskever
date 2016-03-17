namespace Taskever.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Taskever.Infrastructure.EntityFramework.Migrations.SeedData;

    internal sealed class Configuration : DbMigrationsConfiguration<Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate.TaskeverDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate.TaskeverDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
