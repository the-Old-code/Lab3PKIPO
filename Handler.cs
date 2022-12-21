using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace DataHandling
{
    struct Dataset 
    {
        public double value;
        public DateTime date;
        public Dataset(string date, double value) 
        {
            this.date = DateTime.ParseExact(date, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture); 
            this.value = value; 
        }

    }
    
    abstract class Handler
    {
        public abstract void Read(string path);
        public abstract void Run();
        public abstract void Print();
    }

    class TxtDataHandler : Handler 
    {
        List<Dataset> dataset = new List<Dataset>();
        List<Dataset> result;

        public override void Read(string path)
        {
            string TxtString = File.ReadAllText(path);
            
        }

        public override void Run()
        {
            result = new List<Dataset>(dataset);
            result.Sort((x, y) => DateTime.Compare(x.date, y.date));
            //result.Sort((x, y) => x.value.CompareTo(y.value));
        }

        public override void Print()
        {
            foreach (var item in result)
            {
                Console.WriteLine("{0,-15} {1,-20}", item.value, item.date);
            }
        }
    }

    class JsonDataHandler : Handler
    {
        List<Dataset> dataset = new List<Dataset>();
        List<Dataset> result;
        public override void Read(string path) 
        {
            string jsonString = File.ReadAllText(path);
            // Convert the JSON string to a JObject:
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonString);
            foreach (var item in jsonObj)
            {
                dataset.Add(new Dataset(Convert.ToString(item["dt1"]), Convert.ToDouble(item["d1"])));
            }
            
        }
        public override void Run() 
        {
            result = new List<Dataset>(dataset);
            result.Sort((x, y) => DateTime.Compare(x.date, y.date));
            //result.Sort((x, y) => x.value.CompareTo(y.value));
        }
        public override void Print()
        {
            foreach (var item in result)
            {
                Console.WriteLine("{0,-15} {1,-20}", item.value, item.date);
            }
        }
    }
}
