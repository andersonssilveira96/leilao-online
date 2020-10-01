using System;
using System.Collections.Generic;

namespace LeilaoOnline.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Leilao> Leilao { get; set; }
    }
}
