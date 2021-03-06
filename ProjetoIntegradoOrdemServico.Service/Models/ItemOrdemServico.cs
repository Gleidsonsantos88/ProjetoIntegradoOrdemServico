using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoOrdemServico.Service.Models
{
    public class ItemOrdemServico : Entity
    {

        [Required(ErrorMessage = "Informe o serviço")]
        public Guid ServicoId { get; set; }

        [Required(ErrorMessage = "Informe o valor do serviço")]
        public Decimal Valor { get; set; }
        
        public DateTime DataCriacao { get; set; }
        public Guid OrdemServicoId { get; set; }
        public virtual OrdemServico OrdemServico { get; set; }

        [Required(ErrorMessage = "Informe a descrição do serviço")]
        public string DescricaoServico { get; set; }
    }
}
