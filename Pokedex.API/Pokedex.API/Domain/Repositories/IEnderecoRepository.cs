using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> ListAsync();
        Task AddAsync(Endereco endereco);
        Task<Endereco> FindByIdAsync(int id);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);
    }
}
