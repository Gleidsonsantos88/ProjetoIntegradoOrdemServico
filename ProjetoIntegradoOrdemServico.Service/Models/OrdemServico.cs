﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegradoOrdemServico.Service.Models
{
    public class OrdemServico : Entity
    {
        [Required(ErrorMessage = "Informe o técnico")]
        public Guid TecnicoId { get; set; }

        [Required(ErrorMessage ="Informe o usuário de criação")]
        public Guid UsuarioCriacaoId { get; set; }

        [Required(ErrorMessage = "Informe a data de inicio do serviço")]
        public DateTime DataInicioServico { get; set; }

        [Required(ErrorMessage = "Informe o nome técnico")]
        public string NomeTecnico { get; set; }

        [MaxLength(500, ErrorMessage = "Observação não pode ter mais de 500 caracteres")]
        public String Observacao { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataVigencia { get; set; }
        public Decimal ValorTotal { get; set; }

        public virtual ItemOrdemServico ItemOrdemServicos { get; set; }
        public virtual OrdemServicoSituacao OrdemServicoSituacoes { get; set; }
    }
}
