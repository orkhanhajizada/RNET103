#region Interface

// // See https://aka.ms/new-console-template for more information
//
// using System.Collections;
// using System.Reflection;
// using Interfaces.Models;
//
// // Object initialization
// Kaleci kaleci = new()
// {
//     Firstname = "Volkan",
//     LastName = "Demirel",
//     UniformNumber = "1",
//     Position = "Kaleci",
//     Takvim = "1981",
//     SutGucu = 50,
//     Agresiflik = 50,
//     MilliFutbolcu = false,
//     ElleTopKontrolu = 100
// };
//
// Forvet forvet = new()
// {
//     Firstname = "Dzeko",
//     LastName = "Edin",
//     UniformNumber = "9",
//     Position = "Forvet",
//     Takvim = "1986",
//     SutGucu = 100,
//     Agresiflik = 100,
//     MilliFutbolcu = false
// };
//
// Defans defans = new()
// {
//     Firstname = "Serdar",
//     LastName = "Aziz",
//     UniformNumber = "4",
//     Position = "Defans",
//     Takvim = "1990",
//     SutGucu = 90,
//     Agresiflik = 90,
//     MilliFutbolcu = true
// };
//
//
// // ArrayList her elemani boxlayip object olarak tutar. Tip olarak hersel olabilir.
// // ArrayList her elemani object olarak tuttugu icin boxing-unboxing islemi yapar.
// // Boxing-unboxing islemi performans kaybina sebep olur.
// // ArrayList yerine List<T> kullanmak daha performansli olur.
// var items = new ArrayList();
//
// items.Add(kaleci);
// items.Add(forvet);
// items.Add(defans);
//
// var models = Assembly.GetExecutingAssembly().GetTypes()
//     .Where(x => x.IsClass && x.Namespace == "Interfaces.Models");
//
//
// while (true)
// {
//     foreach (var item in models)
//     {
//         Console.WriteLine(item.Name);
//     }
//     // Console.WriteLine("1- Kaleci");
//     // Console.WriteLine("2- Forvet");
//     // Console.WriteLine("3- Defans");
//
//     Console.Write("Seciminiz: ");
//
//     var secim = Console.ReadLine();
//     
//     
//
//     // switch (secim)
//     // {
//     //     case "1":
//     //         foreach (var item in items)
//     //         {
//     //             if (item is Kaleci)
//     //             {
//     //                 Kaleci kaleci1 = (Kaleci)item;
//     //                 foreach (var property in kaleci1.GetType().GetProperties())
//     //                 {
//     //                     Console.WriteLine(property.Name + ": " + property.GetValue(kaleci1));
//     //                 }
//     //             }
//     //         }
//     //
//     //         break;
//     //     case "2":
//     //         foreach (var item in items)
//     //         {
//     //             if (item is Forvet)
//     //             {
//     //                 Forvet forvet1 = (Forvet)item;
//     //                 foreach (var property in forvet1.GetType().GetProperties())
//     //                 {
//     //                     Console.WriteLine(property.Name + ": " + property.GetValue(forvet1));
//     //                 }
//     //             }
//     //         }
//     //
//     //         break;
//     //     case "3":
//     //         foreach (var item in items)
//     //         {
//     //             if (item is Defans)
//     //             {
//     //                 Defans defans1 = (Defans)item;
//     //                 foreach (var property in defans1.GetType().GetProperties())
//     //                 {
//     //                     Console.WriteLine(property.Name + ": " + property.GetValue(defans1));
//     //                 }
//     //             }
//     //         }
//     //
//     //         break;
//     //     default:
//     //         Console.WriteLine("Hatali secim");
//     //         break;
//     // }
//
//     Console.WriteLine("Devam etmek icin bir tusa basiniz...");
//
//     Console.ReadKey();
// }

#endregion


#region Enum

// using Interfaces.Enums;
// using Interfaces.Models;
//
// namespace Interfaces;
//
// public class Program
// {
//     public static void Update(Employee employee)
//     {
//         employee.Status = Status.UpdatedAndActive; // -> UpdatedAndActive
//     }
//     
//     public static void Delete(Employee employee)
//     {
//         employee.Status = Status.Deleted; // -> Deleted
//     }
//
//     public static void Main()
//     {
//         var employee = new Models.Employee
//         {
//             Id = 1,
//             Name = "Volkan",
//             Surname = "Demirel",
//             Status = Status.Actice, // -> Active
//             Department = Department.It
//             
//         };
//
//         var updated = employee;
//         updated.Name = "Volkan2";
//         Update(updated);
//         // Console.WriteLine(Enum.GetName(updated.Department));
//         // Console.WriteLine(employee.Status);
//
//         // foreach (var item in Enum.GetValues<Department>())
//         // {
//         //     Console.WriteLine(item);
//         // }
//         
//         // foreach (var item in Enum.GetNames(typeof(Department)))
//         // {
//         //     Console.WriteLine(item);
//         // }
//         foreach (var item in Enum.GetValues(typeof(Department)))
//         {
//             Console.WriteLine((int)item);
//         }
//     }
// }

#endregion


#region Lab

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Interfaces.Enums;

namespace Interfaces;

public class Program()
{
    public static void Main()
    {
        Console.WriteLine("Database sechiniz: ");
        Console.WriteLine("1- PostgreSql");
        Console.WriteLine("2- SqlServer");
        Console.WriteLine("3- Oracle");
        Console.WriteLine("4- MySql");
        
        var secim = Console.ReadLine();
        var secimInt = Convert.ToInt32(secim);
        var secimEnum = (SqlConnections)secimInt;
        var connection = GetDisplayName(secimEnum);
        Console.WriteLine(connection);
        
    }
    private static string GetDisplayName(Enum enumValue)
    {
        var displayName = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()!
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName()!;
        if (string.IsNullOrEmpty(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }
    
    // public void DisplayName()
    // {
    //     var sqlName = SqlConnections.GetAttribute<DisplayAttribute>();
    //     Console.WriteLine (sqlName.Name);
    // } 
}

#endregion