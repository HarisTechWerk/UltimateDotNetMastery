using System;
using BadEmployee = LSPDemo.BadExample.Employee;
using GoodEmployee = LSPDemo.GoodExample.Employee;
using GoodContractEmployee = LSPDemo.GoodExample.ContractEmployee;
using GoodPermanentEmployee = LSPDemo.GoodExample.PermanentEmployee;

class Program
{
  static void Main()
  {
    Console.WriteLine("❌ Bad Example (Violates LSP):");
    try
    {
      BadEmployee badEmployee = new LSPDemo.BadExample.ContractEmployee(); // LSP Violation!
      Console.WriteLine($"Bonus: {badEmployee.CalculateBonus(50000)}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("\n✅ Good Example (Follows LSP):");
    GoodEmployee goodEmployee1 = new GoodPermanentEmployee { Name = "John" };
    GoodEmployee goodEmployee2 = new GoodContractEmployee { Name = "Alice" };

    Console.WriteLine($"{goodEmployee1.Name} Bonus: {goodEmployee1.CalculateBonus(50000)}");
    Console.WriteLine($"{goodEmployee2.Name} Bonus: {goodEmployee2.CalculateBonus(50000)}");
  }
}
