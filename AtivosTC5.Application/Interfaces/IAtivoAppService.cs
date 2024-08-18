
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.Interfaces
{
    public interface IAtivoAppService
    {
        Task<IList<AtivoReponseModel>> ListaAtivos();
    }
}
