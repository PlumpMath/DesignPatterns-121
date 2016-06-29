using System;

namespace AllIn.BehavioralPatterns
{
    /*
     Когда надо передавать в качестве параметров определенные действия, вызываемые в ответ на другие действия.
        То есть когда необходимы функции обратного действия в ответ на определенные действия.

    Когда необходимо обеспечить выполнение очереди запросов, а также их возможную отмену.

    Когда надо поддерживать логгирование изменений в результате запросов. 
        Использование логов может помочь восстановить состояние системы - для этого необходимо будет использовать
            последовательность запротоколированных команд.
         */

    class Command
    {
        //Command
        public interface ICommand
        {
            void Execute();
            void Undo();
        }

        //ConcreteCommand
        public class TVOnCommand : ICommand
        {
            private readonly TV _tv;

            public TVOnCommand(TV tvSet)
            {
                _tv = tvSet;
            }

            public void Execute()
            {
                _tv.On();
            }

            public void Undo()
            {
                _tv.Off();
            }
        }

        //Receiver
        public class TV
        {
            public void On()
            {
                Console.WriteLine("TV is On");
            }

            public void Off()
            {
                Console.WriteLine("TV is off....");
            }
        }

        //Invoker
        public class Pult
        {
            private ICommand _command;

            public Pult()
            {
            }

            public void SetCommand(ICommand command)
            {
                _command = command;
            }

            public void PressButton()
            {
                _command.Execute();
            }

            public void PressUndo()
            {
                _command.Undo();
            }
        }

        //static void Main(string[] args)
        //{
        //    Pult pult = new Pult();

        //    TV tv = new TV();

        //    pult.SetCommand(new TVOnCommand(tv));

        //    pult.PressButton();

        //    pult.PressUndo();
        //}
    }
}
