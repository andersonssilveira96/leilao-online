using LeilaoOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LeilaoOnline.Infra.Data.Configs
{
    public class LeilaoConfig : IEntityTypeConfiguration<Domain.Entities.Leilao>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Leilao> builder)
        {
            builder.HasKey(e => e.Id);
           
            builder.Property(u => u.Nome).HasMaxLength(80);
            builder.Property(u => u.DataAbertura).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(u => u.DataFinalizacao).IsRequired();
            builder.Property(u => u.Usado).IsRequired();

            builder.HasOne(u => u.Usuario).WithMany(u => u.Leilao).HasForeignKey(u => u.UsuarioResponsavelId).IsRequired();

            builder.Ignore(u => u.Valido);
            builder.Ignore(u => u.Encerrado);

            builder.HasData(new Leilao()
            {
                Id = Guid.NewGuid(),
                DataAbertura = DateTime.Now,
                DataFinalizacao = DateTime.Now,
                Nome = "Leilão do Audi TT",
                Usado = false,
                UsuarioResponsavelId = Guid.Parse("a7353f28-e5fb-4d51-888b-0564d67bcf2b"),
                ValorInicial = 246000
            });

            builder.HasData(new Leilao()
            {
                Id = Guid.NewGuid(),
                DataAbertura = DateTime.Now,
                DataFinalizacao = DateTime.Now,
                Nome = "Leilão da BMW 320i",
                Usado = true,
                UsuarioResponsavelId = Guid.Parse("a7353f28-e5fb-4d51-888b-0564d67bcf2b"),
                ValorInicial = 83500
            });           
        }
    }
}
