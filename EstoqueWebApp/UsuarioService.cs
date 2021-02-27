using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EstoqueWebApp.Models;
using Microsoft.IdentityModel.Tokens;

namespace EstoqueWebApp
{
    public class UsuarioService
    {
        private readonly EstoqueDbContext _context;

        public UsuarioService(EstoqueDbContext context)
        {
            _context = context;
        }

        public Usuario Authenticate(string username, string password)
        {
            var user = _context.Usuarios.Where(x => x.NomeUsuario == username && x.Senha == password).FirstOrDefault();

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.NomeUsuario),
                    new Claim("Store", "adm")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Senha = "";

            return user;
        }
    }
}
