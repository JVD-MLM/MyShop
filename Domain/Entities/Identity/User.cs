using Microsoft.AspNetCore.Identity;

namespace MyShop.Domain.Entities.Identity;

public class User : IdentityUser<Guid>
{
    public bool IsAdmin { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public void SetDelete()
    {
        IsDeleted = true;
    }
}