using System.Collections.Generic;

namespace AllIn.BehavioralPatterns
{
    /*
     Применяется для часто повторяющихся операций.
         */
    class Interpeter
    {
        //Context
        public class Context
        {
            private readonly Dictionary<string, int> _variables;

            public Context()
            {
                _variables = new Dictionary<string, int>();
            }

            //get value by name
            public int GetVariable(string name) => _variables[name];

            public void SetVariable(string name, int value)
            {
                if (_variables.ContainsKey(name))
                    _variables[name] = value;

                else
                    _variables.Add(name, value);
            }
        }

        //AbstractExpression
        public interface IExpression
        {
            int Intrepet(Context context);
        }

        //TerminalExpression
        public class NumberExpression : IExpression
        {
            private readonly string _name;

            public NumberExpression(string variable)
            {
                _name = variable;
            }

            public int Intrepet(Context context) => context.GetVariable(_name);
        }

        //NonTerminalExpressionA
        public class AddExpression : IExpression
        {
            private readonly IExpression _leftExpression;

            private readonly IExpression _rightExpression;

            public AddExpression(IExpression leftExpression, IExpression rightExpression)
            {
                _leftExpression = leftExpression;
                _rightExpression = rightExpression;
            }

            public int Intrepet(Context context) => _rightExpression.Intrepet(context) + _leftExpression.Intrepet(context);
        }

        //NonTerminalExpressionB
        public class SubstractExpression : IExpression
        {
            private readonly IExpression _leftExpression;

            private readonly IExpression _rightExpression;

            public SubstractExpression(IExpression leftExpression, IExpression rightExpression)
            {
                _leftExpression = leftExpression;
                _rightExpression = rightExpression;
            }

            public int Intrepet(Context context) => _leftExpression.Intrepet(context) - _rightExpression.Intrepet(context);
        }


        //static void Main(string[] args)
        //{
        //    Context context = new Context();

        //    int x = 5;
        //    int y = 8;
        //    int z = 2;

        //    context.SetVariable("x", x);
        //    context.SetVariable("y", y);
        //    context.SetVariable("z", z);

        //    IExpression expression = new SubstractExpression(
        //        new AddExpression(
        //            new NumberExpression("x"), new NumberExpression("y")), new NumberExpression("z")
        //        );

        //    int result = expression.Intrepet(context);
        //    Console.WriteLine($"Result is {result}");
        //}

    }
}
