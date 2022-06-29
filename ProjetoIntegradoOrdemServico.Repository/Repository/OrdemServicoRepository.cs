using ProjetoIntegradoOrdemServico.Repository.Context;
using ProjetoIntegradoOrdemServico.Service.Interfaces;
using ProjetoIntegradoOrdemServico.Service.Models;

namespace ProjetoIntegradoOrdemServico.Repository.Repository
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(ProjetoIntegradoDbContext context) : base(context) { }
    }
}
