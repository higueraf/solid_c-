using System;

namespace Solid1SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of Wine
            Wine wine = new Wine("Casillero del Diablo", "Viña Concha y Toro");
            // Create an instance of WineDB and pass it the instance of Wine
            WineDB wineDB = new WineDB(wine);
            // Call the Save() method of WineDB
            wineDB.Save();
            // Create an instance of WineRequest and pass it the instance of Wine
            WineRequest wineRequest = new WineRequest(wine);
            // Call the Send() method of WineRequest
            wineRequest.Send();
        }
    }

    public class Wine
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public Wine(string Name, string Brand)
        {
            this.Name = Name;
            this.Brand = Brand;
        }
    }

    public class WineDB
    {
        private Wine _wine;
        public WineDB(Wine wine)
        {
            _wine = wine;
        }
        public void Save()
        {
            Console.WriteLine($"Saved {_wine.Name} and {_wine.Brand}");
        }
    }

    public class WineRequest
    {
        private Wine _wine;
        public WineRequest(Wine wine)
        {
            _wine = wine;
        }
        public void Send()
        {
            Console.WriteLine($"Sent {_wine.Name} and {_wine.Brand}");
        }
    }
}
