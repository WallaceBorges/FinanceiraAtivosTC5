using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Entities
{
    public class Usuario:EntityBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public Portfolio? portfolio { get; set; }

    }
}
