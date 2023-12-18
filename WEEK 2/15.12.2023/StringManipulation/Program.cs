//LowerCase - metni küçük harfe çevirir.
//UpperCase - metni büyük harfe çevirir.
//Replace - metindeki bir karakteri başka bir karakterle değiştirir.
//indexof - metnin içinde arama yapar.
//lastindexof - metnin içinde arama yapar.
//startswith - metin belirtilen karakterle başlıyorsa true döner.
//endswith - metin belirtilen karakterle bitiyorsa true döner.
//contains - metin belirtilen karakteri içeriyorsa true döner.
//trim - metnin başındaki ve sonundaki boşlukları siler.
//split - metni belirtilen karaktere göre ayırır.
//toCharArray - metni karakter dizisine çevirir.
//ToLower - metni küçük harfe çevirir.
//ToUpper - metni büyük harfe çevirir.
//Replace - metindeki bir karakteri başka bir karakterle değiştirir.
//ToString - metni stringe çevirir.

// var text = "A,S.D/;T*F-E+";
// text = text.Replace(",", " ")
//     .Replace(".", " ")
//     .Replace(";", " ")
//     .Replace("/", " ")
//     .Replace("*", " ")
//     .Replace("-", " ")
//     .Replace("+", " ");
//
// string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

// text = string.Join(" ", words);

// char[] chars = {',', '.', ';', '/', '*', '-', '+'};
//
// var text2 = text.Split(separator:chars, options:StringSplitOptions.RemoveEmptyEntries);
//
// Console.WriteLine(string.Join(" ", text2));   


//substring - metnin bir bölümünü alır.


// const string text = "Code Academy RNET103";
//
// var text1 = text.Substring(5);
// var text2 = text.Substring(5,8);
//
// Console.WriteLine(text1);
// Console.WriteLine(text2);


// using System.Diagnostics;
// using System.Text;
// using BenchmarkDotNet.Attributes;
// using BenchmarkDotNet.Running;
//
// void SampleIndexOf()
// {
//     var text = "Code Academy RNET103";
//     var find = 'a';
//
//     if (text.IndexOf(find) != text.LastIndexOf(find))
//     {
//         Console.WriteLine($"Text ichinde birden chox " + $"{find}" + " herfi var");
//     }
//     else
//     {
//         Console.WriteLine($"Text ichinde birden chox " + $"{find}" + " herfi  yoxdur");
//     }
//     
// }
// SampleIndexOf();



// murat.vuranok@example.com 
//---------------------------
// -Adi: Murat
// -Soyadi: Vuranok
// -Domain: example
// -Uzantı: com
//---------------------------

// string[] emails =
// {
//     "orkhan.hajizada@gmail.com"
// };
//
// var tre = new String('-', 40);
//
// string result = $"""
//                 {tre}
//                 -Adi: _firstName
//                 -Soyadi: _lastName
//                 -Domain: _domain
//                 -Uzantı: _extension
//                 {tre}
// """;
//
// string firstName = "Murat";
//
// result = result.Replace("_firstName", firstName);
//
// Console.WriteLine(result);


// void TestCase1()
// {
//     Stopwatch sw = new Stopwatch();
//     
//     //Test with string
//     
//     sw.Start();
//     // StringTest();
//     sw.Stop();
//     Console.WriteLine("StringTest: {0} ms", sw.ElapsedMilliseconds);
//     
//     
//     //Test with StringBuilder
//     sw.Restart();
//     sw.Start();
//     // StringBuilerTest();
//     sw.Stop();
//     Console.WriteLine("StringTest: {0} ms", sw.ElapsedMilliseconds);
// }

// void StringTest()
// {
//     string result = "";
//     
//     for (int i = 0; i < 100000; i++)
//     {
//         result += " a";
//     }
// }
//
// void StringBuilerTest()
// {
//     StringBuilder sb = new StringBuilder();
//     
//     for (int i = 0; i < 100000; i++)
//     {
//         sb.Append(" a");
//     }
// }

// TestCase1();

// BenchmarkRunner.Run<StrinngVsBuilder>();
//
// public class StrinngVsBuilder
// {
//     private const int _count = 100000;
//     [Benchmark]
//     public void StringTest()
//     {
//         string result = "";
//     
//         for (int i = 0; i < _count; i++)
//         {
//             result += " a";
//         }
//     }
//
//     [Benchmark]
//     public void StringBuilerTest()
//     {
//         StringBuilder sb = new StringBuilder();
//     
//         for (int i = 0; i < _count; i++)
//         {
//             sb.Append(" a");
//         }
//     }
// }


// string input = "text";
// string input2 = "text2";
//
// string numbs = "5555599999";

// Console.WriteLine(string.Compare(input, input2));

// Console.WriteLine(input.PadLeft(3,'-'));
// Console.WriteLine(input.PadRight(3,'-'));
// Console.WriteLine(input.GetType());
// Console.WriteLine(input.GetType().Name);
// Console.WriteLine(input.GetTypeCode());
// Console.WriteLine(numbs.Remove(5,5));

// Console.WriteLine(input.Contains(input2));



//*
// **
// ***
// ****
// *****
// ******
// *******


for (var i = 0; i < 7; i++)
{
    for (var j = 0; j < i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}




