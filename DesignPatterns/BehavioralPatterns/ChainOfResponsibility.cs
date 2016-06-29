using System;

namespace AllIn.BehavioralPatterns
{
    /*
    Когда имеется более одного объекта, который может обработать определенный запрос

    Когда надо передать запрос на выполнение одному из нескольких объект, точно не определяя, какому именно объекту

    Когда набор объектов задается динамически
         */

    class ChainOfResponsibility
    {
        //Client
        public class Receiver
        {
            //bank transfers
            public bool BankTransfers { get; set; }

            //WesternUnion, Unistream
            public bool MoneyTransfer { get; set; }

            //PayPal transfer
            public bool PayPalTransfer { get; set; }

            public Receiver(bool bankTransfer, bool moneyTransfer, bool payPalTransfer)
            {
                BankTransfers = bankTransfer;
                MoneyTransfer = moneyTransfer;
                PayPalTransfer = payPalTransfer;
            }
        }

        //Handler
        public abstract class PaymentHandler
        {
            public PaymentHandler Successor { get; set; }

            public abstract void Handle(Receiver receiver);
        }

        //ConcreteHandler1
        public class BankPaymentHandler : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.BankTransfers)
                    Console.WriteLine("Transfering with Bank");

                else
                    Successor?.Handle(receiver);
            }
        }

        //ConcreteHandler2
        public class MoneyPaymentHandle : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.MoneyTransfer)
                    Console.WriteLine("Transfering with WesternUnion");

                else
                    Successor?.Handle(receiver);
            }
        }

        //ConcreteHandler3
        public class PayPalReceiver : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.PayPalTransfer)
                    Console.WriteLine("Transfering with PayPal");

                else
                    Successor?.Handle(receiver);
            }
        }

        //static void Main(string[] args)
        //{
        //    Receiver receiver = new Receiver(false, true, true);

        //    PaymentHandler bankPaymentHandler = new BankPaymentHandler();

        //    PaymentHandler moneyPaymentHandler = new MoneyPaymentHandle();

        //    PaymentHandler payPalPaymentHandler = new PayPalReceiver();

        //    bankPaymentHandler.Successor = moneyPaymentHandler;

        //    payPalPaymentHandler.Successor = moneyPaymentHandler;

        //    bankPaymentHandler.Handle(receiver);


        //}
    }
}
