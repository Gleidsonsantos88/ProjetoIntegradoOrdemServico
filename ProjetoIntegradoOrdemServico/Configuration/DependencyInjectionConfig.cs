using Microsoft.Extensions.DependencyInjection;
using ProjetoIntegradoOrdemServico.Repository.Context;
using ProjetoIntegradoOrdemServico.Repository.Repository;
using ProjetoIntegradoOrdemServico.Service.Interfaces;
using ProjetoIntegradoOrdemServico.Service.Services;

namespace ProjetoIntegradoOrdemServico.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProjetoIntegradoDbContext>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();

            return services;
        }
    }
}
