using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTest>>> GetProductTest()
        {
          if (_context.ProductTest == null)
          {
              return NotFound();
          }
            return await _context.ProductTest.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTest>> GetProductTest(int id)
        {
          if (_context.ProductTest == null)
          {
              return NotFound();
          }
            var productTest = await _context.ProductTest.FindAsync(id);

            if (productTest == null)
            {
                return NotFound();
            }

            return productTest;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTest(int id, ProductTest productTest)
        {
            if (id != productTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(productTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTestExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTest>> PostProductTest(ProductTest productTest)
        {
          if (_context.ProductTest == null)
          {
              return Problem("Entity set 'MyDBContext.ProductTest'  is null.");
          }
            _context.ProductTest.Add(productTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTest", new { id = productTest.Id }, productTest);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTest(int id)
        {
            if (_context.ProductTest == null)
            {
                return NotFound();
            }
            var productTest = await _context.ProductTest.FindAsync(id);
            if (productTest == null)
            {
                return NotFound();
            }

            _context.ProductTest.Remove(productTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTestExists(int id)
        {
            return (_context.ProductTest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
