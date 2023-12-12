void Sample1()
{
    string userName = "admin";

    if (userName == "admin")
    {
        Console.WriteLine("Welcome Admin");
    }
    else
    {
        Console.WriteLine("Welcome Guest");
    }
}

// Sample1();


void Sample2()
{
    var number = int.Parse(Console.ReadLine() ?? string.Empty);

    if (number is > 100 or < 0)
    {
        Console.WriteLine("Invalid Number " + number);
    }
    else
    {
        Console.WriteLine("Valid Number " + number);
    }
}

// Sample2();


void Sample3()
{
    Console.WriteLine("Enter number ");
    var number = int.Parse(Console.ReadLine() ?? string.Empty);

    if (number is >= 0 and <= 100)
    {
        Console.WriteLine("Valid Number " + number);
    }
    else
    {
        Console.WriteLine("Invalid Number " + number);
        Sample3();
    }
}

// Sample3();


void Sample4()
{
    Console.WriteLine("Enter number ");
    var number = int.Parse(Console.ReadLine() ?? string.Empty);

    if (number >= 0 && number <= 100)
    {
        if (number <= 30)
        {
            Console.WriteLine("FF " + number);
        }
        else if (number <= 50)
        {
            Console.WriteLine("DD " + number);
        }
        else if (number <= 70)
        {
            Console.WriteLine("CC " + number);
        }
        else if (number <= 84)
        {
            Console.WriteLine("BB " + number);
        }
        else
        {
            Console.WriteLine("AA " + number);
        }
    }
    else
    {
        Console.WriteLine("Invalid Number " + number);
        Sample4();
    }
}

// Sample4(); 

/////Switch Case/////


void Sample5()
{
    Console.WriteLine("Enter username ");

    var userName = Console.ReadLine() ?? string.Empty;

    switch (userName)
    {
        case ("admin"):
            Console.WriteLine("Welcome Admin Panel");
            break;
        case ("user"):
            Console.WriteLine("Welcome User Panel");
            break;
        default:
            Console.WriteLine("Invalid User");
            break;
    }
}
// Sample5();


void Sample6()
{
    Console.WriteLine("Enter number ");
    var number = int.Parse(Console.ReadLine() ?? string.Empty);

    switch (number)
    {
        case >= 0 and <= 100:
            switch (number)
            {
                case <= 30:
                    Console.WriteLine("FF " + number);
                    break;
                case <= 50:
                    Console.WriteLine("DD " + number);
                    break;
                case <= 70:
                    Console.WriteLine("CC " + number);
                    break;
                case <= 84:
                    Console.WriteLine("BB " + number);
                    break;
                default:
                    Console.WriteLine("AA " + number);
                    break;
            }

            break;
        default:
            Console.WriteLine("Invalid Number " + number);
            Sample6();
            break;
    }
}

// Sample6();


void Sample7()
{
    //Renkler -> Siyah, Kırmızı,Yeşil,Sarı,Mavi, Pembem
    //Colors -> Black, Red, Green, Yellow, Blue, Pink

    Console.WriteLine("Enter color name ");

    var colorName = Console.ReadLine() ?? string.Empty;

    // switch (colorName)
    // {
    //     case "Siyah":
    //         Console.WriteLine("Black");
    //         break;
    //     case "Kırmızı":
    //         Console.WriteLine("Red");
    //         break;
    //     case "Yeşil":
    //         Console.WriteLine("Green");
    //         break;
    //     case "Sarı":
    //         Console.WriteLine("Yellow");
    //         break;
    //     case "Mavi":
    //         Console.WriteLine("Blue");
    //         break;
    //     case "Pembe":
    //         Console.WriteLine("Pink");
    //         break;
    //     default:
    //         Console.WriteLine("Invalid Color");
    //         break;
    // }

    var result = colorName switch
    {
        "Siyah" => "Black",
        "Kırmızı" => "Red",
        "Yeşil" => "Green",
        "Sarı" => "Yellow",
        "Mavi" => "Blue",
        "Pembe" => "Pink",
        _ => "Invalid Color"
    };
    Console.WriteLine(result);
}

// Sample7();


void Sample8()
{
    string userName = "admin";
    string password = "123";

    switch (userName, password)
    {
        case ("admin","123"):
            Console.WriteLine("Login Success");
            break;
        
        default:
            Console.WriteLine("Login Failed");
            break;
    }
}