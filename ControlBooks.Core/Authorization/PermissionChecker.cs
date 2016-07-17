using Abp.Authorization;
using ControlBooks.Authorization.Roles;
using ControlBooks.MultiTenancy;
using ControlBooks.Users;

namespace ControlBooks.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
