using System.Threading.Tasks;
using Abp.Application.Services;
using ControlBooks.Roles.Dto;

namespace ControlBooks.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
