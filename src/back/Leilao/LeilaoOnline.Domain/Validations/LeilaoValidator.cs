using FluentValidation;
using LeilaoOnline.Domain.Entities;

namespace LeilaoOnline.Domain.Validations
{
    public class LeilaoValidator : AbstractValidator<Leilao>
    {
        public LeilaoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.UsuarioResponsavelId)
                .NotEmpty()
                .WithMessage("Usuário responsavél é obrigatório");

            RuleFor(x => x.DataAbertura)
                .NotEmpty()
                .WithMessage("Data de abertura é obrigatória")
                .LessThanOrEqualTo(x => x.DataFinalizacao)
                .WithMessage("Data de abertura precisa ser inferior a data de finalização");

            RuleFor(x => x.DataFinalizacao)
                .NotEmpty()
                .WithMessage("Data de finalização é obrigatória")
                .GreaterThanOrEqualTo(x => x.DataAbertura)
                .WithMessage("Data de finalização precisa ser superior a data de abertura");

            RuleFor(x => x.ValorInicial)
                .NotEmpty()
                .WithMessage("Valor inicial é obrigatório");
        }
    }
}
