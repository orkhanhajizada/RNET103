using System.Transactions;
using Inheritance.Models;

namespace Inheritance;

public static class Program
{
    public static void Main()
    {
        // var dog = new Dog {Name = "Dog", Bite = true};
        // var cat = new Cat {Name = "Cat", Pawing = true};
        // dog.Display();
        // cat.Display();


        // Dog dog = new Dog();
        // dog.Name = "Rex";
        // dog.Bite = true;
        // dog.Display();
        // dog.Sound();
        // // dog.Berk();
        //
        // Cat cat = new Cat();
        // cat.Name = "Tom";
        // cat.Pawing = true;
        // cat.Display();
        // cat.Sound();
        // cat.Meow();

        var employee = new Employee();
        // employee.AddEmployee();
        // Console.WriteLine(employee);


        var dictionary = new Dictionary<string, string>
        {
            { "Firstname", "John" },
            { "Lastname", "Doe" },
            { "Phone", "123456789" },
            { "Address", "Baku" },
            { "Email", "jhon.doe@gmail.com" },
        };


        // employee.AddEmployeeFromDictionary(dictionary);
        // Console.WriteLine(employee);

        // var disposable = new Disposable();
        // disposable.Print();
        for (int i = 0; i < 10; i++)
        {
            var destructor = new Destructor(i);
        }
        GC.Collect();
        Console.Read();
        // Console.WriteLine(destructor.Number);
    }


    class Disposable : IDisposable
    {
        public bool IsDisposed { get; set; }
        public void Print() => Console.WriteLine($"IsDisposed: {IsDisposed}");

        public void Dispose()
        {
            IsDisposed = true;
        }
    }

    class Destructor
    {
        public int Number { get; set; }
        
        public Destructor(int number)
        {
            Number = number;
            Console.WriteLine("Instance created");
        }
        
        ~Destructor()
        {
            Console.WriteLine("Instance destroyed");
        }
    }
}