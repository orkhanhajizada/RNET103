// void Sample1()
// {
//     string[] cities = new string[5];

//     cities[0] = "New York";

//     int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
//     char[] chars = { 'a' };
// }

// // Sample1();

// void Sample2()
// {
//     string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

//     Console.WriteLine(cars[new Random().Next(0, cars.Length)]);
// }

// // Sample2();


// void Sample3(){

//     var test = new string[3] { "a", "b", "c" };

//     //3cunu nece elave elemek olar?
//     System.Console.WriteLine(t.Length);

//     Array.Resize(ref test, 4);

//     Array.Resize(ref test, 5);

//     test[4] = "d";
//     System.Console.WriteLine(test.Length);
//     System.Console.WriteLine(test[4]);
// }

// // Sample3();


// void Sample4(){
//     List<string> citiest = new List<string>(){
//         "Baku",
//         "Ganja",
//         "Sumqayit"
//     };

//     citiest.Add("Shamkir");
//     citiest.Add("Shaki");

//     citiest.Remove("Shamkir");

//     citiest.RemoveAt(0);

//     citiest.Insert(0, "Baku");

//     citiest.Sort();

// }


// void Sample5()
// {
//     // Dictionary<key, value> cities = new Dictionary<key, value>();

//     Dictionary<int, string> cities = new();

//     // var dictionary = new Dictionary<string, string>();

//     // Dictionary<string, string> dictionary2 = new();

//     cities.Add(1, "Baku");
//     cities.Add(2, "Ganja");
//     cities.Add(3, "Sumqayit");

//     System.Console.WriteLine(cities[1]);

//     var _seherler = new Dictionary<string, int>(){
//         {"Baku", 1},
//         {"Ganja", 2},
//         {"Sumqayit", 3}
//     };

//     System.Console.WriteLine(_seherler["Baku"]);

//     System.Console.WriteLine(_seherler);

//     foreach (var item in _seherler)
//     {
//         System.Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//     }
// }

// Sample5();


// void Sample6()
// {

//     //for, foreach, while, do while

//     List<string> citiest = new List<string>(){
//         "Baku",
//         "Ganja",
//         "Sumqayit"
//     };

//     var _seherler = new Dictionary<string, int>(){
//         {"Baku", 1},
//         {"Ganja", 2},
//         {"Sumqayit", 3}
//     };

//     // for (int i = 0; i < citiest.Count; i++)
//     // {
//     //     System.Console.WriteLine("for: " + citiest[i]);
//     // }


//     //sonsuz dongu
//     // for(;;){
//     //     System.Console.WriteLine("for: ");
//     // }

//     //tERSDEN ISHLEYEN FOR
//     // for (int i = 1000 - 1; i >= 0 ; i--)
//     // {
//     //     System.Console.WriteLine(i);
//     // }


//     //while -> for dongusunun parcalanmis versiyasidir, true false ile ishleyir

//     // int i = 0;
//     // while (i < citiest.Count)
//     // {
//     //     System.Console.WriteLine("while: " + citiest[i]);
//     //     i++;
//     // }

//     // while(true){
//     //     System.Console.WriteLine("while: "); //sonsuz dongu
//     // }


//     // foreach (var item in citiest)
//     // {
//     //     System.Console.WriteLine("foreach: " + item);
//     // }


//     //break (sonlandirir),  
//     //continue (sonraki iterasiyaya kecir (meselen dongu ichindedirse onu sonrandirib novbeti indexe kechir kecir)),
//     //return  yapiyi sonlandirir - method, function, class, program,struct,enum,interface. istifade edildikde bunlar sonlanmish olur
//     //goto -  


//     //do while -> while`in tersidir, once isleyir sonra shert yoxlanilir

//     int i = 0;
//     do
//     {
//         System.Console.WriteLine("do while: " + citiest[i]);
//         i++;
//     } while (i < citiest.Count);


//     foreach (KeyValuePair<string, int> item in _seherler)
//     {
//         System.Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
//     }
// }

// Sample6();


// void Sample7()
// {
//     List<string> cities = new List<string>() { "Ankara", "İstanbul" };
//     cities.Add("Bursa");
//     cities.Add("İzmir");
//     cities.Add("Antalya");
//     cities.Add("Adana");
//     cities.Add("Trabzon");
//     cities.Add("Samsun");
//     cities.Add("Konya");
//     cities.Add("Kayseri");
//     cities.Add("Kocaeli");
//     cities.Add("Diyarbakır");
//     cities.Add("Gaziantep");
//     cities.Add("Şanlıurfa");
//     cities.Add("Mersin");
//     cities.Add("Malatya");
//     cities.Add("Kahramanmaraş");
//     cities.Add("Erzurum");
//     cities.Add("Eskişehir");

//     cities.IndexOf("Ankara");

//     foreach (var item in cities.Select((value, index) => new { Index = index, Value = value }))
//     {
//         Console.WriteLine($"Index: {item.Index}, Value: {item.Value}");
//     }
// }


// Sample7();


// void Sample8()
// {
//     string[] cities =
//     {"New York",
//     "Paris",
//     "London",
//     "Sydney",
//     "Cairo",
//     "London",
//     "Moscow",
//     "Toronto",
//     "Mumbai",
//     "Rome"};

//     // var duplicates = cities.GroupBy(x => x.ToLower());
//     // foreach (var city in duplicates)
//     // {
//     //     if (city.Count() > 1)
//     //     {
//     //         Console.WriteLine(city.Key + " " + city.Count());

//     //     }
//     // }

//     // var duplicates = cities
//     // .GroupBy(x => x.ToLower())
//     // .Where(group => group.Count() > 1)
//     // .Select(group => $"{group.Key} {group.Count()}")
//     // .ToList();

//     // Console.WriteLine(string.Join(Environment.NewLine, duplicates));

//     string param = "London";

//     int index = Array.IndexOf(cities, param);
//     int lastIndex = Array.LastIndexOf(cities, param);

//     if (index != lastIndex)
//     {
//         System.Console.WriteLine($"{param} Duplicate");
//     }
//     else
//     {
//         System.Console.WriteLine($"{param} Not Duplicate");
//     }

// }

// Sample8();


Sample9();

void Sample9()
{
    var name = Console.ReadLine();

    if(string.IsNullOrEmpty(name)){
        Console.WriteLine("Name is empty");
        return;
    }

    var result = name.ToLower().GroupBy(x => x)
        .Select(x => new { x.Key, Count = x.Count() });

    Console.WriteLine(string.Join(Environment.NewLine, result));

    // foreach (var item in result)
    // {
    //     Console.WriteLine($"Key: {item.Key}, Count: {item.Count}");
    // }
}