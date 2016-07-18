using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ControlBooks.Authors.Dtos;
using ControlBooks.Books.Dtos;


namespace ControlBooks.Authors
{
    public interface IAutorAppService : IApplicationService
    {
        Task<Autor> InsertNewAutor(AutorDto input);
        AutorDto UpdateAutorDto(AutorDto input);
        void DeleteAutor(string input);
        Task<ListResultOutput<AutorDto>> GetAllAutor();
        AutorDto GetDetail(string input);


    }
}