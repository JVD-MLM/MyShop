using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace MyShop.Identity.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public bool IsAdmin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsDeleted { get; protected set; }
    public DateTime CreatedAt { get; set; }
    public bool IsBlocked { get; set; }
    public string MobileActiveCode { get; set; }
    public bool IsActive { get; set; }
    public UserGender Gender { get; set; }

    public void SetDelete()
    {
        IsDeleted = true;
    }
}

public enum UserGender
{
    /// <summary>
    ///     مرد
    /// </summary>
    [Description("مرد")] Male = 1,

    /// <summary>
    ///     زن
    /// </summary>
    [Description("زن")] Female = 2,


    /// <summary>
    ///     نامشخص
    /// </summary>
    [Description("نامشخص")] Both = 3
}