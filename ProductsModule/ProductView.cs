
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Infrastructure.Memory.ProductModule;
using Bar_Control_System_2025.Shared;

namespace Bar_Control_System_2025.ProductsModule
{
    public class ProductView : BaseView<Product>, IMainView
    {
        public ProductView(ProductRepository repository) : base("Product", repository)
        {
        }

        public override void ViewRegister(bool showHeader)
        {
            if (showHeader)
                ShowHeader();

            Console.WriteLine("Products View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30}", "Id", "Nome", "Valor");

            Product[] products = repository.SelectRegister();

            for (int i = 0; i < products.Length; i++)
            {
                Product p = products[i];

                if (p == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -30} | {2, -30}", p.Id, p.Name, p.Cost.ToString("C2"));
            }

            ShowMessage("Press ENTER to continue...", ConsoleColor.Green);
        }

        protected override Product GetData()
        {
            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Type the product's name: ");
                name = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowMessage("Type a valid name!", ConsoleColor.DarkMagenta);
                    Console.Clear();
                }
            }

            bool converted = false;

            decimal cost = 0.0m;

            while (!converted)
            {
                Console.Write("Type the cost of the product: ");
                converted = decimal.TryParse(Console.ReadLine(), out cost);

                if (!converted)
                {
                    ShowMessage("Type a valid number", ConsoleColor.DarkMagenta);
                    Console.Clear();
                }
            }

            return new Product(name, cost);
        }
    }


}
