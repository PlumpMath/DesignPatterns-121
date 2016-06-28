using System;

namespace AllIn.StructuralPatterns
{
    /*
     Когда необходимо использовать имеющийся класс, но его интерфейс не соответствует потребностям

    Когда надо использовать уже существующий класс совместно с другими классами, интерфейсы которых не совместимы
         */

    class Adapter
    {
        //Target
        public interface ITransport
        {
            void Drive();
        }

        public class Auto : ITransport
        {
            public void Drive()
            {
                Console.WriteLine("The car is driving");
            }
        }

        //Client
        public class Driver
        {
            public void Travel(ITransport transport)
            {
                transport.Drive();
            }
        }

        public interface IAnimal
        {
            void Move();
        }

        //Adptee
        public class Camel : IAnimal
        {
            public void Move()
            {
                Console.WriteLine("Camel is moving");
            }
        }

        //Adapter
        public class CamelToTransportAdapter : ITransport
        {
            private readonly Camel _camel;

            public CamelToTransportAdapter(Camel camel)
            {
                _camel = camel;
            }

            public void Drive()
            {
                _camel.Move();
            }
        }

        //    static void Main(string[] args)
        //    {
        //        //driver class
        //        Driver driver = new Driver();

        //        //auto
        //        Auto auto = new Auto();

        //        //travelling by auto
        //        driver.Travel(auto);

        //        //no road, need to use camel
        //        Camel camel = new Camel();

        //        //using adapter
        //        ITransport camelTransport = new CamelToTransportAdapter(camel);

        //        //continue travelling
        //        driver.Travel(camelTransport);
        //    }
        }
}
