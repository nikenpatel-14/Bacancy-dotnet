
using AssignmeentWebApi.Repository.Model;

namespace AssignmeentWebApi.Services.Interfaces
{
    public interface IProductServices
    {

        List<Product> getAllProducts();
        Product getProductById(int id);
        List<Product> getProductsByCategory(string categoryName);

        Product addProduct(Product product);

        bool deleteProduct(int id);

    }
}
