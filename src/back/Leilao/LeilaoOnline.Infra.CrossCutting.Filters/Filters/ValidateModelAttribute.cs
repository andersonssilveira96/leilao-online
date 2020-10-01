using LeilaoOnline.Infra.CrossCutting.Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeilaoOnline.Infra.CrossCutting.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {           
            if (!context.ModelState.IsValid)
            {
                var retorno = new RetornoModel() { Sucesso = false };
                foreach (var state in context.ModelState)
                {
                    retorno.Erros.Add("Campo " + state.Key + " está inválido");                    
                }

                context.Result = new BadRequestObjectResult(retorno);
            }
        }
    }
}
