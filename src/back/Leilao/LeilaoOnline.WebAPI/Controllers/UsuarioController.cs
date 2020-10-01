using LeilaoOnline.Application.Interfaces;
using LeilaoOnline.Application.Models;
using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Infra.CrossCutting.Filters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoOnline.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }             
  
        [HttpPost]
        public ActionResult<RetornoModel> Post([FromBody] UsuarioModel model)
        {
            var retorno = _usuarioAppService.Autenticar(model);
            if (retorno != null)
                return Ok(new RetornoModel() { Sucesso = true, Mensagem = TokenService.GenerateToken(retorno) }); 
            else
                return BadRequest(new RetornoModel() { Sucesso = false, Mensagem = "Usuário ou senha inválidos" }); 
        }       
    }
}
