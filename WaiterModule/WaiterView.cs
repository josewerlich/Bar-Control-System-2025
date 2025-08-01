

using Bar_Control_System_2025.Domain.WaiterModule;
using Bar_Control_System_2025.Infrastructure.Memory.WaiterModule;
using Bar_Control_System_2025.Shared;

namespace Bar_Control_System_2025.WaiterModule
{
    public class WaiterView : BaseView<Waiter>, IMainView
    {
        public WaiterView(WaiterRepository repository) : base("Waiter", repository)
        {
        }

        public override void ViewRegister(bool showHeader)
        {
            if (showHeader)
                ShowHeader();

            Console.WriteLine("Waiter View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "CPF");

            Waiter[] waiters = repository.SelectRegister();

            for (int i = 0; i < waiters.Length; i++)
            {
                Waiter w = waiters[i];

                if (w == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", w.Id, w.Name, w.SSN);
            }

            ShowMessage("Press ENTER to continue...", ConsoleColor.Green);
        }

        protected override Waiter GetData()
        {
            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Type the waiter's name: ");
                name = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowMessage("Type a valid name", ConsoleColor.DarkMagenta);
                    Console.Clear();
                }
            }

            string ssn = string.Empty;

            while (string.IsNullOrWhiteSpace(ssn))
            {
                Console.Write("Type the SSN of the waiter: ");
                ssn = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(ssn))
                {
                    ShowMessage("Type a valid SSN...", ConsoleColor.DarkMagenta);
                    Console.Clear();
                }
            }

            return new Waiter(name, ssn);
        }
    }
}
