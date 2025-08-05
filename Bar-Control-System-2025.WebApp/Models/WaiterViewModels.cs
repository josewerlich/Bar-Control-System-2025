using Bar_Control_System_2025.Domain.WaiterModule;
using System.ComponentModel.DataAnnotations;

namespace Bar_Control_System_2025.WebApp.Models;

public class AddWaiterViewModel
{
   
    //[Range(1,1000, ErrorMessage ="The number \"Table Number\" needs to be between 1 and 1000.")]
    public string Name { get; set; }

    //[Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public string SSN { get; set; }

    public AddWaiterViewModel()
    {
    }
}
public class EditWaiterViewModel
{
    public int Id { get; set; }

    //[Range(1, 1000, ErrorMessage = "The number \"Table Number\" needs to be between 1 and 1000.")]
    public string Name { get; set; }

    //[Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public string SSN { get; set; }

    public EditWaiterViewModel()
    {
    }

    public EditWaiterViewModel (int id, string name, string ssn)
    {
        Id = id;
        Name = name;
        SSN = ssn;
    }
}
public class DeleteWaiterViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }


    public DeleteWaiterViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public DeleteWaiterViewModel() { }
}
public class WaiterViewModels
{
        public List<DetailWaiterViewModel> Register { get; set; } = new List<DetailWaiterViewModel>();

        public WaiterViewModels(List<Waiter> waiters)
        {
            foreach (Waiter w in waiters)
            {
                DetailWaiterViewModel viewModel = new DetailWaiterViewModel(
                    w.Id,
                    w.Name,
                    w.SSN

                );

                Register.Add(viewModel);
            }
        }
    }

    public class DetailWaiterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DetailWaiterViewModel(int id, string name, string ssn)
        {
            Id = id;
            Name = name;
            SSN = ssn;
        }

    }

