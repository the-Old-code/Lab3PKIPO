using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace DataHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler json = new JsonDataHandler();
            json.Read(@"D:\labs\Проектирование ПО\response_1668000415288.json");
            json.Run();
            json.Print();
            //string dat = "2022-11-03T03:02:39.606573";
            //-string dat = "03.11.2022 03:02:39";
            //DateTime date = DateTime.ParseExact(dat, "yyyy-MM-ddTHH:mm:ss.FFFFFF", CultureInfo.InvariantCulture);
            //-DateTime date = DateTime.ParseExact(dat, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //-Console.WriteLine(date);
        }
    }
}
