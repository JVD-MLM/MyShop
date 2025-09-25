namespace MyShop.Domain.BaseEntities;

public abstract class BaseEntity<T>
{
    public T Id { get; protected set; }
    public bool IsDeleted { get; protected set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public void SetDelete()
    {
        IsDeleted = true;
    }
}