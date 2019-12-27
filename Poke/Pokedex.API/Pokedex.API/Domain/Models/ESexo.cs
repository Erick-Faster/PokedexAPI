using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Pokedex.API.Domain.Models
{
    public enum ESexo : byte
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2
    }
}
