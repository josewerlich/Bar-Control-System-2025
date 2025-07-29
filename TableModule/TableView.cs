using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Shared;



public class TableView : BaseView<Table>, IMainView
{
    public TableView(TableRepository tableRepository) : base("Table", tableRepository)
    {
    }

    public override void ViewRegister(bool showHeader)
    {
        if (showHeader)
            ShowHeader();

        Console.WriteLine("Tables View");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -30}",
            "Id", "Table Number", "Table Size", "Status"
        );

        Table[] tables = repository.SelectRegister();

        for (int i = 0; i < tables.Length; i++)
        {
            Table t = tables[i];

            if (t == null)
                continue;

            string statusTable = t.TableOccupied ? "Table Full" : "Avalilable";

            Console.WriteLine(
              "{0, -10} | {1, -30} | {2, -30}",
                t.id, t.TableNumber, t.TableSize, statusTable
            );
        }

        ShowMessage("Press ENTER to continue...", ConsoleColor.DarkYellow);
    }

    protected override Table GetData()
    {
        bool convertedNumber = false;

        int tableNumber = 0;

        while (!convertedNumber)
        {
            Console.Write("Type the number of the table: ");
            convertedNumber = int.TryParse(Console.ReadLine(), out tableNumber);

            if (!convertedNumber)
            {
                ShowMessage("Type a valid number!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        bool convertedSize = false;

        int tableSize = 0;

        while (!convertedSize)
        {
            Console.Write("Type the Table Size: ");
            convertedSize = int.TryParse(Console.ReadLine(), out tableSize);

            if (!convertedSize)
            {
                ShowMessage("Type a valid number!", ConsoleColor.DarkYellow);
                Console.Clear();
            }
        }

        return new Table(tableNumber, tableSize);
    }
}
