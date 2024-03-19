using System.ComponentModel.DataAnnotations.Schema;

namespace OOPClassObject.Models;

class Employee // default acces modifier is internal
//Access modifier - public, private, protected, internal
// public - access from anywhere
// private - access only from the same class
// protected - access from the same class and from the derived class
// internal - access from the same assembly 
{
    // Class ichindeki property ve methodlarin access modifieri default olarak private'dir.

    //sinif icindeki property ve methodlara erismek icin public access modifier kullanilir.
    //public access modifier kullanildiginda property ve methodlara sinifin disindan ve ichinden erisilebilir.
    //Encapsulation - property ve methodlara erisimi kisitlamak,
    //sinifin disindan erisimi engellemek,
    //sinifin ichindeki property ve methodlara erisimi saglamak
    //property ve methodlara erisimi kisitlamak icin private access modifier kullanilir.
    //property ve methodlara erisimi saglamak icin public access modifier kullanilir.
    public int Id { get; set; } //get - read, set - write, get return type is propertys type, set return type is void
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string Phone { get; set; } = null!;
    public string? Address { get; set; }
    public DateTime Birthday { get; set; }

    public string? CompanyEmail
    {
        get => $"{FirstName}.{LastName}";
    }

    [NotMapped] // this property will not be mapped to the database. db'de tablo olusturulurken bu property olusturulmayacak
    public string Fullname
    {
        get => $"{FirstName} {LastName}";
    }

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            if (value < 18)
                throw new Exception("Age must be greater than 18");

            _age = value;
        }
    }


    public void Set(int age) => _age = age;

    public int Get() => _age;


    // class function

    public void Create(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }

    public void UpdateMail(string mail)
    {
        Email = mail;
    }

    public void CreateCompanyEmail(string companyDomain)
    {
        Email = $"{FirstName}.{LastName}@{companyDomain}";
    }
}