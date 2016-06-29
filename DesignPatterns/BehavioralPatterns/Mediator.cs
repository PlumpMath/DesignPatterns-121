using System;

namespace AllIn.BehavioralPatterns
{
    /*
    Когда имеется множество взаимосвязаных объектов, связи между которыми сложны и запутаны.

    Когда необходимо повторно использовать объект, однако повторное использование затруднено в силу сильных связей 
        с другими объектами.
         */

    class Mediatorr
    {
        //Mediator
        public abstract class Mediator
        {
            public abstract void Send(string message, Colleague colleague);
        }

        //Colleague
        public abstract class Colleague
        {
            protected Mediator Mediator;

            protected Colleague(Mediator mediator)
            {
                Mediator = mediator;
            }

            public virtual void Send(string message)
            {
                Mediator.Send(message, this);
            }

            public abstract void Notify(string message);
        }

        //ConcreteColleagueA
        public class CustomerColleague : Colleague
        {
            public CustomerColleague(Mediator mediator) : base(mediator)
            {
            }

            public override void Notify(string message)
            {
                Console.WriteLine($"Message to customer {message}");
            }
        }

        //ConcreteColleagueB
        public class ProgrammerColleague : Colleague
        {
            public ProgrammerColleague(Mediator mediator) : base(mediator)
            {
            }

            public override void Notify(string message)
            {
                Console.WriteLine($"Message to programmer {message}");
            }
        }

        //ConcreteColleagueC
        public class TesterColleague : Colleague
        {
            public TesterColleague(Mediator mediator) : base(mediator)
            {
            }

            public override void Notify(string message)
            {
                Console.WriteLine($"Message to tester {message}");
            }
        }

        //ConcreteMediator
        public class ManagerMediator : Mediator
        {
            public Colleague Customer { get; set; }
            public Colleague Programmer { get; set; }
            public Colleague Tester { get; set; }

            public override void Send(string message, Colleague colleague)
            {
                if (Customer == colleague)
                    Programmer.Notify(message);

                else if (Programmer == colleague)
                    Tester.Notify(message);

                else if (Tester == colleague)
                    Customer.Notify(message);
            }
        }

        //static void Main(string[] args)
        //{
        //    ManagerMediator mediator = new ManagerMediator();

        //    Colleague customer = new CustomerColleague(mediator);
        //    Colleague programmer = new ProgrammerColleague(mediator);
        //    Colleague tester = new TesterColleague(mediator);

        //    mediator.Customer = customer;
        //    mediator.Programmer = programmer;
        //    mediator.Tester = tester;

        //    customer.Send("Есть заказ, надо сделать программу");
        //    programmer.Send("Программа готова, надо протестировать");
        //    tester.Send("Программа протестирована и готова к продаже");
        //}

    }
}
