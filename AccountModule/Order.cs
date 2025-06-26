using Bar_Control_System_2025.ProductsModule;

namespace Bar_Control_System_2025.AccountModule;

public class Order
{
    public int id;
    public Product Product;
    public int Quantity;
    private static int idCounter = 0;

    public Order(Product product, int quantity)
    {
        id = ++idCounter;
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalCostPartial()
    {
        return Product.Cost * Quantity;
    }

    public override string ToString()
    {
        return $"{Quantity} x {Product.Name}";
    }
}