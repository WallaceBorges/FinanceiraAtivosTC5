using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models.Responses
{
    public class TransacaoReponseModel
    {
        public int Portifolio_Id { get; set; }
        public int TipoTransacao { get; set; }
        public string? NomeTipoTransacao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }
        public AtivoReponseModel? Ativo { get; set; }
     
    }
}
