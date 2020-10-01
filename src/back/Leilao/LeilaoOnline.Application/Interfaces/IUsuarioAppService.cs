using LeilaoOnline.Application.Models;
using LeilaoOnline.Domain.Entities;

namespace LeilaoOnline.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioModel Autenticar(UsuarioModel model);
    }
}
