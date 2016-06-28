namespace AllIn.StructuralPatterns
{
    /*
     Когда надо динамически добавлять к объекту новые функциональные возможности. 
        При этом данные возможности могут быть сняты с объекта

    Когда применение наследования неприемлемо. Например, если нам надо определить множество различных функциональностей 
        и для каждой функциональности наследовать отдельный класс, то структура классов может очень сильно разрастись.
            Еще больше она может разрастись, если нам необходимо создать классы, реализующие все возможные сочетания
                добавляемых функциональностей.
         */

    class Decorator
    {
        //Component
        public abstract class Pizza
        {
            public string Name { get; set; }

            protected Pizza(string name)
            {
                Name = name;
            }

            public abstract int GetCost();
        }

        //ConcreteComponentA
        public class ItalianPizza : Pizza
        {
            public ItalianPizza() : base("Italian Pizza")
            {
            }

            public override int GetCost() => 10;
        }

        //ConcreteComponentB
        public class BulgarianPizza : Pizza
        {
            public BulgarianPizza() : base("Bulgarian Pizza")
            {
            }

            public override int GetCost() => 8;
        }

        //Decorator
        public abstract class PizzaDecorator : Pizza
        {
            protected Pizza Pizza { get; set; }

            protected PizzaDecorator(string name, Pizza pizza) : base(name)
            {
                Pizza = pizza;
            }
        }

        //ConcreteDecoratorA
        public class TomattoPizza : PizzaDecorator
        {
            public TomattoPizza(Pizza pizza) : base(pizza.Name + " with tomattoes ", pizza)
            {
            }

            public override int GetCost() => Pizza.GetCost() + 3;
        }

        //ConcreteDecoratorB
        public class CheesePizza : PizzaDecorator
        {
            public CheesePizza(Pizza pizza) : base(pizza.Name + " with cheese ", pizza)
            {
            }

            public override int GetCost() => Pizza.GetCost() + 5;
        }
        
        //    static void Main(string[] args)
        //    {
        //        Pizza pizza1 = new ItalianPizza();
        //        pizza1 = new TomattoPizza(pizza1);  //Italian pizza with tomatoes
        //        Console.WriteLine($"Name: {pizza1.Name}");
        //        Console.WriteLine($"Price: {pizza1.GetCost()}");

        //        Pizza pizza2 = new ItalianPizza();
        //        pizza2 = new CheesePizza(pizza2);   //Bulgarian pizza with cheese
        //        Console.WriteLine($"Name: {pizza2.Name}");
        //        Console.WriteLine($"Price: {pizza2.GetCost()}");

        //        Pizza pizza3 = new BulgarianPizza();
        //        pizza3 = new TomattoPizza(pizza3);    //Bulgarian pizza with tommatoes and cheese
        //        pizza3 = new CheesePizza(pizza3);
        //        Console.WriteLine($"Name: {pizza3.Name}");
        //        Console.WriteLine($"Price: {pizza3.GetCost()}");
        //    }
    }
}
