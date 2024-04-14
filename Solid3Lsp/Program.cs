using System;

namespace Solid3Lsp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Liskov Substitution Principle (LSP)
            // Derived classes must be substitutable for their base classes
            // without altering the correctness of the program.

            // Fake data
            string customer = "John Doe";
            decimal amount = 1000;
            decimal taxes = 200;

            // Create a LocalSale object with fake data
            LocalSale localSale = new LocalSale(customer, amount, taxes);

            // Perform sale-related actions
            localSale.Generate();
            localSale.CalculateTaxes();

            // Create a ForeignSale object with fake data
            ForeignSale foreignSale = new ForeignSale(customer, amount);

            // Perform sale-related actions
            foreignSale.Generate();
        }
    }

    public abstract class SaleAbstract
    {
        protected string customer;
        protected decimal amount;
        public abstract void Generate();
    }

    public abstract class SaleWithTaxes : SaleAbstract
    {
        protected decimal taxes;
        public abstract void CalculateTaxes();
    }

    public class LocalSale : SaleWithTaxes
    {
        public LocalSale(string customer, decimal amount, decimal taxes)
        {
            this.customer = customer;
            this.amount = amount;
            this.taxes = taxes;
        }
        public override void Generate()
        {
            Console.WriteLine("Generate Local Sale");
        }

        public override void CalculateTaxes()
        {
            Console.WriteLine("Calculate Taxes for Local Sale");
        }
    }

    public class ForeignSale : SaleAbstract
    {
        public ForeignSale(string customer, decimal amount)
        {
            this.customer = customer;
            this.amount = amount;
        }
        public override void Generate()
        {
            Console.WriteLine("Generate Foreign Sale");
        }
    }
}

