#region Leeson

// namespace OOPClassObject;
//
// public class Program
// {
//     public static void Main()
//     {
//         // //Instance -> yeni bir ornek olusturmak
//         // Employee employee = new Employee();
//         // // employee.Id = 1;
//         // // employee.FirstName = "Ahmet";
//         // // employee.LastName = "Kaya";
//         // // employee.Email = "ahmet.kaya@gmail.com";
//         // // employee.Phone = "05555555555";
//         // // employee.Address = "Istanbul";
//         //
//         // int age =int.Parse(Console.ReadLine());
//         // employee.Age = age;
//         //
//         // Console.WriteLine(employee.Age);
//         // Console.WriteLine(employee.FirstName);
//         // Console.WriteLine(employee.LastName);
//         // Console.WriteLine(employee.Email);
//         // Console.WriteLine(employee.Phone);
//         // Console.WriteLine(employee.Address);
//         //
//         //
//         //
//         // employee.Create("Ahmet","Kaya","05555555555");
//         // employee.UpdateMail("test@gmail.com");
//
//         var student = new Students();
//         List<Students> students = new();
//         int id = 0;
//
//
//         while (true)
//         {
//             Console.WriteLine("1. Yeni tələbə əlavə et");
//             Console.WriteLine("2. Mövcud tələbələri göstər");
//             Console.WriteLine("3. Mövcud tələbəni göstər");
//             Console.WriteLine("4. Mövcud tələbəni yenilə");
//             Console.WriteLine("5. Mövcud tələbəni sil");
//             Console.WriteLine("6. Çıxış");
//             Console.Write("Seçiminiz: ");
//             var choice = Console.ReadLine();
//
//             switch (choice)
//             {
//                 case "1":
//                     CreateStudent();
//                     break;
//                 case "2":
//                     GetStudents();
//                     break;
//                 case "3":
//                     GetStudent();
//                     break;
//                 case "4":
//                     UpdateStudent();
//                     break;
//                 case "5":
//                     DeleteStudent();
//                     break;
//                 case "6":
//                     return;
//                 default:
//                     Console.WriteLine("Düzgün seçim edin.");
//                     break;
//             }
//         }
//
//         void CreateStudent()
//         {
//             Console.WriteLine("Tələbənin adını daxil edin");
//             string name = Console.ReadLine();
//
//             Console.WriteLine("Tələbənin soyadını daxil edin");
//
//             string surname = Console.ReadLine();
//
//             Console.WriteLine("Tələbənin doğum tarixini daxil edin");
//
//             DateOnly birthday = DateOnly.Parse(Console.ReadLine());
//
//             Console.WriteLine("Tələbənin telefon nömrəsini daxil edin");
//
//             string phone = Console.ReadLine();
//
//             Console.WriteLine("Tələbənin yaşadığı ünvanı daxil edin");
//
//             string address = Console.ReadLine();
//
//             var newStudent =  student.Create(id++,name, surname, birthday, phone, address);
//             students.Add(newStudent);
//             Console.WriteLine("Tələbə əlavə edildi");
//             Console.WriteLine(newStudent.Name, newStudent.Surname, newStudent.Birthday, newStudent.Phone, newStudent.Address);
//         }
//
//         void GetStudents()
//         {
//             student.GetStudents();
//         }
//         
//         void GetStudent()
//         {
//             
//         }
//         
//         void UpdateStudent()
//         {
//             
//         }
//         
//         void DeleteStudent()
//         {
//             
//         }
//     }
// }
//
//
// // List<string> animals = [];
// //
// // while (true)
// // {
// //     Console.WriteLine("1. Yeni heyvan əlavə et");
// //     Console.WriteLine("2. Mövcud heyvanları göstər");
// //     Console.WriteLine("3. Mövcud heyvanı göstər");
// //     Console.WriteLine("4. Mövcud heyvanı yenilə");
// //     Console.WriteLine("5. Mövcud heyvanı sil");
// //     Console.WriteLine("6. Çıxış");
// //     Console.Write("Seçiminiz: ");
// //     var choice = Console.ReadLine();
// //
// //     switch (choice)
// //     {
// //         case "1":
// //             CreateAnimal();
// //             break;
// //         case "2":
// //             GetAnimals();
// //             break;
// //         case "3":
// //             GetAnimal();
// //             break;
// //         case "4":
// //             UpdateAnimal();
// //             break;
// //         case "5":
// //             DeleteAnimal();
// //             break;
// //         case "6":
// //             return;
// //         default:
// //             Console.WriteLine("Düzgün seçim edin.");
// //             break;
// //     }
// // }
// //
// // void CreateAnimal()
// // {
// //     Console.Write("Heyvanın adını daxil edin: ");
// //     var name = Console.ReadLine();
// //
// //     if (string.IsNullOrWhiteSpace(name))
// //     {
// //         Console.Write("Heyvanın adını düzgün daxil edin: ");
// //     }
// //     else if (animals.Contains(name))
// //     {
// //         Console.WriteLine("Heyvan artıq mövcuddur.");
// //         return;
// //     }
// //     else
// //     {
// //         animals.Add(name);
// //     }
// //
// // }
// //
// //
// // void GetAnimals()
// // {
// //     if (animals.Count == 0)
// //     {
// //         Console.WriteLine("Siyahı boşdur.");
// //         return;
// //     }
// //     foreach (var animal in animals)
// //     {
// //         Console.WriteLine(animal);
// //     }
// // }
// //
// // void GetAnimal()
// // {
// //     Console.Write("Heyvanın adını daxil edin: ");
// //     var name = Console.ReadLine();
// //
// //     if (string.IsNullOrWhiteSpace(name))
// //     {
// //         Console.WriteLine("Heyvanın adını daxil edin.");
// //         return;
// //     }
// //     if (!animals.Contains(name))
// //     {
// //         Console.WriteLine("Heyvan tapılmadı.");
// //         return;
// //     }
// //
// //     Console.WriteLine(name);
// // }
// //
// // void UpdateAnimal()
// // {
// //     Console.Write("Heyvanın köhnə adını daxil edin: ");
// //     var oldName = Console.ReadLine();
// //
// //     if (string.IsNullOrWhiteSpace(oldName))
// //     {
// //         Console.WriteLine("Heyvanın adını düzgun daxil edin.");
// //         return;
// //     }
// //
// //     if (!animals.Contains(oldName))
// //     {
// //         Console.WriteLine("Heyvan tapılmadı.");
// //         return;
// //     }
// //
// //     Console.Write("Yeni heyvanın adını daxil edin: ");
// //     var newName = Console.ReadLine();
// //
// //     if (string.IsNullOrEmpty(newName))
// //     {
// //         Console.WriteLine("Heyvanın adını daxil edin.");
// //         return;
// //     }
// //
// //     if (animals.Contains(newName))
// //     {
// //         Console.WriteLine("Heyvan artıq mövcuddur.");
// //         return;
// //     }
// //
// //     var index = animals.IndexOf(oldName);
// //     animals[index] = newName;
// // }
// //
// // void DeleteAnimal()
// // {
// //     Console.Write("Silmək istədiyiniz heyvanın adını daxil edin: ");
// //     var name = Console.ReadLine();
// //
// //     if (string.IsNullOrWhiteSpace(name))
// //     {
// //         Console.WriteLine("Heyvanın adını düzgün daxil edin.");
// //         return;
// //     }
// //
// //     if (!animals.Contains(name))
// //     {
// //         Console.WriteLine("Heyvan tapılmadı.");
// //         return;
// //     }
// //
// //     animals.Remove(name);
// // }

#endregion


#region Lab

/*

# Kitabxana İdarəetmə Sistemi

   Bu sistem kitabxana işlərinin idarə edilməsini asanlaşdırmaq üçün hazırlanmış bir proqramdır.

   ## Siniflər

   ### `Book` Sinifi

   Bu sinif kitablar haqqında əsas məlumatları saxlayır.

   #### Xüsusiyyətlər

   - `Name`: Kitabın adı
   - `AuthorName`: Müəllifin adı
   - `PageCount`: Səhifə sayı
   - `Price`: Qiymət
   - `Code`: Kitabın kodu (Kitabın adının baş hərfləri və sıra nömrəsi)

   ### `Library` Sinifi

   Bu sinif kitabxananın əsas funksiyalarını idarə edir.

   #### Xüsusiyyətlər

   - `Books`: `Book` obyektlərinin siyahısı

   #### Metodlar

   - `AddBook()`: Kitabxanaya yeni kitab əlavə edir.
   - `GetBook()`: Verilən şərtlərə uyğun kitabı qaytarır.
   - `FindAllBooks()`: Verilən şərtlərə uyğun bütün kitabları qaytarır.
   - `RemoveAllBooks()`: Verilən şərtlərə uyğun kitabları silir və silinən kitabların sayını qaytarır.

   ### `Order` Sinifi

   Bu sinif satış proseslərini idarə edir.

   #### Xüsusiyyətlər

   - `Id`: Sifarişin identifikasiya nömrəsi
   - `Books`: Sifariş olunan kitabların siyahısı
   - `TotalPrice`: Ümumi qiymət
   - `Date`: Sifariş tarixi

   #### Metodlar

   - Satış prosesini həyata keçirən metod: Sifariş olunan kitabların qiymətlərini hesablayır.

   ## İstifadə Qaydası

   Kitabxana sistemi ilə işləmək üçün əvvəlcə `Library` obyekti yaradın, sonra lazım olan `Book` obyektlərini əlavə edin. Sifariş yaratmaq üçün `Order` obyekti yaradaraq lazımi kitabları əlavə edin və ümumi qiyməti hesablayın.

 */





#endregion

