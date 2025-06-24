namespace Bar_Control_System_2025.ConsoleApp.Shared;

public interface IMainView
{
    char ShowMenu();
    void AddRegister();
    void EditRegister();
    void DeleteRegister();
    void ViewRegister(bool showHeader);
}
