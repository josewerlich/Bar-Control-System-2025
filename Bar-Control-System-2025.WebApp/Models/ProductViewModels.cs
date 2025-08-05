using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.TableModule;
using System.ComponentModel.DataAnnotations;

namespace Bar_Control_System_2025.WebApp.Models;

public class AddProductViewModel
{
   
    //[Range(1,1000, ErrorMessage ="The number \"Table Number\" needs to be between 1 and 1000.")]
    public string Name { get; set; }

   //[Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public decimal Cost { get; set; }

    public AddProductViewModel()
    {
    }
}
public class EditProductViewModel
{
    public int Id { get; set; }

    //[Range(1, 1000, ErrorMessage = "The number \"Table Number\" needs to be between 1 and 1000.")]
    public string Name { get; set; }

    //[Range(1, 1000, ErrorMessage = "The number \"Table Size\" needs to be between 1 and 1000.")]
    public decimal Cost { get; set; }

    public EditProductViewModel()
    {
    }

    public EditProductViewModel (int id, string name, decimal cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
    }
}
public class DeleteProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }


    public DeleteProductViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public DeleteProductViewModel() { }
}
public class ProductViewModels
    {
        public List<DetailProductViewModel> Register { get; set; } = new List<DetailProductViewModel>();

        public ProductViewModels(List<Product> products)
        {
            foreach (Product p in products)
            {
            DetailProductViewModel viewModel = new DetailProductViewModel(
                    p.Id,
                    p.Name,
                    p.Cost

                );

                Register.Add(viewModel);
            }
        }
    }

    public class DetailProductViewModel
{
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DetailProductViewModel(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

    }

