using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LeilaoOnline.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository([FromServices] DataContext context) : base(context)
        {
        }

        public Usuario ObterPorEmailESenha(Usuario usuario)
        {
            return DbSet.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha && x.Ativo == true).FirstOrDefault();
        }
    }
}
