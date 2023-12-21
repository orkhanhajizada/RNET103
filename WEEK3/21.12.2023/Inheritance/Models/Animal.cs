namespace Inheritance.Models;

public class Animal
{
    public string Name { get; set; } = null!;
    
    
    public void Display()
    {
        Console.WriteLine($"Animal: {Name}");
    }

    public virtual void Sound()
    {
        Console.WriteLine("Animal sound");
    }
}

public class Dog : Animal
{
    public bool Bite { get; set; }

    // public void Berk()
    // {
    //     Console.WriteLine("woof woof");
    // }
    public override void Sound()
    {
        Console.WriteLine("woof woof");
    }
}



public class Cat : Animal
{
    public bool Pawing { get; set; }

    // public void Meow()
    // {
    //     Console.WriteLine("meow meow");
    // }

    public override void Sound()
    {
        Console.WriteLine("meow meow");
    }
}