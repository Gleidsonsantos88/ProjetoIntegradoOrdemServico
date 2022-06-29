using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoOrdemServico.Service.Models
{
    public class OrdemServicoSituacao : Entity
    {
        [Required(ErrorMessage = "Informe o usuário de criação")]
        public Guid UsuarioCriacaoId { get; set; }

        public Guid OrdemServicoId { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public OrdemServicoStatus OrdemServicoStatus { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
