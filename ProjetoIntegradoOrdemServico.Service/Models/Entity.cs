using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoOrdemServico.Service.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
