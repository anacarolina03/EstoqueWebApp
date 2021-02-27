using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EstoqueWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EstoqueWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacaoController : ControllerBase
    {
        private readonly EstoqueDbContext _context;

        public AutenticacaoController(EstoqueDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public object PostUsuario(Usuario usuario)
        {
            var service = new UsuarioService(_context);
            var user = service.Authenticate(usuario.NomeUsuario, usuario.Senha);

            var token = TokenService.GenerateToken(user);

            return new { token };
        }
    }
}
