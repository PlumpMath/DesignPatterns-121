using System;

namespace DesignPatterns.CreationalPatterns
{
    class FactoryMethod
    {
        /*
        Когда заранее неизвестно, объекты каких типов необходимо создавать

        Когда система должна быть независимой от процесса создания новых объектов и расширяемой:
            в нее можно легко вводить новые классы, объекты которых система должна создавать.

        Когда создание новых объектов необходимо делегировать из базового класса классам наследникам
        */
        //Product
        public abstract class House
        {
        }

        //ConcreteProductA
        public class WoodHouse : House
        {
            public WoodHouse()
            {
                Console.WriteLine("Wood house was built");
            }
        }

        //ConcreteproductB
        public class PanelHouse : House
        {
            public PanelHouse()
            {
                Console.WriteLine("Panel house was built");
            }
        }

        //ConcreteCreatorA
        public class WoodDeveloper : Developer
        {
            public WoodDeveloper(string name) : base(name)
            {
            }

            public override House CreateHouse() => new WoodHouse();
        }

        //ConcreteCreatorB
        public class PanelDeveloper : Developer
        {
            public PanelDeveloper(string name) : base(name)
            {
            }

            public override House CreateHouse() => new PanelHouse();
        }

        //Creator
        public abstract class Developer
        {
            public string Name { get; set; }

            protected Developer(string name)
            {
                Name = name;
            }

            //Factory method
            public abstract House CreateHouse();
        }


        //static void Main(string[] args)
        //{
        //    Developer panelDeveloper = new PanelDeveloper("Panel house builder");
        //    House panelHouse = panelDeveloper.CreateHouse();

        //    Developer woodDeveloper = new WoodDeveloper("Wood house builder");
        //    House woodHouse = woodDeveloper.CreateHouse();
        //}
    }
}
