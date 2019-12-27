using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class TrainerResource
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //public string Sexo { get; set; }
        public string Email { get; set; }
        public string Liga { get; set; }

    }
}
