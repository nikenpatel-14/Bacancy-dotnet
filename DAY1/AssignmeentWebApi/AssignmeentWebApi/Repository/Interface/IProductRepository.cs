using AssignmeentWebApi.Repository.Model;

namespace AssignmeentWebApi.Repository.Interfaces
{
    public interface IProductRepository
    {

        List<Product> getAllProducts();
        Product getProductById(int id);
        List<Product> getProductsByCategory(string categoryName);

        Product addProduct(Product product);

        Product updateProduct(Product product , int id);

        bool deleteProduct(int id);
    }
}
