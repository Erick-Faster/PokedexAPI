using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<Trainer>> ListAsync();
        Task<SaveTrainerResponse> SaveAsync(Trainer trainer);
        Task<SaveTrainerResponse> UpdateAsync(int id, Trainer trainer);
        Task<SaveTrainerResponse> DeleteAsync(int id);

        
    }
}
