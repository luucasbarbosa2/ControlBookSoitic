using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ControlBooks.Authors;
using ControlBooks.Publishers;

namespace ControlBooks.Books.Dtos
{

        [AutoMapFrom(typeof(Book))]
        public class BookDto : FullAuditedEntityDto<Guid>
        {
        public virtual String Titulo { get; set; }
       
        public virtual String Subtitulo { get; set; }
      
        public virtual String Sinopse { get; set; }

        public virtual DateTime Ano { get; set; }

        public virtual int Volume { get; set; }

        public int AutorId { get; set; }
        
        public int PublisherId { get; set; }

        public int TenantId { get; set; }

        public static BookDto MaptoDto(Book item)
            {
            var dto = item.MapTo<BookDto>();

            dto.Titulo = item.Titulo;;
            dto.Subtitulo = item.Subtitulo;
            dto.Sinopse = item.Sinopse;
            dto.Ano = item.Ano;
            dto.Volume = item.Volume;
            dto.AutorId = item.AutorId;
            dto.PublisherId = item.PublisherId;
            dto.TenantId = item.TenantId;

            return dto;

            }
        }
    
}