using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Services;

namespace EducationPortalADO.DAL.Infrastructure
{
    public static class Provider
    {
        public static Account AuthorizedUser { get; set; } = default;

        public static string ConnectionString { get; set; }

        public static AccountService AccountService { get; set; } 

        public static RoleService RoleService { get; set; }
    }
}
