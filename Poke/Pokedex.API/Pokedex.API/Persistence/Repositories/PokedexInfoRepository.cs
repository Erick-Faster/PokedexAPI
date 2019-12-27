using Microsoft.EntityFrameworkCore;
using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Persistence.Repositories
{
    public class PokedexInfoRepository : BaseRepository, IPokedexInfoRepository
    {
        public PokedexInfoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<PokedexInfo>> ListAsync()
        {
            return await _context.PokedexInfos.ToListAsync();
        }

        public async Task AddAsync(PokedexInfo pokedexInfo)
        {
            await _context.PokedexInfos.AddAsync(pokedexInfo);
        }

        public async Task<PokedexInfo> FindByIdAsync(Guid id)
        {
            return await _context.PokedexInfos.FindAsync(id);
        }

        public void Update(PokedexInfo pokedexInfo)
        {
            _context.PokedexInfos.Update(pokedexInfo);
        }

        public void Remove(PokedexInfo pokedexInfo)
        {
            _context.PokedexInfos.Remove(pokedexInfo);
        }
    }
}
