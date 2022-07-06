using Microsoft.EntityFrameworkCore;
using ProjetoIntegradoOrdemServico.Repository.Context;
using ProjetoIntegradoOrdemServico.Service.Interfaces;
using ProjetoIntegradoOrdemServico.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Repository.Repository
{
    public class OrdemServicoRepository : Repository<OrdemServico>, IOrdemServicoRepository
    {
        protected readonly ProjetoIntegradoDbContext _context;
        public OrdemServicoRepository(ProjetoIntegradoDbContext context) : base(context) {
            _context = context;
        }

        public async Task<List<OrdemServico>> ObterOrdemServicoPorTecnico(Guid tecnicoId)
        {
            return await Task.Run(() => _context.OrdemServicos
                                        .Include("ItemOrdemServicos")
                                        .Include("OrdemServicoSituacoes")
                                        .Where(x => x.TecnicoId == tecnicoId).ToList());
        }

        public async Task<List<OrdemServico>> ObterOrdensServico()
        {
            return await Task.Run(() => _context.OrdemServicos
                                        .Include("ItemOrdemServicos")
                                        .Include("OrdemServicoSituacoes")
                                        .ToList());
        }
    }
}
