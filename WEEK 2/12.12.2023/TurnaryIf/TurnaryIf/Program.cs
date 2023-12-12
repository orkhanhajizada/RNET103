void Sample1()
{
    bool result = true;

    Console.WriteLine(result ? "true" : "false");
}

// Sample1();

// void CalculateTaxAndCredit()
// {
//     Console.WriteLine("Please enter your yearly income: ");
//     var yearlyIncome = int.Parse(Console.ReadLine() ?? string.Empty);
//
//     if (yearlyIncome < 0)
//     {
//         Console.WriteLine("Yearly income must be greater than 0");
//         CalculateTaxAndCredit();
//     }
//
//     int creditRaiting;
//     while (true)
//     {
//         Console.WriteLine("Please enter your credit raiting: ");
//         creditRaiting = int.Parse(Console.ReadLine() ?? string.Empty);
//
//         if (creditRaiting is >= 0 and <= 850)
//         {
//             break;
//         }
//
//         Console.WriteLine("Credit raiting must be between 0 and 850");
//     }
//
//
//     int debtAmount;
//     while (true)
//     {
//         Console.WriteLine("Please enter your debt amount: ");
//         debtAmount = int.Parse(Console.ReadLine() ?? string.Empty);
//
//         if (debtAmount >= 0)
//         {
//             break;
//         }
//
//         Console.WriteLine("Debt amount must be greater than 0 or equal to 0");
//     }
//
//     var message = yearlyIncome > 50000 && creditRaiting > 700 && debtAmount == 0 
//         ? "Credit approved" : "Credit denied";
//     Console.WriteLine(message);
//
//     var tax = yearlyIncome switch
//     {
//         < 20000 => yearlyIncome * 0.1,
//         < 50000 => yearlyIncome * 0.2,
//         _ => yearlyIncome * 0.3
//     };
//
//     Console.WriteLine($"Tax: {tax}");
// }
//
// CalculateTaxAndCredit();


// CalculateTaxAndCredit();
// return;

int GetUserInput(string message, int min, int max)
{
    int value;
    do
    {
        Console.WriteLine(message);
        value = int.Parse(Console.ReadLine() ?? string.Empty);
    } while (value < min || value > max);

    return value;
}

void CalculateTaxAndCredit()
{
    var yearlyIncome = GetUserInput("Please enter your yearly income: ", 0, int.MaxValue);
    var creditRating = GetUserInput("Please enter your credit rating: ", 0, 850);
    var debtAmount = GetUserInput("Please enter your debt amount: ", 0, int.MaxValue);

    var message = yearlyIncome > 50000 && creditRating > 700 && debtAmount == 0
        ? "Credit approved" : "Credit denied";
    Console.WriteLine(message);

    var tax = CalculateTax(yearlyIncome);
    Console.WriteLine($"Tax: {tax}");
}

double CalculateTax(int income)
{
    return income switch
    {
        < 20000 => income * 0.1,
        < 50000 => income * 0.2,
        _ => income * 0.3
    };
}





