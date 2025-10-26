namespace MyShop.Application.DTOs.Authentication;

public class SignUpRequestDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}