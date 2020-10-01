using FluentValidation.Results;
using System;
using System.ComponentModel;

namespace LeilaoOnline.Application.Models
{
    public class LeilaoModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorInicial { get; set; }
        public bool Usado { get; set; }
        public bool Encerrado { get; set; }
        public Guid? UsuarioResponsavelId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public virtual ValidationResult Valido { get; set; }
    }
}
