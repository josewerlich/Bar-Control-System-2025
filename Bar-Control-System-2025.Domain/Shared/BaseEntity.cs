namespace Bar_Control_System_2025.Domain.Shared;


public abstract class BaseEntity<TEntity>
{
    public int Id { get; set; }

    public abstract void UpdateRegister(TEntity registerUpdated);
    public abstract string Validate();
}
