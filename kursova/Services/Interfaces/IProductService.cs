using System.Collections.Generic;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product GetProductByName(string name);
    void AddProduct(Product product);
}
