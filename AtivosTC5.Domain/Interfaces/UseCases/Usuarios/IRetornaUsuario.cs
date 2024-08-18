using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.UseCases.Usuarios
{
    public interface IRetornaUsuario
    {
        Usuario ObterPorId(int id);
    }
}
