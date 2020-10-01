using LeilaoOnline.Infra.Data.Context;
using LeilaoOnline.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LeilaoOnline.Infra.Data.Repository
{
    public class LeilaoRepository : Repository<Leilao>, ILeilaoRepository
    {
        public LeilaoRepository([FromServices] DataContext context) : base(context)
        {
        }

        public override IEnumerable<Leilao> ObterTodos()
        {
            var dataAtual = DateTime.Now;

            var retorno = (from leilao in Db.Leilao
                           join usuario in Db.Usuario on leilao.UsuarioResponsavelId equals usuario.Id
                           select new Leilao
                           {
                               Id = leilao.Id,
                               DataAbertura = leilao.DataAbertura,
                               DataFinalizacao = leilao.DataFinalizacao,
                               Usuario = usuario,
                               UsuarioResponsavelId = leilao.UsuarioResponsavelId,
                               Nome = leilao.Nome,
                               Usado = leilao.Usado,
                               Valido = leilao.Valido,
                               ValorInicial = leilao.ValorInicial,
                               Encerrado = leilao.DataFinalizacao < dataAtual 
                           })
                           .AsNoTracking();

            return retorno;
        }
        public override Leilao ObterPorId(Guid id)
        {
            return DbSet.Include(x => x.Usuario).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
