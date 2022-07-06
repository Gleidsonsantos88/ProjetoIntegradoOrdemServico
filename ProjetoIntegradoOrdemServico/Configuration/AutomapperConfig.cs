using AutoMapper;
using ProjetoIntegradoOrdemServico.Service.Models;
using ProjetoIntegradoOrdemServico.ViewModel;

namespace ProjetoIntegradoOrdemServico.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<OrdemServico, OrdemServicoViewModel>().ReverseMap();
            CreateMap<ItemOrdemServico, ItemOrdemServicoViewModel>().ReverseMap();
            CreateMap<OrdemServicoSituacao, OrdemServicoSituacaoViewModel>().ReverseMap();
        }
    }
}
