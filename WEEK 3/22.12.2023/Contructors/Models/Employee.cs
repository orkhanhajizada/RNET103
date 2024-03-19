namespace Contructors.Models;

public class BaseEntity
{
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedIp { get; set; } = null!;
    public string CreatedComputerName { get; set; } = null!;
    public string CreatedAdUserName { get; set; } = null!;

    public int? ModifiedBy { get; set; }
    public DateTime? ModifieDate { get; set; }
    public string? ModifiedIp { get; set; }
    public string? ModifiedComputerName { get; set; }
    public string? ModifiedAdUserName { get; set; }
}

public class Employee : BaseEntity
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public Employee() //constructor
    {
        CreatedDate = DateTime.Now;
        CreatedComputerName = Environment.MachineName;
        CreatedAdUserName = Environment.UserName;
        CreatedBy = 1;
        CreatedIp = "::1";
    }

    public Employee(string firstname) : this() //constructor
    {
        Firstname = firstname;
    }

    public Employee(string firstname, string lastname) : this(firstname) //constructor
    {
        Lastname = lastname;
    }

    public Employee(string firstname, string lastname, string mail) : this(firstname, lastname) //constructor
    {
        Mail = mail;
    }

    public Employee(string firstname, string lastname, string mail, string phone) :
        this(firstname, lastname, mail) //constructor
    {
        Phone = phone;
    }

    public Employee(string firstname, string lastname, string mail, string phone, string address) : this(firstname,
        lastname, mail, phone) //constructor
    {
        Address = address;
    }

    ~Employee() //destructor
    {
    }
}