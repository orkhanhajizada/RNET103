namespace OOPClassObject.Models;

public class Students
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateOnly Birthday { get; set; }
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;


    public Students Create(int id,string name, string surname, DateOnly birthday, string phone, string address)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Phone = phone;
        Email = CreateEmail(Name, Surname);
        Address = address;

        return this;
    }

    public void UpdateStudent(string name, string surname, DateOnly birthday, string phone, string address)
    {
        Name = name;
        Surname = surname;
        Birthday = birthday;
        Phone = phone;
        Address = address;
    }

    private string CreateEmail(string name, string surname)
    {
        return $"{Name}.{Surname}@code.edu.az".ToLower();
    }
    
    public void GetStudents()
    {
        Console.WriteLine($"Id: {Id} - Ad: {Name} - Soyad: {Surname} - Doğum tarixi: {Birthday} - Telefon: {Phone} - Ünvan: {Address} - Email: {Email}");
    }
}