using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Trainer
    {
        public int IdTrainer { get; set; }

        public string Nome { get; set; }
        //public ESexo Sexo { get; set; }
        public string Email { get; set; }
        public string Liga { get; set; }

        public IList<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public IList<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
    }
}
