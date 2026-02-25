
using AssignmeentWebApi.DTOs;
using AssignmeentWebApi.Repository.Interfaces;
using AssignmeentWebApi.Repository.Model;
using AssignmeentWebApi.Services.Interfaces;
using AutoMapper;

namespace AssignmeentWebApi.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductServices(IProductRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public List<ProductDTO> getAllProducts()
        {
            var product = _repository.getAllProducts();
            return _mapper.Map<List<ProductDTO>>(product);
        }
        public ProductDTO getProductById(int id)
        {
            var product = _repository.getProductById(id);
            return _mapper.Map<ProductDTO>(product) ;
        }
        public List<ProductDTO> getProductsByCategory(string categoryName)
        {
            var product = _repository.getProductsByCategory(categoryName);
            return _mapper.Map<List<ProductDTO>>(product);
        }

        public ProductDTO addProduct(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var result = _repository.addProduct(product);
            return _mapper.Map<ProductDTO>(result);
        }

        public ProductDTO updateProduct(ProductDTO dto , int id)
        {
            var product = _mapper.Map<Product>(dto);
            var result = _repository.updateProduct(product ,id);
            return _mapper.Map<ProductDTO>(result);

        }
        public bool deleteProduct(int id)
        {
            return _repository.deleteProduct(id);
        }
    }
}
