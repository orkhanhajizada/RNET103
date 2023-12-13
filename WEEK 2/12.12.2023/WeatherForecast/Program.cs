using Microsoft.Extensions.Configuration;


await GetCity();


static async Task GetCity()
{
    while (true)
    {
        Console.Write("Enter the city name: ");
        var cityName = Console.ReadLine();

        if (string.IsNullOrEmpty(cityName))
        {
            Console.WriteLine("City name can not be empty.");
            continue;
        }

        // const string apiKey = "1bb300dcd9a775979470903c0afbefe3\n";
        // string json = File.ReadAllText("../../../appsettings.json");
        // JObject jsonObject = JObject.Parse(json);
        // string apiKey =  (string)jsonObject["AppSettings"]!["OpenWeatherMapApiKey"]!;

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("/Users/orkhanhajizada/Desktop/RNET103/WEEK 2/12.12.2023/WeatherForecast/appsettings.json",
                optional: true, reloadOnChange: true)
            .Build();

        var apiKey = configuration["AppSettings:OpenWeatherMapApiKey"];


        var weatherData = await GetWeatherData(cityName, apiKey!);

        if (!string.IsNullOrEmpty(weatherData))
        {
            ProcessAndDisplayWeatherData(weatherData);
        }
    }
}


static async Task<string?> GetWeatherData(string cityName, string apiKey)
{
    using var client = new HttpClient();
    try
    {
        var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

        var response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        Console.WriteLine($"Weather forecast not available. Error code: {response.StatusCode}");
        return null;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return null;
    }
}

static void ProcessAndDisplayWeatherData(string? weatherData)
{
    if (weatherData == null) return;
    dynamic jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(weatherData) ??
                       throw new InvalidOperationException();
    var temperatureKelvin = Math.Round((double)jsonData["main"]["temp"]);
    var temperature = Math.Round(temperatureKelvin - 273.15);
    var weatherDescription = jsonData.weather[0].description;
    double windSpeed = jsonData.wind.speed;


    Console.WriteLine($"Temperature: {temperature}°C");
    Console.WriteLine($"Weather forecast: {weatherDescription}");
    Console.WriteLine($"Wind speed: {windSpeed} m/s");

    GiveAdvice((int)temperature, weatherDescription, (int)windSpeed);
}


static void GiveAdvice(int temperature, string weatherDescription, int windSpeed)
{
    Console.WriteLine("Clothing advice");

    if (temperature >= 30)
    {
        Console.WriteLine("Wear light clothing, use sunscreen and a hat.");
    }
    else if (temperature is >= 20 and < 30)
    {
        Console.WriteLine("Wear light clothing.");
    }
    else if (temperature is >= 15 and < 20)
    {
        Console.WriteLine("Wear a jacket.");
    }
    else if (temperature is > 5 and < 15)
    {
        Console.WriteLine("Wear a jacket and a hat.");
    }
    else
    {
        Console.WriteLine("Dress warmly and wear non-slip shoes.");
    }

    Console.WriteLine("Activity advice");

    switch (weatherDescription.ToLower())
    {
        case var desc when desc.Contains("clear sky"):
            Console.WriteLine("It's a great day to go out and play sports.");
            break;
        case var desc when desc.Contains("clouds"):
            Console.WriteLine("You can play billiards or bowling because it might rain");
            break;
        case var desc when desc.Contains("drizzle"):
            Console.WriteLine("It's drizzling. Read a book at home or coffeshop.");
            break;
        case var desc when desc.Contains("rainy"):
            Console.WriteLine("Don't forget to take an umbrella. Great weather for indoor activities.");
            break;
        case var desc when desc.Contains("snow"):
            Console.WriteLine("It's snowing great. It's time to play snowball!");
            break;
        default:
            Console.WriteLine("Daxil etdiyiniz hava proqnozu tanınmır.");
            break;
    }

    Console.WriteLine("Wind advice");

    switch (windSpeed)
    {
        case > 20:
            Console.WriteLine("The wind is too strong, go home immediately.");
            break;
        case > 10:
            Console.WriteLine("It's windy, be careful when walking.");
            break;
        default:
            Console.WriteLine("The wind is not very strong, you can move easily.");
            break;
    }
}