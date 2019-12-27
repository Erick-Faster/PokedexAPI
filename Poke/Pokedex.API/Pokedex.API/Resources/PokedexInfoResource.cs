using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class PokedexInfoResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type_1 { get; set; }
    }
}
