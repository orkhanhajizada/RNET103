using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Interfaces.Enums;

public enum SqlConnections
{
    None = 0,

    [Display(Name = "User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;")]
    PostgreSql = 1,

    [Display(Name = "Server=localhost;database=myDatabase;integrated security=true;trust server certificate=true")]
    SqlServer = 2,

    [Display(Name = "Data Source=MyOracleDB;User Id=myUsername;Password=myPassword;Integrated Security=no;")]
    Oracle = 3,

    [Display(Name = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;")]
    MySql = 4
    
    
    
}

//
// public static class EnumExtensions
// {
//     public static string GetDisplayName(this Enum enumValue)
//     {
//         string displayName;
//         displayName = enumValue.GetType()
//             .GetMember(enumValue.ToString())
//             .FirstOrDefault()!
//             .GetCustomAttribute<DisplayAttribute>()?
//             .GetName()!;
//         if (String.IsNullOrEmpty(displayName))
//         {
//             displayName = enumValue.ToString();
//         }
//         return displayName;
//     }
// }