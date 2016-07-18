using System;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace ControlBooks.Publishers
{
    public interface IPublisherManage : IDomainService
    {
        Task<Publisher> Create(Publisher input);
        Task<Publisher> Update(Publisher input);

        void Delete(Guid id);

    }
}