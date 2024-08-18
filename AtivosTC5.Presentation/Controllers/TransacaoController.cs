using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.UseCases.Ativos;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
using AtivosTC5.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public TransacaoController(ILogger<UsuarioController> logger,
                                IRetornaUsuario usuarioService,
                                IEfetuaTransacaoCompra transacao,
                                IEfetuaTransacaoVenda transacaoVenda)
        {
            _logger = logger;
            _retornaUsuario = usuarioService;
            _transacaoCompra = transacao;
            _transacaoVenda = transacaoVenda;
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
    }
}
