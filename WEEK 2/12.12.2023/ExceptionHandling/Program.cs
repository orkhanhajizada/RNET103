void Sample1()
{
    Console.WriteLine("Enter your phone number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Your phone number is: " + number);
}


void Sample2()
{
    try
    {
        Console.WriteLine("Enter your phone number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Your phone number is: " + number);
    }
    catch (Exception e)
    {
        Console.WriteLine("Invalid input");
        throw;
    }
    finally
    {
    }
}

// Sample2();

//
// void Sample3()
// {
//     try
//     {
//         Console.WriteLine("Enter your phone number: ");
//         int number = Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Your phone number is: " + number);
//     }
//     catch (Exception e)
//     {
//
//         Console.WriteLine("Invalid input");
//         throw;
//     }
//     finally
//     {
//         Console.WriteLine("Finally block");
//     }
// }
//
// class NotFoundException : Exception
// {
//     public NotFoundException(string message) : base(message)
//     {
//     }
// }


AtmApp();
return;

void AtmApp()
{
    var balance = 1000;

    while (true)
    {
        Console.WriteLine("1. Pul Çıxarma");
        Console.WriteLine("2. Pul Yatırma");
        Console.WriteLine("3. Büdcə Sorğulama");
        Console.WriteLine("4. Çıxış");
        Console.Write("Seçiminizi daxil edin: ");
        var selection = Convert.ToInt32(Console.ReadLine());

        switch (selection)
        {
            case 1:
                Console.WriteLine("Çıxarmaq istədiyiniz məbləği daxil edin: ");
                var outAmount = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (outAmount < 0)
                        throw new AmountOutOfRangeException("Məbləğ 0-dan kiçik ola bilməz");


                    if (outAmount > balance)
                        throw new AmountOutOfRangeException("Büdcə yoxdur");

                    balance -= outAmount;
                    Console.WriteLine("Əməliyyat uğurla yerinə yetirildi. Cari balansınız : " + balance + " AZN");
                }
                catch (AmountOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                continue;
            
            case 2:
                Console.WriteLine("Yatırmaq istədiyiniz məbləği daxil edin: ");
                var income = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (income <= 0)
                        throw new AmountOutOfRangeException("Məbləğ 0-dan kiçik ola bilməz");
                    balance += income;
                    Console.WriteLine("Əməliyyat uğurla yerinə yetirildi Cari balansınız : " + balance + " AZN");
                }
                catch (AmountOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                continue;
            
            case 3:
                Console.WriteLine("Büdcəniz: " + balance);
                continue;
            
            case 4:
                Console.WriteLine("Çıxış");
                break;
            
            default:
                Console.WriteLine("Yalnış seçim");
                continue;
        }

        break;
    }
}

class AmountOutOfRangeException : Exception
{
    public AmountOutOfRangeException(string message) : base(message)
    {
    }
}
