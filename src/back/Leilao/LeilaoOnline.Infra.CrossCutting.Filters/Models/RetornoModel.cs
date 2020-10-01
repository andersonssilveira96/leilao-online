using System.Collections.Generic;

namespace LeilaoOnline.Infra.CrossCutting.Filters.Models
{
    public class RetornoModel
    {
        public RetornoModel()
        {
            Erros = new List<string>();
        }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public List<string> Erros { get; set; }
    }
}
