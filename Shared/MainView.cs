using Bar_Control_System_2025.AccountModule;
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Memory.AccountModule;
using Bar_Control_System_2025.Infrastructure.Memory.ProductModule;
using Bar_Control_System_2025.Infrastructure.Memory.WaiterModule;
using Bar_Control_System_2025.ProductsModule;
using Bar_Control_System_2025.Shared;
using Bar_Control_System_2025.WaiterModule;

public class MainView
{
    private char userOption;

    private TableRepository tableRepository;
    private TableView tableView;

    private WaiterRepository waiterRepository;
    private WaiterView waiterView;

    private ProductRepository productRepository;
    private ProductView productView;

    private AccountRepository accountRepository;
    private AccountView accountView;

    public MainView()
    {
        tableRepository = new TableRepository();
        waiterRepository = new WaiterRepository();
        productRepository = new ProductRepository();   
        accountRepository = new AccountRepository();

        tableView = new TableView(tableRepository);
        waiterView = new WaiterView(waiterRepository);
        productView = new ProductView(productRepository);

        accountView = new AccountView(
            accountRepository,
            productRepository,
            tableRepository,
            waiterRepository
        );
        //Test Data 
        Table table = new Table(1, 3);
        Waiter waiter = new Waiter("John", "555-55-5555");
        Product product = new Product("Blue Moon 12oz", 4.50m);

        tableRepository.AddRegister(table);
        waiterRepository.AddRegister(waiter);
        productRepository.AddRegister(product);
    }

    public void ShowMainMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|              Bar Control              |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Table Control");
        Console.WriteLine("2 - Waiter Control");
        Console.WriteLine("3 - Products Control");
        Console.WriteLine("4 - Check Control");
        Console.WriteLine("E - Exit");

        Console.WriteLine();

        Console.Write("Type an option: ");
        userOption = Console.ReadLine()![0];
    }

    public IMainView GetView()
    {
        if (userOption == '1')
            return tableView;

        if (userOption == '2')
            return waiterView;

        if (userOption == '3')
            return productView;

        if (userOption == '4')
            return accountView;

        return null;
    }
}

