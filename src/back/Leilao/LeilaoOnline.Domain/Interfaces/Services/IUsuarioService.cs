using LeilaoOnline.Domain.Entities;

namespace LeilaoOnline.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Autenticar(Usuario model);
    }
}
