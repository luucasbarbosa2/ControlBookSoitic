using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ControlBooks.Authors;

namespace ControlBooks.Authors.Dtos
{
    [AutoMapFrom(typeof(Authors.Autor))]
    public class AutorDto : FullAuditedEntityDto<Guid>
    {
        public virtual String Nome { get; set; }
        public virtual String Sobrenome { get; set; }
        public virtual int Idade { get; set; }
        public virtual int TenantId { get; set; }

        public static AutorDto MaptoDto(Authors.Autor item)
        {
            var dto = item.MapTo<AutorDto>();

            dto.Nome = item.Nome;
            dto.Sobrenome = item.Sobrenome;
            dto.Idade = item.Idade;
            dto.TenantId = item.TenantId;

            return dto;

        }
    }
}
