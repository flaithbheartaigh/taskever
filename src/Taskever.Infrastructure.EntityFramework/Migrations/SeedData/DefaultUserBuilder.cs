using Abp.Authorization.Users;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskever.Infrastructure.EntityFramework.Data.Repositories;
using Taskever.Security.MultiTenancy;
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
            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Break();

            CreateTennantUserAndRoles();
            // CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                //Admin role for host
                var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.CreatorUserId == null && r.Name == StaticRoleNames.Host.Admin);
                if (adminRoleForTenancyOwner == null)
                {
                    adminRoleForTenancyOwner = _context.Roles.Add(new TaskeverRole { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                    _context.SaveChanges();
                }

                //Admin user for tenancy owner
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
                        }
                    );
                    _context.SaveChanges();

                    _context.UserRoles.Add(new UserRole(adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));
                    _context.SaveChanges();
                }

                transaction.Commit();
            }
        }

        private void CreateTennantUserAndRoles()
        {            
            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                //Admin role for host
                var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
                if (adminRoleForTenancyOwner == null)
                {
                    adminRoleForTenancyOwner = _context.Roles.Add(new TaskeverRole { Name = StaticRoleNames.Host.Admin, DisplayName = StaticRoleNames.Host.Admin, IsStatic = true });
                    _context.SaveChanges();
                }

                //Admin user for tenancy owner
                var adminUserForTenancyOwner = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "host");
                if (adminUserForTenancyOwner == null)
                {
                    adminUserForTenancyOwner = _context.Users.Add(
                        new TaskeverUser
                        {
                            TenantId = null,
                            UserName = "host",
                            Name = "Host",
                            Surname = "Administrator",
                            EmailAddress = "admin@aspnetboilerplate.com",
                            IsEmailConfirmed = true,
                            Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe
                        });

                    _context.SaveChanges();

                    _context.UserRoles.Add(new UserRole(adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));
                    _context.SaveChanges();
                }

                //Default tenant
                var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
                if (defaultTenant == null)
                {
                    defaultTenant = _context.Tenants.Add(new Tenant { TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName });
                    _context.SaveChanges();
                }

                //Admin role for 'Default' tenant
                var adminRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == StaticRoleNames.Tenant.Admin);
                if (adminRoleForDefaultTenant == null)
                {
                    adminRoleForDefaultTenant = _context.Roles.Add(new TaskeverRole { TenantId = defaultTenant.Id, Name = StaticRoleNames.Tenant.Admin, DisplayName = StaticRoleNames.Tenant.Admin, IsStatic = true });
                    try { 
                    _context.SaveChanges();
                        }
                    catch(Exception ex)
                    {
                        int i = 0;
                    }
                }

                //Member role for 'Default' tenant
                var memberRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == StaticRoleNames.Tenant.Member);
                if (memberRoleForDefaultTenant == null)
                {
                    _context.Roles.Add(new TaskeverRole { TenantId = defaultTenant.Id, Name = StaticRoleNames.Tenant.Member, DisplayName = StaticRoleNames.Tenant.Member, IsStatic = true });
                    _context.SaveChanges();
                }

                //Admin user for 'Default' tenant
                var adminUserForDefaultTenant = _context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");
                if (adminUserForDefaultTenant == null)
                {
                    adminUserForDefaultTenant = _context.Users.Add(
                        new TaskeverUser
                        {
                            TenantId = defaultTenant.Id,
                            UserName = "admin",
                            Name = "System",
                            Surname = "Administrator",
                            EmailAddress = "admin@aspnetboilerplate.com",
                            IsEmailConfirmed = true,
                            Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==", //123qwe
                        });
                    _context.SaveChanges();

                    _context.UserRoles.Add(new UserRole(adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));
                    _context.SaveChanges();
                }

                transaction.Commit();
            }
        }
    }
}