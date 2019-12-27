using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Endereco : Entity
    {
        
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public Guid Id_Trainer { get; set; }
        public Trainer Trainer { get; set; }
        
    }
}
