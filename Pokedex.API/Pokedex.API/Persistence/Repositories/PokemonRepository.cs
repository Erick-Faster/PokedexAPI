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
    public class PokemonRepository : BaseRepository, IPokemonRepository
    {
        public PokemonRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Pokemon>> ListAsync()
        {
            return await _context.Pokemons.Include(p => p.Trainer)
                                          .Include(p => p.PokedexInfo)
                                          .ToListAsync();
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _context.Pokemons.AddAsync(pokemon);
        }

        public async Task<Pokemon> FindByIdAsync(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        public void Update(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
        }

        public void Remove(Pokemon pokemon)
        {
            _context.Pokemons.Remove(pokemon);
        }
    }
}
