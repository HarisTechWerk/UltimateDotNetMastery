using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenges.SOLID_Principles.OCP
{
    public class Employee
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Employee(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public double CalculateBonus(double salary)
        {
            if (Type == "Permanent")
            {
                return salary * 0.1; // 10%
            }
            else if (Type == "Contract")
            {
                return salary * .05; // 5%
            }
            else
            {
                throw new Exception("Invalid Employee Type");
            }
        }

    }
}