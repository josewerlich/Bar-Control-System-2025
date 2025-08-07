
using Bar_Control_System_2025.Domain.AccountModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace Bar_Control_System_2025.Infrastructure.Files.AccountModule;

public class AccountRepositoryInFile : BaseRepositoryToFile<Account>
{
    public AccountRepositoryInFile(DataContext dataContext) : base(dataContext)
    {
    }

    protected override List<Account> GetRegister()
    {
        return dataContext.Accounts;
    }

    public List<Account> SelectAccountUsingDateAndTime(DateTime dataOpening)
    {
        List<Account> ordersFromTheDay = new List<Account>();

        foreach (Account account in register)
        {
            if (account.DateTimeOpening.Date == dataOpening.Date)
                ordersFromTheDay.Add(account);
        }

        return ordersFromTheDay;
    }

    public List<Account> SelecionarContasEmAberto()
    {
        List<Account> openAccount = new List<Account>();

        foreach (Account account in register)
        {
            if (account.StillOpen)
                openAccount.Add(account);
        }

        return openAccount;
    }

    public List<Account> SelectClosedAccounts()
    {
        List<Account> closedAccounts = new List<Account>();

        foreach (Account account in register)
        {
            if (!account.StillOpen)
                closedAccounts.Add(account);
        }

        return closedAccounts;
    }
}