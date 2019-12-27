using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> ListAsync();
        Task AddAsync(Pokemon pokemon);
        Task<Pokemon> FindByIdAsync(Guid id);
        void Update(Pokemon pokemon);
        void Remove(Pokemon pokemon);
    }
}
