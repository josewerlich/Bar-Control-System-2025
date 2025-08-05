using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.Shared;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;

namespace Bar_Control_System_2025.Domain.AccountModule
{
    public class Account : BaseEntity<Account>
    {
        public string Customer;
        public Table Table;
        public Waiter Waiter;
        public DateTime DateTimeOpening;
        public DateTime DateTimeClosing;
        public bool StillOpen; 
        public Order[] Order; 

        public Account(string customer, Table table, Waiter waiter)
        {
            Customer = customer;
            Table = table;
            Waiter = waiter;
            Order = new Order[100];

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

            for (int i = 0; i < Order.Length; i++)
            {
                if (Order[i] == null)
                    continue;

                totalCost += Order[i].TotalCostPartial();
            }
            return totalCost;
        }


        public Order RegisterOrder(Product product, int quantity)
        {
            Order newOrder = new Order(product, quantity);

            Order[FindAvailableID()] = newOrder;

            return newOrder;
        }

        public void RemoveOrder(int idOrder)
        {
            int idToRemove = -1;

            for (int i = 0; i < Order.Length; i++)
            {
                if (Order[i] == null) continue;

                if (Order[i].id == idOrder)
                {
                    idToRemove = i;
                    break;
                }
            }

            Order[idToRemove] = null;
        }

        private int FindAvailableID()
        {
            for (int i = 0; i < Order.Length; i++)
            {
                if (Order[i] == null)
                    return i;
            }

            return -1;
        }
    }

}
