using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Entities
{
    public class Ativo:EntityBase
    {
        public int TipoAtivo_Id { get; set; }
        public string Sigla { get; set; }

        public AtivoTipo? ativoTipo { get; set; }
        public IList<Portfolio>? portfolios { get; set; }
        public IList<Transacao>? transacoes { get; set; }
    }
}
