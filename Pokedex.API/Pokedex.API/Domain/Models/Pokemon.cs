using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Pokemon
    {
        public int IdPokemon { get; set; }

        public string Name_Custom { get; set; }
        public int Nivel { get; set; }

        public int Id_Trainer { get; set; }
        public Trainer Trainer { get; set; }

        public int Id_Pokedex { get; set; }
        public PokedexInfo PokedexInfo { get; set; }

    }
}
