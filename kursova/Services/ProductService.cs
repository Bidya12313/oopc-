public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product GetProductByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Назва продукту не може бути порожньою.");
        }

        return _productRepository.GetProductByName(name);
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentException("Продукт не може бути null.");
        }

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException("Назва продукту не може бути порожньою.");
        }

        if (product.Price <= 0)
        {
            throw new ArgumentException("Ціна продукту повинна бути більшою за нуль.");
        }

        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentException("Продукт не може бути null.");
        }

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException("Назва продукту не може бути порожньою.");
        }

        if (product.Price <= 0)
        {
            throw new ArgumentException("Ціна продукту повинна бути більшою за нуль.");
        }

        _productRepository.UpdateProduct(product);
    }
}
