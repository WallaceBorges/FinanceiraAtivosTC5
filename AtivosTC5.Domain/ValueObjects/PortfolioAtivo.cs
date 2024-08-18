using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.ValueObjects
{
    public class PortfolioAtivo
    {
        public int Portfolio_Id { get; set; }
        public int Ativo_Id { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }


        public Ativo? ativo { get; set; }
        public Portfolio? portfolio { get; set; }
    }
}
