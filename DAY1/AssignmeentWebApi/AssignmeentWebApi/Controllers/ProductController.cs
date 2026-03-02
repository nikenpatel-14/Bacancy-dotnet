using AssignmeentWebApi.Repository.Model;
using AssignmeentWebApi.Services.Interfaces;
using AutoMapper;
using AssignmeentWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AssignmeentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        private readonly IMapper _mapper;


        public ProductController(IProductServices services,IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
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
        [Authorize(Roles = "admin,vendor")]
        public IActionResult AddProduct(ProductDTO product)
        {
            var added = _services.addProduct(product);

            return Created();
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "admin,vendor")]
        public IActionResult UpdateProduct (ProductDTO product,int id)
        {
            var result = _services.updateProduct(product, id);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _services.deleteProduct(id);
            return NoContent();
        }
    }
}
