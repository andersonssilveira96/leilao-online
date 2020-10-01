using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Interfaces.Services;

namespace LeilaoOnline.Domain.Services
{
    public class LeilaoService : ILeilaoService
    {
        private readonly ILeilaoRepository _leilaoRepository;        
        public LeilaoService(ILeilaoRepository leilaoRepository)                        
        {
            _leilaoRepository = leilaoRepository;          
        }
        public Leilao Adicionar(Leilao leilao)
        {
            leilao.Validar();

            if (!leilao.Valido.IsValid)
                return leilao;
            
            return _leilaoRepository.Adicionar(leilao);            
        }

        public Leilao Atualizar(Leilao leilao)
        {
            leilao.Validar();

            if (!leilao.Valido.IsValid)
                return leilao;

            return _leilaoRepository.Atualizar(leilao);
        }
    }
}
