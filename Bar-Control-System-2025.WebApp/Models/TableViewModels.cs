using Bar_Control_System_2025.Domain.TableModule;
using System.ComponentModel.DataAnnotations;

namespace Bar_Control_System_2025.WebApp.Models;

public class AddTableViewModel
{
   
    [Range(1,1000, ErrorMessage ="The number \"Table Number\" needs to be between 1 and 1000.")]
    public int TableNumber { get; set; }

    [Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public int TableSize { get; set; }

    public AddTableViewModel()
    {
    }
}
public class EditTableViewModel
{
    public int Id { get; set; }

    [Range(1, 1000, ErrorMessage = "The number \"Table Number\" needs to be between 1 and 1000.")]
    public int TableNumber { get; set; }

    [Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public int TableSize { get; set; }

    public EditTableViewModel()
    {
    }

    public EditTableViewModel (int id, int tableNumber, int tableSize)
    {
        Id = id;
        TableNumber = tableNumber;
        TableSize = tableSize;
    }
}
public class DeleteTableViewModel
{
    public int Id { get; set; }
    public int TableNumber { get; set; }


    public DeleteTableViewModel(int id, int tableNumber)
    {
        Id = id;
        TableNumber = tableNumber;
    }

    public DeleteTableViewModel() { }
}
public class TableViewModels
    {
        public List<DetailTableViewModel> Register { get; set; } = new List<DetailTableViewModel>();

        public TableViewModels(List<Table> tables)
        {
            foreach (Table t in tables)
            {
                DetailTableViewModel viewModel = new DetailTableViewModel(
                    t.Id,
                    t.TableNumber,
                    t.TableSize

                );

                Register.Add(viewModel);
            }
        }
    }

    public class DetailTableViewModel
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public int TableSize { get; set; }
        public DetailTableViewModel(int id, int tableNumber, int tableSize)
        {
            Id = id;
            TableNumber = tableNumber.ToString();
            TableSize = tableSize;
        }

    }

