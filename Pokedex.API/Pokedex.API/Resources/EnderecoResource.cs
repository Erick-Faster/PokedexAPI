using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class EnderecoResource
    {
        public int IdEndereco { get; set; }

        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public TrainerResource Trainer { get; set; } 

    }
}
