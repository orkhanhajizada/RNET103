using System.Dynamic;

namespace DynamicThinks;

public class Program
{
    public static void Main(string[] args)
    {
        
        string number = "123";
        object objNumber = number;


        string? newNumber1 = objNumber.ToString();
        string newNumber2 = (string)objNumber;
        string? newNumber3 = objNumber as string; // sadece referans tiplerde kullanılır.
        string? newNumber4 = Convert.ToString(objNumber);
        
        dynamic dynamicNumber = number; // run timeda verecek erroru compile timeda vermez.
        int newNumber5 = dynamicNumber;


        dynamic dynamicObj = new ExpandoObject(); // expando object ile dinamik bir obje oluşturulur. 
        
        dynamicObj.Name = "Mehmet";
        
        Console.WriteLine(dynamicObj.Name);
        
    }

    
}

