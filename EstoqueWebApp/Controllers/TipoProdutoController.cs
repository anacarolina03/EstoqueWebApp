using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstoqueWebApp.Models;

namespace EstoqueWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly EstoqueDbContext _context;

        public TipoProdutoController(EstoqueDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoProduto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProduto>>> GetTipoProdutos()
        {
            return await _context.TipoProdutos.ToListAsync();
        }

        // GET: api/TipoProduto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProduto>> GetTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);

            if (tipoProduto == null)
            {
                return NotFound();
            }

            return tipoProduto;
        }

        // PUT: api/TipoProduto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProduto(int id, TipoProduto tipoProduto)
        {
            if (id != tipoProduto.CodTipoProduto)
            {
                return BadRequest();
            }

            _context.Entry(tipoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoProduto
        [HttpPost]
        public async Task<ActionResult<TipoProduto>> PostTipoProduto(TipoProduto tipoProduto)
        {
            _context.TipoProdutos.Add(tipoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoProduto", new { id = tipoProduto.CodTipoProduto }, tipoProduto);
        }

        // DELETE: api/TipoProduto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.CodTipoProduto == id);
        }
    }
}