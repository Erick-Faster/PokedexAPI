using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IPokedexInfoRepository
    {
        Task<IEnumerable<PokedexInfo>> ListAsync();
        Task AddAsync(PokedexInfo pokedexInfo);
        Task<PokedexInfo> FindByIdAsync(Guid id);
        void Update(PokedexInfo pokedexInfo);
        void Remove(PokedexInfo pokedexInfo);
    }
}
