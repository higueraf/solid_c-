using Solid2Ocp;
using System;
using System.Net;
using System.Numerics;


namespace Solid2Ocp
{
    class Program
    {
        static void Main(string[] args)
        {
            // LisPrinciple
            // Open for extension but closed for modification

            // Fake data
            var sedan = new Sedan { Model = "Toyota Camry", Price = 25000, Invoice = 0.9m };
            var van = new Van { Model = "Ford Transit", Price = 30000, Invoice = 0.85m, Promo = 1000 };
            var truck = new Truck { Model = "Chevrolet Silverado", Price = 40000, Invoice = 0.95m, Traction = 1500 };
            // Create a list of vehicles
            var vehicles = new List<IVehicle> { sedan, van, truck };
            // Create an instance of the Invoice class to calculate the total
            var invoiceCalculator = new Invoice();
            // Calculate the total
            var total = invoiceCalculator.GetTotal(vehicles);
            // Display the total
            Console.WriteLine($"Total Invoice: {total:C}");
        }
    }
    public interface IVehicle
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal GetPrice();
    }
    public class Sedan : IVehicle
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal GetPrice()
        {
            return Price * Invoice;
        }
    }
    public class Van : IVehicle
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal Promo { get; set; }
        public decimal GetPrice()
        {
            return (Price * Invoice) - Promo;
        }
    }
    public class Truck : IVehicle
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal Invoice { get; set; }
        public decimal Traction { get; set; }
        public decimal GetPrice()
        {
            return (Price * Invoice) + Traction;
        }
    }
    public class Invoice
    {
        public decimal GetTotal(IEnumerable<IVehicle> lstVehicles)
        {
            decimal total = 0;

            foreach (var vehicle in lstVehicles)
            {
                total += vehicle.GetPrice();
            }
            return total;
        }
    }
}
