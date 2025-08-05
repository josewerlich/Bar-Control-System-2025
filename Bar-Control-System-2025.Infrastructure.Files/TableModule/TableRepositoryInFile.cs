
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;

namespace Bar_Control_System_2025.Infrastructure.Files.TableModule
{
    public class TableRepositoryInFile : BaseRepositoryToFile<Table>
    {
        public TableRepositoryInFile(DataContext dataContext) : base(dataContext)
        {

        }

        protected override List<Table> GetRegister()
        {
            return dataContext.Tables;
        }
    }
}
