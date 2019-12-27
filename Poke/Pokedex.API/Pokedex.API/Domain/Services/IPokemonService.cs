using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> ListAsync();
        Task<SavePokemonResponse> GetById(Guid id);
        Task<SavePokemonResponse> SaveAsync(Pokemon pokemon);
        Task<SavePokemonResponse> UpdateAsync(Guid id, Pokemon pokemon);
        Task<SavePokemonResponse> DeleteAsync(Guid id);
    }
}
