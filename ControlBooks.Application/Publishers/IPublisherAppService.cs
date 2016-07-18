using ControlBooks.Publishers.Dtos;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace ControlBooks.Publishers
{
    public interface IPublisherAppService : IApplicationService
    {
        Task<Publisher> InsertNewPublisher(PublisherDto input);
        PublisherDto UpdatePublisherDto(PublisherDto input);
        void DeletePublisher(string input);
        Task<ListResultOutput<PublisherDto>> GetAllPublisher();
        PublisherDto GetDetail(string input);
    }
}