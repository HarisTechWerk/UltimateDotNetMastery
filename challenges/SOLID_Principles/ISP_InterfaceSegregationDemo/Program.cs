using SOLID_Principles.ISP_InterfaceSegregationDemo.GoodExample;

class Program
{
  static void Main()
  {
    IWork human = new HumanWorker();
    IWork robot = new RobotWorker();

    human.Work();
    robot.Work();

    IEat humanEater = new HumanWorker();
    humanEater.Eat();
  }
}