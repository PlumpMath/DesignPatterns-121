using System;

namespace AllIn.BehavioralPatterns
{
    /*
     Когда поведение объекта должно зависеть от его состояния и может изменяться динамически во время выполнения

    Когда в коде методов объекта используются многочисленные условные конструкции, выбор которых зависит 
        от текущего состояния объекта
         */

    class State
    {
        //State
        public interface IWaterState
        {
            void Heat(Water water);
            void Frost(Water water);
        }

        //ConcreteStateA
        public class SolidWaterState : IWaterState
        {
            public void Heat(Water water)
            {
                Console.WriteLine("Melting ice");
                water.WaterState = new LiquidWaterState();
            }

            public void Frost(Water water)
            {
                Console.WriteLine("Continue freezing");
            }
        }

        //ConcreteStateB
        public class LiquidWaterState : IWaterState
        {
            public void Heat(Water water)
            {
                Console.WriteLine("Converting to gas");
                water.WaterState = new GasWaterState();
            }

            public void Frost(Water water)
            {
                Console.WriteLine("Freezing water");
                water.WaterState = new SolidWaterState();
            }
        }

        //ConcreteStateC
        public class GasWaterState : IWaterState
        {
            public void Heat(Water water)
            {
                Console.WriteLine("Heating gas");
            }

            public void Frost(Water water)
            {
                Console.WriteLine("Making liquid");
                water.WaterState = new LiquidWaterState();
            }
        }

        //Context
        public class Water
        {
            public IWaterState WaterState { get; set; }

            public Water(IWaterState waterState)
            {
                WaterState = waterState;
            }

            public void Heat()
            {
                WaterState.Heat(this);
            }

            public void Frost()
            {
                WaterState.Frost(this);
            }
        }

        //    static void Main(string[] args)
        //    {
        //        Water water = new Water(new LiquidWaterState());

        //        water.Heat();

        //        water.Frost();

        //        water.Frost();
        //    }
    }
}
