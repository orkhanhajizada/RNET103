using System.Text;

namespace Inheritance.Models;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;


    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var property in GetType().GetProperties())
        {
            sb.Append($"{property.Name,-15}: {property.GetValue(this, null)} \n");
        }

        return sb.ToString();
    }

    private void GenerateEmail()
    {
        Email = $"{Firstname.ToLower()}.{Lastname.ToLower()}@gmail.com".ToLower();
    }

    // public void AddEmployee()
    // {
    //     foreach (var property in GetType().GetProperties())
    //     {
    //         if (property.Name is "Email" or "Id")
    //             continue;
    //         Console.WriteLine(property.Name);
    //         GetType().GetProperty(property.Name)?.SetValue(this, Console.ReadLine());
    //     }
    //
    //     GenerateEmail();
    // }
    
    public void AddEmployeeFromDictionary(Dictionary<string, string> dictionary)
    {
        foreach (var property in GetType().GetProperties())
        {
            if (property.Name is "Email" or "Id")
                continue;
            Console.WriteLine(property.Name);
            property.SetValue(this, dictionary[property.Name]);
        }

        GenerateEmail();
    }
    
    
    
}