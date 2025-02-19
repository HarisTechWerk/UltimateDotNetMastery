namespace LSPDemo.BadExample
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty; // Initialize Name property
        public virtual double CalculateBonus(double salary)
        {
            return salary * 0.1;
        }
    }

    public class ContractEmployee : Employee
    {
        public override double CalculateBonus(double salary)
        {
            throw new NotImplementedException("Contract employees do not get a bonus.");
        }
    }
}
