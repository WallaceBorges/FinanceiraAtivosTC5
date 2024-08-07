using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Entities
{
    public class Portfolio : EntityBase
    {
        public int Usuario_Id { get; set; }
        public string Descricao { get; set; }

        public Usuario? usuario { get; set; }
        public IList<Ativo>? ativos { get; set; }
        public IList<Transacao>? transacoes { get; set; }

    }
}
