using ProjetoIntegradoOrdemServico.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Service.Interfaces
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        Task<List<OrdemServico>> ObterOrdemServicoPorTecnico(Guid tecnicoId);
        Task<List<OrdemServico>> ObterOrdensServico();
    }
}
