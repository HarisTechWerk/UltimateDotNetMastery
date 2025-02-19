namespace SOLID_Principles.OCP.OCPDemo.BadExample
{
    public class Employee
    {
        public string Name { get; set; }
        public string EmployeeType { get; set; }

        public Employee(string name, string type)
        {
            Name = name;
            EmployeeType = type;
        }

        public double CalculateBonus(double salary)
        {
            if (EmployeeType == "Permanent")
                return salary * 0.1;
            else
                return salary * 0.05;
        }
    }
}
