// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;

namespace OOPDelegate;

// public interface ILogger
// {
//     void Log(string message);
// }
//
// public class SmsLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("SMS gonderildi -> " + message);
//     }
// }
//
// public class DatabaseLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("Database kaydedildi -> " + message);
//     }
// }
//
// public class MailLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("Mail gonderildi -> " +message);
//     }
// }
//
// public class XmlLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("XML kaydedildi -> " +message);
//     }
// }
//
// public class TextFileLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("Text kaydedildi -> " +message);
//     }
// }
//
// public class NotificationLogger : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine("NotificationLogger kaydedildi -> " + message);
//     }
// }

public class Employee
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
}

public class Program
{
    // static Action<string> SmsLog = message => new SmsLogger().Log(message);
    // static Action<string> DatabaseLog = message => new DatabaseLogger().Log(message);
    // static Action<string> MailLog = message => new MailLogger().Log(message);
    // static Action<string> XmlLog = message => new XmlLogger().Log(message);
    // static Action<string> TextFileLog = message => new TextFileLogger().Log(message);
    // static Action<string> NotificationLog = message => new NotificationLogger().Log(message);
    //
    // public delegate void LogSystem(string message);
    // public delegate void LogSystemByUser(string message, Guid id);
    // public delegate void LogSystemTime(string message, DateTime dateTime);
    
    public static  class GenericMethods
    {
        public static string CreateUrl(string url)
        {
            return url.ToLower().Replace("", "-")
                .Replace("ş", "s")
                .Replace("?", "");
        }
    }

    public static void Main()
    {
        #region Delegate

        // 1ci usul beledir

        // ILogger[] loggers =
        // {
        //     new DatabaseLogger(),
        //     new MailLogger(),
        //     new SmsLogger(),
        //     new XmlLogger(),
        //     new TextFileLogger()
        //     new NotificationLogger()
        // };
        //
        // foreach (var logger in loggers)
        // {
        //     logger.Log("Log mesaji");
        // }

        // 2ci usul

        // var actionLogs = new Action<string>[]
        // {
        //     SmsLog,
        //     XmlLog,
        //     MailLog,
        //     DatabaseLog,
        //     TextFileLog,
        //     NotificationLog
        // };
        //
        // foreach (var log in actionLogs)
        // {
        //     log("Log mesaji");
        // }

        // Action<string> Level5 = new Action<string>(SmsLog);
        // Level5 += XmlLog;
        // Level5 += MailLog;
        // Level5 += SmsLog;
        // Level5 += DatabaseLog;
        // Level5 += TextFileLog;
        // Level5 += NotificationLog;
        //
        // Level5("log mesaji");
        //
        //
        // Action<string> Level1 = new Action<string>(SmsLog);
        // Level1 += XmlLog;
        // Level1 += DatabaseLog;
        //
        //
        //
        // Level1("log mesaji");


        // 3cu usul

        // LogSystem logSystemL1 = new LogSystem(SmsLog);
        // logSystemL1 += new MailLogger().Log;
        // logSystemL1 += new NotificationLogger().Log;
        // logSystemL1("Log mesaji");

        #endregion
        
        #region Expression
        
        // // 1 example
        // Expression<Func<int, int>> square = num => num * num;
        //
        // Func<int, int> result = square.Compile();
        //
        // Console.WriteLine(result(5));
        //
        //
        // //2 example
        // Expression<Func<int, int, bool>> IsGreaterThan = (n1, n2) => n1 > n2;
        //
        // var IsGreaterThanResult = IsGreaterThan.Compile();
        //
        // Console.WriteLine(IsGreaterThanResult(10, 4));
        //
        // // void IsGreater(int a, int b, out bool result) => result = a > b;
        //
        //
        // Expression<Func<Employee, bool>> IsAdultExpression = e => e.Age >= 18;
        //
        // if (IsAdultExpression.Body is BinaryExpression binaryExpression)
        // {
        //     Console.WriteLine(binaryExpression);
        //     Console.WriteLine(binaryExpression.Left);
        //     Console.WriteLine(binaryExpression.Right);
        //     Console.WriteLine(binaryExpression.NodeType);
        // }
        //
        //
        // List<string> list = new List<string>();
        //
        // list.Add("Code Academy");
        // list.Add("Code1 Academy");
        // list.Add("Code1ş Academy");
        //
        // Func<string, bool> customExpression = x =>
        //     x.ToLower().Replace("ş", "s").Contains("code");
        //
        // var newList = list.Where(customExpression).ToList();
        //
        // foreach (var item in newList) Console.WriteLine(item);
        //
        // var intList = new List<string>
        // {
        //     "5",
        //     "10",
        //     "20",
        //     "30",
        //     "40"
        // };
        //
        // Func<List<string>, List<int>> convertToInt = x => x.ConvertAll(int.Parse).ToList();
        //
        // var newlist = convertToInt(intList);
        //
        // Console.WriteLine(newlist);
        //
        //
        // Console.Clear();
        //
        //
        // var list2 = new List<int>();
        // var rand = new Random();
        //
        // list2.AddRange(Enumerable.Range(0, 250)
        //     .OrderBy(i => rand.Next())
        //     .Take(5));
        //
        // foreach (var item in list2)
        // {
        //     Console.WriteLine(item);
        // }
        
        #endregion

        string productName = "test prosuct";
        var url = "";

        Convert.ToString(productName);




    }
}