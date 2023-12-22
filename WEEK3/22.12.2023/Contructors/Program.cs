// See https://aka.ms/new-console-template for more information

using Contructors.Models;

Console.WriteLine("Hello, World!");


/*
 İstifadəçi İdarəetmə Sistemi
   Ümumi Baxış
   Bu sistem əsas istifadəçi idarəetmə funksiyalarını həyata keçirir, təhlükəsiz parol idarəetməsi və istifadəçi məlumatlarının göstərilməsini təmin edir.
   
   İnterfeys və Siniflər
   IAccount İnterfeysi
   PasswordChecker(): Parametr olaraq string password qəbul edir.
   
   ShowInfo(): İstifadəçi məlumatlarını göstərir.
   
   User Sinifi (IAccount-u İmplement Edir)
   Id: İstifadəçinin unikal identifikatoru.
   Fullname: İstifadəçinin tam adı.
   Email: İstifadəçinin elektron poçt ünvanı.
   Password: Şifrələnmiş parol.
   Metodlar
   PasswordChecker(): Gələn string password dəyərinin tələb olunan şərtləri ödəyib-ödəmədiyini yoxlayır və true və ya false dəyər qaytarır. Şərtlər:
   
   Parolda ən az 8 simvol olmalıdır.
   Parolda ən az bir böyük hərf olmalıdır.
   Parolda ən az bir kiçik hərf olmalıdır.
   Parolda ən az bir rəqəm olmalıdır.
   ShowInfo(): Bu metod istifadəçinin Id, Fullname və Email dəyərlərini konsola çap edir.
   
   Əlavə Tələblər
   Id dəyəri hər dəfə yeni bir istifadəçi obyekti yaradıldıqda avtomatik artmalıdır. Dəyişdirilə bilməz ancaq oxuna bilər olmalıdır.
   İstifadəçi yaradarkən Email və Parolun təyin edilməsi məcburidir.
   İstifadəçiyə təyin edilən parol, PasswordChecker metodunda göstərilən kriteriyaları ödəməlidir.
   İmplementasiya Qeydləri
   İstifadəçi məlumatlarının təhlükəsizliyini və məxfiliyini qoruyun.
   Sistem çox iş parçacıqlı istifadə üçün nəzərdə tutulubsa, iş parçacıqlı təhlükəsizliyə diqqət edin.
   Kod keyfiyyətini və genişləndirilməsini təmin etmək üçün SOLID prinsiplərinə əməl edin.
 */
while (true)
{
    var user = new User();

    Console.WriteLine("Enter your fullname");    
    var name = Console.ReadLine();

    Console.WriteLine("Enter your email");
    var email = Console.ReadLine();

    Console.WriteLine("Enter your password");
    var password = Console.ReadLine();

    if(user.PasswordChecker(password))
    {
        user.Fullname = name;
        user.Email = email;
        user.Password = password;

        Console.WriteLine("User created successfully");
        Console.WriteLine(user.ShowInfo());
    }
    else
    {
        Console.WriteLine("Password is not valid");
    }
}
 
    
    