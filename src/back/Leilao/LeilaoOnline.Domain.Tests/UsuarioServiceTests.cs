using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Services;
using Moq;
using Xunit;

namespace LeilaoOnline.Domain.Tests
{
    public class UsuarioServiceTests
    {
        [Fact]
        public void Usuario_Logar_NaoPermitirUsuarioDesativado()
        {

            // Arrange 
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var usuario =  new Usuario() { Email = "teste@teste.com.br", Senha = "202cb962ac59075b964b07152d234b70", Ativo = false };
           
            Usuario nulo = null;

            usuarioRepository.Setup(x => x.ObterPorEmailESenha(usuario)).Returns(nulo);

            var usuarioService = new UsuarioService(usuarioRepository.Object);

            // Act
            var retorno = usuarioService.Autenticar(usuario);

            // Assert
            Assert.True(retorno == null);
        }

        [Fact]
        public void Usuario_Logar_PermitirUsuarioAtivado()
        {
            // Arrange
            var usuarioRepository = new Mock<IUsuarioRepository>();
            var usuario = new Usuario() { Email = "teste@teste.com.br", Senha = "202cb962ac59075b964b07152d234b70", Ativo = true };
         
            usuarioRepository.Setup(x => x.ObterPorEmailESenha(usuario)).Returns(usuario);

            var usuarioService = new UsuarioService(usuarioRepository.Object);

            // Act
            var retorno = usuarioService.Autenticar(usuario);

            // Assert
            Assert.True(retorno != null);
        }
    }
}
