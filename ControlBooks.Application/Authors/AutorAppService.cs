using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using ControlBooks.Authors;
using ControlBooks.Authors.Dtos;

namespace ControlBooks.Authors
{
    public class AutorAppService : IAutorAppService
    {
        private readonly IAutorManage _autorManage;
        private readonly IRepository<Autor, Guid> _autorRepository;
        private readonly IAbpSession _abpSession;

        public AutorAppService(IAutorManage autorManage, IRepository<Autor, Guid> autorRepository, IAbpSession abpSession)
        {
            _autorManage = autorManage;
            _autorRepository = autorRepository;
            _abpSession = abpSession;


        }

        public Task<Autor> InsertNewAutor(AutorDto input)
        {
            var autor = Autor.Create(input.Nome, input.Sobrenome, input.Idade, _abpSession.GetTenantId());
            var autorResult = _autorManage.Create(autor);
            return autorResult;
        }

        public AutorDto UpdateAutorDto(AutorDto input)
        {
            var autor = input.MapTo<Autor>();
            var autorResult = _autorManage.Update(autor);
            return autorResult.MapTo<AutorDto>();

        }

        public void DeleteAutor(string input)
        {
            

            var idGuid = Guid.Parse(input);

            _autorManage.Delete(idGuid);

           
        }

        public async Task<ListResultOutput<AutorDto>> GetAllAutor()
        {
            var result = await _autorRepository.GetAllListAsync();
            var list = new HashSet<AutorDto>();
            foreach (var item in result)
            {
                list.AddIfNotContains(AutorDto.MaptoDto(item));
            }

            return new ListResultOutput<AutorDto>(list.ToList());
        }

        public AutorDto GetDetail(string input)
        {
            var id = Guid.Parse(input);
            var result = _autorRepository.GetAll().FirstOrDefault(x => x.Id == id);

            return result.MapTo<AutorDto>();
        }
    }
}