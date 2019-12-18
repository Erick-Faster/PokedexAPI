using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> ListAsync();
        Task AddAsync(Trainer trainer);
        Task<Trainer> FindByIdAsync(int id);
        void Update(Trainer trainer);
        void Remove(Trainer trainer);
    }
}
