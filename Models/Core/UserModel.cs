namespace Models.Core;

public class UserModel
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set;}
    public string? Password { get; set;}
}