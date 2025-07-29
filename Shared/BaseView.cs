using Bar_Control_System_2025.Domain.Shared;
using Bar_Control_System_2025.Infrastructure.Memory.ProductModule;
using Bar_Control_System_2025.Infrastructure.Memory.WaiterModule;

namespace Bar_Control_System_2025.Shared;

public abstract class BaseView<TEntity> where TEntity : BaseEntity<TEntity>
{
    protected string entityName;
    protected BaseRepository<TEntity> repository;
    private string v;
    private ProductRepository repository1;
    private TableRepository tableRepository;
    private WaiterRepository repository2;

    protected BaseView(string entityName, BaseRepository<TEntity> repository)
    {
        this.entityName = entityName;
        this.repository = repository;
    }

    protected BaseView(string v, ProductRepository repository1)
    {
        this.v = v;
        this.repository1 = repository1;
    }

    protected BaseView(string v, TableRepository tableRepository)
    {
        this.v = v;
        this.tableRepository = tableRepository;
    }

    protected BaseView(string v, WaiterRepository repository2)
    {
        this.v = v;
        this.repository2 = repository2;
    }

    public virtual char ShowMenu()
    {
        ShowHeader();

        Console.WriteLine($"1 - Add {entityName}");
        Console.WriteLine($"2 - Edit {entityName}s");
        Console.WriteLine($"3 - Delete {entityName}");
        Console.WriteLine($"4 - View {entityName}");
        Console.WriteLine($"E - Exit");

        Console.WriteLine();

        Console.Write("Select an option: ");
        char selectedOption = Console.ReadLine().ToUpper()[0];

        return selectedOption;
    }

    public virtual void AddRegister()
    {
        ShowHeader();

        Console.WriteLine($"Register of {entityName}");

        Console.WriteLine();

        TEntity newRegister = GetData();

        string erros = newRegister.Validate();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nPress Enter to continue...");
            Console.ReadLine();

            AddRegister();

            return;
        }

       repository.AddRegister(newRegister);

        Console.WriteLine($"\n{entityName} registered with success!");
        Console.ReadLine();
    }

    public virtual void EditRegister()
    {
        ShowHeader();

        Console.WriteLine($"Edited register of the {entityName}");

        Console.WriteLine();

        ViewRegister(false);

        Console.Write("Type the ID you want to edit: ");
        int selectedID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        TEntity updatedRegister = GetData();

        repository.EditRegister(selectedID, updatedRegister);

        Console.WriteLine($"\n{entityName} updated!");
        Console.ReadLine();
    }

    public void DeleteRegister()
    {
        ShowHeader();

        Console.WriteLine($"Delete {entityName}");

        Console.WriteLine();

        ViewRegister(false);

        Console.Write("Type the ID you want to delete: ");
        int selectedID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repository.DeleteRegister(selectedID);

        Console.WriteLine($"\n{entityName} deleted!");
        Console.ReadLine();
    }

    public abstract void ViewRegister(bool showHeader);

    protected void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine($"Control of {entityName}s");
        Console.WriteLine();
    }

    protected void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine();
        Console.WriteLine(message);

        Console.ResetColor();
        Console.ReadLine();
    }
    protected abstract TEntity GetData();
}