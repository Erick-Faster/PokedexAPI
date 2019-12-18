using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public int Id_Trainer { get; set; }
        public Trainer Trainer { get; set; }
        
    }
}
