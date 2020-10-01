using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Interfaces.Services;

namespace LeilaoOnline.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario Autenticar(Usuario usuario)
        {            
            return _usuarioRepository.ObterPorEmailESenha(usuario);
        }
    }
}
