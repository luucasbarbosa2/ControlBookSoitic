using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ControlBooks.Authors;
using ControlBooks.Publishers;


namespace ControlBooks.Books
{
    [Table("Books")]

    public class Book : FullAuditedEntity<Guid>, IMustHaveTenant, ISoftDelete
    {
        [Required]
        [StringLength(250)]
        public virtual String Titulo { get; set; }

        [Required]
        [StringLength(250)]
        public virtual String Subtitulo { get; set; }

        [Required]
        [StringLength(250)]
        public virtual String Sinopse { get; set; }

        [Required]

        public virtual DateTime Ano { get; set; }

        [Required]
        public virtual int Volume { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        public int TenantId { get; set; }

        public static Book Create(
            String titulo, 
            String subtitulo,
            String sinopse,
            DateTime ano, 
            int volume, 
            int autorId,
            int publisherId,
            int tenantId)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Titulo = titulo,
                Subtitulo = subtitulo,
                Sinopse = sinopse,
                Ano = ano,
                Volume = volume,
                AutorId = autorId,
                PublisherId = publisherId,
                TenantId = tenantId
            };

            return book;
        }


    }
}