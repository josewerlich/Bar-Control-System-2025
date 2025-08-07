

using Bar_Control_System_2025.Domain.AccountModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Files.AccountModule;
using Bar_Control_System_2025.Infrastructure.Files.ProductRepositoryInFile;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.WaiterRepositoryInFile;
using Bar_Control_System_2025.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Index()
    {
        List<Account> accounts = accountRepository.SelectRegister();

        ViewAccountViewModel viewAccountsViewModel = new ViewAccountViewModel(accounts);

        return View(viewAccountsViewModel);
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
}