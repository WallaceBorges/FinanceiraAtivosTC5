using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.UseCases.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.UseCases.Usuarios
{
    public class RetornaUsuario : IRetornaUsuario
    {
        private IUsuarioRepository _usuarioRepository;

        public RetornaUsuario(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObterPorId(int id) => _usuarioRepository.ObterPorId(id);
    }
}
