using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SavePokemonResource
    {
        [Required]
        [MaxLength(25)]
        public string Name_Custom { get; set; }

        [Required]
        public int Nivel { get; set; }

        public int Id_Trainer { get; set; }

        [Required]
        public int Id_Pokedex { get; set; }
    }
}
