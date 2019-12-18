using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SavePokedexInfoResponse : BaseResponse
    {
        public PokedexInfo PokedexInfo { get; protected set; }
        
        private SavePokedexInfoResponse(bool success, string message, PokedexInfo pokedexInfo) : base(success, message)
        {
            PokedexInfo = pokedexInfo;
        }

        public SavePokedexInfoResponse(PokedexInfo pokedexInfo) : this(true, string.Empty, pokedexInfo)
        {

        }

        public SavePokedexInfoResponse(string message) : this(false, message, null)
        {

        }

    }
}
