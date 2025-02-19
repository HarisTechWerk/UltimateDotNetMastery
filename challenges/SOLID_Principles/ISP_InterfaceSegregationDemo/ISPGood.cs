using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_Principles.ISP_InterfaceSegregationDemo.GoodExample
{
    public interface IWork
    {
        void Work();
    }

    public interface IEat
    {
        void Eat();
    }

    public class HumanWorker : IWork, IEat
    {
        public void Work() => Console.WriteLine("Human is working...");
        public void Eat() => Console.WriteLine("Human is eating...");
    }

    public class RobotWorker : IWork
    {
        public void Work() => Console.WriteLine("Robot is working...");
    }
}