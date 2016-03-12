namespace Taskever.Security.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            public const string Admin = "HostAdmin";
        }

        public static class Tenant
        {
            public const string Admin = "TenantAdmin";
            public const string Member = "Member";
        }
    }
}
