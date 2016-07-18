using System;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;



namespace ControlBooks.Publishers
{
    public class PublisherManage : IPublisherManage
    {
        private readonly IRepository<Publisher, Guid> _publisherRepository;

        public PublisherManage(IRepository<Publisher, Guid> autorRepository)
        {
            _publisherRepository = autorRepository;
        }

        public Task<Publisher> Create(Publisher input)
        {
            var autorResult = _publisherRepository.InsertAsync(input);
            return autorResult;
        }
        public Task<Publisher> Update(Publisher input)
        {
            var autor = _publisherRepository.UpdateAsync(input);
            return autor;
        }

        public void Delete(Guid id)
        {
            _publisherRepository.Delete(id);
        }
    }
}