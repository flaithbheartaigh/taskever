using System.Linq;
using Abp.Timing;

using Taskever.Infrastructure.EntityFramework;

using Taskever.Infrastructure.EntityFramework.Data;
using Taskever.Infrastructure.EntityFramework.Data.Repositories;

using Taskever.Security.MultiTenancy;


namespace Taskever.Test.Data
{
    public class TestDataBuilder
    {
        public const string TestEventTitle = "Test event title";

        private readonly TaskeverDbContext _context;

        public TestDataBuilder(TaskeverDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestData();
        }

        private void CreateTestData()
        {
            // In-Memory Db?? 
            // set up additional users as users for friends system Using Test Tennant?? [Will this work with MultiTenancy Disabled?]

            // TestTennantName = "System Test Account - This should not persist in database"
            // Then delete tennant after test run and cascade delete all associated data

            // var defaultTenant = _context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            // _context.Events.Add(Event.Create(defaultTenant.Id, TestEventTitle, Clock.Now.AddDays(1)));
            // _context.SaveChanges();
        }
    }
}