
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;

namespace Bar_Control_System_2025.Infrastructure.Files.WaiterRepositoryInFile;

public class WaiterRepositoryInFile : BaseRepositoryToFile<Waiter>
{
    public WaiterRepositoryInFile(DataContext dataContext) : base(dataContext)
    {

    }

    protected override List<Waiter> GetRegister()
    { 

        return dataContext.Waiters;
    }
}
