
using Bar_Control_System_2025.Domain.AccountModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Bar_Control_System_2025.WebApp.Models;

public class OpenAccountViewModel
{
    [Required(ErrorMessage = "The field \"Customer\" is required")]
    [MinLength(3, ErrorMessage = "The filed \"Customer\" needs to have at least 3 characters.")]
    [MaxLength(100, ErrorMessage = "The filed \"Customer\" needs to have maximum of 100 characters.")]
    public string Customer { get; set; }

    [Required(ErrorMessage = "The field \"Table\" is required.")]
    public int TableId { get; set; }
    public List<SelectListItem> AvailableTables { get; set; }

    [Required(ErrorMessage = "The field \"Waiter\" is required.")]
    public int WaiterId { get; set; }
    public List<SelectListItem> AvailableWaiters { get; set; }

    public OpenAccountViewModel()
    {
        AvailableTables = new List<SelectListItem>();
        AvailableWaiters = new List<SelectListItem>();
    }

    public OpenAccountViewModel(List<Table> tables, List<Waiter> waiters) : this()
    {
        foreach (var t in tables)
        {
            SelectListItem availableTable = new SelectListItem(t.TableNumber.ToString(), t.Id.ToString());

            AvailableTables.Add(availableTable);
        }

        foreach (var w in waiters)
        {
            SelectListItem availableWaiter = new SelectListItem(w.Name.ToString(), w.Id.ToString());

            AvailableWaiters.Add(availableWaiter);
        }
    }
}

public class ViewAccountViewModel
{
    public List<DetailAccountViewModel> Registers { get; set; }

    public ViewAccountViewModel(List<Account> accounts)
    {
        Registers = new List<DetailAccountViewModel>();

        foreach (var a in accounts)
        {
            DetailAccountViewModel detailAccountViewModel = new DetailAccountViewModel(
                a.Id,
                a.Customer,
                a.Table.TableNumber,
                a.Waiter.Name,
                a.StillOpen,
                a.CalculateTotalCost(),
                a.Orders.ToList()
            );

            Registers.Add(detailAccountViewModel);
        }
    }
}

public class DetailAccountViewModel
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public int Table { get; set; }
    public string Waiter { get; set; }
    public bool StillOpen { get; set; }
    public decimal TotalCost { get; set; }
    public List<OrderAccountViewModel> Orders { get; set; }

    public DetailAccountViewModel(
        int id,
        string customer,
        int table,
        string waiter,
        bool stillOpen,
        decimal totalCost,
        List<Order> orders
    )
    {
        Id = id;
        Customer = customer;
        Table = table;
        Waiter = waiter;
        StillOpen = stillOpen;
        TotalCost = totalCost;

        Orders = new List<OrderAccountViewModel>();

        foreach (var item in orders)
        {
            var orderAccountViewModel = new OrderAccountViewModel(
                item.id,
                item.Product.Name,
                item.Quantity,
                item.TotalCostPartial()
            );

           Orders.Add(orderAccountViewModel);
        }
    }
}

public class OrderAccountViewModel
{
    public int Id { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal PartialTotal { get; set; }

    public OrderAccountViewModel(int id, string product, int quantity, decimal partialTotal)
    {
        Id = id;
        Product = product;
        Quantity = quantity;
        PartialTotal = partialTotal;
    }
}

