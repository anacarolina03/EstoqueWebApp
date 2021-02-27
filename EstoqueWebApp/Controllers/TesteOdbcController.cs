using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TesteOdbcController : ControllerBase
    {
        // GET: <TesteOdbcController>
        [HttpGet]
        public object Get()
        {
            return new { teste = TesteConexaoOdbc.Teste() };
        }
    }
}
