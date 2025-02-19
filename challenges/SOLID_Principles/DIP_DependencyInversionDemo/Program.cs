using System;
using BadShoppingMall = DIP_DependencyInversionDemo.BadExample.ShoppingMall;
using GoodShoppingMall = DIP_DependencyInversionDemo.GoodExample.ShoppingMall;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("❌ Bad Example (Violation of DIP)");
    var mallBad = new BadShoppingMall(); // Tight coupling
    mallBad.ProcessPurchase(100);

    Console.WriteLine("\n✅ Good Example (Following DIP)");
    var payment = new DIP_DependencyInversionDemo.GoodExample.PayPalPayment(); // Loose coupling, we can switch easily
    var mallGood = new GoodShoppingMall(payment);
    mallGood.ProcessPurchase(200);
  }
}