using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBooks.Authors
{
    [Table("Autor")]

    public class Autor : FullAuditedEntity<Guid>, IMustHaveTenant, ISoftDelete
    {
        [Required]
        [StringLength(250)]
        public virtual String Nome { get; set; }

        [Required]
        [StringLength(250)]
        public virtual String Sobrenome { get; set; }

        [Required]
        public virtual int Idade { get; set; }
        public int TenantId { get; set; }

        public static Autor Create(String nome, String sobrenome, int idade, int tenantId)
        {
            var autor = new Autor
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Sobrenome = sobrenome,
                Idade = idade,
                TenantId = tenantId
            };

            return autor;
        }


    }
}
