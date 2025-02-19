using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIP_DependencyInversionDemo.BadExample
{
    public class ShoppingMall
    {
        private CreditCardPayment _creditCardPayment; // Directly depending on concrete class
        public ShoppingMall()
        {
            _creditCardPayment = new CreditCardPayment(); // Tight coupling
        }

        public void ProcessPurchase(decimal amount)
        {
            _creditCardPayment.Pay(amount);
        }
    }

    // Low level module (Payment Method)
    public class CreditCardPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying ${amount} using Credit Card");
        }
    }
}