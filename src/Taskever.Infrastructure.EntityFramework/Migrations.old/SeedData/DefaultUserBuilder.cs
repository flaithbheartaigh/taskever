using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate;

using Taskever.Security.Roles;
using Taskever.Security.Users;

namespace Taskever.Infrastructure.EntityFramework.Migrations.SeedData
{
    public class DefaultUserBuilder
    {
        private readonly TaskeverDbContext _context;

        public DefaultUserBuilder(TaskeverDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateUsers();
        }

        private void CreateUsers()
        {
            if (!System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Launch();

            //Admin role for host
            var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.CreatorUserId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = _context.Roles.Add(new TaskeverRole { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin });
                _context.SaveChanges();
            }

            var adminUserForTenancyOwner = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "admin");
            if (adminUserForTenancyOwner == null)
            {
                adminUserForTenancyOwner = _context.Users.Add(
                    new TaskeverUser
                    {
                        TenantId = null,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe
                    });

                _context.SaveChanges();

                _context.Roles.Add(new TaskeverRole() { CreatorUserId = adminUserForTenancyOwner.Id, DisplayName="User Role", Name = "User Role"});

                _context.SaveChanges();
            }
        }
    }
}