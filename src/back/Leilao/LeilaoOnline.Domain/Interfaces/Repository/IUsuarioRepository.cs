using LeilaoOnline.Domain.Entities;

namespace LeilaoOnline.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObterPorEmailESenha(Usuario usuario);
    }
}
