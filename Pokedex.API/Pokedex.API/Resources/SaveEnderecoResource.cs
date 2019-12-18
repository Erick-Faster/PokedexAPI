using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class SaveEnderecoResource
    {
        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(20)]
        public string Pais { get; set; }

        [Required]
        public int Id_Trainer { get; set; }
    }
}
