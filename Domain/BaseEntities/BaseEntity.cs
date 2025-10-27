namespace MyShop.Domain.BaseEntities;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } // todo
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; } // todo

    public void SetDelete()
    {
        IsDeleted = true;
    }
}