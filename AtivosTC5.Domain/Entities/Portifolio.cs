using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Entities
{
    public class Portifolio : EntityBase
    {
        public int Usuario_Id { get; set; }
        public string Descricao { get; set; }
    }
}
