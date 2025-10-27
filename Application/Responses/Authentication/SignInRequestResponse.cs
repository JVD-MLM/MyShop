namespace MyShop.Application.Responses.Authentication;

public class SignInRequestResponse
{
    public string Token { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RoleName { get; set; }
    public string ExpiredAt { get; set; }
}