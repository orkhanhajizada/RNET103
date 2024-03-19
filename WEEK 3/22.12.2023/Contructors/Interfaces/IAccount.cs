using Contructors.Models;

namespace Contructors.Interfaces;

public interface IAccount
{
    bool PasswordChecker(string password);
    string ShowInfo();
}