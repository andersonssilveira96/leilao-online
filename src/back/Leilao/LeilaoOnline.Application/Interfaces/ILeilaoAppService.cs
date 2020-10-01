using LeilaoOnline.Application.Models;
using System;
using System.Collections.Generic;

namespace LeilaoOnline.Application.Interfaces
{
    public interface ILeilaoAppService
    {
        IEnumerable<LeilaoModel> ObterTodos();
        LeilaoModel ObterPorId(Guid Id);
        LeilaoModel Adicionar(LeilaoModel model);
        LeilaoModel Atualizar(Guid Id, LeilaoModel model);
        bool Remover(Guid Id);
    }
}
