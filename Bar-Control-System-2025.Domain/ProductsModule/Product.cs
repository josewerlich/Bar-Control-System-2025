using Bar_Control_System_2025.Domain.Shared;

namespace Bar_Control_System_2025.Domain.ProductsModule
{
    public class Product : BaseEntity<Product>
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

     
        public override void UpdateRegister(Product updateRegister)
        {
            Name = updateRegister.Name;
            Cost = updateRegister.Cost;
        }

        public override string Validate()
        {
            string errors = string.Empty;

            if (Name.Length < 2 || Name.Length > 100)
                errors += "The field \"Name\"  must have between 3 and 100 characters.";

            if (Cost == 0.0m)
                errors += "The field \"Cost\" must have a positive number.";

            return errors;
        }
    }
}