
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;

namespace Bar_Control_System_2025.Infrastructure.Files.ProductRepositoryInFile;

public class ProductReposirotyInFile : BaseRepositoryToFile<Product>
{
    public ProductReposirotyInFile(DataContext dataContext) : base(dataContext)
    {

    }

    protected override List<Product> GetRegister()
    {
        return dataContext.Products;
    }
}
