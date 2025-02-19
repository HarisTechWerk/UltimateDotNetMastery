namespace SOLID_Principles.OCP.OCPDemo.GoodExample
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public Employee(string name) => Name = name;

        // ✅ Mark this method as Abstract to allow overrides
        public abstract double CalculateBonus(double salary);
    }

    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(string name) : base(name) { }

        // ✅ Override the abstract method correctly
        public override double CalculateBonus(double salary) => salary * 0.1;
    }

    public class ContractEmployee : Employee
    {
        public ContractEmployee(string name) : base(name) { }

        // ✅ Override the abstract method correctly
        public override double CalculateBonus(double salary) => salary * 0.05;
    }
}
