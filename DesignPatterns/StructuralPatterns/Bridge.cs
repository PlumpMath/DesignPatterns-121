using System;

namespace AllIn.StructuralPatterns
{
    /*
     Когда надо избежать постоянной привязки абстракции к реализации

    Когда наряду с реализацией надо изменять и абстракцию независимо друг от друга.
        То есть изменения в абстракции не должно привести к изменениям в реализации
         */

    class Bridge
    {
        //Implementor
        public interface ILanguage
        {
            void Build();

            void Execute();
        }

        //ConcreteImplementorA
        public class CPPLanguage : ILanguage
        {
            public void Build()
            {
                Console.WriteLine("With C++ compiler combine to binary code");
            }

            public void Execute()
            {
                Console.WriteLine("Starting programm");
            }
        }

        //ConcreteImplementorB
        public class CSharpLanguage : ILanguage
        {
            public void Build()
            {
                Console.WriteLine("With Roslyn compiler compiling the programm");
            }

            public void Execute()
            {
                Console.WriteLine("JIT into binary code");
                Console.WriteLine("CLR runs manage code");
            }
        }

        //Abstraction
        public abstract class Programmer
        {
            public ILanguage Language { get; set; }

            protected Programmer(ILanguage language)
            {
                Language = language;
            }

            public virtual void DoWork()
            {
                Language.Build();
                Language.Execute();
            }

            public abstract void EarnMoney();
        }

        //RefinedAbstractionA
        public class FreelanceProgrammer : Programmer
        {
            public FreelanceProgrammer(ILanguage language) : base(language)
            {
            }

            public override void EarnMoney()
            {
                Console.WriteLine("Earning money for order");
            }
        }

        //RefinedAbstractionB
        public class CorporateProgrammer : Programmer
        {
            public CorporateProgrammer(ILanguage language) : base(language)
            {
            }

            public override void EarnMoney()
            {
                Console.WriteLine("Earning salary per month");
            }
        }

            //static void Main(string[] args)
            //{
            //    Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            //    freelancer.DoWork();
            //    freelancer.EarnMoney();

            //    freelancer.Language = new CSharpLanguage();
            //    freelancer.DoWork();
            //    freelancer.EarnMoney();
            //}
        }
}
