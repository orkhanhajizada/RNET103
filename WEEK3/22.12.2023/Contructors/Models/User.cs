using Contructors.Interfaces;

namespace Contructors.Models;

public class User : IAccount
{
    private static int _id;
    public int Id
    {
        get => ++_id;
        
    }
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    private string _password = null!;
    public string Password
    {
        get => _password;
        set
        {
            if (!PasswordChecker(value)) return;
            _password = value;
        }
    } 

    public bool PasswordChecker(string password)
    {
        return password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsLower) &&
               password.Any(char.IsDigit);
    }

    public string ShowInfo()
    {
        return $"Id: {Id}, Fullname: {Fullname}, Email: {Email}";
    }
}