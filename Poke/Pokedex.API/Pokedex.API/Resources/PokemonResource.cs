using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class PokemonResource
    {
        public Guid Id { get; set; }

        public string Name_Custom { get; set; }
        public int Nivel { get; set; }

        public TrainerResource Trainer { get; set; }
        public PokedexInfoResource PokedexInfo { get; set; }
    }
}
