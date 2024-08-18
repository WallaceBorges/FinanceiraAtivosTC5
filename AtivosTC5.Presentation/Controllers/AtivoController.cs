using AtivosTC5.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtivosTC5.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IAtivoAppService _appService;

        public AtivoController(ILogger<UsuarioController> logger,
                                 IAtivoAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        /// <summary>
        /// Retorna um usuá por ID.
        /// </summary>
        [Authorize]
        [HttpGet("obter-lista-ativos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                _logger.LogInformation("Executando método Obter todos");

                var ativos = _appService.ListaAtivos();
                if (ativos == null)
                    throw new Exception($"Erro ao buscar lista de ativos");

                return Ok(await ativos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }
    }
}
