using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBooks.Authors
{
    public interface IAutorManage : IDomainService
    {
        Task<Autor> Create(Autor input);
        Task<Autor> Update(Autor input);

        void Delete(Guid id);


    }
}
