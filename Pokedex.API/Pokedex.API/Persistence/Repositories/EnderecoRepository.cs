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
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Endereco>> ListAsync()
        {
            return await _context.Enderecos.Include(p => p.Trainer)
                                           .ToListAsync();
        }

        public async Task AddAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
        }

        public async Task<Endereco> FindByIdAsync(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public void Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
        }

        public void Delete(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
        }
    }
}
