namespace StaticAndConst.Models;

public abstract class Animal
{
    public string Name { get; set; }

    void Show()
    {
        Console.WriteLine("Animal");
    }
}


public class Cat : Animal
{
    public string Color { get; set; }

    

}