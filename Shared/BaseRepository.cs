namespace Bar_Control_System_2025.ConsoleApp.Shared;

public abstract class BaseRepository<TEntity> where TEntity : BaseEntity<TEntity>
{
    protected TEntity[] register = new TEntity[100];
    protected int registerCounter = 0;
    protected int counter = 0;

    public void AddRegister(TEntity newRegister)
    {
        register[registerCounter] = newRegister;

        registerCounter++;
    }

    public bool EditRegister(int idSelected, TEntity registerUpdate)
    {
        TEntity selectedRegister = SelectRegisterID(idSelected);

        if (selectedRegister == null)
            return false;

        selectedRegister.UpdateRegister(registerUpdate);

        return true;
    }

    public bool DeleteRegister(int idSelecionado)
    {
        for (int i = 0; i < register.Length; i++)
        {
            if (register[i] == null)
                continue;

            else if (register[i].id == idSelecionado)
            {
                register[i] = null;

                return true;
            }
        }

        return false;
    }

    public TEntity[] SelectRegister()
    {
        return register;
    }

    public TEntity SelectRegisterID(int idSelected)
    {
        for (int i = 0; i < register.Length; i++)
        {
            TEntity Register = register[i];

            if (Register == null)
                continue;

            if (Register.id == idSelected)
                return Register;
        }

        return null;
    }
}
