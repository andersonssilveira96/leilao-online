using LeilaoOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LeilaoOnline.Infra.Data.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
          
            builder.Property(u => u.Nome).HasMaxLength(80);
            builder.Property(u => u.Email).HasMaxLength(80);
            builder.Property(u => u.Senha).HasMaxLength(80);
            builder.Property(u => u.Ativo).IsRequired().HasDefaultValue(true);


            builder.HasData(new Usuario() { Id = Guid.Parse("a7353f28-e5fb-4d51-888b-0564d67bcf2b"), Nome = "Usuario de Teste", Senha = "202cb962ac59075b964b07152d234b70", Ativo = true, Email = "teste@teste.com.br" });
        }
    }
}
