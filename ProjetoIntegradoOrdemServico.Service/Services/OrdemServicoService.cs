using ProjetoIntegradoOrdemServico.Service.Interfaces;
using ProjetoIntegradoOrdemServico.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Service.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoRepository = ordemServicoRepository;
        }
        public async Task<Guid> Add(OrdemServico ordemServico)
        {
            ordemServico.DataCriacao = DateTime.Now;
            ordemServico.ValorTotal = ordemServico.ItemOrdemServicos.Sum(x => x.Valor);
            ordemServico.ItemOrdemServicos.ForEach(x => x.DataCriacao = DateTime.Now);
            ordemServico.DataCriacao = DateTime.Now;
            await _ordemServicoRepository.Adicionar(ordemServico);
            return await Task.Run(() => ordemServico.Id);
        }

        public async Task<IEnumerable<OrdemServico>> OrdemServico()
        {
            return await _ordemServicoRepository.ObterOrdensServico();
        }

        public async Task<IEnumerable<OrdemServico>> OrdemServicoPorTecnico(Guid tecnicoId)
        {
            return await _ordemServicoRepository.ObterOrdemServicoPorTecnico(tecnicoId);
        }
    }
}
