using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LeilaoOnline.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Db;
        protected DbSet<T> DbSet;

        public Repository([FromServices]DataContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual T Adicionar(T obj)
        {
            var returnObj = DbSet.Add(obj);
            return returnObj.Entity;
        }

        public virtual T ObterPorId(Guid id)
        {
            var returnObj = DbSet.Find(id);

            if (returnObj != null)
                Db.Entry(returnObj).State = EntityState.Detached;

            return returnObj;
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual T Atualizar(T obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int Salvar()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
