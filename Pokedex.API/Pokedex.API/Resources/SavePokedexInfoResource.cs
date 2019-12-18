using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SavePokedexInfoResource
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(8)]
        public string Type_1 { get; set; }

        [Required]
        [MaxLength(8)]
        public string Type_2 { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int HP { get; set; }

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Defense { get; set; }

        [Required]
        public int SP_Atk { get; set; }

        [Required]
        public int SP_Def { get; set; }

        [Required]
        public int Speed { get; set; }

        [Required]
        public int Generation { get; set; }

        [Required]
        [MaxLength(5)]
        public string Legendary { get; set; }
    }
}
