using System;
using System.Net;
using System.Numerics;
using System.Runtime.ConstrainedExecution;


namespace Solid1Srp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single Responsability Principle
            // One Class, One Job.

            // Creating a school object with fake data
            School school = new School("Greenwood High School", "123 Elm Street", "Springfield", "555-1234");
            // Creating a SchoolDB object and saving the school data
            SchoolDB schoolDB = new SchoolDB(school);
            schoolDB.Save();
            // Creating a SchoolRequest object and sending a request with school data
            SchoolRequest schoolRequest = new SchoolRequest(school);
            schoolRequest.Send();
        }
    }
    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public School(string Name, string Address, string City, string Phone)
        {
            this.Name = Name;
            this.Address = Address;
            this.City = City;
            this.Phone = Phone;
        }
    }
    public class SchoolDB
    {
        private School _school;
        public SchoolDB(School school)
        {
            _school = school;
        }
        public void Save()
        {
            Console.WriteLine("Saved SchoolDB Name: " + _school.Name +
                  " - Address: " + _school.Address +
                  " - City: " + _school.City +
                  " - Phone: " + _school.Phone);
        }
    }
    public class SchoolRequest
    {
        private School _school;
        public SchoolRequest(School school)
        {
            _school = school;
        }
        public void Send()
        {
            Console.WriteLine($"Sent SchoolDB Name: {_school.Name} - Address: {_school.Address} - City: {_school.City} - Phone: {_school.Phone}");
        }
    }
}
