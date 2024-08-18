using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models
{
    public class AtivoPortfolioDTO
    {
        public int Ativo_Id { get; set; }
        public int AtivoTipo_Id { get; set; }
        public string AtivoTipoNome { get; set; }
        public string Sigla { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
