using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Domain.Services.Communication
{
    public class SaveTrainerResponse : BaseResponse
    {
        public Trainer Trainer { get; private set; }

        private SaveTrainerResponse(bool success, string message, Trainer trainer) : base(success, message)
        {
            Trainer = trainer;
        }

        public SaveTrainerResponse(Trainer trainer) : this(true, string.Empty, trainer)
        {

        }

        public SaveTrainerResponse(string message) : this(false, message, null)
        {

        }
    }
}
