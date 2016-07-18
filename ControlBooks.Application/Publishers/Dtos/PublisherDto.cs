using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ControlBooks.Publishers.Dtos
{
    [AutoMapFrom(typeof(Publisher))]
    public class PublisherDto : FullAuditedEntityDto<Guid>
    {
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual int TenantId { get; set; }

        public static PublisherDto MaptoDto(Publisher item)
        {
            var dto = item.MapTo<PublisherDto>();

            dto.Nome = item.Nome;
            dto.Descricao = item.Descricao;
            dto.TenantId = item.TenantId;

            return dto;

        }

    }
}