
using AssignmeentWebApi.DTOs;
using AssignmeentWebApi.Repository.Model;

namespace AssignmeentWebApi.Services.Interfaces
{
    public interface IProductServices
    {

        List<ProductDTO> getAllProducts();
        ProductDTO getProductById(int id);
        List<ProductDTO> getProductsByCategory(string categoryName);

        ProductDTO addProduct(ProductDTO product);

        ProductDTO updateProduct(ProductDTO product,int id);

        bool deleteProduct(int id);

    }
}
