using System;

namespace AllIn.StructuralPatterns
{
    /*
Когда имеется сложная система, и необходимо упростить с ней работу.
Фасад позволит определить одну точку взаимодействия между клиентом и системой.

Когда надо уменьшить количество зависимостей между клиентом и сложной системой. 
Фасадные объекты позволяют отделить, изолировать компоненты системы от клиента и развивать
    и работать с ними независимо.

Когда нужно определить подсистемы компонентов в сложной системе. 
Создание фасадов для компонентов каждой отдельной подсистемы позволит упростить взаимодействие между ними 
    и повысить их независимость друг от друга.
 */

    class Facade
    {
        //SubSystemA
        public class TextEditor
        {
            public void CreateCode()
            {
                Console.WriteLine("Code writing");
            }

            public void Save()
            {
                Console.WriteLine("Saving code");
            }
        }

        //SubSystemB
        public class Compiler
        {
            public void Compile()
            {
                Console.WriteLine("Compiling code");
            }
        }

        //SubSystemC
        public class CLR
        {
            public void Execute()
            {
                Console.WriteLine("Executing app");
            }

            public void Finish()
            {
                Console.WriteLine("Finishing app");
            }
        }

        //Facade
        public class VisualStudioFacade
        {
            private readonly TextEditor _textEditor;

            private readonly Compiler _compiler;

            private readonly CLR _clr;

            public VisualStudioFacade(TextEditor textEditor, Compiler compiler, CLR clr)
            {
                _textEditor = textEditor;
                _compiler = compiler;
                _clr = clr;
            }

            public void Start()
            {
                _textEditor.CreateCode();
                _textEditor.Save();
                _compiler.Compile();
                _clr.Execute();
            }

            public void Stop()
            {
                _clr.Finish();
            }
        }

        //Client
        public class Programmer
        {
            public void CreateApplication(VisualStudioFacade visualStudioFacade)
            {
                visualStudioFacade.Start();
                visualStudioFacade.Stop();
            }
        }

            //static void Main(string[] args)
            //{
            //    VisualStudioFacade ideFacade = new VisualStudioFacade(new TextEditor(), new Compiler(), new CLR());

            //    Programmer programmer = new Programmer();

            //    programmer.CreateApplication(ideFacade);
            //}
    }
}
