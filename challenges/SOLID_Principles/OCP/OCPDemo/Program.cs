using System;
using SOLID_Principles.OCP.OCPDemo.BadExample;
using SOLID_Principles.OCP.OCPDemo.GoodExample;

class Program
{
  static void Main()
  {
    Console.WriteLine("🔴 Testing EmployeeBad.cs (Violates OCP)");

    var badEmp1 = new SOLID_Principles.OCP.OCPDemo.BadExample.Employee("John", "Permanent");
    Console.WriteLine($"{badEmp1.Name} Bonus: {badEmp1.CalculateBonus(5000)}");

    var badEmp2 = new SOLID_Principles.OCP.OCPDemo.BadExample.Employee("Jane", "Contract");
    Console.WriteLine($"{badEmp2.Name} Bonus: {badEmp2.CalculateBonus(5000)}");

    Console.WriteLine("\n✅ Testing EmployeeGood.cs (Follows OCP)");

    var goodEmp1 = new SOLID_Principles.OCP.OCPDemo.GoodExample.PermanentEmployee("John");
    Console.WriteLine($"{goodEmp1.Name} Bonus: {goodEmp1.CalculateBonus(5000)}");

    var goodEmp2 = new SOLID_Principles.OCP.OCPDemo.GoodExample.ContractEmployee("Jane");
    Console.WriteLine($"{goodEmp2.Name} Bonus: {goodEmp2.CalculateBonus(5000)}");
  }
}
