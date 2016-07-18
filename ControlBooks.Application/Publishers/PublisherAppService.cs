using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using ControlBooks.Publishers.Dtos;

namespace ControlBooks.Publishers
{
    public class PublisherAppService : IPublisherAppService
    {
        private readonly IPublisherManage _publisherManage;
        private readonly IRepository<Publisher, Guid> _publisherRepository;
        private readonly IAbpSession _abpSession;

        public PublisherAppService(IPublisherManage publisherManage, IRepository<Publisher, Guid> publisherRepository, IAbpSession abpSession)
        {
            _publisherManage = publisherManage;
            _publisherRepository = publisherRepository;
            _abpSession = abpSession;


        }

        public Task<Publisher> InsertNewPublisher(PublisherDto input)
        {
            var publisher = Publisher.Create(input.Nome, input.Descricao,  _abpSession.GetTenantId());
            var publisherResult = _publisherManage.Create(publisher);
            return publisherResult;
        }

        public PublisherDto UpdatePublisherDto(PublisherDto input)
        {
            var publisher = input.MapTo<Publisher>();
            var publisherResult = _publisherManage.Update(publisher);
            return publisherResult.MapTo<PublisherDto>();

        }

        public void DeletePublisher(string input)
        {


            var idGuid = Guid.Parse(input);

            _publisherManage.Delete(idGuid);


        }

        public async Task<ListResultOutput<PublisherDto>> GetAllPublisher()
        {
            var result = await _publisherRepository.GetAllListAsync();
            var list = new HashSet<PublisherDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(PublisherDto.MaptoDto(item));
            }

            return new ListResultOutput<PublisherDto>(list.ToList());
        }

        public PublisherDto GetDetail(string input)
        {
            var id = Guid.Parse(input);
            var result = _publisherRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return result.MapTo<PublisherDto>();
        }
    }
}