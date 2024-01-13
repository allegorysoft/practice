using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Allegory.StockManagement.Products;

public class ProductManager : DomainService
{
    public IProductRepository ProductRepository { get; }

    public ProductManager(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }


    public async Task<Product> CreateAsync(string code)
    {
        var existingCustomer = await ProductRepository.FindByCodeAsync(code);

        if (existingCustomer != null)
        {
            throw new CodeAlreadyExistsException(typeof(Product), code);
        }

        return new Product(GuidGenerator.Create(), code);
    }

    public async Task ChangeCodeAsync(Product product, string inputCode)
    {
        if (product.Code == inputCode)
        {
            return;
        }

        var existingCustomer = await ProductRepository.FindByCodeAsync(inputCode);

        if (existingCustomer != null && existingCustomer.Id != product.Id)
        {
            throw new CodeAlreadyExistsException(typeof(Product), inputCode);
        }

        product.SetCode(inputCode);
    }
}