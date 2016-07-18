using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ControlBooks.Books;

namespace ControlBooks.Publishers
{

        [Table("Publisher")]

        public class Publisher : FullAuditedEntity<Guid>, IMustHaveTenant, ISoftDelete
        {
            [Required]
            [StringLength(250)]
            public virtual String Nome { get; set; }

            [Required]
            [StringLength(800)]
            public virtual String Descricao { get; set; }

            public ICollection<Book> Books { get; set; }

            public int TenantId { get; set; }

            public static Publishers.Publisher Create(String nome, String descricao,  int tenantId)
            {
                var publisher = new Publisher()
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Descricao = descricao,
          
                    TenantId = tenantId
                };

                return publisher;
            }


        }
    }
