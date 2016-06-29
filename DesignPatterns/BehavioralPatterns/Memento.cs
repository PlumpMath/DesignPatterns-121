using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllIn.BehavioralPatterns
{
    /*
     Когда нужно охранить его состояние объекта для возможного последующего восстановления

    Когда сохранение состояния должно проходить без нарушения принципа инкапсуляции
         */

    class Memento
    {
        //Originator
        public class Hero
        {
            private int _patrons = 10;
            private int _lives = 5;

            public void Shoot()
            {
                if (_patrons > 0)
                {
                    _patrons--;
                    Console.WriteLine($"We are shooting. {_patrons} patrons left");
                }

                else
                {
                    Console.WriteLine("No more patrons");
                }
            }

            //State saving
            public HeroMemento SaveState()
            {
                Console.WriteLine($"Game is saving... {_patrons} patrons left, {_lives} lives left");
                return new HeroMemento(_patrons, _lives);
            }

            //Restoring state
            public void RestoreState(HeroMemento memento)
            {
                _patrons = memento.Patrons;
                _lives = memento.Lives;
            }
        }

        //Memento
        public class HeroMemento
        {
            public int Patrons { get; private set; }
            public int Lives { get; private set; }

            public HeroMemento(int patrons, int lives)
            {
                Patrons = patrons;
                Lives = lives;
            }
        }

        //Caretaker
        public class GameHistory
        {
            public Stack<HeroMemento> History { get; private set; }

            public GameHistory()
            {
                History = new Stack<HeroMemento>();
            }
        }

        //static void Main(string[] args)
        //{
        //    Hero hero = new Hero();
        //    hero.Shoot();  //making shot 9 patrons left
        //    GameHistory game = new GameHistory();

        //    game.History.Push(hero.SaveState());   //save game

        //    hero.Shoot();  //making shot 8 patrons left

        //    hero.RestoreState(game.History.Pop());

        //    hero.Shoot();  //making shot 8 patrons left


        //}
    }
}
