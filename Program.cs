using Bar_Control_System_2025.AccountModule;
using Bar_Control_System_2025.Domain.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.TableModule;
using Bar_Control_System_2025.Shared;

namespace Bar_Control_System_2025
{

    internal class Program
    {

        static void Main(string[] args)
        {
            DataContext context = new DataContext(loadData: true);

            ProductRepositoryInFile tableRepository = new TableRepositoryInFile(context);

            Table table = new Table(1, 2);

            tableRepository.AddRegister(table);

            
        }
        static void Main2(string[] args)
        {
            MainView mainView = new MainView();

            while (true)
            {
                mainView.ShowMainMenu();

                IMainView selectedView = mainView.GetView();

                if (selectedView == null)
                    break;

                char userOption = selectedView.ShowMenu();

                if (char.ToUpper(userOption) == 'E')
                    break;

                if (selectedView is AccountView accountView)
                {

                    switch (userOption)
                    {
                        case '1': accountView.AddRegister(); break;

                        case '2': accountView.ShowOrderManagementView(); break;

                        case '3': accountView.ViewRegister(true); break;
                    }
                }
                else
                {
                    switch (userOption)
                    {
                        case '1': selectedView.AddRegister(); break;

                        case '2': selectedView.EditRegister(); break;

                        case '3': selectedView.DeleteRegister(); break;

                        case '4': selectedView.ViewRegister(true); break;
                    }
                }
            }
        }
    }

    }
