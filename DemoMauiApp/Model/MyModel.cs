using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace DemoMauiApp.Model
{
    public class MyModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string thumbnail { get; set; }

        public string Brand { get; set; }
        /*public int Population { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }*/
    }

    [JsonSerializable(typeof(List<MyModel>))]
    internal sealed partial class MyModelContext : JsonSerializerContext
    {

    }
}
