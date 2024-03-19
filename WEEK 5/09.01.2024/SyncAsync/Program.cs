using System.Diagnostics;

namespace SyncAsync;

public class Program
{
    // internal class Bacon
    // {
    // }
    //
    // internal class Coffee
    // {
    // }
    //
    // internal class Egg
    // {
    // }
    //
    // internal class Juice
    // {
    // }
    //
    // internal class Toast
    // {
    // }


    #region Sync

    // public static void Main(string[] args)
    // {
    //     Coffee cup = PourCoffee();
    //     Console.WriteLine("coffee is ready");
    //
    //     Egg eggs = FryEggs(2);
    //     Console.WriteLine("eggs are ready");
    //
    //     Bacon bacon = FryBacon(3);
    //     Console.WriteLine("bacon is ready");
    //
    //     Toast toast = ToastBread(2);
    //     ApplyButter(toast);
    //     ApplyJam(toast);
    //     Console.WriteLine("toast is ready");
    //
    //     Juice oj = PourOJ();
    //     Console.WriteLine("oj is ready");
    //     Console.WriteLine("Breakfast is ready!");
    // }

    // private static Juice PourOJ()
    // {
    //     Console.WriteLine("Pouring orange juice");
    //     return new Juice();
    // }
    //
    // private static void ApplyJam(Toast toast) =>
    //     Console.WriteLine("Putting jam on the toast");
    //
    // private static void ApplyButter(Toast toast) =>
    //     Console.WriteLine("Putting butter on the toast");
    //
    // private static Toast ToastBread(int slices)
    // {
    //     for (int slice = 0; slice < slices; slice++)
    //     {
    //         Console.WriteLine("Putting a slice of bread in the toaster");
    //     }
    //
    //     Console.WriteLine("Start toasting...");
    //     Task.Delay(3000).Wait();
    //     Console.WriteLine("Remove toast from toaster");
    //
    //     return new Toast();
    // }
    //
    // private static Bacon FryBacon(int slices)
    // {
    //     Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //     Console.WriteLine("cooking first side of bacon...");
    //     Task.Delay(3000).Wait();
    //     for (int slice = 0; slice < slices; slice++)
    //     {
    //         Console.WriteLine("flipping a slice of bacon");
    //     }
    //
    //     Console.WriteLine("cooking the second side of bacon...");
    //     Task.Delay(3000).Wait();
    //     Console.WriteLine("Put bacon on plate");
    //
    //     return new Bacon();
    // } 
    //
    // private static Egg FryEggs(int howMany)
    // {
    //     Console.WriteLine("Warming the egg pan...");
    //     Task.Delay(3000).Wait();
    //     Console.WriteLine($"cracking {howMany} eggs");
    //     Console.WriteLine("cooking the eggs ...");
    //     Task.Delay(3000).Wait();
    //     Console.WriteLine("Put eggs on plate");
    //
    //     return new Egg();
    // }
    //
    // private static Coffee PourCoffee()
    // {
    //     Console.WriteLine("Pouring coffee");
    //     return new Coffee();
    // }

    #endregion


    #region Async

    // static async Task Main(string[] args)
    // {
    //     Coffee cup = PourCoffee();
    //     Console.WriteLine("coffee is ready");
    //
    //     var eggsTask = FryEggsAsync(2);
    //     var baconTask = FryBaconAsync(3);
    //     var toastTask = MakeToastWithButterAndJamAsync(2);
    //
    //     var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
    //     while (breakfastTasks.Count > 0)
    //     {
    //         Task finishedTask = await Task.WhenAny(breakfastTasks);
    //         if (finishedTask == eggsTask)
    //         {
    //             Console.WriteLine("eggs are ready");
    //         }
    //         else if (finishedTask == baconTask)
    //         {
    //             Console.WriteLine("bacon is ready");
    //         }
    //         else if (finishedTask == toastTask)
    //         {
    //             Console.WriteLine("toast is ready");
    //         }
    //
    //         await finishedTask;
    //         breakfastTasks.Remove(finishedTask);
    //     }
    //
    //     Juice oj = PourOJ();
    //     Console.WriteLine("oj is ready");
    //     Console.WriteLine("Breakfast is ready!");
    // }
    //
    // static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    // {
    //     var toast = await ToastBreadAsync(number);
    //     ApplyButter(toast);
    //     ApplyJam(toast);
    //
    //     return toast;
    // }
    //
    // private static Juice PourOJ()
    // {
    //     Console.WriteLine("Pouring orange juice");
    //     return new Juice();
    // }
    //
    // private static void ApplyJam(Toast toast) =>
    //     Console.WriteLine("Putting jam on the toast");
    //
    // private static void ApplyButter(Toast toast) =>
    //     Console.WriteLine("Putting butter on the toast");
    //
    // private static async Task<Toast> ToastBreadAsync(int slices)
    // {
    //     for (int slice = 0; slice < slices; slice++)
    //     {
    //         Console.WriteLine("Putting a slice of bread in the toaster");
    //     }
    //
    //     Console.WriteLine("Start toasting...");
    //     await Task.Delay(3000);
    //     Console.WriteLine("Remove toast from toaster");
    //
    //     return new Toast();
    // }
    //
    // private static async Task<Bacon> FryBaconAsync(int slices)
    // {
    //     Console.WriteLine($"putting {slices} slices of bacon in the pan");
    //     Console.WriteLine("cooking first side of bacon...");
    //     await Task.Delay(3000);
    //     for (int slice = 0; slice < slices; slice++)
    //     {
    //         Console.WriteLine("flipping a slice of bacon");
    //     }
    //
    //     Console.WriteLine("cooking the second side of bacon...");
    //     await Task.Delay(3000);
    //     Console.WriteLine("Put bacon on plate");
    //
    //     return new Bacon();
    // }
    //
    // private static async Task<Egg> FryEggsAsync(int howMany)
    // {
    //     Console.WriteLine("Warming the egg pan...");
    //     await Task.Delay(3000);
    //     Console.WriteLine($"cracking {howMany} eggs");
    //     Console.WriteLine("cooking the eggs ...");
    //     await Task.Delay(3000);
    //     Console.WriteLine("Put eggs on plate");
    //
    //     return new Egg();
    // }
    //
    // private static Coffee PourCoffee()
    // {
    //     Console.WriteLine("Pouring coffee");
    //     return new Coffee();
    // }

    #endregion


    #region Async example

    // static async Task Main(string[] args)
    // {
    //     Stopwatch stopwatch = new Stopwatch();
    //     stopwatch.Start();
    //     var url = new Uri("https://randomuser.me/api/?results=5000");
    //     var content = await DownloadContentAsync(url);
    //     Console.WriteLine(content);
    //     stopwatch.Stop();
    //     
    //     Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
    // }
    //
    // public static async Task<string> DownloadContentAsync(Uri url)
    // {
    //     using var client = new HttpClient();
    //     
    //     HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
    //     
    //     if(response.IsSuccessStatusCode)
    //     {
    //        string content = await response.Content.ReadAsStringAsync();
    //        return content;
    //     }
    //     else
    //     {
    //         return string.Empty;
    //     }
    // }

    #endregion

    #region Cancellation token

    // public static async Task Main(string[] args)
    // {
    //     CancellationTokenSource tokenSource = new CancellationTokenSource();
    //     CancellationToken token = tokenSource.Token;
    //     var i = 0;
    //
    //     while (i<1000000000)
    //     {
    //         await Task.Run(()=> Console.WriteLine(i), token);
    //         await Task.Delay(100, token);
    //
    //         if (i == 100)
    //         {
    //             await tokenSource.CancelAsync();
    //         }
    //
    //         Console.WriteLine(token);
    //         Interlocked.Increment(ref i);
    //         
    //     }
    // }

    #endregion

    public static async Task Main(string[] args)
    {
        await AsyncTets();
        SyncTest();
    }

    private static async Task AsyncTets()
    {
        var uris = new[]
        {
            "https://apple.com/",
            "https://microsoft.com/",
            "https://google.com/",
            "https://facebook.com/",
            "https://amazon.com/",
            "https://twitter.com/",
            "https://stackoverflow.com/"
            
        };
        
        using HttpClient client = new HttpClient();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var tasks = uris.Select(async uri =>
        {
            var response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            // Console.WriteLine(content);
        });
        
        await Task.WhenAll(tasks);
        stopwatch.Stop();
        Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms async");
    }

    private static void SyncTest()
    {
        
        var uris = new[]
        {
            "https://apple.com/",
            "https://microsoft.com/",
            "https://google.com/",
            "https://facebook.com/",
            "https://amazon.com/",
            "https://twitter.com/",
            "https://stackoverflow.com/"
            
        };
        
        using HttpClient client = new HttpClient();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        foreach (var uri in uris)
        {
            var response = client.GetAsync(uri).GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            // Console.WriteLine(content);
        }
        
        
        stopwatch.Stop();
        Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms sync");
        
    }
    
}