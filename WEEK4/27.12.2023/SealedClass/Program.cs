// See https://aka.ms/new-console-template for more information

using System.Reflection;
using SealedClass.Models;

namespace SealedClass;

public static class Program
{
    static Category category;
    static Kategori kategori;

    public static void Main(string[] args)
    {
        #region Sealed
        // var magazine = new Magazine();
        // var novel = new Novel();
        // var biography = new Biography();
        // var story = new Story();
        // var dictionary = new Dictionary();
        // var encyclopedia = new Encyclopedia();
        //
        // object[] books = { magazine, novel, biography, story, dictionary, encyclopedia };
        //
        // // foreach (var book in books)
        // // {
        // //     MethodInfo[] methods = book.GetType().GetMethods();
        // //     
        // //     foreach (var method in methods)
        // //     {
        // //         if (method.Name.Contains("Log"))
        // //         {
        // //             // Console.WriteLine($"Method name : {method.Name}");
        // //             method.Invoke(book, null);
        // //         }
        // //     }
        // // }
        //
        // var types = Assembly.GetExecutingAssembly().GetTypes();
        // var drivedTypes = types.Where(x => x.IsSubclassOf(typeof(Book))).ToList();
        //
        // foreach (var type in drivedTypes)
        // {
        //     Book book = (Book)Activator.CreateInstance(type);
        //     
        //     MethodInfo[] methods = book.GetType().GetMethods();
        //     
        //     foreach (var method in methods)
        //     {
        //         if (method.Name.Contains("Log"))
        //         {
        //             // Console.WriteLine($"Method name : {method.Name}");
        //             method.Invoke(book, null);
        //         }
        //     }
        // }
        #endregion

        
        
        #region Struct
        // class mutleq new ile instance alinmalidir amma struct alinmaga ehtiyyac yoxdur
        // category = new Category();
        // category.Name = "Category name";
        // category.Description = "Category description";
        //
        //
        // kategori.Name = "Kategori name";
        // kategori.Description = "Kategori description";

        #endregion
        
        
        #region Generic

        Box<string> b = new Box<string>();
        b.Set = "5";
        
        Box<int> b1 = new Box<int>();
        b1.Set = 5;
        
        Box<Category> b2 = new Box<Category>();
        b2.Set = new Category();

        #endregion

        #region Lab

        // var user = new User
        // {
        //     Id = 1,
        //     Name = "Name",
        //     Age = 25
        // };

        var userDto = new UserDto
        {
            Name = "Orkhan",
            Age = 25
        };
        
        var mapper = new Mapper<UserDto, User>();
        // var userDto = mapper.Map(user);
        var user = mapper.Map(userDto);
        
        // Console.WriteLine($"Name : {user.Name}");
        // Console.WriteLine($"Age : {user.Age}");

        #endregion
    }
}