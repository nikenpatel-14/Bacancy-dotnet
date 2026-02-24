using AssignmeentWebApi.Repository.Model;
using AssignmeentWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssignmeentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_services.getAllProducts());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_services.getProductById(id));
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProductByCategory(string category)
        {
            return Ok(_services.getProductsByCategory(category));
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var added = _services.addProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = added.Id }, added);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _services.deleteProduct(id);
            return NoContent();
        }
    }
}
