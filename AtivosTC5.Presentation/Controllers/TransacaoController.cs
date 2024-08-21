using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.UseCases.Ativos;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
using AtivosTC5.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AtivosTC5.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private readonly IRetornaUsuario _retornaUsuario;
        private readonly IEfetuaTransacaoCompra _transacaoCompra;
        private readonly IEfetuaTransacaoVenda _transacaoVenda;
        private readonly IRetornaListaTransacao _retornaListaTransacao;
        
        public TransacaoController(ILogger<UsuarioController> logger,
                                IRetornaUsuario usuarioService,
                                IEfetuaTransacaoCompra transacao,
                                IEfetuaTransacaoVenda transacaoVenda,
                                IRetornaListaTransacao retornaListaTransacao)
        {
            _logger = logger;
            _retornaUsuario = usuarioService;
            _transacaoCompra = transacao;
            _transacaoVenda = transacaoVenda;
            _retornaListaTransacao = retornaListaTransacao;
        }

        /// <summary>
        /// Efetua compra do ativo.
        /// </summary>
        [Authorize]
        [HttpPost("efetua-compra-ativo")]
        public async Task<IActionResult> PostEfetuaCompra(TransacaoRequestModel model)
        {
         
            try
            {
                _logger.LogInformation("Executando método PostEfetuaCompra");

                var portfolio = await _transacaoCompra.EfetuarTransacao(model);
               
                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Efetua venda do ativo.
        /// </summary>
        [Authorize]
        [HttpPost("efetua-Venda-ativo")]
        public async Task<IActionResult> PostEfetuaVenda(TransacaoRequestModel model)
        {
            try
            {
                _logger.LogInformation("Executando método PostEfetuaVenda");

                var portfolio = await _transacaoVenda.EfetuarTransacao(model);

                return Ok(portfolio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Retorna as transações do usuário logado.
        /// </summary>
        [Authorize]
        [HttpGet("retorna-transacoes-usuario")]
        public async Task<IActionResult> GetListaTransacoesPorUser()
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                _logger.LogInformation("Executando método GetListaTransacoesPorUser");

                var Lista = await _retornaListaTransacao.ListaTransacao(userId);
                
                return Ok(Lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Retorna as transações do usuário logado e data selecionada.
        /// </summary>
        [Authorize]
        [HttpGet("retorna-transacoes-usuario-data/{data}")]
        public async Task<IActionResult> GetListaTransacoesPorData(DateTime data)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                _logger.LogInformation("Executando método GetListaTransacoesPorData");

                var Lista = await _retornaListaTransacao.ListaTransacaoPorData(data,userId);

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Retorna as transações do usuário logado e portfolio selecionado.
        /// </summary>
        [Authorize]
        [HttpGet("retorna-transacoes-usuario-portfolio/{idPort}")]
        public async Task<IActionResult> GetListaTransacoesPorPortfolio(int idPort)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                _logger.LogInformation("Executando método GetListaTransacoesPorPortfolio");

                var Lista = await _retornaListaTransacao.ListaTransacaoPortfolio(idPort, userId);

                return Ok(Lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now} - Exception Forçada: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
    }
}
