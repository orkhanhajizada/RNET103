namespace SealedClass.Models;

public class Category
{
    // bosh constructor claslarda vermek olur
    public Category() 
    {
    }
    
    // this() yazdigimiz zaman bosh constructoru ishledir
    public Category(int id, string name, string description) : this() 
    {
        Id = id;
        Name = name;
        Description = description;
    }

    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


// classdan ferqli olaraq structlar value type olaraq ishleyir ve stackde yerlesir, kichik datalar uchundur
public struct  Kategori 
{
    // public Kategori() // evvel bosh struct constructor vermek olmurdu, c# 10`dan sonra vermek olur
    // {
    // }
    
    
    //bosh constructor olmasa da ishleyir amma classda mutleq bosh constructor olmalidir
    public Kategori(int id, string name, string description) 
    {
        Id = id;
        Name = name;
        Description = description;
    }

    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}