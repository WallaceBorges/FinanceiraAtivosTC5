using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Entities
{
    public class Transacao:EntityBase
    {
        public int Portifolio_Id { get; set; }
        public int Ativo_Id { get; set; }
        public int TipoTransacao { get; set; }
        public decimal  Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataTransacao { get; set; }
        
        public Portfolio? portfolio { get; set; }
        public Ativo? ativo { get; set; }

    }
}
