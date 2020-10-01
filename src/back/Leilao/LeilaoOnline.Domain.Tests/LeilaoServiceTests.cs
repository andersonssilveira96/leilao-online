using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Services;
using Moq;
using System;
using Xunit;

namespace LeilaoOnline.Domain.Tests
{
    public class LeilaoServiceTests
    {
        [Fact]
        public void Leilao_Cadastrar_RotornarComSucesso()
        {
            // Arrange 
            var leilaoRepository = new Mock<ILeilaoRepository>();
            var leilao = new Leilao() 
            { 
                Id = Guid.NewGuid(), 
                ValorInicial = 3000, 
                UsuarioResponsavelId = Guid.NewGuid(),
                DataAbertura =  DateTime.Now,
                DataFinalizacao =  DateTime.Now,
                Nome = "Teste",
                Usado = false
            };

            leilaoRepository.Setup(x => x.Adicionar(leilao)).Returns(leilao);

            var leilaoService = new LeilaoService(leilaoRepository.Object);

            // Act
            var retorno = leilaoService.Adicionar(leilao);

            // Assert
            Assert.True(retorno.Valido.IsValid);
        }

        [Fact]
        public void Leilao_Cadastrar_RotornarComErro()
        {
            // Arrange 
            var leilaoRepository = new Mock<ILeilaoRepository>();
            var leilao = new Leilao()
            {
                Id = Guid.NewGuid(),
                ValorInicial = 3000,
                UsuarioResponsavelId = Guid.NewGuid(),                
                Nome = "Teste"             
            };

            leilaoRepository.Setup(x => x.Adicionar(leilao)).Returns(leilao);

            var leilaoService = new LeilaoService(leilaoRepository.Object);

            // Act
            var retorno = leilaoService.Adicionar(leilao);

            // Assert
            Assert.False(retorno.Valido.IsValid);
        }


        [Fact]
        public void Leilao_Atualizar_RotornarComSucesso()
        {
            // Arrange 
            var leilaoRepository = new Mock<ILeilaoRepository>();
            var leilao = new Leilao()
            {
                Id = Guid.NewGuid(),
                ValorInicial = 3000,
                UsuarioResponsavelId = Guid.NewGuid(),
                DataAbertura = DateTime.Now,
                DataFinalizacao = DateTime.Now,
                Nome = "Teste",
                Usado = false
            };

            leilaoRepository.Setup(x => x.Atualizar(leilao)).Returns(leilao);

            var leilaoService = new LeilaoService(leilaoRepository.Object);

            // Act
            var retorno = leilaoService.Atualizar(leilao);

            // Assert
            Assert.True(retorno.Valido.IsValid);
        }

        [Fact]
        public void Leilao_Atualizar_RotornarComErro()
        {
            // Arrange 
            var leilaoRepository = new Mock<ILeilaoRepository>();
            var leilao = new Leilao()
            {
                Id = Guid.NewGuid(),
                ValorInicial = 3000,
                UsuarioResponsavelId = Guid.NewGuid(),
                DataAbertura = DateTime.Now,               
                Nome = "Teste",
                Usado = false
            };

            leilaoRepository.Setup(x => x.Adicionar(leilao)).Returns(leilao);

            var leilaoService = new LeilaoService(leilaoRepository.Object);

            // Act
            var retorno = leilaoService.Atualizar(leilao);

            // Assert
            Assert.False(retorno.Valido.IsValid);
        }
    }
}
