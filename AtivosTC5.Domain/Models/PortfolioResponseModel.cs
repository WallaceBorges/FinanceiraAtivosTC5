using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models
{
    public class PortfolioResponseModel
    {
        public int Usuario_Id { get; set; }
        public int Portifolio_Id { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }

       public IList<AtivoPortfolioDTO>? Ativos{ get; set; }
    }
}
