using System;
using Abp.Extensions;
using Abp.Authorization.Users;
using Abp.Utils;
using Abp.Utils.Etc;
using Taskever.Security.MultiTenancy;
using Microsoft.AspNet.Identity;
using System.Threading;
using System.ComponentModel.DataAnnotations.Schema;

using Taskever.Utils;

namespace Taskever.Security.Users
{
    [Table("AbpUsers")]
    public class TaskeverUser : AbpUser<Tenant, TaskeverUser>
    {
        /// <summary>
        /// Profile image of the user. 
        /// </summary>
        public virtual string ProfileImage { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static TaskeverUser CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new TaskeverUser
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password),
                IsEmailConfirmed = true,
                IsActive = true
            };
        }

        public string NameAndSurname
        {
            get
            {
                return String.Format("{0} {1}", Name, Surname);
            }
        }

        public void GenerateEmailConfirmationCode()
        {
            EmailConfirmationCode = RandomCodeGenerator.Generate(16);
        }

        public void GeneratePasswordResetCode()
        {
            PasswordResetCode = RandomCodeGenerator.Generate(32);
        }
        
        public void ConfirmEmail(string confirmationCode)
        {
            if (IsEmailConfirmed)
            {
                return;
            }

            if (EmailConfirmationCode != confirmationCode)
            {
                throw new ApplicationException("Wrong email confirmation code!");
            }

            IsEmailConfirmed = true;
        }

        /// <summary>
        /// Gets current user id.
        /// </summary>
        public static long? CurrentUserId
        {
            get
            {
                var userId = Thread.CurrentPrincipal.Identity.GetUserId();
                if (userId == null)
                {
                    return null;
                }

                return Convert.ToInt32(userId);
            }
        }
    }
}
