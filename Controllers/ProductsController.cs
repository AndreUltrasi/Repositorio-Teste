using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;

        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {

            var response = await _repository.GetProductsAsync();

            return Ok(response);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            if (id < 0)
            {
                throw new Exception("Não é permitido id menor que zero");
            }
            var response = await _repository.GetProductsByIdAsync(id);

            return Ok(response);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Products>> PutProducts(int id, Products products)
        {
            var response = await _repository.UpdateProductsAsync(products, id);

            return Ok(response);

        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            var response = await _repository.CreateProductsAsync(products);

            return Ok(response);
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var response = await _repository.DeleteProductsAsync(id);

            return Ok(response);

        }

    }
}
