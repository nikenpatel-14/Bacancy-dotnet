
using AssignmeentWebApi.Repository.Interfaces;
using AssignmeentWebApi.Repository.Model;
using AssignmeentWebApi.Services.Interfaces;

namespace AssignmeentWebApi.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }
        public List<Product> getAllProducts()
        {
            return _repository.getAllProducts();
        }
        public Product getProductById(int id)
        {
            return _repository.getProductById(id);
        }
        public List<Product> getProductsByCategory(string categoryName)
        {
            return _repository.getProductsByCategory(categoryName);
        }

        public Product addProduct(Product product)
        {
            return _repository.addProduct(product);
        }

        public bool deleteProduct(int id)
        {
            return _repository.deleteProduct(id);
        }
    }
}
