using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoOrdemServico.Service.Interfaces;
using ProjetoIntegradoOrdemServico.Service.Models;
using ProjetoIntegradoOrdemServico.Service.Services;
using ProjetoIntegradoOrdemServico.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Controllers
{
    [Route("api/ordemservico")]
    [ApiController]
    public class OrdermServicoController : ControllerBase
    {
        private readonly IOrdemServicoService _ordemServicoService;
        private readonly IMapper _mapper;
        public OrdermServicoController(IOrdemServicoService ordemServicoService,
                                       IMapper mapper)
        {
            _ordemServicoService = ordemServicoService;
            _mapper = mapper;
        }

        [Route("criar")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Criar(OrdemServicoViewModel ordemServico)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var response = await _ordemServicoService.Add(_mapper.Map<OrdemServico>(ordemServico));
                return Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrdemServicoViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Listar()
        {

            var ordensServico = _mapper.Map<List<OrdemServicoViewModel>>(await _ordemServicoService.OrdemServico());

            if (ordensServico == null)
                return NotFound();

            return Ok(ordensServico);
        }

        [HttpGet("listar-portecnico/{tecnicoid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrdemServicoViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarPorTecnico(Guid tecnicoId)
        {

            var ordensServico = _mapper.Map<List<OrdemServicoViewModel>>(await _ordemServicoService.OrdemServicoPorTecnico(tecnicoId));

            if (ordensServico == null)
                return NotFound();

            return Ok(ordensServico);
        }

    }
}
