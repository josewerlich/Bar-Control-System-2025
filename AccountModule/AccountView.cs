using Bar_Control_System_2025.ConsoleApp.Shared;
using Bar_Control_System_2025.ProductsModule;
using Bar_Control_System_2025.WaiterModule;

namespace Bar_Control_System_2025.AccountModule;

public class AccountView : IMainView
{
    private AccountRepository accountRepository;
    private ProductRepository productRepository;
    private TableRepository tableRepository;
    private WaiterRepository waiterRepository;

    public AccountView(
        AccountRepository accountRepository,
        ProductRepository productRepository,
        TableRepository tableRepository,
        WaiterRepository waiterRepository
    )
    {
        this.accountRepository = accountRepository;
        this.productRepository = productRepository;
        this.tableRepository = tableRepository;
        this.waiterRepository = waiterRepository;
    }

    public char ShowMenu()
    {
        ShowHeader();

        Console.WriteLine($"1 - Add Account");
        Console.WriteLine($"2 - Manage Accounts");
        Console.WriteLine($"3 - View Accounts");
        Console.WriteLine($"E - Exit");

        Console.WriteLine();

        Console.Write("Type a valid option: ");
        char userOption = Console.ReadLine().ToUpper()[0];

        return userOption;
    }

    public void ShowOrderManagementView()
    {
        ShowHeader();

        Console.WriteLine("A");

        Console.WriteLine();

        ViewRegister(false);

        Console.Write("Type the ID of the account you want to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Account selectedAccount = accountRepository.SelectAccountViaID(id);

        Console.WriteLine();

        while (true)
        {
            ViewAccountOrders(selectedAccount);

            Console.WriteLine();

            Console.WriteLine($"1 - Add new Order");
            Console.WriteLine($"2 - Remove Order");
            Console.WriteLine($"E - Exit");

            Console.WriteLine();

            Console.Write("Type a valid option: ");
            char userOption = Console.ReadLine()[0];

            if (char.ToUpper(userOption) == 'E')
                break;

            switch (userOption)
            {
                case '1': AddOrder(selectedAccount); break;

                case '2': RemoveOrder(selectedAccount); break;
            }
        }
    }

    public void AddRegister()
    {
        ShowHeader();

        Console.WriteLine("Account Opening");

        Console.WriteLine();

        Account newAccount = GetData();

        string errors = newAccount.Validate();

        if (errors.Length > 0)
        {
            
            ShowMessage(
                string.Concat(errors, "\nPress ENTER to continue..."),
                ConsoleColor.Red
                
            );
            

            AddRegister();

            return;
        }

        accountRepository.Register(newAccount);

        ShowMessage($"Account Open!", ConsoleColor.Yellow);
    }

    public void EditRegister()
    {
    }

    public void DeleteRegister()
    {
    }

    public void ViewRegister(bool showHeader)
    {
        if (showHeader)
            ShowHeader();

        Console.WriteLine("Accounts View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
            "Id", "Customer", "Table", "Waiter", "Opening", "Status"
        );

        Account[] accounts = accountRepository.SelectAccount();

        for (int i = 0; i < accounts.Length; i++)
        {
            Account a = accounts[i];

            if (a == null)
                continue;

            string accountStatus = a.StillOpen ? "Open" : "Close";

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -14} | {3, -20} | {4, -20} | {5, -20}",
                a.id, a.Customer, a.Table.TableNumber, a.Waiter.Name, a.DateTimeOpening.ToShortDateString(), accountStatus
            );
        }

        ShowMessage("Type ENTER to continue...", ConsoleColor.DarkYellow);
    }

    private void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|             Bar Control               |");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
    }

    private void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        Console.WriteLine();
        Console.WriteLine(message);

        Console.ResetColor();

        Console.ReadLine();
    }

    private Account GetData()
    {
        string customer = string.Empty;

        while (string.IsNullOrWhiteSpace(customer))
        {
            Console.Write("Type the name of the customer: ");
            customer = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(customer))
            {
                ShowMessage("The name is required", ConsoleColor.DarkMagenta);
                Console.Clear();
            }
        }

        ViewTables();

        Console.WriteLine();

        Console.Write("Type the ID of the table to use: ");
        int tableId = Convert.ToInt32(Console.ReadLine());

        Table selectedTable = tableRepository.SelectRegisterID(tableId);

        WaitersView();

        Console.WriteLine();

        Console.Write("Type the ID of the waiter for this table: ");
        int waiterId = Convert.ToInt32(Console.ReadLine());

        Waiter selectedWaiter = waiterRepository.SelectRegisterID(waiterId);

        return new Account(customer, selectedTable, selectedWaiter);
    }

    private void ViewTables()
    {
        Console.WriteLine();

        Console.WriteLine("Tables View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
            "Id", "Number", "Size", "Status"
        );

        Table[] tables = tableRepository.SelectRegister();

        for (int i = 0; i < tables.Length; i++)
        {
            Table t = tables[i];

            if (t == null)
                continue;

            string tableStatus = t.TableOccupied ? "Occupied" : "Available";

            Console.WriteLine(
              "{0, -10} | {1, -20} | {2, -20} | {3, -30}",
                t.id, t.TableNumber, t.TableSize, tableStatus
            );
        }
    }

    private void WaitersView()
    {
        Console.WriteLine();

        Console.WriteLine("Waiters View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "CPF");

        Waiter[] waiters = waiterRepository.SelectRegister();

        for (int i = 0; i < waiters.Length; i++)
        {
            Waiter w = waiters[i];

            if (w == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", w.id, w.Name, w.SSN);
        }
    }

    private void ViewAccountOrders(Account account)
    {
        Console.WriteLine("Order View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -14} | {3, -20}",
            "ID", "Product", "Quantity", "Partial Cost"
        );

        Order[] order = account.Order;

        for (int i = 0; i < order.Length; i++)
        {
            Order o = order[i];

            if (o == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -14} | {3, -20}",
                o.id, o.Product.Name, o.Quantity, o.TotalCostPartial().ToString("C2")
            );
        }
    }

    private void ProductsView()
    {
        Console.WriteLine("Products View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "Valor");

        Product[] product = productRepository.SelectRegister();

        for (int i = 0; i < product.Length; i++)
        {
            Product p = product[i];

            if (p == null)
                continue;

            Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", p.id, p.Name, p.Cost.ToString("C2"));
        }
    }

    private void AddOrder(Account selectedAccount)
    {
        while (true)
        {
            ShowHeader();

            Console.WriteLine("Add Products to the Order");

            Console.WriteLine();

            ProductsView();

            Console.WriteLine();

            Console.Write("Type the ID of the product you want to add: ");
            int idProduct = Convert.ToInt32(Console.ReadLine());

            Product selectedProduct = productRepository.SelectRegisterID(idProduct);

            Console.Write("Type the quantity of the product: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Order order = selectedAccount.RegisterOrder(selectedProduct, quantity);

            ShowMessage($"Order \"{order.ToString()}\" added!", ConsoleColor.Green);

            Console.Write("Add a new product (Y/N)? ");
            char userOprion = Console.ReadLine()[0];

            if (char.ToUpper(userOprion) == 'N')
                break;
        }
    }

    private void RemoveOrder(Account selectedAccount)
    {
        while (true)
        {
            ShowHeader();

            Console.WriteLine("Account Removal");

            Console.WriteLine();

            ViewAccountOrders(selectedAccount);

            Console.WriteLine();

            Console.Write("Type the ID you want to remove: ");
            int idOrder = Convert.ToInt32(Console.ReadLine());

            selectedAccount.RemoveOrder(idOrder);

            ShowMessage($"Order Removed!", ConsoleColor.Green);

            Console.Write("Do you want to remove another order? (Y/N)? ");
            char opcaoEscolhida = Console.ReadLine()[0];

            if (char.ToUpper(opcaoEscolhida) == 'N')
                break;
        }
    }
}
