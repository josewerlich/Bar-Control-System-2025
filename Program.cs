using Bar_Control_System_2025.ConsoleApp.Shared;

namespace Bar_Control_System_2025
{
 
        internal class Program
        {
            static void Main(string[] args)
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
