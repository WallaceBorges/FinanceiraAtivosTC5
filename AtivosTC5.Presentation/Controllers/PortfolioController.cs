using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Application.Interfaces;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AtivosTC5.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly IRetornaUsuario _retornaUsuario;
        private readonly IPortfolioAppService _portiFolioService;

        public PortfolioController(ILogger<UsuarioController> logger,
                                 IRetornaUsuario usuarioService,
                                 IPortfolioAppService portFolioAppService)
        {
            _logger = logger;
            _retornaUsuario = usuarioService;
            _portiFolioService = portFolioAppService;
        }

        /// <summary>
        /// Retorna um Portfolio por ID.
        /// </summary>
        [Authorize]
        [HttpGet("obter-portifolio-id/{id}")]
        public async Task<IActionResult> GetPortfolioPorId(int id)
        {
            try
            {
                _logger.LogInformation("Executando método GetPortfolioPorId");

                var portfolio = await _portiFolioService.GetPortfolioPorId(id);
                if (portfolio == null)
                    throw new Exception("Portfolio não localizado.");

                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }

        /// <summary>
        /// Retorna uma lista de Portfolio do usuário logado.
        /// </summary>
        [Authorize]
        [HttpGet("obter-lista-por-usuario")]
        public async Task<IActionResult> GetPortfolioPorIdUsuario()
        {
            var userId = User.FindFirst("Id")?.Value;
            try
            {
                _logger.LogInformation("Executando método GetPortfolioPorIdUsuario");

                var portfolio = await _portiFolioService.GetPortfolioPorIdUsuario(int.Parse(userId));
                if (portfolio == null)
                    throw new Exception("Nenhum Portfolio  localizado.");

                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }

        /// <summary>
        /// Cadastro de portifolio para usuario logado.
        /// </summary>
        [Authorize]
        [HttpPost("cadastra-portfolio")]
        public async Task<IActionResult> PostPostfolio([FromBody]PortfolioRequestModel requestModel)
        {
            var userId = User.FindFirst("Id")?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            try
            {
                _logger.LogInformation($"Cadastrando portfolio para o usuario {userName}");

                var portifolio = new Portfolio {
                        Descricao=requestModel.Descricao,   
                        Nome=requestModel.Nome, 
                        Usuario_Id=int.Parse(userId)
                };

                var response = await _portiFolioService.PostPortfolio(portifolio);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }
    }
}
