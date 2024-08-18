using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models.Requests
{
    public class TransacaoRequestModel
    {
        public int Portifolio_Id { get; set; }
        public int Ativo_Id { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
