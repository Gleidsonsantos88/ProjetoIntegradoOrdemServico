using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoOrdemServico.ViewModel
{
    public class OrdemServicoSituacaoViewModel
    {
        [Required(ErrorMessage = "Informe o usuário de criação")]
        public Guid UsuarioCriacaoId { get; set; }

        public Guid OrdemServicoId { get; set; }
        public OrdemServicoViewModel OrdemServico { get; set; }
        public OrdemServicoStatusViewModel OrdemServicoStatus { get; set; }
    }
}
