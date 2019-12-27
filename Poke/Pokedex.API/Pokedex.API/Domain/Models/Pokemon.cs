using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Models
{
    public class Pokemon : Entity
    {
        public string Name_Custom { get; set; }
        public int Nivel { get; set; }

        public Guid Id_Trainer { get; set; }
        public Trainer Trainer { get; set; }

        public Guid Id_Pokedex { get; set; }
        public PokedexInfo PokedexInfo { get; set; }

    }
}
