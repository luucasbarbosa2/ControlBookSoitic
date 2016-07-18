using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ControlBooks.MultiTenancy.Dto;

namespace ControlBooks.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
