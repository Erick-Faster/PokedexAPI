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
        Task<SaveTrainerResponse> GetById(Guid id);
        Task<SaveTrainerResponse> SaveAsync(Trainer trainer);
        Task<SaveTrainerResponse> UpdateAsync(Guid id, Trainer trainer);
        Task<SaveTrainerResponse> DeleteAsync(Guid id);

        
    }
}
