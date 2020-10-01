using LeilaoOnline.Domain.Entities;

namespace LeilaoOnline.Domain.Interfaces.Services
{
    public interface ILeilaoService
    {
        Leilao Adicionar(Leilao leilao);
        Leilao Atualizar(Leilao leilao);
    }
}
