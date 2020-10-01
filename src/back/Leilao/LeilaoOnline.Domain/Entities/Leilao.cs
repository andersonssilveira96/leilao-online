using FluentValidation.Results;
using LeilaoOnline.Domain.Validations;
using System;

namespace LeilaoOnline.Domain.Entities
{
    public class Leilao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorInicial { get; set; }
        public bool Usado { get; set; }
        public bool Encerrado { get; set; }
        public Guid UsuarioResponsavelId { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public virtual Usuario Usuario { get; set; }        
        public virtual ValidationResult Valido { get; set; }
        public ValidationResult Validar()
        {         
            Valido = new LeilaoValidator().Validate(this);
            return Valido;
        }
    }
}
