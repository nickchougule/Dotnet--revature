// string name = null;

// var defaultname= name ?? "Nik";

// var istrue=1 ==1;

// Console.WriteLine($"{defaultname}");

// return;

// var logger1= singletonLogger.CreateStaticLogger();
// var logger2= singletonLogger.CreateStaticLogger();
// var logger3= singletonLogger.CreateStaticLogger();

// Console.WriteLine(logger1.GetHashCode());
// Console.WriteLine(logger2.GetHashCode());
// Console.WriteLine(logger3.GetHashCode());
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<DISingleton>();

var serviceProvider= services.BuildServiceProvider();

var diLogger1 = serviceProvider.GetService<DISingleton>();
var diLogger2= serviceProvider.GetService<DISingleton>();
var dilogger3= new DISingleton();

Console.WriteLine(diLogger1.GetHashCode());
Console.WriteLine(diLogger2.GetHashCode());
Console.WriteLine(dilogger3.GetHashCode());

public class DISingleton
{
    public int value{get;set;}
}

// public class singletonLogger
// {
//     private static singletonLogger ? singletonInstance;

//     private singletonLogger(){}

//     public static singletonLogger CreateStaticLogger()
//     {
//         lock (typeof(singletonLogger))
//         {
//             if (singletonInstance == null)
//         {
            
//             singletonInstance= new singletonLogger();
//         }
//         }

//         return singletonInstance;
//     }
    
// }