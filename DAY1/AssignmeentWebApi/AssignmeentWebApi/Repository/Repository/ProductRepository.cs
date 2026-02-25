using AssignmeentWebApi.Data;
using AssignmeentWebApi.Repository.Interfaces;
using AssignmeentWebApi.Repository.Model;

namespace AssignmeentWebApi.Repository.Repository
{
    public class ProductRepository :IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Product> getAllProducts()
        {
            return _dbContext.products.ToList();
        }
        public Product getProductById(int id)
        {
            return _dbContext.products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> getProductsByCategory(string categoryName)
            {
               return _dbContext.products.Where(x=>x.Category == categoryName).ToList();
            }

        public Product addProduct(Product product)
        {
            _dbContext.products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product updateProduct(Product product ,int id)
        {
            var currProduct = _dbContext.products.Find(id);

            currProduct.Name = product.Name;
            currProduct.Price = product.Price;
            currProduct.Category = product.Category;
            _dbContext.SaveChanges();
            return currProduct;


        }

        public bool deleteProduct(int id)
        {
           var product = _dbContext.products.FirstOrDefault(x=>x.Id == id);
            _dbContext.products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
