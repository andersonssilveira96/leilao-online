using AutoMapper;
using LeilaoOnline.Application.Interfaces;
using LeilaoOnline.Application.Models;
using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Interfaces.Services;
using LeilaoOnline.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace LeilaoOnline.Application.Services
{
    public class LeilaoAppService : ILeilaoAppService
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly ILeilaoService _leilaoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public LeilaoAppService(ILeilaoRepository leilaoRepository, 
                                ILeilaoService leilaoService, 
                                IMapper mapper, 
                                IUnitOfWork uow)
        {
            _leilaoRepository = leilaoRepository;
            _leilaoService = leilaoService;
            _mapper = mapper;
            _uow = uow;
        }

        public IEnumerable<LeilaoModel> ObterTodos()
        {
            var retorno = _leilaoRepository.ObterTodos();
            return _mapper.Map<IEnumerable<LeilaoModel>>(retorno);
        }

        public LeilaoModel ObterPorId(Guid Id)
        {
            var retorno = _leilaoRepository.ObterPorId(Id);
            return _mapper.Map<LeilaoModel>(retorno);
        }

        public LeilaoModel Adicionar(LeilaoModel model)
        {
            var leilao = _mapper.Map<Leilao>(model);

            _uow.BeginTransaction();

            leilao = _leilaoService.Adicionar(leilao);

            if(leilao.Valido.IsValid)
                _uow.Commit();

            return _mapper.Map<LeilaoModel>(leilao);
        }

        public LeilaoModel Atualizar(Guid Id, LeilaoModel model)
        {
            _uow.BeginTransaction();

            var leilao = _leilaoRepository.ObterPorId(Id);

            if (leilao != null)
            {
                leilao.Nome = model.Nome;
                leilao.DataAbertura = model.DataAbertura;
                leilao.DataFinalizacao = model.DataFinalizacao;
                leilao.Usado = model.Usado;
                leilao.ValorInicial = model.ValorInicial;
            }
            else
            {
                return null;
            }

            leilao = _leilaoService.Atualizar(leilao);

            if(leilao.Valido.IsValid)
                _uow.Commit();

            return _mapper.Map<LeilaoModel>(leilao);
        }

        public bool Remover(Guid Id)
        {
            _uow.BeginTransaction();

            _leilaoRepository.Remover(Id); 
            
            _uow.Commit();

            return true;            
        }
    }
}
