using System;
using System.Collections.Generic;

namespace Solid4Isp
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Interface Segregation Principle (ISP)
            // Classes should only be forced to implement interfaces that are relevant to them,
            // avoiding unnecessary dependencies and promoting cohesion

            // Fake data for sale
            Sale sale = new Sale { Amount = 1000, Date = DateTime.Now };
            // Fake data for user
            User user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            // Create instances of SaleService and UserService
            SaleService saleService = new SaleService();
            UserService userService = new UserService();
            // Test SaleService
            saleService.Add(sale);
            var retrievedSale = saleService.Get(1); // Assuming Id 1 exists
            Console.WriteLine($"Retrieved Sale: {retrievedSale}");
            // Test UserService
            userService.Add(user);
            var retrievedUser = userService.Get(1); // Assuming Id 1 exists
            Console.WriteLine($"Retrieved User: {retrievedUser.Name}");
            // Additional actions on UserService
            userService.Update(user);
            userService.Delete(1); // Assuming Id 1 exists
        }
    }

    public class SaleService : IEditableActions<Sale>
    {
        public void Add(Sale entity)
        {
            Console.WriteLine("Created Sale: " + entity.Amount);
        }
        public Sale Get(int Id)
        {
            Console.WriteLine("Get Sale Id " + Id);
            return new Sale();
        }
        public List<Sale> GetList()
        {
            return new List<Sale>();
        }
        public void Update(Sale entity)
        {
            Console.WriteLine("Updated Sale " + entity.Amount);
        }
        public void Delete(int id)
        {
            Console.WriteLine("Deleted Sale Id " + id);
        }
    }

    public class UserService : IBasicActions<User>, IEditableActions<User>
    {
        public void Add(User entity)
        {
            Console.WriteLine("Created User " + entity.Name);
        }
        public User Get(int Id)
        {
            Console.WriteLine("Get User Id " + Id);
            return new User();
        }
        public List<User> GetList()
        {
            return new List<User>();
        }
        public void Update(User entity)
        {
            Console.WriteLine("Updated User " + entity.Name);
        }
        public void Delete(int id)
        {
            Console.WriteLine("Deleted User Id " + id);
        }
    }

    public interface IBasicActions<T>
    {
        T Get(int id);
        List<T> GetList();
        void Add(T entity);
    }

    public interface IEditableActions<T>
    {
        void Update(T entity);
        void Delete(int id);
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Sale
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
