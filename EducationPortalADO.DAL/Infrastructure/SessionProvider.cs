using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Services;

namespace EducationPortalADO.DAL.Infrastructure
{
    /// <summary>
    /// 
    /// Stores data about current session
    /// Authorized user etc.
    /// </summary>
    public static class SessionProvider
    {
        public static Account AuthorizedUser { get; set; } = default;
    }
}
