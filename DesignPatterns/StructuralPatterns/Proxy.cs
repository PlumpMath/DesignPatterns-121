namespace AllIn.StructuralPatterns
{
    /*
     Когда надо осуществлять взаимодействие по сети, а объект-проси должен имитировать поведения объекта
        в другом адресном пространстве. Использование прокси позволяет снизить накладные издержки при передачи данных
            через сеть. Подобная ситуация еще называется удалённый заместитель (remote proxies)

    Когда нужно управлять доступом к ресурсу, создание которого требует больших затрат.
        Реальный объект создается только тогда, когда он действительно может понадобится, а до этого все запросы
            к нему обрабатывает прокси-объект. Подобная ситуация еще называется виртуальный заместитель (virtual proxies)

    Когда необходимо разграничить доступ к вызываемому объекту в зависимости от прав вызывающего объекта. 
        Подобная ситуация еще называется защищающий заместитель (protection proxies)

    Когда нужно вести подсчет ссылок на объект или обеспечить потокобезопасную работу с реальным объектом. 
        Подобная ситуация называется "умные ссылки" (smart reference)
         */
    class Proxy
    {
        //Subject
        public interface IMath
        {
            double Add(double x, double y);
            double Sub(double x, double y);
            double Mul(double x, double y);
            double Div(double x, double y);
        }

        //RealSubject
        public class Math : IMath
        {
            public double Add(double x, double y) => x + y;

            public double Sub(double x, double y) => x - y;

            public double Mul(double x, double y) => x * y;

            public double Div(double x, double y) => x / y;
        }

        //Proxy
        public class MathProxy : IMath
        {
            private readonly Math _math = new Math();

            public double Add(double x, double y) => _math.Add(x, y);

            public double Sub(double x, double y) => _math.Sub(x, y);

            public double Mul(double x, double y) => _math.Mul(x, y);

            public double Div(double x, double y) => _math.Div(x, y);
        }

            //static void Main(string[] args)
            //{
            //    // Create math proxy
            //    MathProxy proxy = new MathProxy();

            //    // Do the math
            //    Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            //    Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            //    Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            //    Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
            //}
        }
}
