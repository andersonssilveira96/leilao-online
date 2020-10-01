using FluentValidation.Results;
using LeilaoOnline.Infra.CrossCutting.Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeilaoOnline.WebAPI.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private ValidationResult _data { get; set; }
        protected ActionResult FailedResponse(ValidationResult result)
        {
            this._data = result;

            return BadRequest(new RetornoModel() { Erros = this.ObterErros(), Sucesso = false, Mensagem = "Erro ao executar o request" });
        }

        private List<string> ObterErros()
        {
            var lista = new List<string>();
            foreach(var item in this._data.Errors)
            {
                lista.Add(item.ErrorMessage);
            }

            return lista;
        }
    }
}
