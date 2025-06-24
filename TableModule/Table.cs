using System;
using Bar_Control_System_2025.ConsoleApp.Shared;

public class Table : BaseEntity<Table>
{
    public int TableNumber { get; set; }
    public int TableSize { get; set; }
    public bool TableOccupied { get; set; }

    public Table(int tableNumber, int tableSize)
    {
        TableNumber = tableNumber;
        TableSize = tableSize;
        TableOccupied = false;
    }

    public void GetTable()
    {
        TableOccupied = true;
    }

    public void GetOutofTable()
    {
        TableOccupied = false;
    }

    public override void UpdateRegister(Table updateRegister)
    {
        TableNumber = updateRegister.TableNumber;
        TableSize = updateRegister.TableSize;
    }

    public override string Validate()
    {
        string errors = string.Empty;

        if (TableNumber < 1)
            errors += "The information \"Number\" cannot be less than zero";

        if (TableSize < 1)
            errors += "The information \"Table Siza\" cannot be less than zero";

        return errors;
    }
}

