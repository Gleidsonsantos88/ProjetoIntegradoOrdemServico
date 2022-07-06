using ProjetoIntegradoOrdemServico.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Service.Interfaces
{
    public interface IOrdemServicoService
    {
        Task<Guid> Add(OrdemServico ordemServico);
        Task<IEnumerable<OrdemServico>> OrdemServicoPorTecnico(Guid tecnicoId);
        Task<IEnumerable<OrdemServico>> OrdemServico();
    }
}
