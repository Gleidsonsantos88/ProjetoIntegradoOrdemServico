using Microsoft.EntityFrameworkCore;
using ProjetoIntegradoOrdemServico.Service.Models;

namespace ProjetoIntegradoOrdemServico.Repository.Context
{
    public class ProjetoIntegradoDbContext : DbContext 
    {
        public ProjetoIntegradoDbContext(DbContextOptions<ProjetoIntegradoDbContext> options) : base(options) { }
        public DbSet<OrdemServico> OrdemServicos { get; set; }
        public DbSet<ItemOrdemServico> ItemOrdemServicos { get; set; }
        public DbSet<OrdemServicoSituacao> OrdemServicoSituacoes { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

    }
}
