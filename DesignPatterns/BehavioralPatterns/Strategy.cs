using System;

namespace AllIn.BehavioralPatterns
{
    /*
     Когда есть несколько родственных классов, которые отличаются поведением. 
        Можно задать один основной класс, а разные варианты поведения вынести в отдельные классы и при необходимости 
            их применять

    Когда необходимо обеспечить выбор из нескольких вариантов алгоритмов, которые можно легко менять в зависимости от условий

    Когда необходимо менять поведение объектов на стадии выполнения программы

    Когда класс, применяющий определенную функциональность, ничего не должен знать о ее реализации
         */

    class Strategy
    {
        //IStrategy
        public interface IMovable
        {
            void Move();
        }

        //ConcreteStrategy1
        public class PetrolMove : IMovable
        {
            public void Move()
            {
                Console.WriteLine("Moving using gas");
            }
        }

        //ConcreteStrategy2
        public class ElectricMove : IMovable
        {
            public void Move()
            {
                Console.WriteLine("Moving using electric power");
            }
        }

        //Context
        public class Car
        {
            protected int PassengersCount { get; set; }

            protected string Model { get; set; }

            public IMovable Movable { get; set; }

            public Car(int passengersCount, string model, IMovable movable)
            {
                PassengersCount = passengersCount;
                Model = model;
                Movable = movable;
            }

            public void Move()
            {
                Movable.Move();
            }
        }

        //static void Main(string[] args)
        //{
        //    Car myCar = new Car(12, "Volvo", new PetrolMove());
        //    myCar.Move();

        //    myCar.Movable = new ElectricMove();
        //    myCar.Move();

        //}
    }
}
