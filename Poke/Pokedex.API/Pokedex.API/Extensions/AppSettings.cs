using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; } // Chave de criptografia
        public int ExpiracaoHoras { get; set; } //Horas ate perder validade
        public string Emissor { get; set; } // Emite
        public string ValidoEm { get; set; } //Quais URL o token eh valido
    }
}
