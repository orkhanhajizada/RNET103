 // void Method1()
 // {
 //     Console.WriteLine("Method1");
 // }


 // public -> access modifier (public, private - ancaq class daxilinde access var, protected - oz klasinda acces var bir de miras alinanda access var, internal)
 // void -> return type (void, int, string, bool, double, float, char, etc.)
 // Method1 -> method name
 // () -> parameter list (optional)
 // { } -> method body


//  void Calculate(int a, int b)
//  {
// rules
//  1. parametrs have a type
//  2. parametrs have a name
//  3. parametrs are separated by comma
//  4. parametrs are optional
//  5. parametrs are local variables
//  6. parametrs are initialized by arguments
//  7. parametrs are passed by value
//  8. parametrs are passed by reference (ref, out)
//  9. parametrs are passed by value (default)
//  10. parametrs 
//      int result = a + b;
//      Console.WriteLine(result);
//  }
//
//  Calculate(b:10,a:20);


 // Test();
 // void Test()
 // {
 //     ReferenceEqualityComparer referenceComparer = ReferenceEqualityComparer.Instance;
 //
 //     MyClass obj1 = new MyClass();
 //     MyClass obj2 = new MyClass(); 
 //     MyClass obj3 = obj2; 
 //
 //     Console.WriteLine(referenceComparer.Equals(obj2,obj3)); 
 // }
 //
 // class MyClass{}

 

 // internal class Program
 //     {
         
         /// <summary>
         /// Creates an email address from the specified first name, last name, and domain.
         /// </summary>
         
         // public static void CreateEmail(string firstName, string domain)
         // {
         //     Console.WriteLine($"{firstName}@{domain}.com");
         // }
         //
         // public static void CreateEmail(string firstName, string lastName, string domain)
         // {
         //     Console.WriteLine($"{firstName}.{lastName}@{domain}.com");
         // }
     
     
     
         // public static void CreateEmail(string firstName, string lastName, string domain, string extension)
         // {
         //     Console.WriteLine($"{firstName}.{lastName}@{domain}.{extension}");
         // }


         // public static void Main()
         // {
         //     // CreateEmail("John", "Doe", "gmail.com", "com");
         //     // CreateEmail("John", "Doe", "gmail.com");
         //     // CreateEmail("John", "gmail.com");
         //     // CreateEmail("John", "Doe");
         //     // CreateEmail("John");
         //     // CreateEmail();
         //     
         //     
         // }



     //     #region Create Email Function
     //
     //     //test
     //     #endregion
     //
     // }


 // Min();
 // NumLength();
 // VowelLetter();
 //
 // void Min()
 // {
 //     var numbers = new[] {100, 1, 2, 3, 4, 5, 6 };
 //     Console.WriteLine(numbers.Min());
 // }
 //
 // void NumLength()
 // {
 //     var number = 123456789;
 //     Console.WriteLine(number.ToString().Length);
 // }
 //
 // void VowelLetter()
 // {
 //     const string text = "Hello World";
 //     
 //     var vowels = new[] {'a', 'e', 'i', 'o', 'u'};
 //     var vowelCount = text.Count(letter => vowels.Contains(letter));
 //
 //     Console.WriteLine(vowelCount);
 // }
 
 
 using Mehriban;

 MailHelper mailHelper = new MailHelper(); 
 var result = mailHelper.SendMail("Welcome", 
                    "Hello RNET103", 
                    "h.orkhan1907@gmail.com", 
                    "to", 
                    "rnet9736@gmail.com", 
                    true);
 Console.WriteLine(result);