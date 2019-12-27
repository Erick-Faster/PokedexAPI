using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Resources
{
    public class LoginUserResource
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RegisterUserResource
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }

    public class UserTokenResource
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimResource> Claims { get; set; }
    }

    public class LoginResponseResource
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenResource UserToken { get; set; }
    }

    public class ClaimResource
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
