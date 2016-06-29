using System;
using System.Collections.Generic;

namespace AllIn.BehavioralPatterns
{
    /*
    Когда система состоит из множества классов, объекты которых должны находиться в согласованных состояниях

    Когда общая схема взаимодействия объектов предполагает две стороны: одна рассылает сообщения и является главным, 
        другая получает сообщения и реагирует на них. Отделение логики обеих сторон позволяет их рассматривать независимо 
            и использовать отдельно друга от друга.

    Когда существует один объект, рассылающий сообщения, и множество подписчиков, которые получают сообщения. 
        При этом точное число подписчиков заранее неизвестно и процессе работы программы может изменяться. 
         */

    class Observer
    {
        public class StockInfo
        {
            public int USD { get; set; }

            public int Euro { get; set; }
        }

        //IObserver
        public interface IObserver
        {
            void Update(object ob);
        }

        //IObservable
        public interface IObservable
        {
            void RegisterObserver(IObserver o);
            void RemoveObserver(IObserver o);
            void NotifyObservers();
        }

        //ConcreteObservable
        public class Stock : IObservable
        {
            private readonly StockInfo _stockInfo;

            private readonly List<IObserver> _observers;

            public Stock()
            {
                _observers = new List<IObserver>();
                _stockInfo = new StockInfo();
            }

            public void RegisterObserver(IObserver o)
            {
                _observers.Add(o);
            }

            public void RemoveObserver(IObserver o)
            {
                _observers.Remove(o);
            }

            public void NotifyObservers()
            {
                foreach (IObserver observer in _observers)
                {
                    observer.Update(_stockInfo);
                }
            }

            public void Market()
            {
                Random rnd = new Random();
                _stockInfo.Euro = rnd.Next(27, 32);
                _stockInfo.USD = rnd.Next(22, 26);
                NotifyObservers();
            }
        }

        //ConcreteObserverA
        public class Broker : IObserver
        {
            public string Name { get; set; }

            private IObservable _stock;

            public Broker(string name, IObservable stock)
            {
                Name = name;
                _stock = stock;
                _stock.RegisterObserver(this);
            }

            public void Update(object ob)
            {
                StockInfo stockInfo = (StockInfo)ob;

                if (stockInfo.USD > 24)
                    Console.WriteLine($"Broker {Name} sells dollars; dollar value is {stockInfo.USD}");

                else
                    Console.WriteLine($"Broker {Name} buys dollars; dollar value is {stockInfo.USD}");
            }

            public void StopTrade()
            {
                _stock.RemoveObserver(this);
                _stock = null;
            }
        }

        //ConcreteObserverB
        public class Bank : IObserver
        {
            public string Name { get; set; }

            private IObservable _stock;

            public Bank(string name, IObservable stock)
            {
                Name = name;
                _stock = stock;
                _stock.RegisterObserver(this);
            }

            public void Update(object ob)
            {
                StockInfo stockInfo = (StockInfo)ob;

                if (stockInfo.Euro > 29)
                    Console.WriteLine($"Bank {Name} sells Euro; current value is {stockInfo.Euro}");

                else
                    Console.WriteLine($"Bank {Name} buys Euro; current value is {stockInfo.Euro}");
            }
        }

        //static void Main(string[] args)
        //{
        //    Stock stock = new Stock();

        //    Bank bank = new Bank("Privat", stock);

        //    Broker broker = new Broker("Bob", stock);

        //    //имитация торгов
        //    stock.Market();

        //    //брокер прекращает наблюдать за торгами
        //    broker.StopTrade();

        //    //имитация торгов
        //    stock.Market();
        //}
    }
}
