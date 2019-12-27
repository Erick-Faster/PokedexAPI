using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SavePokemonResponse : BaseResponse
    {
        public Pokemon Pokemon { get; protected set; }

        private SavePokemonResponse(bool success, string message, Pokemon pokemon) : base(success, message)
        {
            Pokemon = pokemon;
        }

        public SavePokemonResponse(Pokemon pokemon) : this(true, string.Empty, pokemon)
        {

        }

        public SavePokemonResponse(string message) : this(false, message, null)
        {

        }
    }
}
