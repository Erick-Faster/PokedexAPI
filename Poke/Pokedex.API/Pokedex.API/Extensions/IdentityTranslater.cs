using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Extensions
{
    public class IdentityTranslater : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresNonAlphanumeric()
            { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Senhas devem conter ao menos um caracter não alfanumérico." }; }


        //Daq da pra ir implementando mais traducoees
    }
}
