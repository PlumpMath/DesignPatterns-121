using System;
using System.Collections.Generic;

namespace AllIn.StructuralPatterns
{
    /*
     Когда приложение использует большое количество однообразных объектов, из-за чего происходит выделение
        большого количества памяти

    Когда часть состояния объекта, которое является изменяемым, можно вынести во вне. 
        Вынесение внешнего состояния позволяет заменить множество объектов небольшой группой общих разделяемых объектов.
         */

    class Flyweight
    {
        //Flyweight
        public abstract class House
        {
            protected int NumOfStages;

            public abstract void Build(double longtitude, double latitude);
        }

        //ConcreteFlyweightA
        public class PanelHouse : House
        {
            public PanelHouse()
            {
                NumOfStages = 16;
            }

            public override void Build(double longtitude, double latitude)
            {
                Console.WriteLine($"Panel house was built with {NumOfStages} stages, longtitude: {longtitude} " +
                                  $"latitude: {latitude}");
            }
        }

        //ConcreteFlyweightB
        public class BrickHouse : House
        {
            public BrickHouse()
            {
                NumOfStages = 5;
            }

            public override void Build(double longtitude, double latitude)
            {
                Console.WriteLine($"Brick house was built with {NumOfStages} stages, longtitude: {longtitude} " +
                                  $"latitude: {latitude}");
            }
        }

        //FlyweightFactory
        public class HouseFactory
        {
            Dictionary<string, House> houses = new Dictionary<string, House>();

            public HouseFactory()
            {
                houses.Add("panel", new PanelHouse());
                houses.Add("brick", new BrickHouse());
            }

            public House GetHouse(string key)
            {
                if (houses.ContainsKey(key))
                    return houses[key];

                return null;
            }
        }

        //static void Main(string[] args)
        //{
        //    double longtitude = 37.61;
        //    double latitude = 55.73;

        //    HouseFactory houseFactory = new HouseFactory();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        House brickHouse = houseFactory.GetHouse("brick");

        //        brickHouse?.Build(longtitude, latitude);

        //        longtitude += 0.1;
        //        latitude += 0.1;
        //    }

        //    for (int i = 0; i < 5; i++)
        //    {
        //        House panelHouse = houseFactory.GetHouse("panel");

        //        panelHouse?.Build(longtitude, latitude);

        //        longtitude += 0.1;
        //        latitude += 0.1;
        //    }
        //}
    }
}
