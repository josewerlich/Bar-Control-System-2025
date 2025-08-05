

using Bar_Control_System_2025.Domain.AccountModule;
using Bar_Control_System_2025.Domain.ProductsModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Domain.WaiterModule;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bar_Control_System_2025.Infrastructure.Files.Shared
{
    public class DataContext
    {

        public List<Table> Tables { get; set; } = new List<Table>();

        public List<Waiter> Waiters { get; set; } = new List<Waiter>();

        public List<Product> Products { get; set; } = new List<Product>();

        public List<Account> Accounts { get; set; } = new List<Account>();

        private string folderPath = "C:\\temp";
        private string fileName = "data-bar-control.json";

        public DataContext() { }

        public DataContext(bool loadData)
        {
            if (loadData)
            {
                Load();
            }
        }

        public void Save()
        {
            string completePath = Path.Combine(folderPath, fileName);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            var jsonString = JsonSerializer.Serialize(this, jsonOptions);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            File.WriteAllText(completePath, jsonString);

        }

        public void Load() 
        {
            string completePath = Path.Combine(folderPath, fileName);

            if(!File.Exists(completePath)) return;

            string jsonString = File.ReadAllText(completePath);

            if (string.IsNullOrEmpty(jsonString)) return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            DataContext? savedContext = JsonSerializer.Deserialize<DataContext>(jsonString, jsonOptions);

            if (savedContext == null) return;
            
            Tables = savedContext.Tables;
            Waiters = savedContext.Waiters;
            Products = savedContext.Products;
            Accounts = savedContext.Accounts;
            
        }
    }
}
