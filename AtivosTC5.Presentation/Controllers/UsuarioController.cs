using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.Services;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Presentation.Models;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtivosTC5.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IRetornaUsuario _retornaUsuario;
        private readonly IUsuarioAppService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,
                                 IRetornaUsuario usuarioService,
                                 IUsuarioAppService usuarioAppService)
        {
            _logger = logger;
            _retornaUsuario = usuarioService;
            _usuarioService = usuarioAppService;
        }

        /// <summary>
        /// Retorna um usuá por ID.
        /// </summary>
        [Authorize]
        [HttpGet("obter-por-usuario-id/{id}")]
        public  IActionResult ObterPorUsuarioId(int id)
        {
            try
            {
                _logger.LogInformation("Executando método ObterPorUsuarioId");

                var usuario = _retornaUsuario.ObterPorId(id);
                if (usuario == null)
                    throw new Exception("Usuário não localizado.");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest();
            }

        }


        /// <summary>
        /// Serviço para autenticação de usuários.
        /// </summary>
        [AllowAnonymous]
        [Route("Autenticar")]
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarRequestModel usuarioModel)
        {
            try
            {
                var response = _usuarioService?.Autenticar(usuarioModel);
                return StatusCode(200, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Autenticar: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para criação de conta de novos usuários.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("Criar-Conta")]
        public IActionResult CriarConta(CriarContaRequestModel request)
        {
            try
            {
                var response = _usuarioService?.CriarConta(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Conta: {e.Message}");
            }
        }
    }
}
