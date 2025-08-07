using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.Shared;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;

namespace Bar_Control_System_2025.Domain.AccountModule
{
    public class Account : BaseEntity<Account>
    {
        public string Customer { get; set; }
        public Table Table { get; set; }
        public Waiter Waiter { get; set; }

        public DateTime DateTimeOpening { get; set; }

        public DateTime DateTimeClosing { get; set; }
        public bool StillOpen { get; set; }
        public List<Order> Orders { get; set; }

        public Account()
        { }


        public Account(string customer, Table table, Waiter waiter)
        {
            Customer = customer;
            Table = table;
            Waiter = waiter;
            Orders = new List<Order>();

            Open();
        }

        public override void UpdateRegister(Account updateRegister)
        {
            StillOpen = updateRegister.StillOpen;
            DateTimeClosing = updateRegister.DateTimeClosing;
        }

        public override string Validate()
        {
            string errors = string.Empty;

            if (Customer.Length < 3 || Customer.Length > 100)
                errors += "The field \"Customer\" must have between 3 and 100 characters.";

            if (Table == null)
                errors += "The field \"Table\" is requested.";

            if (Waiter == null)
                errors += "The field \"Waiter\" is requested.";

            return errors;
        }

        public void Open()
        {
            StillOpen = true;
            DateTimeOpening = DateTime.Now;

            Table.GetTable();
        }

        public void Close()
        {
            StillOpen = false;
            DateTimeClosing = DateTime.Now;

            Table.GetOutofTable();
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;

            for (int i = 0; i < Orders.Count; i++)
            {
               
                totalCost += Orders[i].TotalCostPartial();
            }
            return totalCost;
        }


        public Order RegisterOrder(Product product, int quantity)
        {
            Order newOrder = new Order(product, quantity);

            Orders.Add(newOrder);

            return newOrder;
        }

        public void RemoveOrder(int idOrder)
        {
            int idToRemove = -1;

            for (int i = 0; i < Orders.Count; i++)
            {

                if (Orders[i].id == idOrder)
                {
                    idToRemove = i;
                    break;
                }
            }

            Orders.RemoveAt(idToRemove);
        }

        
    }

}
