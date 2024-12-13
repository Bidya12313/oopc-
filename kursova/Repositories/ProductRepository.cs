public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products;
    }

    public Product GetProductByName(string name)
    {
        return _context.Products.Find(p => p.Name == name);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = GetProductByName(product.Name);
        if (existingProduct != null)
        {
            existingProduct.Quantity = product.Quantity;
        }
    }

      public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }
}
