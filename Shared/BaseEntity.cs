

public abstract class BaseEntity<TEntity>
{
    public int id;

    public abstract void UpdateRegister(TEntity registerUpdated);
    public abstract string Validate();
}
