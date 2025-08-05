using Bar_Control_System_2025.Domain.Shared;

namespace Bar_Control_System_2025.Infrastructure.Files.Shared;

public abstract class BaseRepositoryToFile<TEntity> where TEntity : BaseEntity<TEntity>
{
    protected DataContext dataContext { get; set; }
    
    protected List<TEntity> register = new List<TEntity>();
    protected int registerCounter = 0;
    protected int counter = 0;
    protected BaseRepositoryToFile(DataContext dataContext)
    {
        this.dataContext = dataContext;

        register = GetRegister();

        int idControl = 0;

        foreach (TEntity r in register)
        {
            if (r.Id > idControl)
                idControl = r.Id;
        }

        counter = idControl;
    }

    protected abstract List<TEntity> GetRegister(); 
    public void AddRegister(TEntity newRegister)
    {
        newRegister.Id = ++counter;

        register.Add(newRegister);

        dataContext.Save();
    }

    public bool EditRegister(int idSelected, TEntity registerUpdate)
    {
        TEntity selectedRegister = SelectRegisterID(idSelected);

        if (selectedRegister == null)
            return false;

        selectedRegister.UpdateRegister(registerUpdate);

        dataContext.Save();

        return true;


    }

    public bool DeleteRegister(int selectedId)
    {
        for (int i = 0; i < register.Count; i++)
        {
            if (register[i] == null)
                continue;

            else if (register[i].Id == selectedId)
            {
                register.RemoveAt(i);

                dataContext.Save();

                return true;
            }
        }


        return false;
    }

    public List<TEntity> SelectRegister()
    {
        return register;
    }

    public TEntity SelectRegisterID(int idSelected)
    {
        for (int i = 0; i < register.Count; i++)
        {
            TEntity Register = register[i];

            if (Register == null)
                continue;

            if (Register.Id == idSelected)
                return Register;
        }

        return null;
    }
}
