

string name = "Orkhan";
















#region MyRegion
// void PassByValue(int number)
// {
//     number = 10;
//     Console.WriteLine(number);
// }
//
//
// //ref keyword
// void PassByReference(ref int number)
// {
//     number = 10;
//     Console.WriteLine(number);
// }

//
// var originalNumber = 5;
//
// PassByValue(originalNumber);
// Console.WriteLine(originalNumber); // 5
// PassByReference(ref originalNumber);
// Console.WriteLine(originalNumber); // 10


//out keyword

// int _toplamSonucu = 0;
// int _carpimSonucu = 0;
//
// void Hesapla(int n1, int n2)
// {
//     int toplam = n1 + n2;
//     int carpim = n1 * n2;
//     _toplamSonucu = toplam;
//     _carpimSonucu = carpim;
//     Console.WriteLine($"Toplam: {toplam} - Çarpım: {carpim}");
// }
//
// Hesapla(2,3);
// int toplamSonucu = _toplamSonucu;
// int carpimSonucu = _carpimSonucu;
// Console.WriteLine($"Toplam Sonucu: {toplamSonucu} - Çarpım Sonucu: {carpimSonucu}");


// Calculate(5, 3, out var sumResult, out var multiplyResult, out var moodResult, out var divisionResult);
//
// Console.WriteLine($"Sum: {sumResult} - Multiply: {multiplyResult} - Mood: {moodResult} - Division: {divisionResult}");
// return;
//
// void Calculate(int a, int b, out int sum, out int multiply, out int mood, out double division)
// {
//     sum = a + b;
//     multiply = a * b;
//     mood = a % b;
//     division = (double)a / b;
// }

// params 

// Hesap(new[] {1,2,3,4,5,6,7,8,9,10});
// Hesap(1,2,3,4,5,6,7,8,9,10);
// return;
//
// void Hesap(params double[] numbers)
// {
//     Console.WriteLine($"Toplam: {numbers.Sum()}");
// }


// var toplam = Topla(5, 3);
// return;
//
// int Topla(int a, int b)
// {
//     return a + b;
// }


// long phoneNumber = Convert.ToInt64(Console.ReadLine());

// var phoneNumber = Console.ReadLine();
//
// while (true)
// {
//     Console.WriteLine(ConvertToLong(phoneNumber));
// }
//
// long ConvertToLong(string phoneNumber)
// {
//     try
//     {
//         return Convert.ToInt64(phoneNumber);
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine("Lütfen geçerli bir telefon numarası giriniz.");
//     }
//
// }


// if (long.TryParse(Console.ReadLine(), out var phoneNumber))
//     Console.WriteLine(phoneNumber);
// else
//     Console.WriteLine("Lütfen geçerli bir telefon numarası giriniz.");

// List<string> animals = new();
// ## Methods
//
// 1. `CreateAnimal(string ad)`: Yeni bir hayvan əlavə edir.
// 2. `GetAnimals()`: Mövcud hayvan siyahısını göstərir.
// 3. `GetAnimal(string ad)`: Siyahıdan müəyyən bir hayvanı göstərir.
// 4. `UpdateAnimal(string köhnəAd, string yeniAd)`: Mövcud hayvanın məlumatlarını yeniləyir.
// 5. `DeleteAnimal(string ad)`: Siyahıdan müəyyən bir hayvanı silir.
//     Validations
//     Daxil Edilən Məlumatların Doğrulanması: Boş məlumatlar qəbul edilmir və istifadəçiyə uyğun xəta mesajı göstərilir.
//     Yaş Kontrolü: Heyvanın yaşı məntiqsiz dərəcədə yüksək və ya mənfi olmamalıdır.
//     Tək Ad Kontrolü: Hər bir heyvanın adı fərqli olmalıdır. Eyni adda bir heyvan əlavə edilməyə çalışıldıqda xəta mesajı verilir.
//     Mövcud Olmayan Hayvan Kontrolü: Yeniləmə və silmə əməliyyatlarında siyahıda olmayan bir heyvan adı daxil edildikdə xəta mesajı göstərilir.

// List<string> animals = [];
//
// while (true)
// {
//     Console.WriteLine("1. Yeni heyvan əlavə et");
//     Console.WriteLine("2. Mövcud heyvanları göstər");
//     Console.WriteLine("3. Mövcud heyvanı göstər");
//     Console.WriteLine("4. Mövcud heyvanı yenilə");
//     Console.WriteLine("5. Mövcud heyvanı sil");
//     Console.WriteLine("6. Çıxış");
//     Console.Write("Seçiminiz: ");
//     var choice = Console.ReadLine();
//
//     switch (choice)
//     {
//         case "1":
//             CreateAnimal();
//             break;
//         case "2":
//             GetAnimals();
//             break;
//         case "3":
//             GetAnimal();
//             break;
//         case "4":
//             UpdateAnimal();
//             break;
//         case "5":
//             DeleteAnimal();
//             break;
//         case "6":
//             return;
//         default:
//             Console.WriteLine("Düzgün seçim edin.");
//             break;
//     }
// }
//
// void CreateAnimal()
// {
//     Console.Write("Heyvanın adını daxil edin: ");
//     var name = Console.ReadLine();
//
//     if (string.IsNullOrWhiteSpace(name))
//     {
//         Console.Write("Heyvanın adını düzgün daxil edin: ");
//     }
//     else if (animals.Contains(name))
//     {
//         Console.WriteLine("Heyvan artıq mövcuddur.");
//         return;
//     }
//     else
//     {
//         animals.Add(name);
//     }
//
// }
//
//
// void GetAnimals()
// {
//     if (animals.Count == 0)
//     {
//         Console.WriteLine("Siyahı boşdur.");
//         return;
//     }
//     foreach (var animal in animals)
//     {
//         Console.WriteLine(animal);
//     }
// }
//
// void GetAnimal()
// {
//     Console.Write("Heyvanın adını daxil edin: ");
//     var name = Console.ReadLine();
//
//     if (string.IsNullOrWhiteSpace(name))
//     {
//         Console.WriteLine("Heyvanın adını daxil edin.");
//         return;
//     }
//     if (!animals.Contains(name))
//     {
//         Console.WriteLine("Heyvan tapılmadı.");
//         return;
//     }
//
//     Console.WriteLine(name);
// }
//
// void UpdateAnimal()
// {
//     Console.Write("Heyvanın köhnə adını daxil edin: ");
//     var oldName = Console.ReadLine();
//
//     if (string.IsNullOrWhiteSpace(oldName))
//     {
//         Console.WriteLine("Heyvanın adını düzgun daxil edin.");
//         return;
//     }
//
//     if (!animals.Contains(oldName))
//     {
//         Console.WriteLine("Heyvan tapılmadı.");
//         return;
//     }
//
//     Console.Write("Yeni heyvanın adını daxil edin: ");
//     var newName = Console.ReadLine();
//
//     if (string.IsNullOrEmpty(newName))
//     {
//         Console.WriteLine("Heyvanın adını daxil edin.");
//         return;
//     }
//
//     if (animals.Contains(newName))
//     {
//         Console.WriteLine("Heyvan artıq mövcuddur.");
//         return;
//     }
//
//     var index = animals.IndexOf(oldName);
//     animals[index] = newName;
// }
//
// void DeleteAnimal()
// {
//     Console.Write("Silmək istədiyiniz heyvanın adını daxil edin: ");
//     var name = Console.ReadLine();
//
//     if (string.IsNullOrWhiteSpace(name))
//     {
//         Console.WriteLine("Heyvanın adını düzgün daxil edin.");
//         return;
//     }
//
//     if (!animals.Contains(name))
//     {
//         Console.WriteLine("Heyvan tapılmadı.");
//         return;
//     }
//
//     animals.Remove(name);
// }

#endregion


