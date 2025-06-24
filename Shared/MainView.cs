


using Bar_Control_System_2025.ConsoleApp.Shared;

public class MainView
{
    private char userOption;

    private TableRepository tableRepository;
    private TableView tableView;

    public MainView()
    {
        tableRepository = new TableRepository();
        tableView = new TableView(tableRepository);
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
            return null;

        if (userOption == '3')
            return null;

        if (userOption == '4')
            return null;

        return null;
    }
}

