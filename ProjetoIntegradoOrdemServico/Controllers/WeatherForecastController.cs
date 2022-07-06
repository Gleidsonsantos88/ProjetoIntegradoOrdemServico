using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradoOrdemServico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        //[Authorize(Roles = "Gestor")]
        public IEnumerable<WeatherForecast> Get()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.Contains("Bearer"))
            {
                authHeader = authHeader.Replace("Bearer ", "");

                var jsonToken = handler.ReadToken(authHeader);
                var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
                var id = tokenS.Claims.First(claim => claim.Type == "iss").Value;
            }

            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Descricao = "Ordem de serviço",
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[Authorize(Roles = "Tecnico")]
        //[HttpGet("sale/{id:int}")]
        public IEnumerable<WeatherForecast> Get2(int id)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.Contains("Bearer"))
            {
                authHeader = authHeader.Replace("Bearer ", "");

                var jsonToken = handler.ReadToken(authHeader);
                var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
              //  var id = tokenS.Claims.First(claim => claim.Type == "iss").Value;
            }


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Descricao = "Ordem de serviço",
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
