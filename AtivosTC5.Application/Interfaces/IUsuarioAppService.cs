using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Models.Responses;
using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        /// <summary>
        /// Método de ação para criar a conta do usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        CriarContaResponseModel CriarConta(CriarContaRequestModel model);

        /// <summary>
        /// Método de ação para autenticar o usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);
    }
}
