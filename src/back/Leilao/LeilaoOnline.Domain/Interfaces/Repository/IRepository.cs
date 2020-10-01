﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LeilaoOnline.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Adicionar(T obj);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
        T Atualizar(T obj);
        void Remover(Guid id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        int Salvar();
    }
}
