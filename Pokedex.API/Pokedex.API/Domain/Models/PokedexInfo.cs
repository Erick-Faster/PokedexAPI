using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class PokedexInfo
    {
        public int IdPokedex { get; set; }

        public int Numero { get; set; }
        public string Name { get; set; }
        public string Type_1 { get; set; }
        public string Type_2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SP_Atk { get; set; }
        public int SP_Def { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public string Legendary { get; set; }

        public IList<Pokemon> Pokemons { get; set; } = new List<Pokemon>(); 
    }
}
