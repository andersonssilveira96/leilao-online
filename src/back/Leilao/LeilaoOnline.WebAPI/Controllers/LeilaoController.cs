using LeilaoOnline.Application.Interfaces;
using LeilaoOnline.Application.Models;
using LeilaoOnline.Infra.CrossCutting.Filters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace LeilaoOnline.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeilaoController : MainController
    {
        private readonly ILeilaoAppService _leilaoAppService;
        public LeilaoController(ILeilaoAppService leilaoAppService)
        {
            _leilaoAppService = leilaoAppService;
        }
        
        [HttpGet]
        public IEnumerable<LeilaoModel> Get()
        {
            return _leilaoAppService.ObterTodos(); 
        }
       
        [HttpGet("{id}")]
        public ActionResult<LeilaoModel> Get(Guid id)
        {
            return _leilaoAppService.ObterPorId(id);
        }
      
        [HttpPost]
        public ActionResult<LeilaoModel> Post([FromBody] LeilaoModel model)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            model.UsuarioResponsavelId = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);

            var retorno = _leilaoAppService.Adicionar(model);
            
            if (!retorno.Valido.IsValid)
                return FailedResponse(retorno.Valido);
            else
                return Ok(new RetornoModel() { Sucesso = retorno.Valido.IsValid, Mensagem = "Leilão inserido com sucesso" });
        }
        
        [HttpPut("{id}")]
        public ActionResult<RetornoModel> Put(Guid id, [FromBody] LeilaoModel model)
        {
            var retorno = _leilaoAppService.Atualizar(id, model);

            if (retorno == null)
                return BadRequest(new RetornoModel() { Sucesso = false, Mensagem = "Leilão não encontrado" });            
            else if(!retorno.Valido.IsValid)
                return FailedResponse(retorno.Valido);
            else
                return Ok(new RetornoModel() { Sucesso = retorno.Valido.IsValid, Mensagem = "Leilão atualizado com sucesso" });
        }
      
        [HttpDelete("{id}")]
        public ActionResult<RetornoModel> Delete(Guid id)
        {
            var retorno = _leilaoAppService.Remover(id);

            if (retorno)
                return Ok(new RetornoModel() { Sucesso = retorno, Mensagem = "Leilão deletado com sucesso" });
            else
                return BadRequest(new RetornoModel() { Sucesso = retorno, Mensagem = "Erro ao deletar leilão" });
        }
    }
}
