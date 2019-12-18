using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface IPokedexInfoService
    {
        Task<IEnumerable<PokedexInfo>> ListAsync();
        Task<SavePokedexInfoResponse> SaveAsync(PokedexInfo pokedexInfo);
        Task<SavePokedexInfoResponse> UpdateAsync(int id, PokedexInfo pokedexInfo);
        Task<SavePokedexInfoResponse> DeleteAsync(int id);
    }
}
