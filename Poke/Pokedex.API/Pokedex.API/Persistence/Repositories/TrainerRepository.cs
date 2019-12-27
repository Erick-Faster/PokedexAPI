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
    public class TrainerRepository : BaseRepository, ITrainerRepository
    {
        public TrainerRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Trainer>> ListAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task AddAsync(Trainer trainer)
        {
            await _context.Trainers.AddAsync(trainer);
        }

        public async Task<Trainer> FindByIdAsync(Guid id)
        {
            return await _context.Trainers.FindAsync(id);
        }

        public void Update(Trainer trainer)
        {
            _context.Trainers.Update(trainer);
        }

        public void Remove(Trainer trainer)
        {
            _context.Trainers.Remove(trainer);
        }
    }
}
