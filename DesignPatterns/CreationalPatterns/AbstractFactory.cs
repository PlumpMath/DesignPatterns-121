using System;

namespace DesignPatterns.CreationalPatterns
{
    /*
              Когда система не должна зависеть от способа создания и компоновки новых объектов

              Когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными

        */

    internal class AbstractFactory
    {
        //AbstractFactory
        public abstract class HeroFactory
        {
            public abstract Weapon GetWeapon();
            public abstract Movement GetMovement();
        }

        //Client
        public class Hero
        {
            private readonly Weapon _weapon;
            private readonly Movement _movement;

            public Hero(HeroFactory heroFactory)
            {
                _weapon = heroFactory.GetWeapon();
                _movement = heroFactory.GetMovement();
            }

            public void Move()
            {
                _movement.Move();
            }

            public void Hit()
            {
                _weapon.Hit();
            }
        }

        //AbstractProductA
        public abstract class Weapon
        {
            public abstract void Hit();
        }

        //ConcreteProductA1
        public class Sword : Weapon
        {
            public override void Hit()
            {
                Console.WriteLine("Hit with sword");
            }
        }

        //ConcreteProductA2
        public class Arbalet : Weapon
        {
            public override void Hit()
            {
                Console.WriteLine("Shoot with arbalet");
            }
        }

        //AbstractProductB
        public abstract class Movement
        {
            public abstract void Move();
        }

        //ConcreteProductB1
        public class Fly : Movement
        {
            public override void Move()
            {
                Console.WriteLine("Hero is flying");
            }
        }

        //ConcreteProductB2
        public class Run : Movement
        {
            public override void Move()
            {
                Console.WriteLine("Hero is running");
            }
        }

        //ConcreteFactoryA
        public class ElfHero : HeroFactory
        {
            public override Movement GetMovement() => new Fly();

            public override Weapon GetWeapon() => new Arbalet();
        }

        //ConcreteFactoryB
        public class Warrior : HeroFactory
        {
            public override Movement GetMovement() => new Run();

            public override Weapon GetWeapon() => new Sword();
        }

        //static void Main(string[] args)
        //{
        //    Hero elf = new Hero(new ElfHero());
        //    elf.Move();
        //    elf.Hit();

        //    Hero warrior = new Hero(new Warrior());
        //    warrior.Move();
        //    warrior.Hit();
        //}
    }
}
