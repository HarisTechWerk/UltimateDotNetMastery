using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenges.SOLID_Principles.OCP
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }
        public abstract double CalculateBonus(double salary);
    }

    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(string name) : base(name)
        {
        }

        public override double CalculateBonus(double salary)
        {
            return salary * 0.1; // 10%
        }
    }

    public class ContractEmployee : Employee
    {
        public ContractEmployee(string name) : base(name)
        {
        }

        public override double CalculateBonus(double salary)
        {
            return salary * .05; // 5%
        }
    }
}