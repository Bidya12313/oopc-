using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product GetProductByName(string name);
    void UpdateProduct(Product product);
    void AddProduct(Product product);
}