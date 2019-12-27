using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveTrainerResource
    {
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Liga { get; set; }
    }
}
