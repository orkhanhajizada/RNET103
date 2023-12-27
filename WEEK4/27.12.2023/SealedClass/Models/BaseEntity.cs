namespace SealedClass.Models;

public abstract class BaseEntity // sadece miras alınabilir abstract oldugu uchun, instans alınamaz
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public virtual void LogCurrentUser()
    {
        Console.WriteLine($"Current user : Admin");
    }

    public virtual void LogLastUser()
    {
        Console.WriteLine($"Last user : Admin");
    }

    public virtual void SetLogDb()
    {
        Console.WriteLine($"Log : BaseEntity " + CreatedDate);
    }

    public void SetLogXml() // virtual yazmirig deye override edile bilmir child classlarda
    {
        Console.WriteLine($"Log : BaseEntity " + CreatedDate);
    }
}

public abstract class Book : BaseEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishDate { get; set; }
    public int PageCount { get; set; }
    public string Publisher { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int StockCount { get; set; }
    
    public override void LogCurrentUser()
    {
        base.LogCurrentUser(); // base class`in methodunu cagirir ordaki kodu ishledir
        Console.WriteLine($"Current user : Book"); // base class`in methodundan sonra bu methodu ishledir
    }

    public sealed override void SetLogDb() // methodu burda sealed etsek diger bookdan miras alan classlarda override edile bilinmir
    {
        Console.WriteLine($"Log SetLogDb : Magazine " + CreatedDate);
    }
}

public sealed class Author : BaseEntity
{
    
}

// public sealed class Category : BaseEntity
// {
//     
// }


//sealed class`dan instance alina biler amma inheritance (miras) alina bilmez
public sealed class Magazine : Book
{
    // public override void SetLogDb()  // Book`da bu sealed edilib override edile bilinmir ona gore 
    // {
    //     Console.WriteLine($"Log : Magazine " + CreatedDate);
    // }
}

public class Novel : Book
{
}

public class Biography : Book
{
}

public class Story : Book
{
}

public class Dictionary : Book
{
}

public class Encyclopedia : Book
{
}