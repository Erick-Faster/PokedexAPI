using Pokedex.API.Domain.Models;
using Pokedex.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> ListAsync();
        Task<SaveEnderecoResponse> SaveAsync(Endereco endereco);
        Task<SaveEnderecoResponse> UpdateASync(int id, Endereco endereco);
        Task<SaveEnderecoResponse> DeleteAsync(int id);
        
    }
}
