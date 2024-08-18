using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models.Responses
{
    /// <summary>
    /// Modelo de dados da resposta para a o fluxo de criação de conta de usuário
    /// </summary>
    public class CriarContaResponseModel
    {
        public string? Mensagem { get; set; }
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
    }
}
