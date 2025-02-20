using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_Principles.ISP_InterfaceSegregationDemo.GoodExample
{
    public interface IWorker
    {
        void Work();
        void Eat();
    }

    public class HumanWorker : IWorker
    {
        public void Work() => Console.WriteLine("Human is working...");
        public void Eat() => Console.WriteLine("Human is eating...");
    }

    public class RobotWorker : IWorker
    {
        public void Work() => Console.WriteLine("Robot is working...");
        public void Eat() => throw new NotImplementedException("Robot cannot eat!"); // Violates ISP, Robots don't eat food
    }