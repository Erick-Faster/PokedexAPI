using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SaveEnderecoResponse : BaseResponse
    {
        public Endereco Endereco { get; protected set; }

        private SaveEnderecoResponse(bool success, string message, Endereco endereco) : base(success, message)
        {
            Endereco = endereco;
        }

        public SaveEnderecoResponse(Endereco endereco) : this(true, string.Empty, endereco)
        {
            
        }

        public SaveEnderecoResponse(string message) : this(false, message, null)
        {

        }


    }
}
