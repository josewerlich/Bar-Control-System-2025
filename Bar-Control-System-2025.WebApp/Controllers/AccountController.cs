using Bar_Control_System_2025.Domain.AccountModule;
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Files.AccountModule;
using Bar_Control_System_2025.Infrastructure.Files.ProductRepositoryInFile;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.WaiterRepositoryInFile;
using Bar_Control_System_2025.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Bar_Control_System_2025.WebApp.Controllers;

public class AccountController : Controller
{
    private readonly DataContext dataContext;
    private readonly AccountRepositoryInFile accountRepository;
    private readonly TableRepositoryInFile tableRepository;
    private readonly WaiterRepositoryInFile waiterRepository;
    private readonly ProductReposirotyInFile productReposiroty;

    public AccountController()
    {
        dataContext = new DataContext(true);

        accountRepository = new AccountRepositoryInFile(dataContext);
        tableRepository = new TableRepositoryInFile(dataContext);
        waiterRepository = new WaiterRepositoryInFile(dataContext);
        productReposiroty = new ProductReposirotyInFile(dataContext);
    }


    [HttpGet]
    public IActionResult Index(string? status)
    {
        List<Account> accounts;

        switch (status)
        {
            case "open":
                accounts = accountRepository.SelectOpenAccounts();
                break;
            case "closed":
                accounts = accountRepository.SelectClosedAccounts();
                break;
            default:
                accounts = accountRepository.SelectRegister();
                break;
        }

        ViewAccountViewModel viewAccountViewModel = new ViewAccountViewModel(accounts);

        return View(viewAccountViewModel);
    }

    [HttpGet]
    public IActionResult Open()
    {
        List<Table> tables = tableRepository.SelectRegister();
        List<Waiter> waiters = waiterRepository.SelectRegister();

        OpenAccountViewModel openAccountViewModel = new OpenAccountViewModel(tables, waiters);

        return View(openAccountViewModel);
    }

    [HttpPost]
    public IActionResult Open(OpenAccountViewModel openAccountViewModel)
    {
        if (!ModelState.IsValid)
            return View(openAccountViewModel);

        Table selectedTable = tableRepository.SelectRegisterID(openAccountViewModel.TableId);
        Waiter selectedWaiter = waiterRepository.SelectRegisterID(openAccountViewModel.WaiterId);

        Account account = new Account(
            openAccountViewModel.Customer,
            selectedTable,
            selectedWaiter
        );

        accountRepository.AddRegister(account);

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Close(int id)
    {
        Account accountSelected = accountRepository.SelectRegisterID(id);

        CloseAccountViewModel closeAccountViewModel = new CloseAccountViewModel(
            accountSelected.Id,
            accountSelected.Customer,
            accountSelected.Table.TableNumber,
            accountSelected.Waiter.Name,
            accountSelected.CalculateTotalCost(),
            accountSelected.Orders
        );

        return View(closeAccountViewModel);
    }

    [HttpPost]
    public IActionResult ConfirmeClosing(int id)
    {
        Account selectedAccount = accountRepository.SelectRegisterID(id);

        selectedAccount.Close();

        dataContext.Save();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult ManageOrders(int id)
    {
        Account selectedAccount = accountRepository.SelectRegisterID(id);

        List<Product> products = productReposiroty.SelectRegister();

        ManageOrdersViewModel manageOrdersViewModel = new ManageOrdersViewModel(
            selectedAccount,
            products
        );

        return View(manageOrdersViewModel);
    }

    [HttpPost]
    public IActionResult AddOrder(int id, AddOrderViewModel addOrderViewModel)
    {
        Account selectedAccount = accountRepository.SelectRegisterID(id);

        Product selectedProduct = productReposiroty.SelectRegisterID(addOrderViewModel.IdProduct);

        Order order = selectedAccount.RegisterOrder(selectedProduct, addOrderViewModel.Quantity);

        dataContext.Save();

        List<Product> products = productReposiroty.SelectRegister();

        ManageOrdersViewModel manageOrdersViewModel = new ManageOrdersViewModel(
            selectedAccount,
            products
        );

        return View(nameof(ManageOrders), manageOrdersViewModel);
    }

    [HttpPost]
    public IActionResult RemoveOrder(int id, int idOrder)
    {
        Account selectedAccount = accountRepository.SelectRegisterID(id);

        selectedAccount.RemoveOrder(idOrder);

        dataContext.Save();

        List<Product> products = productReposiroty.SelectRegister();

        ManageOrdersViewModel manageOrdersViewModel = new ManageOrdersViewModel(
            selectedAccount,
            products
        );

        return View(nameof(ManageOrders), manageOrdersViewModel);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Account selectedAccount = accountRepository.SelectRegisterID(id);

        DetailAccountViewModel detailAccountViewModel = new DetailAccountViewModel(
            selectedAccount.Id,
            selectedAccount.Customer,
            selectedAccount.Table.TableNumber,
            selectedAccount.Waiter.Name,
            selectedAccount.StillOpen,
            selectedAccount.CalculateTotalCost(),
            selectedAccount.Orders
        );

        return View(detailAccountViewModel);
    }
}
