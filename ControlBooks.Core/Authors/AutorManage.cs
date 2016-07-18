using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace ControlBooks.Authors
{
    public class AutorManage : IAutorManage
    {
        private readonly IRepository<Autor, Guid> _autorRepository;

        public AutorManage(IRepository<Autor, Guid> autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public Task<Autor> Create(Autor input)
        {
            var autorResult = _autorRepository.InsertAsync(input);
            return autorResult;
        }
        public Task<Autor> Update(Autor input)
        {
            var autor = _autorRepository.UpdateAsync(input);
            return autor;
        }

        public void Delete(Guid id)
        {
            _autorRepository.Delete(id);
        }
    }
}
