using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalServerItems.Models;
using DigitalServerItems.Repositories;

namespace DigitalServerItems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        readonly IGeneralRepository _productRepository;

        public ProductsController(IGeneralRepository productRepository)
        {
            _productRepository = productRepository;
            _context = _productRepository.ApiContext;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/filter
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFiltered([FromQuery] FilteredData filteredData)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products
              .OrderBy(o => o.Id)
              .Where(s =>
                (filteredData.NameLike == null || s.Name.Contains(filteredData.NameLike)) &&
                (filteredData.ProductType == null || s.ProductType == filteredData.ProductType) &&
                (filteredData.FromDate == null || s.CreatedDate >= filteredData.FromDate) &&
                (filteredData.ToDate == null || s.CreatedDate <= filteredData.ToDate) &&
                (filteredData.Cities == null || filteredData.Cities.Length == 0 || filteredData.Cities.Contains(s.ManufacturerCityId))
            );

            return await products
              .Skip((filteredData.PageNumber - 1) * filteredData.PageSize)
              .Take(filteredData.PageSize)
              .ToListAsync();
        }

        [HttpGet("filterSize")]
        public async Task<ActionResult<int>> GetProductsFilteredSize([FromQuery] FilteredData filteredData)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products
              .Where(s =>
                (filteredData.NameLike == null || s.Name.Contains(filteredData.NameLike)) &&
                (filteredData.ProductType == null || s.ProductType == filteredData.ProductType) &&
                (filteredData.FromDate == null || s.CreatedDate >= filteredData.FromDate) &&
                (filteredData.ToDate == null || s.CreatedDate <= filteredData.ToDate) &&
                (filteredData.Cities == null || filteredData.Cities.Length == 0 || filteredData.Cities.Contains(s.ManufacturerCityId))
            );

            return await products.CountAsync();
        }

        //var products = await _context.Products.ToListAsync();


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApiContext.Products'  is null.");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
