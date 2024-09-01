using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Models.Requests
{
    public class PortfolioRequestModel
    {
        [Required]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
