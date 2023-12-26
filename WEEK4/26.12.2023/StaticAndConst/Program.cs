// See https://aka.ms/new-console-template for more information


//Static -
//staticin deyeri deyishende her yerde deyishir chunki 1denedir yeni statictir. instans alinmir birbasha ozu deyishir ve heryerde deyishmek olur
//deyishenden sonra da her yerde o deyere sahib  olur artiq
//instance almadan ulshmak istedigimiz bir class varsa o class static olmalidir
//instance olusturmadan kullanilabilir
//classlarin icindeki methodlar static olabilir
//static classlarin icindeki methodlar static olmak zorundadir
//static classlarin instance'i olamaz, static classlarin instance'i olmadigi icin constructor'i da olmaz
//static classlarin instance'i olmadigi icin static classlarin icindeki methodlarin icinde this keyword'u kullanilamaz
//static classlarin icindeki methodlarin icinde static olmayan bir classin instance'i olusturulamaz


//Const -

//conts kendiliginden statictir ve degeri degistirilemez
//const degerler compile time'da belli olur ve degistirilemez
//const degerler static olmak zorundadir
//const degerlerin degeri compile time'da belli oldugu icin constructor'i olmaz
//const degerlerin degeri compile time'da belli oldugu icin const degerlerin degeri sadece compile time'da degistirilebilir


//Readonly -
//readonly degerler run time'da belli olur ve degistirilebilir
//readonly degerler static olmak zorunda degildir
//readonly degerlerin degeri run time'da belli oldugu icin constructor'i olmalidir
//readonly degerlerin degeri run time'da belli oldugu icin readonly degerlerin degeri sadece constructor'da degistirilebilir


// Library library = new Library();
// double pi = library.Pi = 3.14159;

// Library.Pi = 3.14159;
//
// Console.WriteLine($"Pi is {Library.Pi}");
//
// string connectionString = Library.ConnectionString;
// Console.WriteLine(connectionString);

// Library.ConnectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";


// //Abstarct
//
// Piyano piyano = new Piyano();
// piyano.Markasi = "Yamaha";
// piyano.Modeli = "P-45";
// piyano.Rengi = "Siyah";
// piyano.Fiyati = 5000;
// piyano.Tuslar = "88";
// piyano.Pedal = "3";
//
// Gitar gitar = new Gitar();
// gitar.Markasi = "Yamaha";
// gitar.Modeli = "C-40";
// gitar.Rengi = "Siyah";
// gitar.Fiyati = 1000;
// gitar.Sap = "Akasya";
// gitar.Teller = "6";
// gitar.Elektronik = "Var";


// Enstrumant enstrumant = new Enstrumant();  Abstratdir deye instance alinmaz
// enstrumant.Markasi = "Yamaha";
// enstrumant.Modeli = "C-40";
// enstrumant.Rengi = "Siyah";
// enstrumant.Fiyati = 1000;

using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CommandLine;
using StaticAndConst.Models;

namespace StaticAndConst;



public class ForeachVsParallelForeach
{
    private List<int> _list;
    
    public ForeachVsParallelForeach()
    {
        _list = new List<int>(){1,2,3,4,5};
    }
    
    [Benchmark]
    public void ExampleForeach()
    {
        foreach (var number in _list)
        {
            Thread.Sleep(1000);
            var result = Math.Sqrt(number);
        }

    }
    
    [Benchmark]
    public void ExampleParalelForeach()
    {
        foreach (var number in _list)
        {
            Thread.Sleep(1000);
            var result = Math.Sqrt(number);
        }

    }
}
class Program
{
    static void Main()
    {
        
        // var cat = new Cat();
        // BenchmarkRunner.Run<ForeachVsParallelForeach>();
        // ForeachVsParallelForeach.ExampleForeach();
        // ForeachVsParallelForeach.ExampleParallelForeach();

        var car = new Car();

        foreach (var property in car.GetType().GetProperties())
        {
            Console.WriteLine(property.Name);
        }

        Console.WriteLine(car.HorsePower());
        Console.WriteLine(car.TankSize());
        Console.WriteLine(car.CurrentOil());
        Console.WriteLine(car.FuelType());
        Console.WriteLine(car.RemaingOilAmount());
        Console.WriteLine(car.WheelTickness());
        
    }
}

// public class ForeachVsParallelForeach
// {
    
    
    // public static void ExampleForeach()
    // {
    //     var numbers = Enumerable.Range(0, 100000000).ToList();
    //     var watch = Stopwatch.StartNew();
    //     foreach (var number in numbers)
    //     {
    //         Thread.Sleep(1000);
    //         var result = Math.Sqrt(number);
    //     }
    //
    //     watch.Stop();
    //     Console.WriteLine($"Foreach: {watch.ElapsedMilliseconds} ms");
    // }
    //
    //
    // public static void ExampleParallelForeach()
    // {
    //     var numbers = Enumerable.Range(0, 100000000).ToList();
    //     var watch = Stopwatch.StartNew();
    //     Parallel.ForEach(numbers, number =>
    //     {
    //         Thread.Sleep(1000);
    //         var result = Math.Sqrt(number);
    //     });
    //     watch.Stop();
    //     Console.WriteLine($"Parallel Foreach: {watch.ElapsedMilliseconds} ms");
    // }
// }