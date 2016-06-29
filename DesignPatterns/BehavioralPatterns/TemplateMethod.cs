using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllIn.BehavioralPatterns
{
    /*
    Когда планируется, что в будущем подклассы должны будут переопределять различные этапы алгоритма
        без изменения его структуры

    Когда в классах, реализующим схожий алгоритм, происходит дублирование кода.
        Вынесение общего кода в шаблонный метод уменьшит его дублирование в подклассах.
         */

    class TemplateMethod
    {
        public abstract class Learning
        {
            public abstract void Learn();
        }

        //AbstractClass
        public abstract class Education : Learning
        {
            //TemplateMethod
            public override void Learn()
            {
                Enter();
                Study();
                PassExams();
                GetDocument();
            }

            public abstract void Enter();

            public abstract void Study();

            public virtual void PassExams()
            {
                Console.WriteLine("Passing exams");
            }

            public abstract void GetDocument();
        }

        //ConcreteClassA
        public class School : Education
        {
            public override void Enter()
            {
                Console.WriteLine("Going to 1-st grade");
            }

            public override void Study()
            {
                Console.WriteLine("Studying in school");
            }

            public override void GetDocument()
            {
                Console.WriteLine("Get first document");
            }
        }

        //ConcreteClassB
        public class University : Education
        {
            public override void Enter()
            {
                Console.WriteLine("Becoming freshman");
            }

            public override void Study()
            {
                Console.WriteLine("Visiting lecture");
            }

            public override void PassExams()
            {
                Console.WriteLine("Passing all exams");
            }

            public override void GetDocument()
            {
                Console.WriteLine("Getting bachelor diploma");
            }
        }

        //static void Main(string[] args)
        //{
        //    School school = new School();

        //    University university = new University();

        //    school.Learn();

        //    university.Learn();
        //}
    }
}
